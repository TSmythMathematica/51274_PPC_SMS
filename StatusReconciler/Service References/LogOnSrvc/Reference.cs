﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APITest.LogOnSrvc {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://firmglobal.com/Confirmit/webservices/", ConfigurationName="LogOnSrvc.LogOnSoap")]
    public interface LogOnSoap {
        
        // CODEGEN: Generating message contract since element name username from namespace http://firmglobal.com/Confirmit/webservices/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://firmglobal.com/Confirmit/webservices/LogOnUser", ReplyAction="*")]
        APITest.LogOnSrvc.LogOnUserResponse LogOnUser(APITest.LogOnSrvc.LogOnUserRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://firmglobal.com/Confirmit/webservices/LogOnUser", ReplyAction="*")]
        System.Threading.Tasks.Task<APITest.LogOnSrvc.LogOnUserResponse> LogOnUserAsync(APITest.LogOnSrvc.LogOnUserRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LogOnUserRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="LogOnUser", Namespace="http://firmglobal.com/Confirmit/webservices/", Order=0)]
        public APITest.LogOnSrvc.LogOnUserRequestBody Body;
        
        public LogOnUserRequest() {
        }
        
        public LogOnUserRequest(APITest.LogOnSrvc.LogOnUserRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://firmglobal.com/Confirmit/webservices/")]
    public partial class LogOnUserRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string username;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string password;
        
        public LogOnUserRequestBody() {
        }
        
        public LogOnUserRequestBody(string username, string password) {
            this.username = username;
            this.password = password;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LogOnUserResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="LogOnUserResponse", Namespace="http://firmglobal.com/Confirmit/webservices/", Order=0)]
        public APITest.LogOnSrvc.LogOnUserResponseBody Body;
        
        public LogOnUserResponse() {
        }
        
        public LogOnUserResponse(APITest.LogOnSrvc.LogOnUserResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://firmglobal.com/Confirmit/webservices/")]
    public partial class LogOnUserResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string LogOnUserResult;
        
        public LogOnUserResponseBody() {
        }
        
        public LogOnUserResponseBody(string LogOnUserResult) {
            this.LogOnUserResult = LogOnUserResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface LogOnSoapChannel : APITest.LogOnSrvc.LogOnSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LogOnSoapClient : System.ServiceModel.ClientBase<APITest.LogOnSrvc.LogOnSoap>, APITest.LogOnSrvc.LogOnSoap {
        
        public LogOnSoapClient() {
        }
        
        public LogOnSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LogOnSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LogOnSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LogOnSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        APITest.LogOnSrvc.LogOnUserResponse APITest.LogOnSrvc.LogOnSoap.LogOnUser(APITest.LogOnSrvc.LogOnUserRequest request) {
            return base.Channel.LogOnUser(request);
        }
        
        public string LogOnUser(string username, string password) {
            APITest.LogOnSrvc.LogOnUserRequest inValue = new APITest.LogOnSrvc.LogOnUserRequest();
            inValue.Body = new APITest.LogOnSrvc.LogOnUserRequestBody();
            inValue.Body.username = username;
            inValue.Body.password = password;
            APITest.LogOnSrvc.LogOnUserResponse retVal = ((APITest.LogOnSrvc.LogOnSoap)(this)).LogOnUser(inValue);
            return retVal.Body.LogOnUserResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<APITest.LogOnSrvc.LogOnUserResponse> APITest.LogOnSrvc.LogOnSoap.LogOnUserAsync(APITest.LogOnSrvc.LogOnUserRequest request) {
            return base.Channel.LogOnUserAsync(request);
        }
        
        public System.Threading.Tasks.Task<APITest.LogOnSrvc.LogOnUserResponse> LogOnUserAsync(string username, string password) {
            APITest.LogOnSrvc.LogOnUserRequest inValue = new APITest.LogOnSrvc.LogOnUserRequest();
            inValue.Body = new APITest.LogOnSrvc.LogOnUserRequestBody();
            inValue.Body.username = username;
            inValue.Body.password = password;
            return ((APITest.LogOnSrvc.LogOnSoap)(this)).LogOnUserAsync(inValue);
        }
    }
}
