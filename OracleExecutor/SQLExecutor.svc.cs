using Oracle.ManagedDataAccess.Client;
using OracleExecutor.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OracleExecutor
{
    public class SQLExecutor : ISQLExecutor
    {
        private int _default_min_poolsize = 1;
        private int _default_max_poolsize = 1;

        private OracleConnection initalizeConnection(ConnectionData ConnectionData)
        {
            string connection_string = String.Format("Data Source={0}; User Id={1}; Password={2}; Max Pool Size={3}; Min Pool Size={4};Pooling='{5}';",
                                            ConnectionData.TNS,
                                            ConnectionData.User,
                                            ConnectionData.Password,
                                            _default_min_poolsize,
                                            _default_max_poolsize
                                       );

            try
            {
                Trace.TraceInformation(String.Format("initiate Connection to {0}@{1}",
                        ConnectionData.User,
                        ConnectionData.TNS
                    )
                );

                OracleConnection db_connection = new OracleConnection(connection_string);
                db_connection.Open();

                return db_connection;
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("Connection couldn't be initiated {0}", e.Message));
                throw;
            }            
        }

        private List<CommandExecutionOutput> executeCommand(OracleConnection connection, CommandGroup commandGroup)
        {
            List<CommandExecutionOutput> result = new List<CommandExecutionOutput>();

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
                    result.Add(l_command_output);
                }
            }

            return result;
        }

        //private Output executeCommandGroups(OracleConnection connection, IList<CommandGroup> commandgroups)
        //{
        //    Output result = new Output();

        //    OracleConnection l_db_connection = connection;
        //    OracleTransaction transaction = l_db_connection.BeginTransaction();
        //    try
        //    {
        //        foreach (CommandGroup commandgroup in commandgroups.Where(group => group.Type == CommandGroupType.Pre))
        //        {
        //            Trace.TraceInformation(String.Format("execute group {0}", commandgroup.Type.ToString()));
        //            result.CommandOutput.AddRange(executeCommand(l_db_connection, commandgroup));
        //        }

        //        foreach (CommandGroup commandgroup in commandgroups.Where(group => group.Type == CommandGroupType.Main))
        //        {
        //            Trace.TraceInformation(String.Format("execute group {0}", commandgroup.Type.ToString()));
        //            result.CommandOutput.AddRange(executeCommand(l_db_connection, commandgroup));
        //        }

        //        foreach (CommandGroup commandgroup in commandgroups.Where(group => group.Type == CommandGroupType.Post))
        //        {
        //            Trace.TraceInformation(String.Format("execute group {0}", commandgroup.Type.ToString()));
        //            result.CommandOutput.AddRange(executeCommand(l_db_connection, commandgroup));
        //        }

        //        transaction.Commit();

        //        result.Result = ExecutionResult.Success;
        //    }
        //    catch (Exception e)
        //    {
        //        Trace.TraceError(String.Format("Error while package deployment {0}", e.Message));
        //        transaction.Rollback();
        //        result.Result = ExecutionResult.Error;
        //    }
        //    finally
        //    {
        //        result.End = DateTime.Now;
        //    }
        //    return result;
        //}

        public Output deployPackageToDB(ConnectionData ConnectionData, Package Package)
        {
            Trace.TraceInformation(
                String.Format("Start processing of package {0} to {1}@{2}",
                    Package.Id,
                    ConnectionData.User,
                    ConnectionData.TNS
                )
            );

            Output DeploymentOutput;
            OracleConnection db_connection = initalizeConnection(ConnectionData);
            try
            {
                DeploymentOutput = executeCommandGroups(db_connection, Package.CommandGroups);
                DeploymentOutput.DeploymentId = Package.Id;
                DeploymentOutput.ConnectionId = ConnectionData.Id;
            }
            finally
            {
                db_connection.Dispose();
            }

            Trace.TraceInformation(
                String.Format("Finished deploymentPackage {0}",
                    Package.Id
                )
            );
            return DeploymentOutput;
        }
    }
}
