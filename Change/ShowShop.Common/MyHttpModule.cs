using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Web.Caching;

namespace ShowShop.Common
{
    public class MyHttpModule : IHttpModule
    {
        public void Init(HttpApplication app)
        {
            app.AuthorizeRequest += new EventHandler(app_AuthorizeRequest);
        }

        public void Dispose() { }

        protected void Rewrite(string requestedPath, System.Web.HttpApplication app)
        {
            foreach (URLRewrite url in SiteUrls.GetSiteUrls().Urls)
            {
                if (Regex.IsMatch(app.Context.Request.Path, url.Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase))
                {
                    app.Context.RewritePath(url.Page, string.Empty, Regex.Replace(app.Context.Request.Path, url.Pattern, url.QueryString, RegexOptions.Compiled | RegexOptions.IgnoreCase));
                    return;
                }
            }
            if (app.Context.Request.Path.ToLower().EndsWith(".shtml"))
            {
                app.Context.Response.Redirect("~/index.html");
            }
        }

        private void app_AuthorizeRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            Rewrite(app.Request.Path, app);
        }
    }

    public class SiteUrls
    {
        #region 内部属性和方法
        string SiteUrlsFile = HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["SiteUrls"]);
        private ArrayList _Urls;
        public ArrayList Urls
        {
            get
            {
                return _Urls;
            }
            set
            {
                _Urls = value;
            }
        }

        private NameValueCollection _Paths;
        public NameValueCollection Paths
        {
            get
            {
                return _Paths;
            }
            set
            {
                _Paths = value;
            }
        }

        private SiteUrls()
        {
            string applicationPath = HttpContext.Current.Request.ApplicationPath;

            if (applicationPath == "/")
            {
                applicationPath = string.Empty;
            }

            Urls = new ArrayList();
            Paths = new NameValueCollection();
            Paths.Add("home", applicationPath);

            XmlDocument xml = new XmlDocument();

            xml.Load(SiteUrlsFile);

            XmlNode root = xml.SelectSingleNode("SiteUrls");
            foreach (XmlNode n in root.ChildNodes)
            {
                if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "rewrite")
                {
                    XmlAttribute name = n.Attributes["name"];
                    XmlAttribute path = n.Attributes["path"];
                    XmlAttribute page = n.Attributes["page"];
                    XmlAttribute querystring = n.Attributes["querystring"];
                    XmlAttribute pattern = n.Attributes["pattern"];

                    if (name != null && path != null && page != null && querystring != null && pattern != null)
                    {
                        Paths.Add(name.Value, applicationPath + path.Value);
                        Urls.Add(new URLRewrite(name.Value, Paths["home"] + pattern.Value, Paths["home"] + page.Value.Replace("^", "&"), querystring.Value.Replace("^", "&")));
                    }
                }
            }
        }
        #endregion

        public static SiteUrls GetSiteUrls()
        {
            string CacheKey = "SiteUrls";
            SiteUrls urls = System.Web.HttpContext.Current.Cache["SiteUrls"] as SiteUrls;
            if (urls == null)
            {
                urls = new SiteUrls();
                System.Web.HttpContext.Current.Cache.Insert(CacheKey, urls, new CacheDependency(urls.SiteUrlsFile), DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.High, null);
            }

            return urls;
        }

        /// <summary>
        /// 输出URL示例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Show(int id)
        {
            return string.Format(Paths["Show"], id);
        }
    }
    public class URLRewrite
    {
        #region 成员变量
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        private string _Pattern;
        public string Pattern
        {
            get
            {
                return _Pattern;
            }
            set
            {
                _Pattern = value;
            }
        }

        private string _Page;
        public string Page
        {
            get
            {
                return _Page;
            }
            set
            {
                _Page = value;
            }
        }

        private string _QueryString;
        public string QueryString
        {
            get
            {
                return _QueryString;
            }
            set
            {
                _QueryString = value;
            }
        }
        #endregion
        #region 构造函数
        public URLRewrite(string name, string pattern, string page, string querystring)
        {
            _Name = name;
            _Pattern = pattern;
            _Page = page;
            _QueryString = querystring;
        }
        #endregion
    }

    public class PageBase : Page
    {
        //// <summary>
        ///  重写默认的HtmlTextWriter方法，修改form标记中的value属性，使其值为重写的URL而不是真实URL。
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {

            if (writer is System.Web.UI.Html32TextWriter)
            {
                writer = new FormFixerHtml32TextWriter(writer.InnerWriter);
            }
            else
            {
                writer = new FormFixerHtmlTextWriter(writer.InnerWriter);
            }

            base.Render(writer);
        }
    }

    internal class FormFixerHtml32TextWriter : System.Web.UI.Html32TextWriter
    {
        private string _url; // 假的URL

        internal FormFixerHtml32TextWriter(TextWriter writer)
            : base(writer)
        {
            _url = HttpContext.Current.Request.RawUrl;
        }

        public override void WriteAttribute(string name, string value, bool encode)
        {
            // 如果当前输出的属性为form标记的action属性，则将其值替换为重写后的虚假URL
            if (_url != null && string.Compare(name, "action", true) == 0)
            {
                value = _url;

            }
            base.WriteAttribute(name, value, encode);
        }
    }
    internal class FormFixerHtmlTextWriter : System.Web.UI.HtmlTextWriter
    {
        private string _url;
        internal FormFixerHtmlTextWriter(TextWriter writer)
            : base(writer)
        {
            _url = HttpContext.Current.Request.RawUrl;
        }

        public override void WriteAttribute(string name, string value, bool encode)
        {
            if (_url != null && string.Compare(name, "action", true) == 0)
            {
                value = _url;
            }

            base.WriteAttribute(name, value, encode);
        }
    }
}

