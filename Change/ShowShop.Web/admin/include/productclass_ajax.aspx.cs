using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

namespace ShowShop.Web.admin.include
{
    public partial class productclass_ajax : System.Web.UI.Page
    {
        ShowShop.BLL.Product.Productclass bll = new ShowShop.BLL.Product.Productclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.CacheControl = "no-cache";
                Response.Expires = 0;
                ProList.InnerHtml = newsstr();
            }
        }

        string newsstr()
        {
            string ParentId = Request.QueryString["ParentId"];
            if (ParentId == "" || ParentId == null)
            {
                ParentId = "0";
            }
            else
            {
                ParentId = ParentId.ToString();
            }
            string liststr = string.Empty;

            DataTable dt = bll.GetFatherList(Convert.ToInt32(ParentId));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dt2 = bll.GetFatherList(Convert.ToInt32(dt.Rows[i]["cid"].ToString()));
                if (dt2.Rows.Count > 0)
                {
                    liststr += "<div><img src=\"../../admin/images/p.gif\" alt=\"点击展开子栏目\"  border=\"0\" class=\"LableItem\" onClick=\"javascript:SwitchImg(this,'" + dt.Rows[i]["cid"].ToString() + "');" +
                       " \" />&nbsp;<span id=\"" + dt.Rows[i]["cid"].ToString() + "\" class=\"LableItem\" ondblclick=\"ReturnValue();\" onClick=\"SelectLable(this);sFiles('" + dt.Rows[i]["cid"].ToString() + "','" + dt.Rows[i]["name"].ToString() + "');\">" + dt.Rows[i]["name"].ToString() + "</span><div id=\"Parent" + dt.Rows[i]["cid"].ToString() + "\" class=\"SubItem\" HasSub=\"True\" style=\"height:100%;display:none;\"></div></div>";
                }
                else
                {
                    liststr += "<div><img src=\"../../admin/images/s.gif\" alt=\"没有子栏目\"  border=\"0\" class=\"LableItem\" />&nbsp;<span id=\"" + dt.Rows[i]["cid"].ToString() + "\" class=\"LableItem\" ondblclick=\"ReturnValue();\" onClick=\"SelectLable(this);sFiles('" + dt.Rows[i]["cid"].ToString() + "','" + dt.Rows[i]["name"].ToString() + "');\">" + dt.Rows[i]["name"].ToString() + "</span></div>";
                }

            }

            if (liststr != string.Empty)
                liststr = "Succee|||" + ParentId + "|||" + liststr;
            else
                liststr = "Fail|||" + ParentId + "|||";
            return liststr;
        }
    }
}
