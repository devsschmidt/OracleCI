using System;
using System.Runtime.Serialization;

namespace OraclePackageManager.Objects
{
    [DataContract]
    public class ConnectionObject
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string TNS { get; set; }

        [DataMember]
        public string User { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public int MinPoolSize { get; set; }

        [DataMember]
        public int MaxPoolSize { get; set; }
    }
}