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
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;

namespace ShowShop.Web.admin.order
{
    /// <summary>
    /// 预付款支付
    /// </summary>
    public partial class order_pre_pay : System.Web.UI.Page
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
            ChangeHope.WebPage.WebControl.Validate(this.txtPayoutMoney, "输入数字将作为金额", "isint", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtRemark, "输入相关的备注信息", "isnull", "必填", "该项不能为空");
            ChangeHope.WebPage.WebControl.Validate(this.txtBosomNote, "输入内部信息", "isnull", "必填", "该项不能为空");
            ChangeHope.WebPage.WebControl.SetDate(this.txtAdsumMoneyDate);
            this.txtAdsumMoneyDate.Text = DateTime.Now.ToShortDateString();
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 订单信息初始化
        /// </summary>
        protected void OrderInfoBind(string orderId)
        {
            ShowShop.BLL.Order.Orders bll = new ShowShop.BLL.Order.Orders();
            ShowShop.Model.Order.Orders model = bll.GetModel(orderId);
            if (model != null)
            {
                this.lblUserId.Text = model.ConsigneeName;
                this.lblUserName.Text = model.UserId;
                this.lblOrderId.Text = model.OrderId;
                this.lblMoneyPayed.Text = GetPayed(model.OrderId);//已付款
                this.lblMoneyCount.Text =  Convert.ToDouble(model.FactPrice).ToString("f2"); //订单总金额
                this.txtPayoutMoney.Text = (( Convert.ToDouble(model.FactPrice.ToString())) - Convert.ToDouble(this.lblMoneyPayed.Text)).ToString();  //需要再支付的金额
                this.txtRemark.Text = model.Remark;
               
            }
        }
        #endregion

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

        #region 公共方法
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

        protected int GetUidByUserId(string userId)
        {
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.Model.Member.MemberAccount model = bll.GetModel(userId);
            if (model != null)
            {
                return model.UID;
            }
            else
            {
                return 0;
            }
        }

        #endregion

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            /*修改人：YM
             *修改时间：2009-12-17
             *判断订单是否是会员订单及用户是否存在
             */
            if (this.lblUserName.Text.Trim() == "")
            {
                this.ltlMsg.Text = "操作失败!您所支付的订单可能是非会员生成的订单.";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
                return;
            }
            ShowShop.Model.Admin.AdminInfo adminInfo = (ShowShop.Model.Admin.AdminInfo)ShowShop.Common.AdministrorManager.Get();
            ShowShop.BLL.Member.MemberAccount memberBll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.Model.Member.MemberAccount memberModel = memberBll.GetModel(this.lblUserName.Text);
            if (memberModel == null)
            {
                this.ltlMsg.Text = "操作失败!该会员不存在.";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
                return;
            }
            #region 订单预付款资金
            ShowShop.Model.Order.PrepayMoney preModel = new ShowShop.Model.Order.PrepayMoney();
            ShowShop.BLL.Order.PrepayMoney preBll = new ShowShop.BLL.Order.PrepayMoney();
            preModel.OrderId = this.lblOrderId.Text;
            preModel.UserName = this.lblUserName.Text;
            preModel.PayoutMoney = Convert.ToDecimal(this.txtPayoutMoney.Text.Trim());
            preModel.Remark = this.txtRemark.Text;
            preModel.BosomNote = this.txtBosomNote.Text;
            preModel.NoteDate = DateTime.Now;
            preModel.NoteName = adminInfo.AdminName;
            #endregion

            #region 用户交易明细
            ShowShop.Model.Member.UserinAndExp userModel = new ShowShop.Model.Member.UserinAndExp();
            ShowShop.BLL.Member.UserinAndExp userBll = new ShowShop.BLL.Member.UserinAndExp();

            //资金的明细
            userModel.UID = memberModel.UID;
            userModel.AdsumMoneyDate = Convert.ToDateTime(this.txtAdsumMoneyDate.Text);
            userModel.AdsumMoney = Convert.ToDecimal(this.txtPayoutMoney.Text);
            userModel.PresentCoupons = 0;
            userModel.RemitMode = 2;
            userModel.RemitBank = string.Empty;
            userModel.Remark = this.txtRemark.Text;
            userModel.FormMode = string.Empty; //通知方式
            userModel.BosomNote = this.txtBosomNote.Text;
            userModel.NoteDate = DateTime.Now;
            userModel.NoteName = adminInfo.AdminName;
            userModel.InComeandExpState = 1;
            userModel.State = 0;
            userModel.UserId = this.lblUserName.Text;
            #endregion

            #region 订单状态
            ShowShop.BLL.Order.Orders orderBll = new ShowShop.BLL.Order.Orders();
            ShowShop.Model.Order.Orders orderModel = orderBll.GetModel(this.lblOrderId.Text);
            #endregion

            ShowShop.BLL.Member.MemberAccount mabll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.Model.Member.MemberAccount mamodel = mabll.GetModel(this.lblUserName.Text);
            try
            {
                //已付款+此次汇款的总和
                decimal payTotail = Convert.ToDecimal(this.GetPayed(this.lblOrderId.Text)) + Convert.ToDecimal(this.txtPayoutMoney.Text.Trim());
                #region 如果有多余的钱
                if (payTotail > Convert.ToDecimal(orderModel.FactPrice))
                {
                    ChangeHope.WebPage.BasePage.PageError("输入的金额大于了订单总额！", "order_bank_pay.aspx?OrderId=" + orderModel.Id);
                    return;
                }
                #endregion

                #region 查询用户金额 操作用户金额
                if (mamodel != null)
                {
                    decimal Price = decimal.Parse(mamodel.Capital.ToString());
                    if (Convert.ToDecimal(this.txtPayoutMoney.Text) > Price)
                    {
                        ChangeHope.WebPage.BasePage.PageError("用户余额不足！", "order_bank_pay.aspx?OrderId=" + orderModel.Id);
                        return;
                    }
                    mabll.Amend(mamodel.UID, "Capital", (Convert.ToDecimal(mamodel.Capital.ToString()) - Convert.ToDecimal(this.txtPayoutMoney.Text)));
                }
                
                #endregion
                preBll.Add(preModel);
                userBll.Add(userModel);

                #region 操作付款状态 订单状态

                int OrderId = ChangeHope.WebPage.PageRequest.GetQueryInt("OrderId");
                if (payTotail >= Convert.ToDecimal(orderModel.FactPrice))
                {
                    if (OrderId > 0)
                    {
                        orderBll.Amend(OrderId, "OrderStatus", ShowShop.Common.OrdersStatusEnum.OrderStatu.未结清.GetHashCode());
                        orderBll.Amend(OrderId, "PaymentStatus", ShowShop.Common.OrdersStatusEnum.PaymentStatu.已经付清.GetHashCode());
                        orderBll.Amend(OrderId, "OgisticsStatus", ShowShop.Common.OrdersStatusEnum.OgisticsStatus.配送中.GetHashCode());
                    }
                }
                else
                {
                    if (OrderId > 0)
                    {
                        orderBll.Amend(OrderId, "OrderStatus", ShowShop.Common.OrdersStatusEnum.OrderStatu.未结清.GetHashCode());
                        orderBll.Amend(OrderId, "PaymentStatus", ShowShop.Common.OrdersStatusEnum.PaymentStatu.未付清.GetHashCode());
                    }
                }
                #endregion
                ChangeHope.WebPage.BasePage.PageRight("已保存该信息", "order_bank_pay.aspx?OrderId=" + orderModel.Id);
            }
            catch
            {
                this.ltlMsg.Text = "操作失败!";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
            }
            finally
            {
                adminInfo = null;
                preModel = null;
                preBll = null;
                orderBll = null;
                orderModel = null;
                GC.Collect();
            }
        }
    }
}
