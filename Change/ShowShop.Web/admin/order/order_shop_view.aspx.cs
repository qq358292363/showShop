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

namespace ShowShop.Web.admin.order
{
    public partial class order_shop_view : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetList();
            }
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        private void GetList()
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Order.ShoppingCard data = new ShowShop.BLL.Order.ShoppingCard();
            ChangeHope.DataBase.DataByPage dataPage = data.GetCartProduct(ChangeHope.WebPage.PageRequest.GetString("q_uniqueid"));
            //第一步先添加表头
            table.AddHeadCol("5%", "序号");
            table.AddHeadCol("35%", "商品名称");
            table.AddHeadCol("10%", "购买数量");
            table.AddHeadCol("10%", "单价");
            table.AddHeadCol("25%", "购买时间");
            table.AddHeadCol("10%", "小计");
            //table.AddHeadCol("5%", "操作");
            table.AddRow();
            //添加表的内容
            if (dataPage.DataReader != null)
            {
                string userName = ChangeHope.WebPage.PageRequest.GetString("UserName");
                string userId = string.Empty;
                ShowShop.BLL.Member.MemberAccount mabll = new ShowShop.BLL.Member.MemberAccount();
                ShowShop.Model.Member.MemberAccount mamodel = mabll.GetModel(userName);
                if (mamodel != null)
                {
                    userId = mamodel.UID.ToString();
                }
                int curpage = ChangeHope.WebPage.PageRequest.GetInt("pageindex");
                if (curpage < 0)
                {
                    curpage = 1;
                }
                int count = 0;

               // YXShop.TemplateAction.Common dp = new YXShop.TemplateAction.Common();
                double totalPrice=0;
                while (dataPage.DataReader.Read())
                {
                    double price = 0.0;
                    price = double.Parse(dataPage.DataReader["pro_ShopPrice"].ToString());
                    if (userId != string.Empty)
                    {
                        price =ShowShop.Common.ProductInfo.DiscountedPrice(Convert.ToInt32(userId), price, dataPage.DataReader["pro_RatingDiscount"].ToString());
                    }
                    /*
                     *修改人:ym
                     *修改时间:2009.10.09
                     */
                    int procount = int.Parse(dataPage.DataReader["quantity"].ToString());
                    double total = price * procount;
                    totalPrice+=total;
                    count++;
                    string No = (15 * (curpage - 1) + count).ToString();
                    table.AddCol(No);
                    table.AddCol(string.Format("<a href='" + sp.DummyPaht + "product/productcontent.aspx?q_productid={1}' target=\"_blank\">{0}</a>", dataPage.DataReader["pro_Name"].ToString(), dataPage.DataReader["pro_Id"].ToString()));
                    table.AddCol(dataPage.DataReader["quantity"].ToString());
                    table.AddCol(dataPage.DataReader["pro_ShopPrice"].ToString());
                    table.AddCol(dataPage.DataReader["addtime"].ToString());
                    
                    table.AddCol(total.ToString());
                    table.AddRow();
                }
                this.lbTotal.Text = "本页合计:" + totalPrice;
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            this.ltlList.Text = view;
        }

    }
}
