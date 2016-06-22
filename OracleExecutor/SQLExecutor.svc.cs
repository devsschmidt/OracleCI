using DataUtil;
using Oracle.ManagedDataAccess.Client;
using OracleExecutor.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace OracleExecutor
{
    public class SQLExecutor : ISQLExecutor
    {
        private int _default_min_poolsize = 1;
        private int _default_max_poolsize = 1;

        private OracleConnection initalizeConnection(ConnectionData ConnectionData)
        {
            return OracleConnectionUtil.initalizeConnection(
                ConnectionData.TNS, 
                ConnectionData.User, 
                ConnectionData.Password,
                Math.Max(ConnectionData.MinPoolSize, _default_min_poolsize),
                Math.Max(ConnectionData.MaxPoolSize, _default_max_poolsize)
            );
        }

        private void executeCommand(OracleConnection connection, CommandGroup commandGroup, ref List<CommandExecutionOutput> CommandOutput)
        {
            foreach (Command command in commandGroup.Commands)
            {
                Trace.TraceInformation(String.Format("execute command {0}", command.Id));

                CommandExecutionOutput l_command_output = new CommandExecutionOutput();

                l_command_output.Type = commandGroup.Type;

                OracleCommand l_db_command = new OracleCommand(command.Text, connection);
                try
                {
                    int l_affected_row_count = l_db_command.ExecuteNonQuery();
                    l_command_output.Value = String.Format("Affected Rows({0})", (l_affected_row_count < 0 ? 0 : l_affected_row_count).ToString());
                    l_command_output.Result = ExecutionResult.Success;
                }
                catch (Exception e)
                {
                    l_command_output.Value = e.Message;
                    l_command_output.Result = ExecutionResult.Error;
                    throw;
                }
                finally
                {
                    l_command_output.End = DateTime.Now;
                    CommandOutput.Add(l_command_output);
                }
            }            
        }

        private void executeCommandGroups(OracleConnection connection, IList<CommandGroup> commandgroups, ref Output output)
        {
            List<CommandExecutionOutput> command_output = output.CommandOutput;

            OracleConnection l_db_connection = connection;
            OracleTransaction transaction = l_db_connection.BeginTransaction();
            try
            {
                foreach (CommandGroup commandgroup in commandgroups.Where(group => group.Type == CommandGroupType.Pre))
                {
                    Trace.TraceInformation(String.Format("execute group {0}", commandgroup.Type.ToString()));
                    executeCommand(l_db_connection, commandgroup, ref command_output);
                }

                foreach (CommandGroup commandgroup in commandgroups.Where(group => group.Type == CommandGroupType.Main))
                {
                    Trace.TraceInformation(String.Format("execute group {0}", commandgroup.Type.ToString()));
                    executeCommand(l_db_connection, commandgroup, ref command_output);
                }

                foreach (CommandGroup commandgroup in commandgroups.Where(group => group.Type == CommandGroupType.Post))
                {
                    Trace.TraceInformation(String.Format("execute group {0}", commandgroup.Type.ToString()));
                    executeCommand(l_db_connection, commandgroup, ref command_output);
                }

                transaction.Commit();

                output.Result = ExecutionResult.Success;
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("Error while package deployment {0}", e.Message));
                transaction.Rollback();
                output.Result = ExecutionResult.Error;
            }
            finally
            {
                output.End = DateTime.Now;
            }
        }

        public Output deployPackageToDB(ConnectionData ConnectionData, Package Package)
        {
            Trace.TraceInformation(
                String.Format("Start processing of package {0} to {1}@{2}",
                    Package.Id,
                    ConnectionData.User,
                    ConnectionData.TNS
                )
            );

            Output deployment_output = new Output();
            try
            {
                OracleConnection db_connection = initalizeConnection(ConnectionData);
                try
                {
                    executeCommandGroups(db_connection, Package.CommandGroups, ref deployment_output);
                    deployment_output.DeploymentId = Package.Id;
                    deployment_output.ConnectionId = ConnectionData.Id;
                }
                finally
                {
                    if (db_connection != null)
                        db_connection.Dispose();
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("Error while package deployment {0}", e.Message));

                deployment_output.End = DateTime.Now;

                CommandExecutionOutput error_output = new CommandExecutionOutput();

                error_output.Start = deployment_output.Start;
                error_output.End = deployment_output.End;
                error_output.Value = e.Message;
                error_output.Result = ExecutionResult.Error;
                deployment_output.CommandOutput.Add(error_output);
            }

            Trace.TraceInformation(
                String.Format("Finished deploymentPackage {0}",
                    Package.Id
                )
            );

            return deployment_output;
        }
    }
}
