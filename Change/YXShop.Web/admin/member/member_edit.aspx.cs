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

namespace ShowShop.Web.admin.member
{
    public partial class member_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("008002002", "对不起，您没有权限进行编辑");
                ShowShop.Common.PromptInfo.Popedom("008001004","对不起，您没有权限进行编辑");
                InitWebControl();            
                if (ChangeHope.WebPage.PageRequest.GetQueryInt("uid") > 0)
                {
                    int uid = ChangeHope.WebPage.PageRequest.GetQueryInt("uid");
                    GetAccount(uid);
                    GetInfo(uid);
                }
                
                
            }
        }

        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.SetDropDownList(this.ddlUserType, "code", "content", "yxs_code_usertype");
            ChangeHope.WebPage.WebControl.SetDropDownList(this.ddlUserGroup, "Id", "Name", "yxs_memberrank");
            ChangeHope.WebPage.WebControl.Validate(this.txtUserId,"会员帐号，该帐号一旦注册将无法进行改变。用户名长度必须为6~20个字符。","isnull_6_20","必填","该项为必填项");
            //kevin 12.12 改
            /*
             *添加时必须密码
             *修改时可选输入
             */         
            if (ChangeHope.WebPage.PageRequest.GetQueryInt("uid") > 0)
            {
                this.litPassword.Text = "用户密码，不输入则不修改密码，密码为6~20个字符串";
            }
            else
            {
                ChangeHope.WebPage.WebControl.Validate(this.txtPasswordRe, "用户密码，不输入则不修改密码，密码为6~20个字符串", "isnull", "", "");
            }           
            ChangeHope.WebPage.WebControl.Validate(this.txtPassword, "用户密码确认，必须与密码相一致", "compare", "与密码一致", "该项必须与密码一致");
            ChangeHope.WebPage.WebControl.Validate(this.txtEmail, "会员的邮件，用于发送一些与用户相关的信息，比如密码发送等。", "isemail", "邮件", "该项必须为邮件");
            ChangeHope.WebPage.WebControl.Validate(this.txtQuestion, "找回密码时候需要填写的问题", "isnull_3_20", "必填", "该项为必填项,字符限制在3至20字符之间");
            ChangeHope.WebPage.WebControl.Validate(this.txtAnswer, "找回密码时候需要填写的答案", "isnull_3_20", "必填", "该项为必填项,字符限制在3至20字符之间");
            ChangeHope.WebPage.WebControl.Validate(this.txtSigned, "用户的签名信息，该信息主要为防止钓鱼信息，用户需要填写自己的签名信息", "isnull_3_2000", "必填", "该项为必填项");
            this.Form.Attributes.Add("onsubmit", "return CheckForm();");
            
            //会员信息
            ChangeHope.WebPage.WebControl.SetDate(this.txtBirthday);
            ChangeHope.WebPage.WebControl.SetDropDownList(this.ddlSex,"code","content","yxs_code_sex");
            ChangeHope.WebPage.WebControl.SetDropDownList(this.ddlMarriage, "code", "content", "yxs_code_marriage");
            ChangeHope.WebPage.WebControl.SetDropDownList(this.ddlPapersType, "code", "content", "yxs_code_papers");
            ChangeHope.WebPage.WebControl.SetDropDownList(this.ddlEducation, "code", "content", "yxs_code_education");

            //联系方式
            this.ddlProvince.Attributes.Add("onchange", "GetCity('"+this.ddlCity.ClientID+"',this.value);");
            this.ddlCity.Attributes.Add("onchange", "GetCity('" + this.ddlBorough.ClientID + "',this.value);");
            this.lblScript.Text = "GetCity('" + this.ddlProvince.ClientID + "','0');\n";
        }

        #region 绑定信息
        private void GetInfo(int uid)
        {
            ShowShop.BLL.Member.MemberInfo bll = new ShowShop.BLL.Member.MemberInfo();
            ShowShop.Model.Member.MemberInfo model = bll.GetModel(uid);
            if (model != null)
            {
                this.ckbPrivacySettings.Checked = model.PrivacySettings==1?true:false;
                this.txtTrueName.Text = model.TrueName;
                this.txtTitle.Text = model.Title;
                //this.txtPhoto.Text = model.Photo;
                this.txtBirthday.Text = model.Birthday.ToString();
                this.ddlPapersType.SelectedValue = model.PapersType;
                this.txtPapersNumber.Text = model.PapersNumber;
                this.txtOrigin.Text = model.Origin;
                this.txtNation.Text = model.Nation;
                this.ddlSex.SelectedValue = model.Sex.ToString();
                this.ddlMarriage.SelectedValue = model.Marriage.ToString();
                this.ddlEducation.SelectedValue = model.Education;
                this.txtGraduateSchool.Text = model.GraduateSchool;
                this.lblScript.Text += "GetCity('" + this.ddlProvince.ClientID + "','0','" + model.Province + "');\n";
                this.lblScript.Text += "GetCity('" + this.ddlCity.ClientID + "','" + model.Province + "','" + model.City + "');\n";
                this.lblScript.Text += "GetCity('" + this.ddlBorough.ClientID + "','" + model.City + "','" + model.Borough + "');\n";
                this.txtAddress.Text = model.Address;
                this.txtZip.Text = model.Zip;
                this.txtOfficePhone.Text = model.OfficePhone;
                this.txtHomePhone.Text = model.HomePhone;
                this.txtMobilePhone.Text = model.MobilePhone;
                this.txtHandPhone.Text = model.HandPhone;
                this.txtFax.Text = model.Fax;
                this.txtPersonWebSite.Text = model.PersonWebSite;
                this.txtQQ.Text = model.QQ;
                this.txtMSN.Text = model.MSN;
                this.txtICQ.Text = model.ICQ;
                this.txtUC.Text = model.UC;
                this.txtLifeHobbies.Text = model.LifeHobbies;
                this.txtCultureHobbies.Text = model.CultureHobbies;
                this.txtEntertainment.Text = model.Entertainment;
                this.txtSportsHobbies.Text = model.SportsHobbies;
                this.txtOtherHobbies.Text = model.OtherHobbies;
                this.txtIncName.Text = model.IncName;
                this.txtDepartment.Text = model.Department;
                this.txtPositions.Text = model.Positions;
                this.txtWorkRange.Text = model.WorkRange;
                this.txtIncAddress.Text = model.IncAddress;
                this.txtMonthlyInCome.Text = model.MonthlyInCome;
                
            }
        }
        private void GetAccount(int uid)
        {
            
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.Model.Member.MemberAccount model = bll.GetModel(uid);
            if (model != null)
            {
                ViewState["uid"] = uid.ToString();
                this.ddlUserType.SelectedValue = model.UserType.ToString();
                this.ddlUserGroup.SelectedValue = model.UserGroup.ToString();
                this.txtUserId.Text = model.UserId;
                this.txtSigned.Text = model.Signed;
                this.txtQuestion.Text = model.Question;
                this.txtAnswer.Text = model.Answer;
                this.txtEmail.Text = model.Email;
                this.ckbState.Checked = model.State==1?true:false;
                this.txtUserId.ReadOnly = true;       
                ViewState["RegisterDate"] = model.RegisterDate.ToString();
                ViewState["RegisterIP"] = model.RegisterIP.ToString();
                ViewState["LastLoginDate"] = model.LastLoginDate.ToString();
                ViewState["LastLoginIP"] = model.LastLoginIP.ToString();
                ViewState["LoginTimes"] = model.LoginTimes.ToString();
                ViewState["Capital"] = model.Capital.ToString();
                ViewState["Coupons"] = model.Coupons.ToString();
                ViewState["Points"] = model.Points.ToString();
                ViewState["PeriodOfValidity"] = model.PeriodOfValidity.ToString();
                this.ltlMemberView.Text = "<a href='member_view.aspx?uid=" + model.UID.ToString() + "'>用户详细信息</a>";
            }
            model = null;
            bll = null;
        }
        #endregion

        private void SaveAccount()
        {
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.Model.Member.MemberAccount model = new ShowShop.Model.Member.MemberAccount();

            model.UserGroup = ChangeHope.Common.StringHelper.StringToInt(this.ddlUserGroup.SelectedValue);          
            model.UserId = this.txtUserId.Text;
            model.UserType = ChangeHope.Common.StringHelper.StringToInt(this.ddlUserType.SelectedValue);
            model.State = this.ckbState.Checked ? 1 : 0;
            model.Signed = this.txtSigned.Text;
            model.Question = this.txtQuestion.Text;
            model.PassWord = this.txtPassword.Text;
            model.Answer = txtAnswer.Text;
            model.Email = txtEmail.Text;

            if (ViewState["uid"] != null)
            {
                model.UID = Convert.ToInt32(ViewState["uid"].ToString());
                model.RegisterDate = Convert.ToDateTime(ViewState["RegisterDate"].ToString());
                model.RegisterIP = ViewState["RegisterIP"].ToString();
                model.LastLoginDate = Convert.ToDateTime(ViewState["LastLoginDate"].ToString());
                model.LastLoginIP = ViewState["LastLoginIP"].ToString();
                model.LoginTimes = Convert.ToInt32(ViewState["LoginTimes"].ToString());
                model.Capital = Convert.ToDecimal(ViewState["Capital"].ToString());
                model.Coupons = Convert.ToDecimal(ViewState["Coupons"].ToString());
                model.Points = Convert.ToDecimal(ViewState["Points"].ToString());
                model.PeriodOfValidity = Convert.ToDateTime(ViewState["PeriodOfValidity"].ToString());
                bll.Update(model);
            }
            else
            {
                model.RegisterDate = DateTime.Now;
                model.RegisterIP = Request.UserHostAddress;
                model.LastLoginDate = DateTime.Now;
                model.LastLoginIP = Request.UserHostAddress;
                model.LoginTimes = 0;
                model.Capital = 0;
                model.Coupons = 0;
                model.Points = 0;
                model.PeriodOfValidity = DateTime.Now;
                bll.Add(model);
            }

        }
        private void SaveInfo()
        {
            ShowShop.BLL.Member.MemberAccount abll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.BLL.Member.MemberInfo bll = new ShowShop.BLL.Member.MemberInfo();
            Model.Member.MemberInfo model = new ShowShop.Model.Member.MemberInfo();
            try
            {
                model.PrivacySettings = ckbPrivacySettings.Checked?1:0;
                model.TrueName = txtTrueName.Text;
                model.Title = txtTitle.Text;
                model.Photo = "";//txtPhoto.Text;
                model.Birthday = ChangeHope.Common.StringHelper.StringToDateTime(txtBirthday.Text);
                model.PapersType = ddlPapersType.SelectedValue;
                model.PapersNumber = txtPapersNumber.Text;
                model.Origin = txtOrigin.Text;
                model.Nation = txtNation.Text;
                model.Sex = ChangeHope.Common.StringHelper.StringToInt(ddlSex.SelectedValue);
                model.Marriage = ChangeHope.Common.StringHelper.StringToInt(ddlMarriage.SelectedValue);
                model.Education = ddlEducation.SelectedValue;
                model.GraduateSchool = txtGraduateSchool.Text;
                model.Province = ChangeHope.WebPage.PageRequest.GetFormString("ctl00$workspace$ddlProvince");
                model.City = ChangeHope.WebPage.PageRequest.GetFormString("ctl00$workspace$ddlCity");
                model.Borough = ChangeHope.WebPage.PageRequest.GetFormString("ctl00$workspace$ddlBorough");
                model.Address = txtAddress.Text;
                /*kevin 12.12 修改*/
                if (txtZip.Text != "")
                {
                    if (!ChangeHope.Common.ValidateHelper.IsSend(txtZip.Text.Trim()))
                    {
                        this.ltlMsg.Text = "请输入正确的邮政编码";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                if (txtOfficePhone.Text != "")
                {
                    if (!ChangeHope.Common.ValidateHelper.IsPhone(txtOfficePhone.Text))
                    {
                        this.ltlMsg.Text = "请输入正确的电话号码";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                if (txtMobilePhone.Text != "")
                {
                    if (!ChangeHope.Common.ValidateHelper.IsMobilePhone(txtMobilePhone.Text))
                    {
                        this.ltlMsg.Text = "请输入正确的手机号码";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                if (txtHomePhone.Text != "")
                {
                    if (!ChangeHope.Common.ValidateHelper.IsPhone(txtHomePhone.Text))
                    {
                        this.ltlMsg.Text = "请输入正确的住宅电话号码";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                if (txtHandPhone.Text != "")
                {
                    if (!ChangeHope.Common.ValidateHelper.IsPhone(txtHandPhone.Text))
                    {
                        this.ltlMsg.Text = "请输入正确的小灵通号码";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                if (txtFax.Text != "")
                {
                    if (!ChangeHope.Common.ValidateHelper.IsPhone(txtFax.Text))
                    {
                        this.ltlMsg.Text = "请输入正确的传真号码";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                if (txtQQ.Text != "")
                {
                    if (!ChangeHope.Common.ValidateHelper.IsNumber(txtQQ.Text) || txtQQ.Text.Length < 5 || txtQQ.Text.Length > 13)
                    {
                        this.ltlMsg.Text = "请输入正确的QQ号码";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                if (txtUC.Text != "")
                {
                    if (!ChangeHope.Common.ValidateHelper.IsNumber(txtUC.Text) || txtUC.Text.Length < 5 || txtUC.Text.Length > 13)
                    {
                        this.ltlMsg.Text = "请输入正确的UC号码";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                model.Zip = txtZip.Text;
                model.OfficePhone = txtOfficePhone.Text;
                model.HomePhone = txtHomePhone.Text;
                model.MobilePhone = txtMobilePhone.Text;
                model.HandPhone = txtHandPhone.Text;
                model.Fax = txtFax.Text;
                model.PersonWebSite = txtPersonWebSite.Text;
                model.QQ = txtQQ.Text;
                model.MSN = txtMSN.Text;
                model.ICQ = txtICQ.Text;
                model.UC = txtUC.Text;
                model.LifeHobbies = txtLifeHobbies.Text;
                model.CultureHobbies = txtCultureHobbies.Text;
                model.Entertainment = txtEntertainment.Text;
                model.SportsHobbies = txtSportsHobbies.Text;
                model.OtherHobbies = txtOtherHobbies.Text;
                model.IncName = txtIncName.Text;
                model.Department = txtDepartment.Text;
                model.Positions = txtPositions.Text;
                model.WorkRange = txtWorkRange.Text;
                model.IncAddress = txtIncAddress.Text;
                model.MonthlyInCome = txtMonthlyInCome.Text;              
                if (bll.Exists(Convert.ToInt32(ViewState["uid"].ToString())) && ViewState["uid"] != null)
                {
                    model.UID = Convert.ToInt32(ViewState["uid"].ToString());
                    bll.Update(model);
                }
                else
                {
                    model.UID = GetIdByUserId(this.txtUserId.Text.Trim());
                    bll.Add(model);
                }
                this.ltlMsg.Text = "编辑信息成功";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
            catch { }
            finally
            {
                model = null;
                bll = null;
            }
        }
        /// <summary>
        /// 根据账号得到自增ID
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        protected int GetIdByUserId(string UserId)
        {
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.Model.Member.MemberAccount model = bll.GetModel(UserId);
            if (model != null)
            {
                return model.UID;
            }
            else
            {
                return -1;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ViewState["uid"] == null)
            {
                ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
                if (bll.Exists(this.txtUserId.Text.Trim()))
                {
                    this.ltlMsg.Text = "该用户已经存在";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
            }
            try
            {
                SaveAccount();
                SaveInfo();
               
            }
            catch (Exception)
            {
                this.ltlMsg.Text = "操作失败";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
            }
           
            //if (ViewState["uid"] != null)
            //{
            //    this.Response.Redirect("member_edit.aspx?uid=" + ViewState["uid"].ToString());
            //}
            //else
            //{
            //    this.ltlMsg.Text = "添加成功，您可以继续添加该用户其它信息，或者返回列表";
            //    this.pnlMsg.Visible = true;
            //    this.pnlMsg.CssClass = "actionOk";
            //    return;
            //}
        }
        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (ViewState["uid"] == null)
        //    {
        //        ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
        //        if (bll.Exists(this.txtUserId.Text.Trim()))
        //        {
        //            this.ltlMsg.Text = "该用户已经存在";
        //            this.pnlMsg.Visible = true;
        //            this.pnlMsg.CssClass = "actionErr";
        //            return;
        //        }
        //    }
        //    SaveAccount();
        //    SaveInfo();
        //    if (ViewState["uid"] != null)
        //    {
        //        this.Response.Redirect("member_edit.aspx?uid=" + ViewState["uid"].ToString());
        //    }
        //    else
        //    {
        //        this.ltlMsg.Text = "添加成功，您可以继续添加该用户其它信息，或者返回列表";
        //        this.pnlMsg.Visible = true;
        //        this.pnlMsg.CssClass = "actionOk";
        //        return;
        //    }
        //}
    }
}
