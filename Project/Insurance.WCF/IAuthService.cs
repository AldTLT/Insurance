using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Insurance.WCF
{ 
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        bool SignIn(string email, string password);

        [OperationContract]
        bool RegistrationAccount(string mail, string fullName, DateTime birthDate, DateTime driverLicenseDate, string password);
    }
}
