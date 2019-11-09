using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Insurance.WCF
{
    [ServiceContract]
    public interface ISmtpService
    {
        [OperationContract]
        void SendPdf(string email);
    }
}
