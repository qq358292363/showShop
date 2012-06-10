using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace ShowShop.Web.admin.order
{
    public partial class order_order_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormString("id") != "")
            {
                string types = Request["Option"].Trim();
                string id = ChangeHope.WebPage.PageRequest.GetFormString("id");
                if (types == "del")
                {
                    if (ShowShop.Common.PromptInfo.Message("005001003") != "ok")
                    {
                        ShowShop.BLL.Order.Orders bll = new ShowShop.BLL.Order.Orders();
                        bll.Delete(id);
                    }
                    else
                    {
                        Response.Write("no");
                    }
                }
            }
            if(!this.Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("005001001");
                GetList();
                InitWebControls();
            }
        }

        private void InitWebControls()
        {
            ChangeHope.WebPage.WebControl.SetDate(this.w_g_OrderDate);
            this.Form.Attributes.Add("onsubmit", "return CheckForm();");
        }

        private void GetList()
        {
            ShowShop.BLL.Order.Orders bll = new ShowShop.BLL.Order.Orders();
            ChangeHope.DataBase.DataByPage datapage = bll.GetListByPage("");
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.Common.OrdersStatusEnum ose = new ShowShop.Common.OrdersStatusEnum();
            table.AddHead("<input type=\"checkbox\"  id=\"cheAll\" onclick=\"SelectAll(cheAll)\"/>/,订单号/,用户名/,下单时间/,商品金额/,<img src=\"..\\images\\notice.gif\" title=\"订单金额=商品总价+运费+支付手续费\" >订单金额/,订单状态/,付款状态/,物流状态/");

            int index = 0;
            if(datapage.DataReader!=null)
            {
                while(datapage.DataReader.Read())
                {
                    index++;
                    table.AddCol(string.Format("<input type=\"checkbox\" name=\"checkboxid\" value=\"{0}\">", datapage.DataReader["Id"].ToString()));
                    string TypeStr = string.Empty;
                    if (datapage.DataReader["OrderType"].ToString() == "1")
                    {
                        TypeStr = "<span style='color:red'>拍</span>";
                    }
                    else if (datapage.DataReader["OrderType"].ToString() == "2")
                    {
                        TypeStr = "<span style='color:red'>团</span>";
                    }
                    table.AddCol(TypeStr + "<a href='order_order_info.aspx?OrderId=" + datapage.DataReader["Id"].ToString() + "'>" + datapage.DataReader["OrderId"].ToString() + "</a>");
                    table.AddCol("<span title='" + datapage.DataReader["UserId"].ToString() + "'>" + ChangeHope.Common.StringHelper.SubString(datapage.DataReader["UserId"].ToString(), 10) + "</span>");
                    table.AddCol(datapage.DataReader["OrderDate"].ToString());
                    table.AddCol("￥" + Convert.ToDouble(datapage.DataReader["TotalPrice"].ToString()).ToString("f2") + " 元");
                    table.AddCol("￥" + Convert.ToDouble(datapage.DataReader["FactPrice"].ToString()).ToString("f2") + " 元");
                    table.AddCol(ose.OrderStatus(int.Parse(datapage.DataReader["OrderStatus"].ToString())));
                    table.AddCol(ose.PaymentStatus(int.Parse(datapage.DataReader["PaymentStatus"].ToString())));
                    table.AddCol(ose.OgisticsStatu(int.Parse(datapage.DataReader["OgisticsStatus"].ToString())));
                    table.AddRow();
                }
            }

            this.ltlView.Text = table.GetTable() + datapage.PageToolBar;
            table = null;
            datapage.Dispose();
            datapage = null;
            bll = null;

        }
        #region 计算商品总价
        private double TotalPrice(string orderId)
        {
            ShowShop.BLL.Order.OrderProduct bll = new ShowShop.BLL.Order.OrderProduct();
            DataTable dt = bll.GetListOrderProduct(orderId);
            double totalPrice = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    totalPrice += Convert.ToDouble(dt.Rows[i]["ProPrice"].ToString()) * Convert.ToDouble(dt.Rows[i]["ProNum"].ToString());
                }
            }
            return totalPrice;
        }
        #endregion
        protected void btnOk_Click(object sender, EventArgs e)
        {
            this.GetList();
        }
    }
}
