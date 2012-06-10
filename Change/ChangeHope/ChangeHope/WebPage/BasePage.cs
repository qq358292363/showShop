namespace ChangeHope.WebPage
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class BasePage
    {
        public void AddStyleSheet(Page page, string cssPath)
        {
            HtmlLink link = new HtmlLink();
            link.Href = cssPath;
            link.Attributes["rel"] = "stylesheet";
            link.Attributes["type"] = "text/css";
        }

        public static void PageError(string ErrMsg, string Url)
        {
            PageError(ErrMsg, Url, "");
        }

        public static void PageError(string ErrMsg, string retrunUrl, string otherInfo)
        {
            WebHint.ShowError(ErrMsg, retrunUrl, otherInfo);
        }

        public static void PageRight(string RightMsg, string Url)
        {
            PageRight(RightMsg, Url, "");
        }

        public static void PageRight(string ErrMsg, string retrunUrl, string otherInfo)
        {
            WebHint.ShowRight(ErrMsg, retrunUrl, otherInfo);
        }
    }
}

