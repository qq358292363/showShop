namespace ChangeHope.Common
{
    using System;
    using System.Net;
    using System.Web;
    using System.Xml;

    public class TaoBaoAPI
    {
        private string _sessionID;
        public const string VERSION = "1.0";

        public TaoBaoAPI()
        {
        }

        public TaoBaoAPI(string sessionID)
        {
            this._sessionID = sessionID;
        }

        public HttpWebResponse taobao_itemcats_get_v2(string parent_cid, string cids, string fields)
        {
            TaoBaoUtil.ParamsBuild build = new TaoBaoUtil.ParamsBuild(this.SessionID, "taobao.itemcats.get.v2");
            if ((parent_cid.Length != 0) || (cids.Length != 0))
            {
                if (parent_cid != "")
                {
                    build.AddParam("parent_cid", parent_cid);
                }
                if (cids != "")
                {
                    build.AddParam("cids", cids);
                }
            }
            build.AddParam("fields", fields);
            build.AddParam("v", "1.0");
            return TaoBaoUtil.HttpRequest3(build.GetURL());
        }

        public XmlDocument taobao_items_get(string q, string fields, int page_no, int page_size, string nicks)
        {
            TaoBaoUtil.ParamsBuild build = new TaoBaoUtil.ParamsBuild(this.SessionID, "taobao.items.get");
            build.AddParam("fields", fields);
            build.AddParam("v", "1.0");
            if (q != string.Empty)
            {
                build.AddParam("q", q);
            }
            if (page_no != 0)
            {
                build.AddParam("page_no", page_no);
            }
            if (page_size != 0)
            {
                build.AddParam("page_size", page_size);
            }
            build.AddParam("nicks", nicks);
            return TaoBaoUtil.HttpRequest(build.GetURL());
        }

        public string taobao_items_get2(string q, string fields, int page_no, int page_size, string nicks)
        {
            TaoBaoUtil.ParamsBuild build = new TaoBaoUtil.ParamsBuild(this.SessionID, "taobao.items.get");
            build.AddParam("fields", fields);
            build.AddParam("v", "1.0");
            if (q != string.Empty)
            {
                build.AddParam("q", q);
            }
            if (page_no != 0)
            {
                build.AddParam("page_no", page_no);
            }
            if (page_size != 0)
            {
                build.AddParam("page_size", page_size);
            }
            build.AddParam("nicks", nicks);
            return TaoBaoUtil.HttpRequest2(build.GetURL());
        }

        public HttpWebResponse taobao_items_onsale_get(string q, string fields, int page_no, int page_size, bool has_discount, bool has_showcase, string orderby, string cid, string seller_cids)
        {
            TaoBaoUtil.ParamsBuild build = new TaoBaoUtil.ParamsBuild(this.SessionID, "taobao.items.onsale.get");
            build.AddParam("fields", fields);
            build.AddParam("v", "1.0");
            if (q != string.Empty)
            {
                build.AddParam("q", q);
            }
            if (page_no != 0)
            {
                build.AddParam("page_no", page_no);
            }
            if (page_size != 0)
            {
                build.AddParam("page_size", page_size);
            }
            if (has_discount)
            {
                build.AddParam("has_discount", "true");
            }
            if (has_showcase)
            {
                build.AddParam("has_showcase", "true");
            }
            if (orderby.Length != 0)
            {
                build.AddParam("order_by", orderby);
            }
            if (cid.Length != 0)
            {
                build.AddParam("cid", cid);
            }
            if (seller_cids.Length != 0)
            {
                build.AddParam("seller_cids", seller_cids);
            }
            return TaoBaoUtil.HttpRequest3(build.GetURL());
        }

        public HttpWebResponse taobao_items_single_get(string fields, string productId, string nicks)
        {
            TaoBaoUtil.ParamsBuild build = new TaoBaoUtil.ParamsBuild(this.SessionID, "taobao.item.get");
            build.AddParam("fields", fields);
            build.AddParam("iid", productId);
            build.AddParam("nick", nicks);
            build.AddParam("v", "1.0");
            return TaoBaoUtil.HttpRequest3(build.GetURL());
        }

        public XmlDocument taobao_shop_get(string fields, string nicks)
        {
            TaoBaoUtil.ParamsBuild build = new TaoBaoUtil.ParamsBuild(this.SessionID, "taobao.shop.get");
            build.AddParam("fields", fields);
            build.AddParam("v", "1.0");
            build.AddParam("nick", nicks);
            return TaoBaoUtil.HttpRequest(build.GetURL());
        }

        public XmlDocument taobao_shop_update(string _title, string _bulletin, string _desc)
        {
            TaoBaoUtil.ParamsBuild build = new TaoBaoUtil.ParamsBuild(this.SessionID, "taobao.shop.update");
            build.AddParam("title", _title);
            build.AddParam("v", "1.0");
            build.AddParam("bulletin", _bulletin);
            build.AddParam("desc", _desc);
            return TaoBaoUtil.HttpRequest(build.GetURL());
        }

        public string SessionID
        {
            get
            {
                if (string.IsNullOrEmpty(HttpContext.Current.Session["sip_sessionid"].ToString()))
                {
                    HttpContext.Current.Session["sip_sessionid"] = Guid.NewGuid().ToString();
                }
                return HttpContext.Current.Session["sip_sessionid"].ToString();
            }
        }
    }
}

