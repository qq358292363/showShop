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

namespace ShowShop.Web.admin.systeminfo
{
    public partial class mail_setting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("010001010");
                InitWebControl();
                GetModel();
            }
        }
        private void GetModel()
        {
            ShowShop.BLL.SystemInfo.MailSetting bll = new ShowShop.BLL.SystemInfo.MailSetting();
            Model.SystemInfo.MailSetting model = bll.GetModel();
            if(model!=null)
            {
                this.txtId.Value = model.Id.ToString();
                this.txtMailId.Text = model.MailId;
                this.txtMailPassword.Text = model.MailPassword;
                this.txtSmtpServerIP.Text = model.SmtpServerIP;
                this.txtSmtpServerPort.Text = model.SmtpServerPort.ToString();
            }
            model = null;
            bll = null;
        }
        private void Save()
        {
            ShowShop.BLL.SystemInfo.MailSetting bll = new ShowShop.BLL.SystemInfo.MailSetting();
            Model.SystemInfo.MailSetting model = new ShowShop.Model.SystemInfo.MailSetting();
            try {
                if (txtMailId.Text.Trim()!="")
                {
                    if (!ChangeHope.Common.ValidateHelper.IsEmail(txtMailId.Text.Trim()))
                    {
                        this.ltlMsg.Text = "操作失败，请输入正确邮箱。";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                model.Id = ChangeHope.Common.StringHelper.StringToInt(this.txtId.Value);
                model.MailId = this.txtMailId.Text;
                model.MailPassword = this.txtMailPassword.Text;
                model.SmtpServerIP = this.txtSmtpServerIP.Text;
                model.SmtpServerPort = ChangeHope.Common.StringHelper.StringToInt(this.txtSmtpServerPort.Text);
                if (model.Id > 0)
                {
                    bll.Update(model);
                }
                else
                {
                    bll.Add(model);
                }
                this.ltlMsg.Text = "操作成功!";
                this.pnlMsg.CssClass = "actionOk";
                this.pnlMsg.Visible = true;
            }
            catch(Exception ex) {
                this.ltlMsg.Text = "操作失败"+ex.ToString();
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
            }
            finally {
                bll = null;
                model = null;
            }
        }
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtSmtpServerIP, "STMP服务器是用来发送邮件的服务器，比如：smtp.gmail.com,在相关邮件系统的说明中有介绍。", "isnull_2", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtSmtpServerPort, "STMP服务器是用来发送邮件的服务器端口，默认为587。", "isint_1_5", "必填", "该项为必填项且必须为数字");
            ChangeHope.WebPage.WebControl.Validate(this.txtMailId, "发送邮件的邮箱，最好为gmail邮箱", "isemail", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtMailPassword, "邮箱密码.", "isnull", "必填", "该项为必填项");
            this.Form.Attributes.Add("onsubmit","return CheckForm()");

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ShowShop.Common.PromptInfo.Popedom("010001014","对不起，您没有权限进行编辑");
            this.Save();
        }
    }
}
