namespace Alpha.UserGuide
{
    using System.Web.Security;
    using AlphaPlus.Configurations;
    using AlphaPlus.User.Models;

    public partial class Index_Page : Fanex.Age.UI.TplPage
    {
        public override void ProcessRequest(ref System.Collections.Hashtable p)
        {
            if (UserSession.Current.CustId == 0)
            {
                Response.Redirect(FormsAuthentication.LoginUrl, true);

                return;
            }
        }

        public override object ValidateRequest(System.Collections.Hashtable p)
        {
            return null;
        }

        public override object InvokeData(System.Collections.Hashtable p)
        {
            return null;
        }

        public override void RenderContent(System.Web.UI.HtmlTextWriter writer)
        {
            Index_Template tpl = new Index_Template();
            tpl.UserGuide = Resources.LocalResourceUserGuide.UserGuide;

            if (!AppSettings.IsSiteLabel789y)
            {
                if (UserSession.Current.IsAgent)
                {
                    if (UserSession.Current.LangKey.Equals("CS", System.StringComparison.OrdinalIgnoreCase)
                        || UserSession.Current.LangKey.Equals("CT", System.StringComparison.OrdinalIgnoreCase))
                    {
                        tpl.urlLink = string.Format("Agent/UserGuide_{0}/index.aspx", UserSession.Current.LangKey);
                    }
                    else
                    {
                        tpl.urlLink = "Agent/UserGuide_E/index.aspx";
                    }
                }
                else if (UserSession.Current.IsMaster)
                {
                    if (UserSession.Current.LangKey.Equals("CS", System.StringComparison.OrdinalIgnoreCase)
                        || UserSession.Current.LangKey.Equals("CT", System.StringComparison.OrdinalIgnoreCase))
                    {
                        tpl.urlLink = string.Format("Master/UserGuide_{0}/index.aspx", UserSession.Current.LangKey);
                    }
                    else
                    {
                        tpl.urlLink = "Master/UserGuide_E/index.aspx";
                    }
                }
            }

            writer.Write(tpl);
        }
    }
}