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
    public partial class order_invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitWebControl();
                InvoiceBind();
            }
        }

        #region 验证
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtInvoiceNumber, "输入发票编号", "isnull", "必填", "该项不能为空");
            ChangeHope.WebPage.WebControl.Validate(this.txtInvoiceRise, "输入发票的抬头", "isnull", "必填", "该项不能为空");
            ChangeHope.WebPage.WebControl.Validate(this.txtInvoiceContent, "输入发票的内容", "isnull", "必填", "该项不能为空");
            ChangeHope.WebPage.WebControl.Validate(this.txtInvoiceName, "输入开票人的姓名", "isnull", "必填", "该项不能为空");
            ChangeHope.WebPage.WebControl.Validate(this.txtInvoiceMoney, "输入发票的金额", "isint", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtRemark, "输入相关的备注信息", "isnull", "必填", "该项不能为空");
            ChangeHope.WebPage.WebControl.Validate(this.txtBosomNote, "输入内部信息", "isnull", "必填", "该项不能为空");
            ChangeHope.WebPage.WebControl.SetDate(this.txtInvoicedDate);
            this.txtInvoicedDate.Text = DateTime.Now.ToShortDateString();
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }
        #endregion

        /// <summary>
        /// 发票类型绑定
        /// </summary>
        protected void InvoiceBind()
        {
            //ShowShop.BLL.Product.Express bll = new ShowShop.BLL.Product.Express();
            //List<ShowShop.Model.Product.Express> model = bll.GetAll();
            //ddlExpressCompany.DataSource = model;
            //ddlExpressCompany.DataTextField = "Name";
            //ddlExpressCompany.DataValueField = "ID";
            //ddlExpressCompany.DataBind();
        }

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
                this.lblUserName.Text = model.UserId; // 用户名 暂时用 userId
                this.lblOrderId.Text = model.OrderId;
                this.lblMoneyPayed.Text = model.Payment.ToString();//已付款？？？？
                this.lblMoneyCount.Text = model.TotalPrice.ToString();//订单总金额
                this.txtRemark.Text = model.Remark;
            }
        }

        protected int GetUidByUserId(string userId)
        {
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.Model.Member.MemberAccount model = bll.GetModel(userId);
            return model.UID;
        }

        #region 邮件发送
        private void SendEmail(string server, string username, string password, string toaddr, string titel, string body)
        {
            try
            {
                MailMessage msg = new MailMessage();
                //发送到
                msg.To.Add(toaddr);
                msg.From = new MailAddress(username, titel, System.Text.Encoding.UTF8);
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
                client.Credentials = new System.Net.NetworkCredential(username, password);
                //Gmail邮箱发送  587
                client.Port = 587;
                client.Host = server;
                client.EnableSsl = true;
                client.Send(msg);
            }
            catch (Exception ex)
            {
                throw ex;
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

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            ShowShop.Model.Order.InvoiceItem model = new ShowShop.Model.Order.InvoiceItem();
            ShowShop.BLL.Order.InvoiceItem bll = new ShowShop.BLL.Order.InvoiceItem();
            ShowShop.Model.Admin.AdminInfo adminInfo = (ShowShop.Model.Admin.AdminInfo)ShowShop.Common.AdministrorManager.Get();
            model.OrderId = this.lblOrderId.Text;
            model.UserName = this.lblUserName.Text;
            model.InvoiceDate = Convert.ToDateTime(this.txtInvoicedDate.Text);
            model.InvoiceContent = this.txtInvoiceContent.Text;
            model.InvoiceMoney = Convert.ToDecimal(this.txtInvoiceMoney.Text);
            model.InvoiceName = this.txtInvoiceName.Text;
            model.InvoiceType = "";  //发票类型
            model.InvoiceNumber = this.txtInvoiceNumber.Text;
            model.InvoiceRise = this.txtInvoiceRise.Text;
            model.BosomNote = this.txtBosomNote.Text;
            model.InformMode = GetInforMode(cbxInformMode)["txt"]; //通知方式
            model.NoteDate = DateTime.Now;
            model.NoteName = adminInfo.AdminName;
            try
            {
                bll.Add(model);
                this.ltlMsg.Text = "操作成功，已保存该信息";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
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
