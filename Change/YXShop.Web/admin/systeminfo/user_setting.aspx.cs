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
using System.Xml.XPath;
using System.Xml;

namespace ShowShop.Web.admin.systeminfo
{
    public partial class user_setting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!this.Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("010001009");
                InitWebControls();
                GetModel();
            }
        }
        private void GetModel()
        {
            ShowShop.BLL.SystemInfo.CustomerSetting bll = new ShowShop.BLL.SystemInfo.CustomerSetting();
            Model.SystemInfo.CustomerSetting model = bll.GetModel();
            if (model != null)
            {
                this.txtId.Value = model.SID.ToString();
                this.ckbAllowRegister.Text = model.AllowRegister;
                this.ckbSameEmailRegister.Text = model.SameEmailRegister.ToString();
                this.ckbAdminValidate.Text = model.AdminValidate.ToString();
                this.ckbEmailValidate.Text = model.EmailValidate.ToString();
                this.txtEmailValidateContent.Text = model.EmailValidateContent;
                this.ckbHandselCoupons.Text = model.HandselCoupons.ToString();
                this.txtHandselCouponsNumber.Text = model.HandselCouponsNumber.ToString();
                this.txtHandselCouponsBeginTime.Text = model.HandselCouponsBeginTime.ToString();
                this.txtHandselCouponsEndTime.Text = model.HandselCouponsEndTime.ToString();
                this.txtHandselPoint.Text = model.HandselPoint;
                this.txtForbidUserId.Text = model.ForbidUserId;
                this.ckbAnswerValidate.Text = model.AnswerValidate.ToString();
                this.txtQuestionFirst.Text = model.QuestionFirst;
                this.txtAnswerFirst.Text = model.AnswerFirst;
                this.txtQuestionSecond.Text = model.QuestionSecond;
                this.txtAnswerSecond.Text = model.AnswerSecond;
                this.ddlUserDefaultGroup.SelectedValue = model.UserDefaultGroup;
                this.ckbGetPasswordMethod.Text = model.GetPasswordMethod.ToString();
                this.txtLoginPoint.Text = model.LoginPoint.ToString();
                this.ckbLoginIsNeedCheckCode.Text = model.LoginIsNeedCheckCode.ToString();
                this.ckbAllowOtherLogin.Text = model.AllowOtherLogin.ToString();
                this.txtMoneyToCoupons.Text = model.MoneyToCoupons;
                this.txtMoneyToDate.Text = model.MoneyToDate;
                this.txtPointToCoupons.Text = model.PointToCoupons;
                this.txtPointToDate.Text = model.PointToDate;
                this.txtCouponsName.Text = model.CouponsName;
                this.txtCouponsUnits.Text = model.CouponsUnits;
                foreach (ListItem item in this.ckbRegisterRequired.Items)
                {
                    if (model.RegisterRequired.IndexOf(item.Value)>=0)
                    {
                        item.Selected=true;
                    }
                }
                foreach (ListItem item in this.ckbRegisterRequiredOptional.Items)
                {
                    if (model.RegisterRequiredOptional.IndexOf(item.Value)>=0)
                    {
                        item.Selected=true;
                    }
                }
                
            }
            bll = null;
            model = null;
        }
        private void InitWebControls()
        {
            ChangeHope.WebPage.WebControl.SetDropDownList(this.ddlUserDefaultGroup, "Id", "Name", "yxs_MemberRank");
            ChangeHope.WebPage.WebControl.Validate(this.txtEmailValidateContent, "用户验证用户邮箱是否具有有效性时，发送到用户邮箱中的内容，请在合适位置添加[@@hyperlink@@]标记，该标记表示一个连接，用户点击该连接后即可激活该帐号", "no", "", "");
            ChangeHope.WebPage.WebControl.Validate(this.txtHandselCouponsNumber, "新用户注册时赠送点券的数量，0表示不赠送", "isint", "数字", "该项填写的必须是一个整数");
            ChangeHope.WebPage.WebControl.SetDate(this.txtHandselCouponsBeginTime);
            ChangeHope.WebPage.WebControl.SetDate(this.txtHandselCouponsEndTime);
            ChangeHope.WebPage.WebControl.Validate(this.txtHandselPoint, "新会员注册后赠送的相应积分，不送积分则填写0", "isint", "数字验证", "该处填写的必须为数字");
            ChangeHope.WebPage.WebControl.Validate(this.txtLoginPoint, "会员每登陆该网站一次所赠送的积分数目，不赠送则填写0", "isint", "数字", "该处必须填写数字");
            ChangeHope.WebPage.WebControl.Validate(this.txtMoneyToCoupons, "每一元人民币能兑换该网站的点券数", "isint", "数字", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtMoneyToDate, "每一元人民币能兑换该网站的有效期", "isint", "数字", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtPointToCoupons, "多少积分能兑换本网站的1点点券", "isint", "数字", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtPointToDate, "多少积分能兑换本网站的1天有效期", "isint", "数字", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtCouponsName, "给您自己网站的点券起一个响亮的名字吧，比如QQB,易币", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtCouponsUnits, "点券的计量单位，比如：个，张，捆", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtHandselCouponsBeginTime,"注册赠送点券的时间段","isnull","必填","该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtHandselCouponsEndTime, "注册赠送点券的时间段", "isnull", "必填", "该项为必填项");
            this.Form.Attributes.Add("onsubmit", "return CheckForm();");
            InitRegisterInfo();
        }
        private void SaveRegisterInfo()
        {
            try
            {
                string AllowRegister = this.ckbAllowRegister.SelectedValue;
                int SameEmailRegister = int.Parse(this.ckbSameEmailRegister.SelectedValue);
                int AdminValidate = int.Parse(this.ckbAdminValidate.SelectedValue);
                int EmailValidate = int.Parse(this.ckbEmailValidate.SelectedValue);
                string EmailValidateContent = this.txtEmailValidateContent.Text;
                int HandselCoupons = int.Parse(this.ckbHandselCoupons.SelectedValue);
                if (txtHandselCouponsNumber.Text.Trim()!="")
                {
                    if (!ChangeHope.Common.ValidateHelper.IsNumber(txtHandselCouponsNumber.Text.Trim()))
                    {
                        this.ltlMsg.Text = "操作失败，点券数量必须是数字。";
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                if (txtHandselPoint.Text.Trim()!="")
                {
                    if (!ChangeHope.Common.ValidateHelper.IsNumber(txtHandselPoint.Text.Trim()))
                    {
                        this.ltlMsg.Text = "操作失败，积分数量必须是数字。";
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                if (txtLoginPoint.Text.Trim()!="")
                {
                    if (!ChangeHope.Common.ValidateHelper.IsNumber(txtLoginPoint.Text.Trim()))
                    {
                        this.ltlMsg.Text = "操作失败，登陆积分数量必须是数字。";
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                if (txtMoneyToCoupons.Text.Trim()!="")
                {
                    if (!ChangeHope.Common.ValidateHelper.IsNumber(txtMoneyToCoupons.Text.Trim()))
                    {
                        this.ltlMsg.Text = "操作失败，资金与点券兑换比必须是数字。";
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                    if(int.Parse(txtMoneyToCoupons.Text.Trim())<=0)
                    {
                        this.ltlMsg.Text = "操作失败，兑换点卷数量必须大于0。";
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                if (txtMoneyToDate.Text.Trim()!="")
                {
                    if (!ChangeHope.Common.ValidateHelper.IsNumber(txtMoneyToDate.Text.Trim()))
                    {
                        this.ltlMsg.Text = "操作失败，资金与有效期兑换比必须是数字。";
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                    if(int.Parse(txtMoneyToDate.Text.Trim())<=0)
                    {
                        this.ltlMsg.Text = "操作失败，兑换有效期数量必须大于0。";
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                if (txtPointToCoupons.Text.Trim()!="")
                {
                    if (!ChangeHope.Common.ValidateHelper.IsNumber(txtPointToCoupons.Text.Trim()))
                    {
                        this.ltlMsg.Text = "操作失败，积分与点券兑换比必须是数字。";
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                    if(int.Parse(txtPointToCoupons.Text.Trim())<=0)
                    {
                        this.ltlMsg.Text = "操作失败，积分兑换点卷数量必须大于0。";
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                if (txtPointToDate.Text.Trim()!="")
                {
                    if (!ChangeHope.Common.ValidateHelper.IsNumber(txtPointToDate.Text.Trim()))
                    {
                        this.ltlMsg.Text = "操作失败，积分与有效期兑换比必须是数字。";
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                    if(int.Parse(txtPointToDate.Text.Trim())<=0)
                    {
                        this.ltlMsg.Text = "操作失败，积分兑换有效期数量必须大于0。";
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                int HandselCouponsNumber = int.Parse(this.txtHandselCouponsNumber.Text);
                DateTime HandselCouponsBeginTime = DateTime.Parse(this.txtHandselCouponsBeginTime.Text);
                DateTime HandselCouponsEndTime = DateTime.Parse(this.txtHandselCouponsEndTime.Text);
                string HandselPoint = this.txtHandselPoint.Text;
                string ForbidUserId = this.txtForbidUserId.Text;
                int AnswerValidate = int.Parse(this.ckbAnswerValidate.Text);
                string QuestionFirst = this.txtQuestionFirst.Text;
                string AnswerFirst = this.txtAnswerFirst.Text;
                string QuestionSecond = this.txtQuestionSecond.Text;
                string AnswerSecond = this.txtAnswerSecond.Text;
                string UserDefaultGroup = this.ddlUserDefaultGroup.SelectedValue;
                int GetPasswordMethod = int.Parse(this.ckbGetPasswordMethod.SelectedValue);
                decimal LoginPoint = decimal.Parse(this.txtLoginPoint.Text);
                int LoginIsNeedCheckCode = int.Parse(this.ckbLoginIsNeedCheckCode.SelectedValue);
                int AllowOtherLogin = int.Parse(this.ckbAllowOtherLogin.SelectedValue);
                string MoneyToCoupons = this.txtMoneyToCoupons.Text;
                string MoneyToDate = this.txtMoneyToDate.Text;
                string PointToCoupons = this.txtPointToCoupons.Text;
                string PointToDate = this.txtPointToDate.Text;
                string CouponsName = this.txtCouponsName.Text;
                string CouponsUnits = this.txtCouponsUnits.Text;
                string RegisterRequired = "";
                string RegisterRequiredOptional = "";

                foreach (ListItem item in this.ckbRegisterRequired.Items)
                {
                    if (item.Selected)
                    {
                        RegisterRequired = RegisterRequired + "," + item.Value;
                    }
                }
                foreach (ListItem item in this.ckbRegisterRequiredOptional.Items)
                {
                    if (item.Selected)
                    {
                        RegisterRequiredOptional = RegisterRequiredOptional + "," + item.Value;
                    }
                }

                ShowShop.Model.SystemInfo.CustomerSetting model = new ShowShop.Model.SystemInfo.CustomerSetting();
                model.AllowRegister = AllowRegister;
                model.SameEmailRegister = SameEmailRegister;
                model.AdminValidate = AdminValidate;
                model.EmailValidate = EmailValidate;
                model.EmailValidateContent = EmailValidateContent;
                model.HandselCoupons = HandselCoupons;
                model.HandselCouponsNumber = HandselCouponsNumber;
                model.HandselCouponsBeginTime = HandselCouponsBeginTime;
                model.HandselCouponsEndTime = HandselCouponsEndTime;
                if (model.HandselCouponsEndTime < model.HandselCouponsBeginTime)
                {
                    this.ltlMsg.Text = "赠送积分的时间段开始时间大于了结束时间！";
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
                model.HandselPoint = HandselPoint;
                model.ForbidUserId = ForbidUserId;
                model.AnswerValidate = AnswerValidate;
                model.QuestionFirst = QuestionFirst;
                model.AnswerFirst = AnswerFirst;
                model.QuestionSecond = QuestionSecond;
                model.AnswerSecond = AnswerSecond;
                model.UserDefaultGroup = UserDefaultGroup;
                model.GetPasswordMethod = GetPasswordMethod;
                model.LoginPoint = LoginPoint;
                model.LoginIsNeedCheckCode = LoginIsNeedCheckCode;
                model.AllowOtherLogin = AllowOtherLogin;
                model.MoneyToCoupons = MoneyToCoupons;
                model.MoneyToDate = MoneyToDate;
                model.PointToCoupons = PointToCoupons;
                model.PointToDate = PointToDate;
                model.CouponsName = CouponsName;
                model.CouponsUnits = CouponsUnits;
                model.RegisterRequired = RegisterRequired;
                model.RegisterRequiredOptional = RegisterRequiredOptional;

                ShowShop.BLL.SystemInfo.CustomerSetting bll = new ShowShop.BLL.SystemInfo.CustomerSetting();
                if (ChangeHope.Common.StringHelper.StringToInt(this.txtId.Value) > 0)
                {
                    model.SID = ChangeHope.Common.StringHelper.StringToInt(this.txtId.Value);
                    bll.Update(model);
                }
                else
                {
                    bll.Add(model);
                }
                this.ltlMsg.Text = "操作成功！";
                this.pnlMsg.CssClass = "actionOk";

            }
            catch (Exception ex)
            {
                SaveRegisterInfo();
                this.ltlMsg.Text = ex.ToString();
                this.pnlMsg.CssClass = "actionErr";
            }
            finally
            {
                ChangeHope.Common.CacheClass.RemoveOneCache("CustomerSetting");
                this.pnlMsg.Visible = true;
            }
        }
        private void InitRegisterInfo()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Server.MapPath("../../App_Data/register_info.xml"));
            XmlNodeList nodeList = xml.SelectSingleNode("/MemberRegister/MemberInfo[@genre='Auto']").ChildNodes;
            foreach (XmlNode node in nodeList)
            {
                XmlElement xmlEle = node as XmlElement;
                if (xmlEle.GetAttribute("name") != "")
                {
                    this.ckbRegisterRequired.Items.Add(new ListItem(xmlEle.GetAttribute("value").ToString(), xmlEle.GetAttribute("name").ToString()));
                    this.ckbRegisterRequiredOptional.Items.Add(new ListItem(xmlEle.GetAttribute("value").ToString(), xmlEle.GetAttribute("name").ToString()));
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ShowShop.Common.PromptInfo.Popedom("010001013","对不起，您没有权限进行编辑");
            SaveRegisterInfo();
        }
    }
}
