using System;
using System.Runtime.Serialization;

namespace OracleExecutor.Objects
{
    [DataContract]
    public class ConnectionData
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string User { get; set; }

        [DataMember]
        public string Host { get; set; }

        [DataMember]
        public int Port { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Database { get; set; }

      
    }
}
