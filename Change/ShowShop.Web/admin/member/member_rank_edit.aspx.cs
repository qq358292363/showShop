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
    public partial class member_rank_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitWebControl();
            if (!this.Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("008003002","对不起，您没有权限进行编辑");
                ShowShop.Common.PromptInfo.Popedom("008003004","对不起，您没有权限进行编辑");
                GetModel();
            }
        }
        private void GetModel()
        {
            int id = ChangeHope.WebPage.PageRequest.GetQueryInt("id");
            if(id>0)
            {
                ShowShop.BLL.Member.MemberRank bll = new ShowShop.BLL.Member.MemberRank();
                Model.Member.MemberRank model = bll.GetModel(id);
                this.txtDiscount.Text = model.Discount.ToString();
                this.txtId.Value = model.Id.ToString();
                this.txtLogoPicImg.ImageUrl ="/"+ model.LogoPic;
                this.txtLogoPicUrl.Value = model.LogoPic;
                this.txtMaxMoney.Text = model.MaxMoney.ToString();
                this.txtMaxScore.Text = model.MaxScore.ToString();
                this.txtMinScore.Text = model.MinScore.ToString();
                this.txtName.Text = model.Name;
                this.txtPriority.Text = model.Priority.ToString();
                this.txtUpgradeMoney.Text = model.UpgradeMoney.ToString();
                this.ckbIsUpgrade.SelectedValue = model.IsUpgrade.ToString();

                foreach (ListItem it in this.ckbOtherInfo.Items)
                {
                    if (it.Value.Equals("IsShowPrice") && model.IsShowPrice.Equals(1))
                    {
                        it.Selected = true;
                    }
                    if (it.Value.Equals("IsSpecial") && model.IsSpecial.Equals(1))
                    {
                        it.Selected = true;
                    }
                    if (it.Value.Equals("Article") && model.Article.Equals(1))
                    {
                        it.Selected = true;
                    }
                    if (it.Value.Equals("Product") && model.Product.Equals(1))
                    {
                        it.Selected = true;
                    }
                    if (it.Value.Equals("ArticleAuditing") && model.ArticleAuditing.Equals(1))
                    {
                        it.Selected = true;
                    }
                    if (it.Value.Equals("ProductAuditing") && model.ProductAuditing.Equals(1))
                    {
                        it.Selected = true;
                    }
                }

                bll = null;
                model = null;
            }

        }
        private void InitWebControl()
        {
            this.txtLogoPic.Attributes.Add("onchange", "ShowImg(this);");
            ChangeHope.WebPage.WebControl.Validate(this.txtName,"会员等级的名称，比如：普通会员，高级会员","isnull","必填","该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtMinScore, "该种类型的会员最低积分数", "isint", "必填", "该项为必填项,且必须为数字");
            ChangeHope.WebPage.WebControl.Validate(this.txtMaxScore, "该种类型的会员最高积分数", "isint", "必填", "该项为必填项,且必须为数字");
            ChangeHope.WebPage.WebControl.Validate(this.txtMaxMoney, "该种类型的会员每次可以购买商品的最大金额", "isint", "必填", "该项为必填项,且必须为数字");
            ChangeHope.WebPage.WebControl.Validate(this.txtUpgradeMoney, "该种类型的会员升级到下一等级需要的人民币数额", "isint", "必填", "该项为必填项,且必须为数字");
            ChangeHope.WebPage.WebControl.Validate(this.txtDiscount, "该种类型的会员的打折折扣是多少", "isint", "必填", "该项为必填项,且必须为数字");
            ChangeHope.WebPage.WebControl.Validate(this.txtPriority, "优先等级从低到高，则该数字由低到高，比如最低等级的该数字为1，最高级则不限", "isint", "必填", "该项为必填项,且必须为数字");
            this.Form.Attributes.Add("onsubmit", "return CheckForm();");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Sava();
        }
        private bool UploadFile()
        {
            ChangeHope.Common.UploadFile upload = new ChangeHope.Common.UploadFile();
            upload.PostedFile = this.txtLogoPic;
            upload.ExtensionLim = ".gif,.jpg";
            upload.FileLengthLim = 100;
            upload.SavePath = "yxuploadfile/memberrank";
            bool uploadSucess = upload.Upload();
            
            if (upload.Upload())
            {
                if (upload.HaveLoad)
                {
                    this.txtLogoPicImg.ImageUrl = upload.FilePath;
                    this.txtLogoPicUrl.Value = upload.FilePath;
                }
                else
                {
                    this.txtLogoPicImg.ImageUrl = this.txtLogoPicUrl.Value;
                }
            }
            else
            {
                this.txtLogoTip.CssClass = "msgError";
            }

            return uploadSucess;
            
        }
        private void Sava()
        {
            if (UploadFile())
            {
                ShowShop.BLL.Member.MemberRank bll = new ShowShop.BLL.Member.MemberRank();
                Model.Member.MemberRank model = new ShowShop.Model.Member.MemberRank();
                //model.Discount=(decimal)ChangeHope.Common.StringHelper.String2Double(this.txtDiscount.Text);
                model.Discount = Convert.ToDecimal(this.txtDiscount.Text);
                model.Id = ChangeHope.Common.StringHelper.StringToInt(this.txtId.Value);
                model.LogoPic = this.txtLogoPicUrl.Value;
                model.MaxMoney = (decimal)ChangeHope.Common.StringHelper.String2Double(this.txtMaxMoney.Text);
                model.MaxScore = (decimal)ChangeHope.Common.StringHelper.String2Double(this.txtMaxScore.Text);
                model.MinScore = (decimal)ChangeHope.Common.StringHelper.String2Double(this.txtMinScore.Text);
                model.Name = this.txtName.Text;
                model.Priority = ChangeHope.Common.StringHelper.StringToInt(this.txtPriority.Text);
                model.UpgradeMoney = (decimal)ChangeHope.Common.StringHelper.String2Double(this.txtUpgradeMoney.Text);
                model.IsUpgrade = ChangeHope.Common.StringHelper.StringToInt(this.ckbIsUpgrade.SelectedValue);
                model.IsShowPrice = 0;
                model.IsSpecial = 0;
                model.Product = 0;
                model.ProductAuditing = 0;
                model.Article = 0;
                model.ArticleAuditing = 0;
                foreach (ListItem it in this.ckbOtherInfo.Items)
                {
                    if (it.Selected)
                    {
                        if (it.Value.Equals("IsShowPrice"))
                        {
                            model.IsShowPrice = 1;
                        }
                        if (it.Value.Equals("IsSpecial"))
                        {
                            model.IsSpecial = 1;
                        }
                        if (it.Value.Equals("Article"))
                        {
                            model.Article = 1;
                        }
                        if (it.Value.Equals("Product"))
                        {
                            model.Product = 1;
                        }
                        if (it.Value.Equals("ArticleAuditing"))
                        {
                            model.ArticleAuditing = 1;
                        }
                        if (it.Value.Equals("ProductAuditing"))
                        {
                            model.ProductAuditing = 1;
                        }
                    }
                }
                if (model.Id > 0)
                {
                    bll.Update(model);
                    this.ltlMsg.Text = "操作成功，已保存该信息";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionOk";
                }
                else
                {
                    bll.Add(model);
                    this.txtName.Text = string.Empty;
                    this.ltlMsg.Text = "操作成功，已保存该信息";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionOk";
                }
                model = null;
                bll = null;
            }
            
        }
    }
}
