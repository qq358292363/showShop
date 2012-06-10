using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace ShowShop.Web.admin.member
{
    public partial class mail_send_single : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitWebControl();
                MemberBind();
            }
        }

        #region 验证
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtEmailTitle, "输入邮件的标题", "isnull", "必填", "该项为必填项，注意链接地址格式");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }
        #endregion

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

        protected void SendByType(string toAddr)
        {
            string server = string.Empty;
            string username = string.Empty;
            string password = string.Empty;
            string title = string.Empty;
            string content = string.Empty;
            ShowShop.BLL.SystemInfo.MailSetting bll = new ShowShop.BLL.SystemInfo.MailSetting();
            ShowShop.Model.SystemInfo.MailSetting model = bll.GetModel();
            if (model != null)
            {
                server = model.SmtpServerIP;
                username = model.MailId;
                password = model.MailPassword;
            }
            title = this.txtEmailTitle.Text.Trim();
            content = this.txtEmailContent.Value;
            SendEmail(server, username, password, toAddr, title, content);
        }
        #endregion

        #region 信息绑定
        protected void MemberBind()
        {
            int uid = ChangeHope.WebPage.PageRequest.GetQueryInt("uid");
            string outDate = "0";
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.Model.Member.MemberAccount model = bll.GetModel(uid);
            lblUserId.Text = model.UserId;
            lblGroupName.Text = GetGroupName(Convert.ToInt32(model.UserGroup));
            lblCapital.Text = model.Capital.ToString();
            lblCoupons.Text = model.Coupons.ToString();
            lblPoints.Text = model.Points.ToString();
            if (Convert.ToDateTime(model.PeriodOfValidity) > System.DateTime.Now)
            {
                TimeSpan ts1 = new TimeSpan(Convert.ToDateTime(model.PeriodOfValidity).Ticks);
                TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                outDate = ts.Days.ToString();
            }
            lblPeriodOfValidity.Text = outDate;
            lblEmail.Text = model.Email;
        }

        protected string GetGroupName(int groupId)
        {
            ShowShop.BLL.Member.MemberRank bll = new ShowShop.BLL.Member.MemberRank();
            ShowShop.Model.Member.MemberRank model = bll.GetModel(groupId);
            if (model != null)
            {
                return model.Name;
            }
            else
            {
                return "无该用户组";
            }
        }
        #endregion

        protected void lbSave_Click(object sender, EventArgs e)
        {
            int uid = ChangeHope.WebPage.PageRequest.GetQueryInt("uid");
            if (this.txtEmailContent.Value == string.Empty)
            {
                this.ltlMsg.Text = "请输入邮件的内容";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
                return;
            }
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.Model.Member.MemberAccount model = bll.GetModel(uid);
            SendByType(model.Email);
            this.ltlMsg.Text = "操作成功，已向" + model.UserId + "发送该邮件！";
            this.pnlMsg.Visible = true;
            this.pnlMsg.CssClass = "actionOk";
        }
    }
}
