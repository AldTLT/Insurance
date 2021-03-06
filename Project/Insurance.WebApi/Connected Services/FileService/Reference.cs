﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insurance.WebApi.FileService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FileService.IFileService")]
    public interface IFileService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileService/GetPdfFile", ReplyAction="http://tempuri.org/IFileService/GetPdfFileResponse")]
        byte[] GetPdfFile(string carNumber, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileService/GetPdfFile", ReplyAction="http://tempuri.org/IFileService/GetPdfFileResponse")]
        System.Threading.Tasks.Task<byte[]> GetPdfFileAsync(string carNumber, string email);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFileServiceChannel : Insurance.WebApi.FileService.IFileService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FileServiceClient : System.ServiceModel.ClientBase<Insurance.WebApi.FileService.IFileService>, Insurance.WebApi.FileService.IFileService {
        
        public FileServiceClient() {
        }
        
        public FileServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FileServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public byte[] GetPdfFile(string carNumber, string email) {
            return base.Channel.GetPdfFile(carNumber, email);
        }
        
        public System.Threading.Tasks.Task<byte[]> GetPdfFileAsync(string carNumber, string email) {
            return base.Channel.GetPdfFileAsync(carNumber, email);
        }
    }
}
