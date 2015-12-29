namespace Alpha.UserGuide.Agent.UserGuide_E
{
    using DNAide.Web;
    using Sunplus.Agent.Model.Entities;

    public partial class Content_Page : Fanex.Age.UI.TplPage
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
            if (UserSession.Current.IsAgent && !string.IsNullOrEmpty(Request["Url"]))
            {
                string urlRequest = Request["Url"].Replace(' ', '+');
                urlRequest = Sunplus.Agent.Utilities.Encryption.CfsDeCrypt(urlRequest);
                string[] arrUrlRequest = urlRequest.Split('/');

                string html = TemplateHandler.LoadTemplate("../Agent/UserGuide_E/" + urlRequest, false);

                html = html.Replace("href=\"../css/", "href=\"css/");
                html = html.Replace("src=\"images/", "src=\"" + arrUrlRequest[0] + "/images/");
                writer.Write(html);
            }
            else
            {
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}