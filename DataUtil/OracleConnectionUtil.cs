using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Diagnostics;

namespace DataUtil
{
    public class OracleConnectionUtil
    {
        private static OracleConnection _connection;

        public static OracleConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    ConnectionSettingSection config = (ConnectionSettingSection)ConfigurationManager.GetSection("Database.Connection");

                    _connection = initalizeConnection(
                        config.TNS,
                        config.User,
                        config.Password,
                        Math.Max(config.MinPoolSize, 1),
                        Math.Max(config.MaxPoolSize, 1)
                    );                    
                }

                return _connection;
            }
        }

        public static OracleConnection initalizeConnection(string TNS, string User, string Password, int MinPoolSize = 1, int MaxPoolSize = 1)
        {
            string connection_string = String.Format("Data Source={0}; User Id={1}; Password={2}; Min Pool Size={3}; Max Pool Size={4}; Pooling='true';",
                                            TNS,
                                            User,
                                            Password,
                                            MinPoolSize,
                                            MaxPoolSize
                                       );

            try
            {
                Trace.TraceInformation(String.Format("initiate Connection to {0}@{1}", User, TNS));

                OracleConnection result = new OracleConnection(connection_string);
                result.Open();

                return result;
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("Connection couldn't be initiated {0}", e.Message));
                throw;
            }
        }
    }
}
