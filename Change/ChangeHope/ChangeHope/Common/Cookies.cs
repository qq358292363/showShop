namespace ChangeHope.Common
{
    using System;
    using System.Web;

    public class Cookies
    {
        public static string getCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            try
            {
                if (cookie != null)
                {
                    return HttpUtility.UrlDecode(cookie.Values[strValue].ToString());
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static bool setCookie(string strName, string name, double time)
        {
            try
            {
                string s = HttpUtility.UrlEncode(name);
                HttpCookie cookie = new HttpCookie(strName);
                cookie.Expires = DateTime.Now.AddMinutes(time);
                cookie.Values.Add("Value", HttpContext.Current.Server.UrlEncode(s));
                HttpContext.Current.Response.Cookies.Add(cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool updateCookies(string strName, string name, double time)
        {
            bool flag;
            try
            {
                HttpContext.Current.Response.Cookies[strName]["Value"] = name;
                flag = setCookie(strName, name, time);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }
    }
}

