using Ninject;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Users.Rules.Interface;
using Users.Rules.Services;

namespace Master.Infraestruture
{
    public static class NinjectBindingsConfigurator
    {
        private static StandardKernel _kernel;

        public static void Start()
        {
            _kernel = new StandardKernel();

            _kernel.Bind<IHttpControllerActivator>()
                   .To<NinjectKActivator>()
                   .InSingletonScope()
                   .WithConstructorArgument("kernel", _kernel);
            _kernel.Bind<IUser>().To<UserServices>().WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["ConnectionString.Business.Web"].ConnectionString);
            _kernel.Bind<IUser>().To<UserServices>();
            GlobalConfiguration.Configuration.DependencyResolver = new LoadNinjectResolver(
                _kernel, GlobalConfiguration.Configuration.DependencyResolver
            );
        }
    }
}