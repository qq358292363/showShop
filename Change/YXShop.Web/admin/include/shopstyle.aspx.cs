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

namespace ShowShop.Web.admin.include
{
    public partial class shopstyle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormString("cid") != string.Empty)
            {
                string types = ChangeHope.WebPage.PageRequest.GetFormString("Option");
                string cid = ChangeHope.WebPage.PageRequest.GetFormString("cid");
                if (types == "judge")
                {
                    Response.Write("ok");
                }
                else
                {
                    Response.Write("错误，请联系管理员");
                }
                Response.End();
                return;
            }

        }
    }
}
