using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OracleExecutor.Objects
{
    [DataContract]
    [Flags]
    public enum CommandGroupType
    {
        [EnumMember]
        Pre=1, 

        [EnumMember]
        Main=2,

        [EnumMember]
        Post=3
    }

    public class CommandGroup
    {
        [DataMember]
        public CommandGroupType Type { get; set; }

        [DataMember]
        public IList<Command> Commands { get; set; }

        public CommandGroup()
        {
            Commands = new List<Command>();
            Type = CommandGroupType.Main;
        }
    }
}