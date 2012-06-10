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
    public partial class email_send : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ChangeHope.WebPage.PageRequest.GetQueryString("strId") != string.Empty)
                {
                    GetUserID();
                }
                GetSendMail();
                MemberRankBind();
                InitWebControl(); 
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
                ChangeHope.WebPage.BasePage.PageError(ex.Message, "email_send.aspx?strId=" + ChangeHope.WebPage.PageRequest.GetQueryString("strId") + "");
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
        protected void MemberRankBind()
        {
            ShowShop.BLL.Member.MemberRank bll = new ShowShop.BLL.Member.MemberRank();
            List<ShowShop.Model.Member.MemberRank> model = bll.GetAllMemberRank();
            cbxlMemberRank.DataSource = model;
            cbxlMemberRank.DataTextField = "Name";
            cbxlMemberRank.DataValueField = "Id";
            cbxlMemberRank.DataBind();
        }

        /// <summary>
        /// 得到系统设定的发送邮箱
        /// </summary>
        protected void GetSendMail()
        {
            ShowShop.BLL.SystemInfo.MailSetting bll = new ShowShop.BLL.SystemInfo.MailSetting();
            ShowShop.Model.SystemInfo.MailSetting model = bll.GetModel();
            if (model != null)
            {
                this.txtSendEmail.Text = model.MailId;
            }
        }

        /// <summary>
        /// 得到初始化时用户的账号串
        /// </summary>
        protected void GetUserID()
        {
            string uid = ChangeHope.WebPage.PageRequest.GetQueryString("strId");
            string userId = string.Empty;
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            List<ShowShop.Model.Member.MemberAccount> model = bll.GetAll(" UID in(" + uid + ")");
            for (int i = 0; i <model.Count; i++)
            {
                userId += model[i].UserId + ",";
            }
            userId = userId.Substring(0, userId.LastIndexOf(','));
            this.txtUserName.Text = userId;
        }
        #endregion

        protected void lbSave_Click(object sender, EventArgs e)
        {
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            List<ShowShop.Model.Member.MemberAccount> model = new List<ShowShop.Model.Member.MemberAccount>();
            //发送给全体
            if (rabtnAllUser.Checked)
            {
                model = bll.GetAll(" 1=1");
                for (int i = 0; i < model.Count; i++)
                {
                    SendByType(model[i].Email);
                }
                this.ltlMsg.Text = "操作成功，已向所有用户发送该邮件！";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
            //发送会员组
            else if (rabtnMemberGroup.Checked)
            {
                string rankID = string.Empty;
                for (int i = 0; i < cbxlMemberRank.Items.Count; i++)
                {
                    if (cbxlMemberRank.Items[i].Selected)
                    {
                        rankID += cbxlMemberRank.Items[i].Value + ",";
                    }
                }
                if (rankID == string.Empty)
                {
                    this.ltlMsg.Text = "请选择要发送到的会员组";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
                rankID = rankID.Substring(0, rankID.LastIndexOf(','));
                model = bll.GetAll(" UserGroup in(" + rankID + ")");
                for (int i = 0; i < model.Count; i++)
                {
                    SendByType(model[i].Email);
                }
                this.ltlMsg.Text = "操作成功，已向指定用户组发送该邮件！";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
            //指定用户名  
            else if (rabtnCheckUser.Checked)
            {
                string uid = this.txtUserName.Text.Trim();
                if (uid.Length == 0)
                {
                    this.ltlMsg.Text = "请输入要发送到的会员";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
                if (uid.EndsWith(","))
                {
                    uid = uid.Substring(0, uid.LastIndexOf(','));
                }
                //进行拆分 给每个字段加上单引号
                string[] arrUid = uid.Split(',');
                uid = string.Empty;
                for (int i = 0; i < arrUid.Length; i++)
                {
                    uid += "'" + arrUid[i] + "'" + ",";
                }
                if (uid.EndsWith(","))
                {
                    uid = uid.Substring(0, uid.LastIndexOf(','));
                }

                model = bll.GetAll(" UserId in(" + uid + ")");
                for (int i = 0; i < model.Count; i++)
                {
                    SendByType(model[i].Email);
                }
                this.ltlMsg.Text = "操作成功，已向指定用户发送该邮件！";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
            //指定邮箱
            else if (rabtnCheckEmail.Checked)
            {
                string email = this.txtEmail.Text.Trim();
                if (email.Length == 0)
                {
                    this.ltlMsg.Text = "请输入要发送到的邮箱";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
                SendByType(email);
                this.ltlMsg.Text = "操作成功，已向所有用户发送该邮件！";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }


        }
    }
}
