namespace ChangeHope.WebPage
{
    using System;
    using System.Text;
    using System.Web;

    public class Script
    {
        public static void Alert(string message)
        {
            ResponseScript("    alert('" + message + "');");
        }

        public static void AlertAndCloseThisOpenWindow(string message)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("    alert('{0}');\n", message);
            builder.AppendLine("    window.opener.reload();");
            builder.AppendLine("    window.close();");
            ResponseScript(builder.ToString());
        }

        public static void AlertAndGoBack(string message)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("    alert('{0}');\n", message);
            builder.AppendLine("    window.history.back();");
            ResponseScript(builder.ToString());
            HttpContext.Current.Response.End();
        }

        public static void AlertAndRedirect(string message, string url)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("    alert('{0}');\n", message);
            builder.AppendFormat("    window.location.href='{0}'\n", url);
            ResponseScript(builder.ToString());
            HttpContext.Current.Response.End();
        }

        public static void AlertAndReload(string message)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("    alert('{0}');\n", message);
            builder.AppendLine("    window.location.reload();");
            ResponseScript(builder.ToString());
            HttpContext.Current.Response.End();
        }

        public static void GoBack()
        {
            ResponseScript("    window.history.back();");
            HttpContext.Current.Response.End();
        }

        public static void ParentPageRedirect(string url)
        {
            ResponseScript("    parent.location.href='" + url + "';");
            HttpContext.Current.Response.End();
        }

        public static void Redirect(string url)
        {
            HttpContext.Current.Response.Redirect(url);
        }

        public static void ResponseScript(string script)
        {
            HttpContext.Current.Response.Write("<script language=\"javascript\" type=\"text/javascript\" defer>\n" + script + "\n</script>\n");
        }
    }
}

