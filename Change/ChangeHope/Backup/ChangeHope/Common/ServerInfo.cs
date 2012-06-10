namespace ChangeHope.Common
{
    using System;
    using System.Configuration;
    using System.Text.RegularExpressions;
    using System.Web;

    public class ServerInfo
    {
        public static string GetAppPath()
        {
            if (HttpContext.Current.Request.ApplicationPath == "/")
            {
                return string.Empty;
            }
            return HttpContext.Current.Request.ApplicationPath;
        }

        public static string GetDataTablePrefix()
        {
            return ConfigurationSettings.AppSettings["DataTablePrefix"].Trim();
        }

        public static string GetRootPath()
        {
            string input = "";
            HttpContext current = HttpContext.Current;
            if (current != null)
            {
                return current.Server.MapPath("~");
            }
            input = AppDomain.CurrentDomain.BaseDirectory;
            if (Regex.Match(input, @"\\$", RegexOptions.Compiled).Success)
            {
                input = input.Substring(0, input.Length - 1);
            }
            return input;
        }

        public static string GetRootURI()
        {
            string str = "";
            HttpContext current = HttpContext.Current;
            if (current == null)
            {
                return str;
            }
            HttpRequest request = current.Request;
            string leftPart = request.Url.GetLeftPart(UriPartial.Authority);
            if ((request.ApplicationPath == null) || (request.ApplicationPath == "/"))
            {
                return leftPart;
            }
            return (leftPart + request.ApplicationPath);
        }

        public static string GetServerPath()
        {
            return HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];
        }

        public static string VersionInformation()
        {
            FileHelper helper = new FileHelper();
            return helper.ReadFileContent(HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"] + "admin/vesion.ini").Trim();
        }
    }
}

