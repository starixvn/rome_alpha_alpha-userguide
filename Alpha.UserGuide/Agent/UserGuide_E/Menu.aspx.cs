namespace Alpha.UserGuide.Agent.UserGuide_E
{
    using System.Web.UI;

    public partial class Menu_Page : Fanex.Age.UI.TplPage
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

        public override void RenderContent(HtmlTextWriter writer)
        {
            Menu_Template tpl = new Menu_Template();
            writer.Write(tpl);
        }
    }
}