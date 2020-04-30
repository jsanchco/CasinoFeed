namespace Codere.SGBOnlineGames.CasinoFeed
{    
    #region Using

    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Codere.SGBOnlineGames.CasinoFeed.App_Start;

    #endregion

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {            
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(AutofacWebapiConfig.Register);
        }
    }
}
