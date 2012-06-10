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
    public partial class productclass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormString("cid") != string.Empty)
                {
                    string types = ChangeHope.WebPage.PageRequest.GetFormString("Option");
                    string cid = ChangeHope.WebPage.PageRequest.GetFormString("cid");
                    if (types == "judge")
                    {
                        this.Judge(cid);
                    }
                    Response.End();
                    return;
                }
            }
        }
        private void Judge(string cid)
        {
            ShowShop.BLL.Product.Productclass probll = new ShowShop.BLL.Product.Productclass();
            DataTable dt = probll.GetFatherList(int.Parse(cid));
            if (dt.Rows.Count > 0)
            {
                Response.Write("该子类下还存在分类,请选择下级分类!");
            }
            else
            {
                Response.Write("ok");
            }
        }
    }
}
