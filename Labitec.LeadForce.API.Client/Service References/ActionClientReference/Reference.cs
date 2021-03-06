﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Labitec.LeadForce.API.Client.ActionClientReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ActionClientReference.IAction")]
    public interface IAction {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAction/GetActions", ReplyAction="http://tempuri.org/IAction/GetActionsResponse")]
        string GetActions(System.Guid siteId, string username, string password, string xml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAction/CreateAction", ReplyAction="http://tempuri.org/IAction/CreateActionResponse")]
        string CreateAction(System.Guid siteId, string username, string password, string xml);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IActionChannel : Labitec.LeadForce.API.Client.ActionClientReference.IAction, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ActionClient : System.ServiceModel.ClientBase<Labitec.LeadForce.API.Client.ActionClientReference.IAction>, Labitec.LeadForce.API.Client.ActionClientReference.IAction {
        
        public ActionClient() {
        }
        
        public ActionClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ActionClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ActionClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ActionClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetActions(System.Guid siteId, string username, string password, string xml) {
            return base.Channel.GetActions(siteId, username, password, xml);
        }
        
        public string CreateAction(System.Guid siteId, string username, string password, string xml) {
            return base.Channel.CreateAction(siteId, username, password, xml);
        }
    }
}
