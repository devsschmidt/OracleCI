using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OracleExecutor.Objects
{

    [DataContract]
    public class Package
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public IList<CommandGroup> CommandGroups { get; set; }

        public Package()
        {
            CommandGroups = new List<CommandGroup>();
        }
    }
}