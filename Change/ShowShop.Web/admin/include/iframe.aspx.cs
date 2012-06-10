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
    public partial class iframe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.CacheControl = "no-cache";
            }
            string sh = Request.QueryString["heights"];
            string wd = Request.QueryString["widths"];
            select_iframe.InnerHtml = select_iframelist(sh, wd);
        }
        string select_iframelist(string sh, string wd)
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            string liststr = "";
            string srcstr = "";
            string rq = Request.QueryString["FileType"];
            string arrrq = rq.Split('|')[0];
            switch (arrrq)
            {
                case "Product_info_class":
                    srcstr = sp.DummyPaht + "admin/include/product_info_class.aspx";
                    break;
                case "Productclass":
                    srcstr = sp.DummyPaht + "admin/include/productclass.aspx";
                    break;
                case "Label_Url_Productclass":
                    srcstr = sp.DummyPaht + "admin/include/label_url_productclass.aspx";
                    break;
                case "productclassone":
                    srcstr = sp.DummyPaht + "admin/include/productclassone.aspx";
                    break;
                case "Random_Productclass"://随意选择分类
                    srcstr = sp.DummyPaht + "admin/include/sel_productclass.aspx";
                    break;
                case "Area":
                    srcstr = sp.DummyPaht + "admin/include/selarea.aspx";
                    break;
                case "Product":
                    srcstr = sp.DummyPaht + "admin/include/selproductinfo.aspx?w_s_pro_Designation=1";
                    break;
                case "OrderCardProduct":
                    srcstr = sp.DummyPaht + "admin/include/selproductinfo.aspx?w_s_pro_Designation=7";
                    break;
                case "integratepurchasProduct":
                    srcstr = sp.DummyPaht + "admin/include/selproductinfo.aspx?w_s_pro_Designation=3";
                    break;
                case "AuctionProduct":
                    srcstr = sp.DummyPaht + "admin/include/selproductinfo.aspx?w_s_pro_Designation=5";
                    break;
                case "Memberlist":
                    srcstr = sp.DummyPaht + "admin/include/memberlist.aspx";
                    break;
                case "ShopStyle":
                    srcstr = sp.DummyPaht + "admin/include/shopstyle.aspx";
                    break;
                default:
                    break;
            }
            liststr += "<iframe src=\"" + srcstr + "\" frameborder=\"0\" id=\"select_main\" scrolling=\"yes\" name=\"select_main\" width=\""+wd+"px\" height=\"" + sh + "px\" />";
            
            return liststr;
        }
    }
}

