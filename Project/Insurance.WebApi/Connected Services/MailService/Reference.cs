﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insurance.WebApi.MailService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MailService.IMailService")]
    public interface IMailService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMailService/SendPdf", ReplyAction="http://tempuri.org/IMailService/SendPdfResponse")]
        void SendPdf(string carNumber, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMailService/SendPdf", ReplyAction="http://tempuri.org/IMailService/SendPdfResponse")]
        System.Threading.Tasks.Task SendPdfAsync(string carNumber, string email);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMailServiceChannel : Insurance.WebApi.MailService.IMailService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MailServiceClient : System.ServiceModel.ClientBase<Insurance.WebApi.MailService.IMailService>, Insurance.WebApi.MailService.IMailService {
        
        public MailServiceClient() {
        }
        
        public MailServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MailServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MailServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MailServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void SendPdf(string carNumber, string email) {
            base.Channel.SendPdf(carNumber, email);
        }
        
        public System.Threading.Tasks.Task SendPdfAsync(string carNumber, string email) {
            return base.Channel.SendPdfAsync(carNumber, email);
        }
    }
}
