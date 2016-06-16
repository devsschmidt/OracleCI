using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OracleExecutor.Objects
{
    [DataContract]
    [Flags]
    public enum ExecutionResult
    {
        [EnumMember]
        Success,

        [EnumMember]
        Error
    }

    [DataContract]
    public class CommandExecutionOutput
    {
        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public DateTime Start { get; set; }

        [DataMember]
        public DateTime End { get; set; }

        [DataMember]
        public ExecutionResult Result { get; set; }

        [DataMember]
        public CommandGroupType Type { get; set; }

        public CommandExecutionOutput()
        {
            Start = DateTime.Now;
        }        
    }

    [DataContract]
    public class Output
    {
        [DataMember]
        public Guid DeploymentId { get; set; }

        [DataMember]
        public Guid ConnectionId { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public DateTime Start { get; set; }

        [DataMember]
        public DateTime End { get; set; }

        [DataMember]
        public ExecutionResult Result { get; set; }
        
        [DataMember]
        public List<CommandExecutionOutput> CommandOutput
        {
            get
            {
                return _command_output;
            }
        }

        private List<CommandExecutionOutput> _command_output = new List<CommandExecutionOutput>();

        public Output()
        {
            Start = DateTime.Now;
        }

        public Output(Guid deploymentId, Guid connectionId)
        {
            Start = DateTime.Now;
            DeploymentId = deploymentId;
            ConnectionId = connectionId;
        }
    }
}