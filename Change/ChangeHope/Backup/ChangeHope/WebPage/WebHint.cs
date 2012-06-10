namespace ChangeHope.WebPage
{
    using ChangeHope.Common;
    using System;
    using System.Web;

    public class WebHint
    {
        internal static void PageRender(string Msg, string returnUrl, bool Succeed, string otherInfo)
        {
            string str = ServerInfo.GetRootURI() + "/sysImages/";
            string str2 = "操作结果!";
            string str4 = "<img src=\"../images/success.gif\" border=\"0\">";
            string str5 = "<font color=\"red\">恭喜！操作成功</font>";
            if (!Succeed)
            {
                str2 = "操作失败信息";
                str4 = "<img src=\"../images/error.gif\" border=\"0\">";
                str5 = "<font color=\"red\">抱歉！操作失败</font>";
            }
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r<head>\r");
            HttpContext.Current.Response.Write("<title>" + str2 + " Inc.</title>\r");
            HttpContext.Current.Response.Write("<link href=\"" + ServerInfo.GetRootURI() + "/admin/style/prompt.css\" rel=\"stylesheet\" type=\"text/css\" />\r");
            HttpContext.Current.Response.Write("<script src=\"" + ServerInfo.GetRootURI() + "/scripts/Prototype.js\" language=\"javascript\" type=\"text/javascript\"></script>\r");
            HttpContext.Current.Response.Write("<script src=\"" + ServerInfo.GetRootURI() + "/configuration/js/Public.js\" language=\"javascript\" type=\"text/javascript\"></script>\r");
            HttpContext.Current.Response.Write("<script language=\"JavaScript\">\r");
            HttpContext.Current.Response.Write("<!--\r");
            HttpContext.Current.Response.Write("var seconds = 5;\r");
            HttpContext.Current.Response.Write("var defaultUrl = \"" + returnUrl + "\";\r");
            HttpContext.Current.Response.Write("onload = function()\r");
            HttpContext.Current.Response.Write("{\r");
            HttpContext.Current.Response.Write("if (defaultUrl == 'javascript:history.go(-1)' && window.history.length == 0)\r");
            HttpContext.Current.Response.Write("{\r");
            HttpContext.Current.Response.Write(" document.getElementById('redirectionMsg').innerHTML = '';\r");
            HttpContext.Current.Response.Write("return;\r");
            HttpContext.Current.Response.Write(" }\r");
            HttpContext.Current.Response.Write("window.setInterval(redirection, 1000);\r");
            HttpContext.Current.Response.Write("}\r");
            HttpContext.Current.Response.Write("function redirection()\r");
            HttpContext.Current.Response.Write("{\r");
            HttpContext.Current.Response.Write("if (seconds <= 0)\r");
            HttpContext.Current.Response.Write("{\r");
            HttpContext.Current.Response.Write("window.clearInterval();\r");
            HttpContext.Current.Response.Write("return;\r");
            HttpContext.Current.Response.Write("}\r");
            HttpContext.Current.Response.Write("seconds --;\r");
            HttpContext.Current.Response.Write("document.getElementById('spanSeconds').innerHTML = seconds;\r");
            HttpContext.Current.Response.Write("if (seconds == 0)\r");
            HttpContext.Current.Response.Write("{\r");
            HttpContext.Current.Response.Write("window.clearInterval();\r");
            HttpContext.Current.Response.Write("location.href = defaultUrl;\r");
            HttpContext.Current.Response.Write("}\r");
            HttpContext.Current.Response.Write("}\r");
            HttpContext.Current.Response.Write("//-->\r");
            HttpContext.Current.Response.Write("</script>\r");
            HttpContext.Current.Response.Write("\r</head>\r");
            HttpContext.Current.Response.Write("<body style=\"font-size:12px;\">\r");
            HttpContext.Current.Response.Write("    <table style=\"width:100%;height:180px;background-color:#F3F3F3;border:solid #B4C9C6 1px\"  border=\"0\" align=\"center\" cellspacing=\"0\" cellpadding=\"0\" class=\"table\">\r   <tr class=\"TR_BG\"><td class=\"sysmain_navi\" style=\"height:30px;font-size:14px; font-weight:bold; padding:2px\" colspan=\"2\">" + str5 + "</td>\r");
            HttpContext.Current.Response.Write("</tr><tr class=\"TR_BG_list\"><td class=\"list_link\" align=\"center\" style=\"width:20%;background-color:#FFF\">" + str4 + "<br /><br /></td><td class=\"list_link\" style='background-color:#FFF'><font color=red>操作描述：</font>\r");
            HttpContext.Current.Response.Write("    <ul>\r");
            HttpContext.Current.Response.Write("        <li id=\"redirectionMsg\"><span style=\"word-wrap:bread-word;word-break:break-all;font-size:12px;\">如果您不做出选择，将在<span id=\"spanSeconds\" style='color:red;'>5</span> 秒后跳转到第一个链接地址。</span></li>\r ");
            HttpContext.Current.Response.Write("        <li><span style=\"word-wrap:bread-word;word-break:break-all;font-size:12px;\">" + Msg + "</span></li>\r         " + otherInfo + "<li>" + UserUrl(returnUrl) + "</li>\r");
            HttpContext.Current.Response.Write("     </ul></td></tr>\r    </table>\r");
            HttpContext.Current.Response.Write("</body>\r</html>\r");
            HttpContext.Current.Response.End();
        }

        public static void ShowError(string ErrMsg, string returnUrl, string otherInfo)
        {
            PageRender(ErrMsg, returnUrl, false, otherInfo);
        }

        internal static void ShowRight(string RightMsg, string returnUrl, string otherInfo)
        {
            PageRender(RightMsg, returnUrl, true, otherInfo);
        }

        private static string UserUrl(string StrUrl)
        {
            if ((StrUrl.Trim() != string.Empty) && (StrUrl.Trim().Length > 5))
            {
                StrUrl = "<a href=\"" + StrUrl + "\"  ><font color=\"red\">返回管理</font></a>";
            }
            return StrUrl;
        }
    }
}

