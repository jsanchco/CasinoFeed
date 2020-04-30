namespace Codere.SGBOnlineGames.CasinoFeed.App_Start
{
    #region Using

    using System.Web.Http;
    using ServiceSlotsGamesCodere;
    using Codere.SGBOnlineGames.CasinoFeed.Domain.Services;
    using System.Reflection;
    using Autofac;
    using Autofac.Integration.WebApi;

    #endregion

    public class AutofacWebapiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            RegisterServices(builder);

            // Set the dependency resolver to be Autofac.
            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterType<ServiceSlotsGamesCodere>()
                   .As<IServiceSlotsGames>()
                   .SingleInstance();
        }
    }
}