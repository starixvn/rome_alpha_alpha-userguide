namespace Alpha.UserGuide
{
    using Alpha.UserGuide.Helpers;
    using Alpha.Web.Helpers;
    using AlphaPlus.Configurations;
    using AlphaPlus.Logging;
    using AlphaPlus.Logging.Web;
    using AlphaPlus.User.Models;
    using System;
    using System.Web;
    using System.Web.Security;
    using TplNetCore;
    using Web;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ConfigurationManager.Init(new ConfigurationHelper());
            TplSettings.UrlVersion = AppSettings.JsVersion;
            TplSettings.Init(new TplSettingHelper());
            UserSession.Init(new HttpContextHelper());
            ShareSession.Init();
            LoggingConfig.ExceptionHandler = new ExceptionHandlerAdapter();
            LoggingConfig.Init();
        }

        private void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (UserSession.Current.IsProtectedMode)
            {
                TerminateSessionAndSignOut();
            }
        }

        private void TerminateSessionAndSignOut()
        {
            Session.Clear();

            if (!Session.IsCookieless)
            {
                FormsAuthentication.SignOut();
            }

            Response.Redirect(MicroSites.OldMainUrl(FormsAuthentication.LoginUrl), true);
        }
    }
}