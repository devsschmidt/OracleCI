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
        private OracleConnection initalizeConnectionPool(ConnectionData connection)
        {
            OracleConnection l_db_connection = new OracleConnection();
            try
            {
                Trace.TraceInformation(String.Format("initiate Connection to {0}@{1}:{2}",
                        connection.Database,
                        connection.Host,
                        connection.Port.ToString()
                    )
                );
                
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("Connection couldn't be initiated {0}", e.Message));
                throw;
            }

            return l_db_connection;
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

        private Output executeCommandGroups(OracleConnection connection, IList<CommandGroup> commandgroups)
        {
            Output result = new Output();

            OracleConnection l_db_connection = connection;
            OracleTransaction transaction = l_db_connection.BeginTransaction();
            try
            {
                foreach (CommandGroup commandgroup in commandgroups.Where(group => group.Type == CommandGroupType.Pre))
                {
                    Trace.TraceInformation(String.Format("execute group {0}", commandgroup.Type.ToString()));
                    result.CommandOutput.AddRange(executeCommand(l_db_connection, commandgroup));
                }

                foreach (CommandGroup commandgroup in commandgroups.Where(group => group.Type == CommandGroupType.Main))
                {
                    Trace.TraceInformation(String.Format("execute group {0}", commandgroup.Type.ToString()));
                    result.CommandOutput.AddRange(executeCommand(l_db_connection, commandgroup));
                }

                foreach (CommandGroup commandgroup in commandgroups.Where(group => group.Type == CommandGroupType.Post))
                {
                    Trace.TraceInformation(String.Format("execute group {0}", commandgroup.Type.ToString()));
                    result.CommandOutput.AddRange(executeCommand(l_db_connection, commandgroup));
                }

                transaction.Commit();

                result.Result = ExecutionResult.Success;
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("Error while package deployment {0}", e.Message));
                transaction.Rollback();
                result.Result = ExecutionResult.Error;
            }
            finally
            {
                result.End = DateTime.Now;
            }
            return result;
        }
    }
}
