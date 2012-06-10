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

namespace ShowShop.Web.admin.plugin
{
    public partial class getcity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.Page.IsPostBack)
            {
                ShowShop.BLL.SystemInfo.Provinces bll = new ShowShop.BLL.SystemInfo.Provinces();
                int parentid = ChangeHope.WebPage.PageRequest.GetQueryInt("parentid");
                if (parentid<0)
                {
                    parentid = 0;
                }
                Response.Write(bll.GetChidNode(parentid.ToString()));
            }
        }
    }
}
