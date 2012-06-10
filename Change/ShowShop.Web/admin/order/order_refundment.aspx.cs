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
    /// 退款
    /// </summary>
    public partial class order_refundment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("005001012","对不起，您没有退款的权限");
                int id = ChangeHope.WebPage.PageRequest.GetQueryInt("OrderId");
                InitWebControl();
                this.OrderInfoBind(this.GetOrderId(id));
                this.hlBack.NavigateUrl = "order_order_info.aspx?OrderId=" + id;
            }

        }

        #region 验证
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtPoundAge, "输入数字将作为手续费金额", "isint", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtRefundmentMoney, "输入数字将作为退款金额", "isint", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtRemark, "输入相关的备注信息", "isnull", "必填", "该项不能为空");
            ChangeHope.WebPage.WebControl.Validate(this.txtBosomNote, "输入内部信息", "isnull", "必填", "该项不能为空");
            ChangeHope.WebPage.WebControl.SetDate(this.txtPaymentDate);
            this.txtPaymentDate.Text = DateTime.Now.ToShortDateString();
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
                this.lblMoneyCount.Text = Convert.ToDouble(model.FactPrice).ToString("f2"); ;//订单总金额
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
            decimal remPrice =0;
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
            List<ShowShop.Model.Order.PaymentMoney> paydata = payBll.GetAll("orderid='" + orderId+"'");
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

        #region 邮件发送
        private void SendEmail(string toaddr, string titel, string body)
        {
            ShowShop.BLL.SystemInfo.MailSetting mailBll = new ShowShop.BLL.SystemInfo.MailSetting();
            ShowShop.Model.SystemInfo.MailSetting mailModel = mailBll.GetModel();
            if (mailModel != null)
            {

                try
                {
                    MailMessage msg = new MailMessage();
                    //发送到
                    msg.To.Add(toaddr);
                    msg.From = new MailAddress(mailModel.MailId, titel, System.Text.Encoding.UTF8);
                    //标题
                    msg.Subject = titel;
                    msg.SubjectEncoding = System.Text.Encoding.UTF8;
                    //内容
                    msg.Body = body;
                    msg.BodyEncoding = System.Text.Encoding.UTF8;
                    msg.IsBodyHtml = true;
                    //优先级
                    msg.Priority = MailPriority.High;
                    SmtpClient client = new SmtpClient();
                    client.Credentials = new System.Net.NetworkCredential(mailModel.MailId, mailModel.MailPassword);
                    //Gmail邮箱发送  587
                    client.Port = 587;
                    client.Host = mailModel.SmtpServerIP;
                    client.EnableSsl = true;
                    client.Send(msg);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region 短消息发送
        /// <summary>
        /// 发送短消息
        /// </summary>
        /// <param name="uid">用户自增ID</param>
        /// <param name="userid">用户账号</param>
        /// <param name="title">短消息标题</param>
        /// <param name="content">短消息内容</param>
        /// <param name="sender">发送人（管理员账号）</param>
        protected void SendMessage(int uid, string userid, string title, string content, string sender)
        {

            ShowShop.BLL.Member.MailReceiver ReceBll = new ShowShop.BLL.Member.MailReceiver();
            ShowShop.Model.Member.MailReceiver ReceModel = new ShowShop.Model.Member.MailReceiver();
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            if (!bll.Exists(userid))
            {
                this.ltlMsg.Text = "不存在用户：" + userid;
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
                return;
            }
            ReceModel.ReceiverId = uid;
            ReceModel.Receiver = userid;
            ReceModel.ReceiveTime = DateTime.Now;
            ReceModel.Stat = 0;
            ReceModel.IsRead = 0;
            ReceModel.Title = title;
            ReceModel.Body = content;
            ReceModel.Sender = sender;
            ReceBll.Add(ReceModel);

        }
        #endregion

        private Dictionary<string, string> GetInforMode(CheckBoxList CbList)
        {
            string val = string.Empty;
            string txt = string.Empty;
            foreach (ListItem lItem in CbList.Items)
            {
                if (lItem.Selected)
                {
                    val += lItem.Value + ",";
                    txt += lItem.Text + ",";
                }
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("val", val.TrimEnd(','));
            dic.Add("txt", val.TrimEnd(','));
            return dic;
        }
        #endregion

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            ShowShop.Model.Admin.AdminInfo adminInfo = (ShowShop.Model.Admin.AdminInfo)ShowShop.Common.AdministrorManager.Get();
            if (Convert.ToDecimal(this.txtRefundmentMoney.Text.Trim()) + Convert.ToDecimal(this.txtPoundAge.Text.Trim()) > Convert.ToDecimal(GetPayed(this.lblOrderId.Text)))
            {
                this.ltlMsg.Text = "退款的金额不能大于已付的金额!";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
                return;
            }
            //银行支付
            ShowShop.BLL.Order.RemittanceInfo remBll = new ShowShop.BLL.Order.RemittanceInfo();
            ShowShop.Model.Order.RemittanceInfo remModel = remBll.GetModelByOrderId(this.lblOrderId.Text);
            //现金支付
            ShowShop.BLL.Order.PaymentMoney payBll = new ShowShop.BLL.Order.PaymentMoney();
            ShowShop.Model.Order.PaymentMoney payModel = payBll.GetModelByOrderId(this.lblOrderId.Text);
            //预付款
            ShowShop.BLL.Order.PrepayMoney preBll = new ShowShop.BLL.Order.PrepayMoney();
            ShowShop.Model.Order.PrepayMoney preModel = preBll.GetModelByOrderId(this.lblOrderId.Text);
            //订单信息
            ShowShop.BLL.Order.Orders orderBll = new ShowShop.BLL.Order.Orders();
            ShowShop.Model.Order.Orders orderModel = orderBll.GetModel(this.lblOrderId.Text);

            #region 退款信息
            ShowShop.BLL.Order.RefundMent refBll = new ShowShop.BLL.Order.RefundMent();
            ShowShop.Model.Order.RefundMent refModel = new ShowShop.Model.Order.RefundMent();
            refModel.OrderId = this.lblOrderId.Text;
            refModel.UserName = this.lblUserId.Text;
            refModel.PaymentDate = Convert.ToDateTime(this.txtPaymentDate.Text);
            refModel.PoundAge = Convert.ToDecimal(this.txtPoundAge.Text.Trim());
            refModel.RefundMentMoney = Convert.ToDecimal(this.txtRefundmentMoney.Text.Trim());
            refModel.RefundMentMode = this.rabRefundmentMode.SelectedItem.Text;
            refModel.Remark = this.txtRemark.Text;
            refModel.InformMode = GetInforMode(cbxInformMode)["txt"]; //通知方式
            refModel.NoteDate = DateTime.Now;
            refModel.NoteName = adminInfo.AdminName;
            #endregion

            #region 用户交易明细
            ShowShop.Model.Member.UserinAndExp userModel = new ShowShop.Model.Member.UserinAndExp();
            ShowShop.BLL.Member.UserinAndExp userBll = new ShowShop.BLL.Member.UserinAndExp();

            //银行资金的明细
            userModel.UID = this.GetUidByUserId(this.lblUserId.Text);
            userModel.AdsumMoneyDate = Convert.ToDateTime(this.txtPaymentDate.Text);
            userModel.AdsumMoney = Convert.ToDecimal(this.txtRefundmentMoney.Text);
            userModel.PresentCoupons = 0;
            userModel.RemitMode = 1;
            userModel.RemitBank = string.Empty;
            userModel.Remark = this.txtRemark.Text;
            userModel.FormMode = GetInforMode(cbxInformMode)["txt"]; //通知方式
            userModel.BosomNote = this.txtBosomNote.Text;
            userModel.NoteDate = DateTime.Now;
            userModel.NoteName = adminInfo.AdminName;
            userModel.InComeandExpState = 0;
            userModel.State = 0;
            userModel.UserId = this.lblUserId.Text;
            #endregion

            try
            {
                if (refModel.RefundMentMoney == orderModel.FactPrice)//如果退款和订单价 匹配
                {
                    remBll.Delete(remModel.ID.ToString());
                    payBll.Delete(payModel.ID.ToString());
                    preBll.Delete(preModel.ID.ToString());
                }
                else
                {
                    if (remModel.RemittanceMoney > 0) //银行汇款
                    {
                        if (remModel.RemittanceMoney <= refModel.RefundMentMoney)
                        {
                            remBll.Delete(remModel.ID.ToString());
                        }
                        else
                        {
                            remModel.RemittanceMoney = remModel.RemittanceMoney - refModel.RefundMentMoney;
                            remBll.Amend(remModel);
                        }
                    }
                    if (preModel.PayoutMoney > 0) //预付款
                    {
                        if (preModel.PayoutMoney <= refModel.RefundMentMoney)
                        {
                            preBll.Delete(preModel.ID.ToString());
                        }
                        else
                        {
                            preModel.PayoutMoney = (preModel.PayoutMoney + remModel.RemittanceMoney) - refModel.RefundMentMoney;
                            preBll.Amend(preModel);
                        }
                    }
                    if (payModel.GatheringMoney > 0) //现金支付
                    {
                        if (payModel.GatheringMoney == (refModel.RefundMentMoney - remModel.RemittanceMoney - preModel.PayoutMoney))
                        {
                            payBll.Delete(payModel.ID.ToString());
                        }
                        else
                        {
                            payModel.GatheringMoney = (remModel.RemittanceMoney + preModel.PayoutMoney + payModel.GatheringMoney) - refModel.RefundMentMoney;
                            payBll.Amend(payModel);
                        }
                    }
                }

                refBll.Add(refModel); //退款信息
                userBll.Add(userModel); //明细记录

                //已付款
                decimal payTotail = Convert.ToDecimal(this.GetPayed(this.lblOrderId.Text));
                if ((payTotail - (Convert.ToDecimal(this.txtRefundmentMoney.Text.Trim()))) < 0)
                {
                    orderModel.PaymentStatus = ShowShop.Common.OrdersStatusEnum.PaymentStatu.等待汇款.GetHashCode();
                }
                else
                {
                    orderModel.PaymentStatus = ShowShop.Common.OrdersStatusEnum.PaymentStatu.已收定金.GetHashCode();
                    
                }
                orderModel.OrderStatus = ShowShop.Common.OrdersStatusEnum.OrderStatu.已经确认.GetHashCode();
                orderBll.Update(orderModel);
                ChangeHope.WebPage.BasePage.PageRight("已保存该信息.", "order_bank_pay.aspx?OrderId=" + orderModel.Id, "<li><a href='order_order_info.aspx?OrderId=" + orderModel.Id.ToString() + "'>返回信息页</a></li>");
                
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
                remModel = null;
                remBll = null;
                userModel = null;
                userBll = null;
                payBll = null;
                payModel = null;
                preBll = null;
                preModel = null;
                orderBll = null;
                orderModel = null;
                GC.Collect();
            }
        }
    }
}
