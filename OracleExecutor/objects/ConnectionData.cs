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
        public string TNS { get; set; }

        [DataMember]
        public string User { get; set; }

        [DataMember]
        public string Password { get; set; }
            
    }
}
