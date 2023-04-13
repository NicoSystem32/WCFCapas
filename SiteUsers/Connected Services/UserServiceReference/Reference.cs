﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiteUsers.UserServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserBusinessModel", Namespace="http://schemas.datacontract.org/2004/07/WcfUsersBusiness.ModelsContract")]
    [System.SerializableAttribute()]
    public partial class UserBusinessModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateOfBirthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GenderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
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
        public int Age {
            get {
                return this.AgeField;
            }
            set {
                if ((this.AgeField.Equals(value) != true)) {
                    this.AgeField = value;
                    this.RaisePropertyChanged("Age");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DateOfBirth {
            get {
                return this.DateOfBirthField;
            }
            set {
                if ((this.DateOfBirthField.Equals(value) != true)) {
                    this.DateOfBirthField = value;
                    this.RaisePropertyChanged("DateOfBirth");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Gender {
            get {
                return this.GenderField;
            }
            set {
                if ((object.ReferenceEquals(this.GenderField, value) != true)) {
                    this.GenderField = value;
                    this.RaisePropertyChanged("Gender");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserServiceReference.IUsersService")]
    public interface IUsersService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/GetUsers", ReplyAction="http://tempuri.org/IUsersService/GetUsersResponse")]
        SiteUsers.UserServiceReference.UserBusinessModel[] GetUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/GetUsers", ReplyAction="http://tempuri.org/IUsersService/GetUsersResponse")]
        System.Threading.Tasks.Task<SiteUsers.UserServiceReference.UserBusinessModel[]> GetUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/InsertUser", ReplyAction="http://tempuri.org/IUsersService/InsertUserResponse")]
        bool InsertUser(SiteUsers.UserServiceReference.UserBusinessModel userToInsert);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/InsertUser", ReplyAction="http://tempuri.org/IUsersService/InsertUserResponse")]
        System.Threading.Tasks.Task<bool> InsertUserAsync(SiteUsers.UserServiceReference.UserBusinessModel userToInsert);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/EditUser", ReplyAction="http://tempuri.org/IUsersService/EditUserResponse")]
        bool EditUser(SiteUsers.UserServiceReference.UserBusinessModel userToEdit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/EditUser", ReplyAction="http://tempuri.org/IUsersService/EditUserResponse")]
        System.Threading.Tasks.Task<bool> EditUserAsync(SiteUsers.UserServiceReference.UserBusinessModel userToEdit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/DeleteUser", ReplyAction="http://tempuri.org/IUsersService/DeleteUserResponse")]
        bool DeleteUser(int userToDelete);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersService/DeleteUser", ReplyAction="http://tempuri.org/IUsersService/DeleteUserResponse")]
        System.Threading.Tasks.Task<bool> DeleteUserAsync(int userToDelete);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUsersServiceChannel : SiteUsers.UserServiceReference.IUsersService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UsersServiceClient : System.ServiceModel.ClientBase<SiteUsers.UserServiceReference.IUsersService>, SiteUsers.UserServiceReference.IUsersService {
        
        public UsersServiceClient() {
        }
        
        public UsersServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UsersServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsersServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsersServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SiteUsers.UserServiceReference.UserBusinessModel[] GetUsers() {
            return base.Channel.GetUsers();
        }
        
        public System.Threading.Tasks.Task<SiteUsers.UserServiceReference.UserBusinessModel[]> GetUsersAsync() {
            return base.Channel.GetUsersAsync();
        }
        
        public bool InsertUser(SiteUsers.UserServiceReference.UserBusinessModel userToInsert) {
            return base.Channel.InsertUser(userToInsert);
        }
        
        public System.Threading.Tasks.Task<bool> InsertUserAsync(SiteUsers.UserServiceReference.UserBusinessModel userToInsert) {
            return base.Channel.InsertUserAsync(userToInsert);
        }
        
        public bool EditUser(SiteUsers.UserServiceReference.UserBusinessModel userToEdit) {
            return base.Channel.EditUser(userToEdit);
        }
        
        public System.Threading.Tasks.Task<bool> EditUserAsync(SiteUsers.UserServiceReference.UserBusinessModel userToEdit) {
            return base.Channel.EditUserAsync(userToEdit);
        }
        
        public bool DeleteUser(int userToDelete) {
            return base.Channel.DeleteUser(userToDelete);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteUserAsync(int userToDelete) {
            return base.Channel.DeleteUserAsync(userToDelete);
        }
    }
}