namespace Alpha.UserGuide
{
    using Sunplus.Agent.Model.Entities;

    public partial class Index_Page : Fanex.Age.UI.TplPage
    {
        public override void ProcessRequest(ref System.Collections.Hashtable p)
        {
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

            if(!Sunplus.Agent.Model.Entities.Permission.UserPermission.IsNeutral)
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