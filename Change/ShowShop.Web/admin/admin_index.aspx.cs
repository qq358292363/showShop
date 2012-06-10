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

namespace ShowShop.Web.admin
{
    public partial class admin_index : System.Web.UI.Page
    {
        protected string WebName;
        protected string WebTitle;
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = "000001";
            int b = Convert.ToInt32(a);
            int i=99999;
            //string a ="2012" +i.ToString("00000");
            if (!IsPostBack)
            {
              ShowShop.Common.AdministrorManager.CheckAdmin();
              ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
              WebName = sp.WebSiteName;
              WebTitle = sp.WebSiteTitle;
            }
        }
    }
}
