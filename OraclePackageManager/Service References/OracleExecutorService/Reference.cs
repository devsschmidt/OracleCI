﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OraclePackageManager.OracleExecutorService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Connection", Namespace="http://schemas.datacontract.org/2004/07/OracleExecutor.Objects")]
    [System.SerializableAttribute()]
    public partial class Connection : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MaxPoolSizeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MinPoolSizeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TNSField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MaxPoolSize {
            get {
                return this.MaxPoolSizeField;
            }
            set {
                if ((this.MaxPoolSizeField.Equals(value) != true)) {
                    this.MaxPoolSizeField = value;
                    this.RaisePropertyChanged("MaxPoolSize");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MinPoolSize {
            get {
                return this.MinPoolSizeField;
            }
            set {
                if ((this.MinPoolSizeField.Equals(value) != true)) {
                    this.MinPoolSizeField = value;
                    this.RaisePropertyChanged("MinPoolSize");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TNS {
            get {
                return this.TNSField;
            }
            set {
                if ((object.ReferenceEquals(this.TNSField, value) != true)) {
                    this.TNSField = value;
                    this.RaisePropertyChanged("TNS");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string User {
            get {
                return this.UserField;
            }
            set {
                if ((object.ReferenceEquals(this.UserField, value) != true)) {
                    this.UserField = value;
                    this.RaisePropertyChanged("User");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Package", Namespace="http://schemas.datacontract.org/2004/07/OracleExecutor.Objects")]
    [System.SerializableAttribute()]
    public partial class Package : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<OraclePackageManager.OracleExecutorService.CommandGroup> CommandGroupsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<OraclePackageManager.OracleExecutorService.CommandGroup> CommandGroups {
            get {
                return this.CommandGroupsField;
            }
            set {
                if ((object.ReferenceEquals(this.CommandGroupsField, value) != true)) {
                    this.CommandGroupsField = value;
                    this.RaisePropertyChanged("CommandGroups");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CommandGroup", Namespace="http://schemas.datacontract.org/2004/07/OracleExecutor.Objects")]
    [System.SerializableAttribute()]
    public partial class CommandGroup : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<OraclePackageManager.OracleExecutorService.Command> CommandsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private OraclePackageManager.OracleExecutorService.CommandGroupType TypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<OraclePackageManager.OracleExecutorService.Command> Commands {
            get {
                return this.CommandsField;
            }
            set {
                if ((object.ReferenceEquals(this.CommandsField, value) != true)) {
                    this.CommandsField = value;
                    this.RaisePropertyChanged("Commands");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public OraclePackageManager.OracleExecutorService.CommandGroupType Type {
            get {
                return this.TypeField;
            }
            set {
                if ((this.TypeField.Equals(value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Command", Namespace="http://schemas.datacontract.org/2004/07/OracleExecutor.Objects")]
    [System.SerializableAttribute()]
    public partial class Command : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TextField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id {
            get {
                return this.IdField;
            }
            set {
                if ((object.ReferenceEquals(this.IdField, value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Text {
            get {
                return this.TextField;
            }
            set {
                if ((object.ReferenceEquals(this.TextField, value) != true)) {
                    this.TextField = value;
                    this.RaisePropertyChanged("Text");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.FlagsAttribute()]
    [System.Runtime.Serialization.DataContractAttribute(Name="CommandGroupType", Namespace="http://schemas.datacontract.org/2004/07/OracleExecutor.Objects")]
    public enum CommandGroupType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Pre = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Main = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Post = 3,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Output", Namespace="http://schemas.datacontract.org/2004/07/OracleExecutor.Objects")]
    [System.SerializableAttribute()]
    public partial class Output : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<OraclePackageManager.OracleExecutorService.CommandExecutionOutput> CommandOutputField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid ConnectionIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid DeploymentIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime EndField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private OraclePackageManager.OracleExecutorService.ExecutionResult ResultField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime StartField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<OraclePackageManager.OracleExecutorService.CommandExecutionOutput> CommandOutput {
            get {
                return this.CommandOutputField;
            }
            set {
                if ((object.ReferenceEquals(this.CommandOutputField, value) != true)) {
                    this.CommandOutputField = value;
                    this.RaisePropertyChanged("CommandOutput");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid ConnectionId {
            get {
                return this.ConnectionIdField;
            }
            set {
                if ((this.ConnectionIdField.Equals(value) != true)) {
                    this.ConnectionIdField = value;
                    this.RaisePropertyChanged("ConnectionId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid DeploymentId {
            get {
                return this.DeploymentIdField;
            }
            set {
                if ((this.DeploymentIdField.Equals(value) != true)) {
                    this.DeploymentIdField = value;
                    this.RaisePropertyChanged("DeploymentId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime End {
            get {
                return this.EndField;
            }
            set {
                if ((this.EndField.Equals(value) != true)) {
                    this.EndField = value;
                    this.RaisePropertyChanged("End");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public OraclePackageManager.OracleExecutorService.ExecutionResult Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Start {
            get {
                return this.StartField;
            }
            set {
                if ((this.StartField.Equals(value) != true)) {
                    this.StartField = value;
                    this.RaisePropertyChanged("Start");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CommandExecutionOutput", Namespace="http://schemas.datacontract.org/2004/07/OracleExecutor.Objects")]
    [System.SerializableAttribute()]
    public partial class CommandExecutionOutput : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime EndField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private OraclePackageManager.OracleExecutorService.ExecutionResult ResultField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime StartField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private OraclePackageManager.OracleExecutorService.CommandGroupType TypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime End {
            get {
                return this.EndField;
            }
            set {
                if ((this.EndField.Equals(value) != true)) {
                    this.EndField = value;
                    this.RaisePropertyChanged("End");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public OraclePackageManager.OracleExecutorService.ExecutionResult Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Start {
            get {
                return this.StartField;
            }
            set {
                if ((this.StartField.Equals(value) != true)) {
                    this.StartField = value;
                    this.RaisePropertyChanged("Start");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public OraclePackageManager.OracleExecutorService.CommandGroupType Type {
            get {
                return this.TypeField;
            }
            set {
                if ((this.TypeField.Equals(value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.FlagsAttribute()]
    [System.Runtime.Serialization.DataContractAttribute(Name="ExecutionResult", Namespace="http://schemas.datacontract.org/2004/07/OracleExecutor.Objects")]
    public enum ExecutionResult : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Success = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Error = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OracleExecutorService.ISQLExecutor")]
    public interface ISQLExecutor {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISQLExecutor/deployPackageToDB", ReplyAction="http://tempuri.org/ISQLExecutor/deployPackageToDBResponse")]
        OraclePackageManager.OracleExecutorService.Output deployPackageToDB(OraclePackageManager.OracleExecutorService.Connection ConnectionData, OraclePackageManager.OracleExecutorService.Package Package);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISQLExecutor/deployPackageToDB", ReplyAction="http://tempuri.org/ISQLExecutor/deployPackageToDBResponse")]
        System.Threading.Tasks.Task<OraclePackageManager.OracleExecutorService.Output> deployPackageToDBAsync(OraclePackageManager.OracleExecutorService.Connection ConnectionData, OraclePackageManager.OracleExecutorService.Package Package);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISQLExecutorChannel : OraclePackageManager.OracleExecutorService.ISQLExecutor, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SQLExecutorClient : System.ServiceModel.ClientBase<OraclePackageManager.OracleExecutorService.ISQLExecutor>, OraclePackageManager.OracleExecutorService.ISQLExecutor {
        
        public SQLExecutorClient() {
        }
        
        public SQLExecutorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SQLExecutorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SQLExecutorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SQLExecutorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public OraclePackageManager.OracleExecutorService.Output deployPackageToDB(OraclePackageManager.OracleExecutorService.Connection ConnectionData, OraclePackageManager.OracleExecutorService.Package Package) {
            return base.Channel.deployPackageToDB(ConnectionData, Package);
        }
        
        public System.Threading.Tasks.Task<OraclePackageManager.OracleExecutorService.Output> deployPackageToDBAsync(OraclePackageManager.OracleExecutorService.Connection ConnectionData, OraclePackageManager.OracleExecutorService.Package Package) {
            return base.Channel.deployPackageToDBAsync(ConnectionData, Package);
        }
    }
}
