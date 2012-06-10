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
using ShowShop.Model.Admin;
using ShowShop.Common;

namespace ShowShop.Web.admin.member
{
    public partial class admin_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("007001002","对不起，您没有权限进行编辑");
                ShowShop.Common.PromptInfo.Popedom("007001004","对不起，您没有权限进行编辑");
                InitWebControl(); 
                GetModel();
            }
        }
        private void GetModel()
        {
            AdminInfo aInfo = AdministrorManager.Get();
            int adminid = ChangeHope.WebPage.PageRequest.GetInt("adminid");
            if (adminid > 0)
            {
                ShowShop.BLL.Admin.Administrators bll = new ShowShop.BLL.Admin.Administrators();
                Model.Admin.Administrators model = bll.GetModel(adminid);
                if (model != null)
                {

                    this.txtAdminId.Value = model.AdminId.ToString();
                    this.txtManageBeginTime.Text = model.ManageBeginTime.ToString();
                    this.txtManageEndTime.Text = model.ManageEndTime.ToString();
                    this.txtName.Text = model.Name;
                    this.txtName.ReadOnly = true;
                    this.ckbAllowModifyPassword.Checked = model.AllowModifyPassWord.Equals(1) ? true : false;
                    if (aInfo.AdminName == "admin")
                    {
                        this.ckbPower.Enabled = false;
                    }
                    this.ckbPower.SelectedValue = model.Power.ToString();
                    this.ckbState.Checked = model.State.Equals(1) ? true : false;
                    ChangeHope.WebPage.WebControl.Validate(this.txtPasswordRe, "密码为空时，则不修改密码", "no", "", "");

                }
                model = null;
                bll = null;
                return;

            }
            ChangeHope.WebPage.WebControl.Validate(this.txtPasswordRe, "密码为空时，则不修改密码", "isnull_6_20", "必填", "该项为必填项,且为6~20个字符");
        }
        private void InitWebControl()
        {
           
            ChangeHope.WebPage.WebControl.Validate(this.txtName,"设置管理员的帐号，该帐号的长度为3~20个英文字符","isnull_3_20","必填","该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtPassword,"为防止输入密码错误，在此处再次确认密码，不修改密码该处则不填写","compare","与密码相同","两次输入的密码不相同！");
            ChangeHope.WebPage.WebControl.SetDate(this.txtManageBeginTime);
            ChangeHope.WebPage.WebControl.SetDate(this.txtManageEndTime);
            ChangeHope.WebPage.WebControl.Validate(this.txtManageEndTime,"该管理员开始有管理权限的时间","isnull","必填","该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtManageBeginTime, "该管理员管理权限的过期时间", "isnull", "必填", "该项为必填项");
            this.Form.Attributes.Add("onsubmit","return CheckForm()");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            if (ChangeHope.Common.StringHelper.StringToDateTime(this.txtManageBeginTime.Text) > ChangeHope.Common.StringHelper.StringToDateTime(this.txtManageEndTime.Text))
            {
                this.ltlMsg.Text = "保存失败！开始时间大于结局时间。";
                this.pnlMsg.CssClass = "actionErr";
                return;
            }
            ShowShop.BLL.Admin.Administrators bll = new ShowShop.BLL.Admin.Administrators();
            Model.Admin.Administrators model = new ShowShop.Model.Admin.Administrators();
            try
            {
                model.AdminId = ChangeHope.Common.StringHelper.StringToInt(this.txtAdminId.Value);
                model.AllowModifyPassWord = this.ckbAllowModifyPassword.Checked ? 1 : 0;
                model.ManageBeginTime = ChangeHope.Common.StringHelper.StringToDateTime(this.txtManageBeginTime.Text);
                model.ManageEndTime = ChangeHope.Common.StringHelper.StringToDateTime(this.txtManageEndTime.Text);
                model.Name = this.txtName.Text;
                model.PassWord = this.txtPassword.Text;
                model.Power = ChangeHope.Common.StringHelper.StringToInt(this.ckbPower.SelectedValue);
                model.State = this.ckbState.Checked ? 1 : 0;
                if (model.AdminId > 0)
                {
                    bll.Update(model);
                }
                else
                {
                    model.Role = "";
                    this.txtAdminId.Value = bll.Add(model).ToString();
                }
                this.ltlMsg.Text = "保存成功！";
                this.pnlMsg.CssClass = "actionOk";

                if (this.txtAdminId.Value.Equals("0"))
                {
                    this.ltlMsg.Text = "保存失败！已经有相同的用户名存在";
                    this.pnlMsg.CssClass = "actionErr";
                }
                else
                {
                    this.txtName.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                this.ltlMsg.Text = "保存失败：<br/>" + ex.ToString();
                this.pnlMsg.CssClass = "actionErr";
            }
            finally
            {
                this.pnlMsg.Visible = true;
                bll = null;
                model = null;
            }
        }
    }
}
