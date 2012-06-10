using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace ShowShop.Web.controls
{
    public partial class cookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowShop.Common.Substation.UpdateCityInfo();
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            Response.Redirect(""+sp.DummyPaht+"default.aspx");
        }
    }
}
