using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace KnockKnockTest.App_Start
{
    public class IocConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterApiControllers(assembly);
            builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}