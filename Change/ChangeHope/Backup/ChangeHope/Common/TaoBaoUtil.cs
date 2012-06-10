namespace ChangeHope.Common
{
    using System;
    using System.Collections;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using System.Xml;

    public class TaoBaoUtil
    {
        public static string getDomainLoginId(string appId, string appUserId)
        {
            ParamsBuild build = new ParamsBuild(GetCode);
            build.AddParam("sip_appkey", appId);
            build.AddParam("sip_apiname", "alisoft.udb.getDomainLoginId");
            build.AddParam("sip_timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            build.AddParam("domainid", "1");
            build.AddParam("userid", appUserId);
            XmlDocument document = HttpRequest(build.GetURL());
            XmlNode node = document.SelectSingleNode("StringResult/code");
            XmlNode node2 = document.SelectSingleNode("StringResult/result");
            if (node.InnerText != "0")
            {
                return appUserId;
            }
            return node2.InnerText;
        }

        public static XmlDocument HttpRequest(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            string requestUriString = ConfigurationManager.AppSettings["APPURL"];
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(requestUriString);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            string xml = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            XmlNode node = document.SelectSingleNode("/error_rsp/code");
            if ((node != null) && (node.InnerText != string.Empty))
            {
            }
            return document;
        }

        public static string HttpRequest(string data, string xPath)
        {
            return HttpRequest(data).SelectSingleNode(xPath).InnerText;
        }

        public static string HttpRequest2(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            string requestUriString = ConfigurationManager.AppSettings["APPURL"];
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(requestUriString);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            return reader.ReadToEnd();
        }

        public static HttpWebResponse HttpRequest3(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            string requestUriString = ConfigurationManager.AppSettings["APPURL"];
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(requestUriString);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            return (HttpWebResponse) request.GetResponse();
        }

        public static HttpWebResponse HttpRequest4(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            string requestUriString = ConfigurationManager.AppSettings["APPURL"];
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(requestUriString);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            return (HttpWebResponse) request.GetResponse();
        }

        public static HttpWebResponse HttpRequest5(string data, byte[] image, string uploadfile, string fileFormName, string contenttype)
        {
            string str = ConfigurationManager.AppSettings["APPURL"];
            Uri requestUri = new Uri(str + data);
            string str2 = "----------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(requestUri);
            request.ContentType = "text/plain";
            request.Method = "POST";
            if ((uploadfile != null) && (uploadfile.Length > 0))
            {
                request.ContentType = "multipart/form-data; boundary=" + str2;
                StringBuilder builder = new StringBuilder();
                builder.Append("--");
                builder.Append(str2);
                builder.Append("\r\n");
                builder.Append("Content-Disposition: form-data; name=\"");
                builder.Append(fileFormName);
                builder.Append("\"; filename=\"");
                builder.Append("test.jpg");
                builder.Append("\"");
                builder.Append("\r\n");
                builder.Append("Content-Type: ");
                builder.Append(contenttype);
                builder.Append("\r\n");
                builder.Append("\r\n");
                string s = builder.ToString();
                byte[] bytes = Encoding.UTF8.GetBytes(s);
                byte[] buffer = Encoding.ASCII.GetBytes("\r\n--" + str2 + "--\r\n");
                long num = (bytes.Length + image.Length) + buffer.Length;
                request.ContentLength = num;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Write(image, 0, image.Length);
                requestStream.Write(buffer, 0, buffer.Length);
            }
            return (HttpWebResponse) request.GetResponse();
        }

        public static string MD5(string data)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            return BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(data))).Replace("-", "");
        }

        public static string GetAppID
        {
            get
            {
                return ConfigurationManager.AppSettings["AppID"];
            }
        }

        public static string GetCode
        {
            get
            {
                return ConfigurationManager.AppSettings["AppCode"];
            }
        }

        public class ParamsBuild
        {
            private SortedList _mySL;
            [CompilerGenerated]
            private string <_code>k__BackingField;

            public ParamsBuild() : this(TaoBaoUtil.GetCode)
            {
            }

            public ParamsBuild(string code)
            {
                this._mySL = new SortedList();
                this._code = code;
            }

            public ParamsBuild(string sip_sessionid, string apiName) : this(TaoBaoUtil.GetCode)
            {
                this.AddParam("sip_appkey", TaoBaoUtil.GetAppID);
                this.AddParam("sip_apiname", apiName);
                this.AddParam("sip_timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                this.AddParam("sip_sessionid", sip_sessionid);
            }

            public ParamsBuild(HttpContext content, string apiName) : this(content.Session.SessionID, apiName)
            {
            }

            public void AddParam(string name, int value)
            {
                this._mySL.Add(name, value);
            }

            public void AddParam(string name, string value)
            {
                this._mySL.Add(name, value);
            }

            public string GetSign()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(TaoBaoUtil.GetCode);
                StringBuilder builder2 = new StringBuilder();
                foreach (DictionaryEntry entry in this._mySL)
                {
                    builder.Append(entry.Key.ToString());
                    if (entry.Value != null)
                    {
                        builder.Append(entry.Value.ToString());
                    }
                }
                return TaoBaoUtil.MD5(builder.ToString());
            }

            public string GetURL()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(this._code);
                StringBuilder builder2 = new StringBuilder();
                foreach (DictionaryEntry entry in this._mySL)
                {
                    builder.Append(entry.Key.ToString());
                    if (entry.Value != null)
                    {
                        builder.Append(entry.Value.ToString());
                    }
                    builder2.AppendFormat("{0}={1}&", entry.Key, entry.Value);
                }
                builder2.AppendFormat("sip_sign={0}", TaoBaoUtil.MD5(builder.ToString()));
                return builder2.ToString();
            }

            private string _code
            {
                [CompilerGenerated]
                get
                {
                    return this.<_code>k__BackingField;
                }
                [CompilerGenerated]
                set
                {
                    this.<_code>k__BackingField = value;
                }
            }
        }
    }
}

