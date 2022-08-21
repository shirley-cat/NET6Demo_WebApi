
using Autofac;
using CommonCode.Helper;
using NET6Demo.Interface.Dependency;
using NET6Demo.Utility.ApiResult;
using NET6Demo.Utility.AppModel;
using NET6Demo.Utility.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using Module = Autofac.Module;

namespace NET6Demo.Utility.Autofac
{
    public class AutofacModule : Module
    {


        protected override void Load(ContainerBuilder container)
        {


            ////base.Load(builder);
            Type baseType = typeof(IDependency);
            var basePath = AppContext.BaseDirectory;

            List<Component> components = AppsettingHelper.Get<Component>("Components");
            foreach (var c in components)
            {
                var iServiceDll = $"{basePath}{c.InterfaceName}";
                var ServiceDll = $"{basePath}{c.ServiceName}";
                Assembly iServiceAssembly = Assembly.LoadFile(iServiceDll);
                Assembly serviceAssembly = Assembly.LoadFile(ServiceDll);
                container.RegisterAssemblyTypes(iServiceAssembly, serviceAssembly)
                    .Where(b => !b.IsAbstract && baseType.IsAssignableFrom(b))
                    .AsImplementedInterfaces();

            }

            // 用于Jwt的各种操作            
            container.RegisterType<JwtSecurityTokenHandler>().InstancePerLifetimeScope();

            //自己写的支持泛型存入Jwt 便于扩展
            container.RegisterType<TokenHelper>().InstancePerLifetimeScope();

            //api返回值处理
            container.RegisterType<ResultHelper>().InstancePerLifetimeScope();
        }
    }
}
