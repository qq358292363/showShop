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
using ShowShop.BLL.Admin;

namespace ShowShop.Web.admin
{
    public partial class admin_left : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.Page.IsPostBack)
            {
                /*
                if (!AdministrorManager.CheckAdmin())
                {
                    return;
                }*/
                ShowShop.Model.Admin.AdminInfo adminInfo = (ShowShop.Model.Admin.AdminInfo)ShowShop.Common.AdministrorManager.Get();
                if (adminInfo != null)
                {
                    this.ltlAdminUserName.Text = adminInfo.AdminName.ToString();
                }
                else
                {
                    this.ltlAdminUserName.Text = "未知的用户";
                }
            }
        }
    }
}
