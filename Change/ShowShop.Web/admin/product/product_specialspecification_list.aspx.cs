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
using System.Text.RegularExpressions;

namespace ShowShop.Web.admin.product
{
    public partial class product_specialspecification_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int productId = ChangeHope.WebPage.PageRequest.GetQueryInt("id");
                int productPutoutType = ChangeHope.WebPage.PageRequest.GetQueryInt("putoutType");
                this.HyperLink2.NavigateUrl = "product_list.aspx?q_PutoutType=" + productPutoutType;
                this.BindList(productId);
            }
        }

        protected void BindList(int ProductId)
        {
            ShowShop.BLL.Product.ProductInfo bll = new ShowShop.BLL.Product.ProductInfo();
            ShowShop.Model.Product.ProductInfo modle = bll.GetModel(ProductId);
            if (modle != null)
            {
               // if (!string.IsNullOrEmpty(modle.pro_Specialspecifications))
                {
                    Regex productSpe = new Regex(@"s_spacebar");
                 //   string[] specifiactionVa = productSpe.Split(modle.pro_Specialspecifications);
                    ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
                    //第一步先添加表头
                    table.AddHeadCol("5%", "序号");
                    table.AddHeadCol("75%", "规格值");
                    table.AddHeadCol("20%", "操作");
                    table.AddRow();
                    //添加表的内容
                    //if (!string.IsNullOrEmpty(specifiactionVa[1]))
                    //{
                    //    this.Spec.Text = specifiactionVa[0];
                    //    int curpage = ChangeHope.WebPage.PageRequest.GetInt("pageindex");
                    //    if (curpage < 0)
                    //    {
                    //        curpage = 1;
                    //    }
                    //    int count = 0;
                    //    string[] spval = specifiactionVa[1].Replace("\r\n",",").Split(',');
                    //    for (int i = 0; i < spval.Length; i++)
                    //    {
                    //        count++;
                    //        string No = (15 * (curpage - 1) + count).ToString();
                    //        table.AddCol(No);
                    //        table.AddCol(spval[i]);
                    //        table.AddCol(string.Format("<a href=product_specialspecification.aspx?productId={0}&id={1}&val={2}&spec={3}>编辑</a>", ProductId, i, spval[i], specifiactionVa[0]));

                    //        table.AddRow();
                    //    }
                    //}
                    string view = table.GetTable();
                    this.Literal1.Text = view;
                }
            }
        }
    }
}
