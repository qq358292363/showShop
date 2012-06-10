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
using System.Collections.Generic;

namespace ShowShop.Web.admin.order
{
    public partial class order_back_consignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = ChangeHope.WebPage.PageRequest.GetQueryInt("OrderId");
                InitWebControl();
                this.OrderInfoBind(this.GetOrderId(id));
                this.hlBack.NavigateUrl = "order_order_info.aspx?OrderId=" + id;
            }
        }

        #region 验证
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtExpressOddNumbers, "输入快递单号", "isnull", "必填", "该项不能为空");
            ChangeHope.WebPage.WebControl.Validate(this.txtConsignMentPeople, "输入经手人姓名", "isnull", "必填", "该项不能为空");
            ChangeHope.WebPage.WebControl.Validate(this.txtRemark, "输入相关的备注信息", "isnull", "必填", "该项不能为空");
            ChangeHope.WebPage.WebControl.Validate(this.txtBosomNote, "输入内部信息", "isnull", "必填", "该项不能为空");
            ChangeHope.WebPage.WebControl.SetDate(this.txtConsignMentDate);
            this.txtConsignMentDate.Text = DateTime.Now.ToShortDateString();
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }
        #endregion

        /// <summary>
        /// 订单信息初始化
        /// </summary>
        protected void OrderInfoBind(string orderId)
        {
            ShowShop.BLL.Order.Orders bll = new ShowShop.BLL.Order.Orders();
            ShowShop.Model.Order.Orders model = bll.GetModel(orderId);
            if (model != null)
            {
                this.lblUserId.Text = model.UserId;
                this.lblUserName.Text = model.ConsigneeName;
                this.lblOrderId.Text = model.OrderId;
                this.lblMoneyPayed.Text = GetPayed(model.OrderId);//已付款
                this.lblMoneyCount.Text = Convert.ToDouble(model.FactPrice).ToString("f4"); ;//订单总金额
                this.lblCourier.Text = GetDeliverById(Convert.ToInt32(model.Courier)); //配送方式
                this.txtRemark.Text = model.Remark;
            }
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
        /// <summary>
        /// 根据ID得到订单号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetOrderId(int id)
        {
            ShowShop.BLL.Order.Orders bll = new ShowShop.BLL.Order.Orders();
            ShowShop.Model.Order.Orders model = bll.GetModel(id);
            if (model != null)
            {
                return model.OrderId;
            }
            else
            {
                return string.Empty;
            }
        }



        protected int GetUidByUserId(string userId)
        {
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.Model.Member.MemberAccount model = bll.GetModel(userId);
            return model.UID;
        }

        /// <summary>
        /// 计算已付款
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        protected string GetPayed(string orderId)
        {
            string totle = string.Empty;
            decimal remPrice = 0;
            decimal payPrice = 0;
            decimal prePrice = 0;
            //银行支付
            ShowShop.BLL.Order.RemittanceInfo remBll = new ShowShop.BLL.Order.RemittanceInfo();
            List<ShowShop.Model.Order.RemittanceInfo> remdate = remBll.GetAll("orderid='" + orderId + "'");
            if (remdate.Count > 0)
            {
                foreach (ShowShop.Model.Order.RemittanceInfo da in remdate)
                {
                    remPrice += Convert.ToDecimal(da.RemittanceMoney.ToString());
                }
            }
            //现金支付
            ShowShop.BLL.Order.PaymentMoney payBll = new ShowShop.BLL.Order.PaymentMoney();
            List<ShowShop.Model.Order.PaymentMoney> paydata = payBll.GetAll("orderid='" + orderId + "'");
            if (paydata.Count > 0)
            {
                foreach (ShowShop.Model.Order.PaymentMoney da in paydata)
                {
                    payPrice += Convert.ToDecimal(da.GatheringMoney.ToString());
                }
            }
            //预付款
            ShowShop.BLL.Order.PrepayMoney preBll = new ShowShop.BLL.Order.PrepayMoney();
            List<ShowShop.Model.Order.PrepayMoney> predata = preBll.GetAll("orderid='" + orderId + "'");
            if (predata.Count > 0)
            {
                foreach (ShowShop.Model.Order.PrepayMoney da in predata)
                {
                    prePrice += Convert.ToDecimal(da.PayoutMoney);
                }
            }
            totle = (remPrice + payPrice + prePrice).ToString();
            return totle;
        }

        /// <summary>
        /// 根据ID得到运送方式的名字
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetDeliverById(int id)
        {
            ShowShop.BLL.Product.Deliver bll = new ShowShop.BLL.Product.Deliver();
            ShowShop.Model.Product.Deliver model = bll.GetModelByID(id);
            if (model != null)
            {
                return model.Name.ToString();
            }
            else
            {
                return "无该运送方式名称";
            }
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            ShowShop.Model.Order.ConsignMent model = new ShowShop.Model.Order.ConsignMent();
            ShowShop.BLL.Order.ConsignMent bll = new ShowShop.BLL.Order.ConsignMent();
            ShowShop.Model.Admin.AdminInfo adminInfo = (ShowShop.Model.Admin.AdminInfo)ShowShop.Common.AdministrorManager.Get();
            model.OrderId = this.lblOrderId.Text;
            model.UserName = this.lblUserName.Text;
            model.ConsignMentDate = Convert.ToDateTime(this.txtConsignMentDate.Text);
            model.ExpressCompany = string.Empty;
            model.ExpressOddNumbers = this.txtExpressOddNumbers.Text;
            model.ConsignMentPeople = this.txtConsignMentPeople.Text;
            model.Remark = this.txtRemark.Text;
            model.BosomNote = this.txtBosomNote.Text;
            model.InformMode = string.Empty;//通知方式
            model.NoteDate = DateTime.Now;
            model.NoteName = adminInfo.AdminName;
            model.Received = ShowShop.Common.OrdersStatusEnum.OgisticsStatus.配送中.GetHashCode();
            model.ConsignMentType = 1;//类型  退货

            #region 订单状态
            ShowShop.BLL.Order.Orders orderBll = new ShowShop.BLL.Order.Orders();
            ShowShop.Model.Order.Orders orderModel = orderBll.GetModel(this.lblOrderId.Text);
            #endregion

            try
            {
                bll.Add(model);

                #region 操作订单状态
                orderModel.OgisticsStatus = ShowShop.Common.OrdersStatusEnum.OgisticsStatus.配送中.GetHashCode();
                orderBll.Update(orderModel);
                #endregion

                ChangeHope.WebPage.BasePage.PageRight("已保存该信息.", "", "<li><a href='order_order_info.aspx?OrderId=" + orderModel.Id.ToString() + "'>返回信息页</a></li>");
                return;
            }
            catch
            {
                this.ltlMsg.Text = "操作失败！";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
            }
            finally
            {
                bll = null;
                model = null;
            }
        }
    }
}
