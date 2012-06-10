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

namespace ShowShop.Web.admin.product
{
    public partial class product_sale_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("003002001");
                this.lblList.Text = GetList();
            }
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        protected string GetList()
        {

            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Order.OrderProduct bll = new ShowShop.BLL.Order.OrderProduct();
            ShowShop.BLL.Order.Orders orderBll = new ShowShop.BLL.Order.Orders();
            ChangeHope.DataBase.DataByPage dataPage = bll.GetListByPage();
            //第一步先添加表头
            table.AddHeadCol("", "订单号");
            table.AddHeadCol("", "用户账号");
            table.AddHeadCol("", "收货人");
            table.AddHeadCol("", "商品名称");
            table.AddHeadCol("", "实际价格");
            table.AddHeadCol("", "下单时间");
            table.AddHeadCol("", "状态");
            table.AddRow();
            //添加表的内容
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    ShowShop.Model.Order.Orders orderModel = orderBll.GetModel(Convert.ToInt32(dataPage.DataReader["OrderId"].ToString()));
                    if (orderModel != null)
                    {
                        table.AddCol(orderModel.OrderId);
                        table.AddCol(orderModel.UserId);
                        table.AddCol(orderModel.ConsigneeName);
                        table.AddCol(dataPage.DataReader["ProName"].ToString());
                        table.AddCol(dataPage.DataReader["ProPrice"].ToString());
                        table.AddCol(orderModel.OrderDate.ToString());
                        table.AddCol(this.ShowStatu(orderModel.OrderStatus));
                        table.AddRow();
                    }
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return view;
        }

        public string ShowStatu(object objStatu)
        {
            string reStr = "";
            if (ChangeHope.Common.ValidateHelper.IsNumber(objStatu.ToString()))
            {
                int statu = Convert.ToInt32(objStatu);
                Type orderstatu = typeof(ShowShop.Common.OrdersStatusEnum.OrderStatu);
                foreach (int i in Enum.GetValues(orderstatu))
                {
                    if (i == statu)
                    {
                        reStr = Enum.GetName(orderstatu, i);
                        break;
                    }
                }
            }
            return reStr;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.lblList.Text = GetList();
        }
    }
}
