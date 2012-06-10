namespace ChangeHope.WebPage
{
    using ChangeHope.Common;
    using System;
    using System.Collections;
    using System.Web;

    public class PageRequest
    {
        public static int GetFormInt(string para)
        {
            int num = -1;
            string formString = GetFormString(para);
            if (ValidateHelper.IsNumber(formString))
            {
                num = int.Parse(formString);
            }
            return num;
        }

        public static Hashtable GetFormPara()
        {
            int count = HttpContext.Current.Request.Form.Count;
            string key = "";
            string str2 = "";
            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < count; i++)
            {
                key = HttpContext.Current.Request.Form.Keys[i].ToString();
                str2 = HttpContext.Current.Request.Form[i].ToString();
                if (!(((key.IndexOf("w_") < 0) && (key.IndexOf("q_") < 0)) || str2.Equals("")))
                {
                    hashtable.Add(key, str2);
                }
            }
            return hashtable;
        }

        public static string GetFormString(string para)
        {
            string str = "";
            if (HttpContext.Current.Request.Form[para] != null)
            {
                str = HttpContext.Current.Request.Form[para].ToString();
            }
            else
            {
                str = "";
            }
            return StringHelper.InputTexts(str.Trim());
        }

        public static int GetInt(string para)
        {
            string inputData = GetString(para);
            int num = -1;
            if (ValidateHelper.IsNumber(inputData))
            {
                num = int.Parse(inputData);
            }
            return num;
        }

        public static Hashtable GetPara()
        {
            if (HttpContext.Current.Request.RequestType.ToLower().Equals("get"))
            {
                return GetQueryPara();
            }
            return GetFormPara();
        }

        public static int GetQueryInt(string para)
        {
            int num = -1;
            string queryString = GetQueryString(para);
            if (ValidateHelper.IsNumber(queryString))
            {
                num = int.Parse(queryString);
            }
            return num;
        }

        public static Hashtable GetQueryPara()
        {
            int count = HttpContext.Current.Request.QueryString.Count;
            string key = "";
            string str2 = "";
            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < count; i++)
            {
                key = HttpContext.Current.Request.QueryString.Keys[i].ToString();
                str2 = HttpContext.Current.Request.QueryString[i].ToString();
                if (!(((key.IndexOf("w_") < 0) && (key.IndexOf("q_") < 0)) || str2.Equals("")))
                {
                    hashtable.Add(key, str2);
                }
            }
            return hashtable;
        }

        public static string GetQueryString(string para)
        {
            string str = "";
            if (HttpContext.Current.Request.QueryString[para] != null)
            {
                str = HttpContext.Current.Request.QueryString[para].ToString();
            }
            else
            {
                str = "";
            }
            return StringHelper.InputTexts(str.Trim());
        }

        public static string GetString(string para)
        {
            if (HttpContext.Current.Request.RequestType.ToLower().Equals("get"))
            {
                return GetQueryString(para);
            }
            return GetFormString(para);
        }
    }
}

