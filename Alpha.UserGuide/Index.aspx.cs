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

            if (CurrentUserSession.IsAgent && !Sunplus.Agent.Model.Entities.Permission.UserPermission.IsNeutral)
            {
                if (UserSession.Current.LangKey == "CS" || UserSession.Current.LangKey == "CT")
                {
                    tpl.urlLink = "Agent/UserGuide_" + UserSession.Current.LangKey + "/" + "index.aspx";
                }
                else
                {
                    tpl.urlLink = "Agent/UserGuide_E/index.aspx";
                }
            }
            else if (CurrentUserSession.IsMaster && !Sunplus.Agent.Model.Entities.Permission.UserPermission.IsNeutral)
            {
                if (UserSession.Current.LangKey == "CS" || UserSession.Current.LangKey == "CT")
                {
                    tpl.urlLink = "Master/UserGuide_" + UserSession.Current.LangKey + "/" + "index.aspx";
                }
                else
                {
                    tpl.urlLink = "Master/UserGuide_E/index.aspx";
                }
            }

            writer.Write(tpl);
        }
    }
}