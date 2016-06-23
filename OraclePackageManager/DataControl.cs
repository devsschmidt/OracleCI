using DataUtil;
using Oracle.ManagedDataAccess.Client;
using OraclePackageManager.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace OraclePackageManager
{
    #region enums
    [DataContract]
    [Flags]
    public enum DeploymentStatus : int
    {
        [EnumMember]
        INITIAL = 0,

        [EnumMember]
        STARTED = 1,

        [EnumMember]
        SUCCESSFULL = 2,

        [EnumMember]
        FAILED = 3
    }

    [DataContract]
    [Flags]
    public enum CommandType
    {
        [EnumMember]
        PRE = 1,

        [EnumMember]
        MAIN = 2,

        [EnumMember]
        POST = 3
    }
    #endregion

    public class DataControl
    {
        private OracleConnection Connection
        {
            get
            {
                return OracleConnectionUtil.Connection;
            }
        }

        #region Connections
        public IList<ConnectionObject> getConnections()
        {
            IList<ConnectionObject> connections = new List<ConnectionObject>();

            try
            {            
                OracleCommand command = new OracleCommand(@"
                    SELECT c_id, c_name, c_tns, c_user, c_password
                    FROM connection",
                    Connection
                );

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    connections.Add( 
                        new ConnectionObject() {
                            Id = Guid.Parse(reader.GetString(0)),
                            Name = reader.GetString(1),
                            TNS = reader.GetString(2),
                            User = reader.GetString(3),
                            Password = reader.GetString(4)
                        }
                    );
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("Connection couldn't be retrieved from database {0}", e.Message));
            }
            return connections;
        }

        public ConnectionObject getConnection(Guid ConnectionId)
        {
            try
            {
                OracleCommand command = new OracleCommand(@"
                    SELECT c_id, c_name, c_tns, c_user, c_password
                    FROM connection
                    WHERE c_id = :id",
                    Connection
                );

                command.Parameters.Add(new OracleParameter("id", ConnectionId.ToString()));

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return 
                        new ConnectionObject()
                        {
                            Id = Guid.Parse(reader.GetString(0)),
                            Name = reader.GetString(1),
                            TNS = reader.GetString(2),
                            User = reader.GetString(3),
                            Password = reader.GetString(4)
                        }
                    ;
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("Connection {0} couldn't be retrieved from database. Error: {1}", ConnectionId.ToString(), e.Message));
            }
            return null;
        }
        #endregion

        #region Package
        public PackageObject getPackage(Guid PackageId)
        {
            try
            {
                OracleCommand command = new OracleCommand(
                    "SELECT p_id, p_created, p_last_modified, p_name " +
                    "FROM package " +
                    "WHERE p_id = :id",
                    Connection
                );

                command.Parameters.Add(new OracleParameter("id", PackageId.ToString()));

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return
                        new PackageObject()
                        {
                            Id = Guid.Parse(reader.GetString(0)),
                            Created = reader.GetDateTime(1),
                            LastModified = reader.GetDateTime(2),
                            Name = reader.GetString(3), 
                            Commands = getCommands(PackageId)
                        }
                    ;
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("Package {0} couldn't be retrieved from database. Error: {1}", PackageId.ToString(), e.Message));
            }
            return null;
        }

        public IList<CommandObject> getCommands(Guid PackageId)
        {
            IList<CommandObject> commands = new List<CommandObject>();

            try
            {
                OracleCommand command = new OracleCommand(
                    "SELECT c_id, c_type_id, c_created, c_last_modified, c_name, c_value, c_sort_index "+
                    "FROM command " +
                    "WHERE c_package_id = :id",
                    Connection
                );

                command.Parameters.Add(new OracleParameter("id", PackageId.ToString()));

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    commands.Add(
                        new CommandObject()
                        {   
                            Id = Guid.Parse(reader.GetString(0)),
                            Type = (CommandType)reader.GetInt32(1),
                            Created = reader.GetDateTime(2),
                            LastModified = reader.GetDateTime(3),
                            Name = reader.GetString(4),
                            Value = reader.GetString(5),
                            SortIndex = reader.GetInt32(6)
                        }
                    );
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("Package {0} couldn't be retrieved from database. Error: {1}", PackageId.ToString(), e.Message));
            }
            return commands;
        }
        #endregion#
    }
}