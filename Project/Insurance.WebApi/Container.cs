using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Insurance.WCF;
using Ninject.Modules;

namespace Insurance.WebApi
{
    public class Container : NinjectModule
    {
        public override void Load()
        {
            Bind<IPolicyService>().To<PolicyService>();
        }
    }
}