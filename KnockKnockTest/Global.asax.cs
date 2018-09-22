using KnockKnockTest.App_Start;
using System.Web.Http;
using System.Web.Mvc;

namespace KnockKnockTest
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            IocConfig.Register(GlobalConfiguration.Configuration);  
        }
    }
}
