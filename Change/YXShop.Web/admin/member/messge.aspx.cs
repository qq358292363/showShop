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

namespace ShowShop.Web.admin.member
{
    public partial class right : System.Web.UI.Page
    {
        protected string Key, Back;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["Key"] != string.Empty)
            {
                Key = Request.QueryString["Key"].ToString();
                Back = Request.UrlReferrer.ToString();
            }
        }
    }
}
