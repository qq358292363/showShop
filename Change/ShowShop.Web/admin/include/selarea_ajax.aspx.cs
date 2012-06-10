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
using System.Data.SqlClient;

namespace ShowShop.Web.admin.include
{
    public partial class selarea_ajax : System.Web.UI.Page
    {
        ShowShop.BLL.SystemInfo.Provinces bll = new ShowShop.BLL.SystemInfo.Provinces();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.CacheControl = "no-cache";
                Response.Expires = 0;
                AreaList.InnerHtml = areastr();
            }
        }

        string areastr()
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
            DataTable dr =bll.GetChid(ParentId);
            for(int i=0;i<dr.Rows.Count;i++)
            {
                DataTable drs = bll.GetChid(dr.Rows[i]["Id"].ToString());
                if (drs.Rows.Count>0)
                {
                    liststr += "<div><img src=\"../../Admin/images/p.gif\" alt=\"点击展开子栏目\"  border=\"0\" class=\"LableItem\" onClick=\"javascript:SwitchImg(this,'" + dr.Rows[i]["Id"].ToString() + "');\" />&nbsp;<span id=\"" + dr.Rows[i]["Id"].ToString() + "\" class=\"LableItem\" ondblclick=\"ReturnValue();\" onClick=\"SelectLable(this);sFiles('" + dr.Rows[i]["Id"].ToString() + "','" + dr.Rows[i]["CityName"].ToString() + "');\">" + dr.Rows[i]["CityName"].ToString() + "</span><div id=\"Parent" + dr.Rows[i]["Id"].ToString() + "\" class=\"SubItem\" HasSub=\"True\" style=\"height:100%;display:none;\"></div></div>";
                }
                else
                {
                    liststr += "<div><img src=\"../../Admin/images/s.gif\" alt=\"没有子栏目\"  border=\"0\" class=\"LableItem\" />&nbsp;<span id=\"" + dr.Rows[i]["Id"].ToString() + "\" class=\"LableItem\" ondblclick=\"ReturnValue();\" onClick=\"SelectLable(this);sFiles('" + dr.Rows[i]["Id"].ToString() + "','" + dr.Rows[i]["CityName"].ToString() + "');\">" + dr.Rows[i]["CityName"].ToString() + "</span></div>";
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