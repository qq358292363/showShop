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
using ShowShop.BLL.Admin;

namespace ShowShop.Web.admin.systeminfo
{
    public partial class paymentmanage_edit : System.Web.UI.Page
    {
        ShowShop.BLL.SystemInfo.TerraceManage terraceBll = new ShowShop.BLL.SystemInfo.TerraceManage();
        string paytype = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("010002002","对不起，您没有权限进行编辑");
                ShowShop.Common.PromptInfo.Popedom("010002004","对不起，您没有权限进行编辑");
                InitWebControl();
                string payment_ID = ChangeHope.WebPage.PageRequest.GetQueryString("Payment_ID");
                paytype = ChangeHope.WebPage.PageRequest.GetQueryString("paytype");
                if (payment_ID != null && payment_ID != "")
                {
                    ShowShop.Model.SystemInfo.TerraceManage terc = terraceBll.GetModelById(Convert.ToInt32(payment_ID));
                    if (terc != null)
                    {
                        ViewState["PutoutID"] = terc.Tmputoutid;
                        ViewState["PutoutTypeID"] = terc.Tmputouttypeid;
                        this.txtName.Text = terc.Tmname;
                        switch (terc.Tmgarden)
                        {
                            case 1:

                                this.txtSellerId.Text = terc.Tmseller;
                                this.txtAccount.Text = terc.Tmaccount;
                                this.txtExpenses.Text = terc.Tmexpenses.ToString();
                                this.txtKey.Text = terc.Tmkey;
                                this.txtTaxis.Text = terc.Tmtaxis.ToString();
                                this.SelPayment.Value = terc.Tmgarden.ToString();
                                this.RdlSetup.SelectedValue = terc.Tmsetup.ToString();
                                this.txtPaymentDesc.Text = terc.Payment_description;

                                this.trPortType.Style.Add("display", "none");
                                break;
                            case 2:
                                this.txtSellerId.Text = terc.Tmseller;
                                this.txtAccount.Text = terc.Tmaccount;
                                this.txtExpenses.Text = terc.Tmexpenses.ToString();
                                this.txtKey.Text = terc.Tmkey;
                                this.txtTaxis.Text = terc.Tmtaxis.ToString();
                                this.SelPayment.Value = terc.Tmgarden.ToString();
                                this.RdlSetup.SelectedValue = terc.Tmsetup.ToString();
                                this.txtPaymentDesc.Text = terc.Payment_description;
                                this.ddlPortType.SelectedValue = terc.Porttype;
                                this.trPortType.Style.Add("display", "block");
                                break;
                            case 3:
                                this.txtSellerId.Text = terc.Tmseller;
                                this.txtAccount.Text = terc.Tmaccount;
                                this.txtExpenses.Text = terc.Tmexpenses.ToString();
                                this.txtKey.Text = terc.Tmkey;
                                this.txtTaxis.Text = terc.Tmtaxis.ToString();
                                this.SelPayment.Value = terc.Tmgarden.ToString();
                                this.RdlSetup.SelectedValue = terc.Tmsetup.ToString();
                                this.txtPaymentDesc.Text = terc.Payment_description;
                                this.trPortType.Style.Add("display", "none");
                                break;
                            case 4:
                                this.txtExpenses.Text = terc.Tmexpenses.ToString();
                                this.SelPayment.Value = terc.Tmgarden.ToString();
                                this.txtPaymentDesc.Text = terc.Payment_description;

                                this.trPortType.Style.Add("display", "none");
                                this.trAccount.Style.Add("display", "none");
                                this.trRdlSetup.Style.Add("display", "none");
                                this.trKey.Style.Add("display", "none");
                                this.trTaxis.Style.Add("display", "none");
                                this.trSellerId.Style.Add("display", "none");
                                this.txtAccount.Attributes.Remove("tip");
                                txtAccount.Attributes.Remove("validatetype");
                                txtAccount.Attributes.Remove("warning");
                                txtAccount.Attributes.Remove("error");
                                this.txtKey.Attributes.Remove("tip");
                                txtKey.Attributes.Remove("validatetype");
                                txtKey.Attributes.Remove("warning");
                                txtKey.Attributes.Remove("error");
                                this.txtTaxis.Attributes.Remove("tip");
                                txtTaxis.Attributes.Remove("validatetype");
                                txtTaxis.Attributes.Remove("warning");
                                txtTaxis.Attributes.Remove("error");
                                this.txtSellerId.Attributes.Remove("tip");
                                txtSellerId.Attributes.Remove("validatetype");
                                txtSellerId.Attributes.Remove("warning");
                                txtSellerId.Attributes.Remove("error");
                                break;
                            case 5:
                                this.txtExpenses.Text = terc.Tmexpenses.ToString();
                                this.SelPayment.Value = terc.Tmgarden.ToString();
                                this.txtPaymentDesc.Text = terc.Payment_description;

                                this.trPortType.Style.Add("display", "none");
                                this.trAccount.Style.Add("display", "none");
                                this.trRdlSetup.Style.Add("display", "none");
                                this.trKey.Style.Add("display", "none");
                                this.trTaxis.Style.Add("display", "none");
                                this.trSellerId.Style.Add("display", "none");
                                this.txtAccount.Attributes.Remove("tip");
                                txtAccount.Attributes.Remove("validatetype");
                                txtAccount.Attributes.Remove("warning");
                                txtAccount.Attributes.Remove("error");
                                this.txtKey.Attributes.Remove("tip");
                                txtKey.Attributes.Remove("validatetype");
                                txtKey.Attributes.Remove("warning");
                                txtKey.Attributes.Remove("error");
                                this.txtTaxis.Attributes.Remove("tip");
                                txtTaxis.Attributes.Remove("validatetype");
                                txtTaxis.Attributes.Remove("warning");
                                txtTaxis.Attributes.Remove("error");
                                this.txtSellerId.Attributes.Remove("tip");
                                txtSellerId.Attributes.Remove("validatetype");
                                txtSellerId.Attributes.Remove("warning");
                                txtSellerId.Attributes.Remove("error");
                                break;
                        }


                    }

                }
                else
                { 
                    if(paytype=="1" || paytype=="3")
                    {
                        this.trPortType.Style.Add("display", "none");
                        if (paytype == "1")
                        {
                            this.SelPayment.SelectedIndex = 0;
                        }
                        else { this.SelPayment.SelectedIndex = 2; }
                    }
                    else if (paytype == "2")
                    {
                        this.trPortType.Style.Add("display", "block");
                        this.SelPayment.SelectedIndex = 1;
                    }
                    else if (paytype == "4" || paytype == "5")
                    {
                        if (paytype == "4")
                        {
                            this.SelPayment.SelectedIndex =3;
                        }
                        else { this.SelPayment.SelectedIndex = 4; }

                        this.trPortType.Style.Add("display", "none");
                        this.trAccount.Style.Add("display", "none");
                        this.trRdlSetup.Style.Add("display", "none");
                        this.trKey.Style.Add("display", "none");
                        this.trTaxis.Style.Add("display", "none");
                        this.trSellerId.Style.Add("display", "none");
                        this.txtAccount.Attributes.Remove("tip");
                        txtAccount.Attributes.Remove("validatetype");
                        txtAccount.Attributes.Remove("warning");
                        txtAccount.Attributes.Remove("error");
                        this.txtKey.Attributes.Remove("tip");
                        txtKey.Attributes.Remove("validatetype");
                        txtKey.Attributes.Remove("warning");
                        txtKey.Attributes.Remove("error");
                        this.txtTaxis.Attributes.Remove("tip");
                        txtTaxis.Attributes.Remove("validatetype");
                        txtTaxis.Attributes.Remove("warning");
                        txtTaxis.Attributes.Remove("error");
                        this.txtSellerId.Attributes.Remove("tip");
                        txtSellerId.Attributes.Remove("validatetype");
                        txtSellerId.Attributes.Remove("warning");
                        txtSellerId.Attributes.Remove("error");
                    }
                    else
                    { this.trPortType.Style.Add("display", "none"); }
                }
            }
        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ShowShop.Model.Admin.AdminInfo adminInfo = (ShowShop.Model.Admin.AdminInfo)ShowShop.Common.AdministrorManager.Get();
            ShowShop.Model.SystemInfo.TerraceManage terrace = new ShowShop.Model.SystemInfo.TerraceManage();
            int id = ChangeHope.WebPage.PageRequest.GetQueryInt("Payment_ID");
            terrace.Tmname = this.txtName.Text.Trim().ToString();
            terrace.Tmseller = this.txtSellerId.Text.Trim().ToString();
            terrace.Tmgarden = Convert.ToInt32(this.SelPayment.Value);
            terrace.Tmexpenses = Convert.ToDecimal(this.txtExpenses.Text);
            terrace.Payment_description = this.txtPaymentDesc.Text.Trim().ToString();
            if(this.SelPayment.Value=="1" || this.SelPayment.Value=="3")
            {
                terrace.Tmkey = this.txtKey.Text.Trim().ToString();
                terrace.Tmaccount = this.txtAccount.Text.Trim().ToString();
                terrace.Tmtaxis = Convert.ToInt32(this.txtTaxis.Text.Trim());
                terrace.Tmsetup = Convert.ToInt32(this.RdlSetup.SelectedValue);
            }
            else if(this.SelPayment.Value=="2")
            {
                terrace.Porttype = this.ddlPortType.SelectedValue;
                terrace.Tmkey = this.txtKey.Text.Trim().ToString();
                terrace.Tmaccount = this.txtAccount.Text.Trim().ToString();
                terrace.Tmtaxis = Convert.ToInt32(this.txtTaxis.Text.Trim());
                terrace.Tmsetup = Convert.ToInt32(this.RdlSetup.SelectedValue);
            }
            terrace.Tmputoutid = ViewState["PutoutID"] == null ? 0 : Convert.ToInt32(ViewState["PutoutID"].ToString());
            terrace.Tmputouttypeid = ViewState["PutoutTypeID"] == null ? 0 : Convert.ToInt32(ViewState["PutoutTypeID"].ToString());
            if (Request["Payment_ID"] != null && Request["Payment_ID"] != "")
            {
                terrace.Tmid = Convert.ToInt32(Request.QueryString["Payment_ID"]);
                terraceBll.Update(terrace);
                ChangeHope.WebPage.BasePage.PageRight("操作成功，已修改该信息", "paymentmanage_list.aspx");
               
            }
            else
            {
                int count = terraceBll.Add(terrace);
                if (count > 0)
                {
                    ChangeHope.WebPage.BasePage.PageRight("操作成功，已保存该信息", "paymentmanage_edit.aspx?paytype=" + terrace.Tmgarden.ToString());
               
                }
            }
        }
        //验证
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtName,"请输入平台名称","isnull","必填","该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtSellerId, "请输入商户ID", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtAccount, "请输入商户的帐户", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtTaxis,"请输入排序号","isint","必填","该项必须为数字");
            ChangeHope.WebPage.WebControl.Validate(this.txtExpenses, "请输入手续费率","isfloat","必填","该项必须为数字");
            ChangeHope.WebPage.WebControl.Validate(this.txtKey, "请输入MD5密钥", "isnull", "必填", "该项为必填项");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }

        /// <summary>
        /// 获取支付平台类型
        /// </summary>
        /// <param name="type"></param>
        protected string  GetPayType(string type)
        {
            this.paytype = type;
           
                return paytype;
           
        }
       
    }
}
