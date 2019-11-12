using Insurance.BL;
using Insurance.BL.Intefaces;
using MainRepository;
using MainRepository.ModelsRepository;
using Stub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Container
{
    public class RepositoryContainer
    {
        public void SetDependency(bool toStub)
        {
            UnityContainer container = new UnityContainer();
            //var context = new DataContext();

            if (toStub)
            {
                container.RegisterType<IAuthRepository, StubAuthRepository>();
                container.RegisterType<IPolicyRepository, StubPolicyRepository>();
                container.RegisterType<ICarRepository, StubCarRepository>();
                container.RegisterType<IRatioRepository, StubRatioRepository>();
                container.RegisterType<IRoleRepository, StubRoleRepository>();
            }
            else
            {
                container.RegisterType<IAuthRepository, AuthRepository>();
                container.RegisterType<IPolicyRepository, PolicyRepository>();
                container.RegisterType<ICarRepository, CarRepository>();
                container.RegisterType<IRatioRepository, RatioRepository>();
                container.RegisterType<IRoleRepository, RoleRepository>();
            }
        }
    }
}
