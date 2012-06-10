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

namespace ShowShop.Web.admin.product
{
    public partial class express_edite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("004002002", "对不起，您没有权限进行编辑");
                ShowShop.Common.PromptInfo.Popedom("004002004", "对不起，您没有权限进行编辑");
                if (ChangeHope.WebPage.PageRequest.GetInt("id") > 0)
                {
                    BandInfo(ChangeHope.WebPage.PageRequest.GetInt("id"));
                }
                InitWebControl();
            }
        }

        #region 验证
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtName, "输入该快递公司的名称", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtFullName, "输入该快递公司的全称", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtAddress, "输入该快递公司的地址", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtPhone, "输入该快递公司的联系电话", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtPerson, "输入该快递公司的联系人", "isnull", "必填", "该项为必填项");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }
        #endregion

        /// <summary>
        /// 显示编辑信息
        /// </summary>
        /// <param name="id"></param>
        protected void BandInfo(int id)
        {
            ShowShop.BLL.Product.Express bll = new ShowShop.BLL.Product.Express();
            ShowShop.Model.Product.Express model = bll.GetModelByID(id);
            this.txtName.Text = model.Name;
            this.txtFullName.Text = model.FullName;
            this.txtAddress.Text = model.Address;
            this.txtPhone.Text = model.Phone;
            this.txtPerson.Text = model.Person;
            this.txtSort.Text = model.Sort.ToString();
            ViewState["ID"] = model.ID.ToString();
            ViewState["NumStr"] = model.Numstr;
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ShowShop.BLL.Product.Express bll = new ShowShop.BLL.Product.Express();
                ShowShop.Model.Product.Express model = new ShowShop.Model.Product.Express();
                model.Name = this.txtName.Text.Trim();
                model.FullName = this.txtFullName.Text.Trim();
                model.Address = this.txtAddress.Text.Trim();

                if (txtPhone.Text!="")
                {
                    if(!ChangeHope.Common.ValidateHelper.IsPhone(txtPhone.Text.Trim()))
                    {
                        this.ltlMsg.Text = "操作失败，请输入正确的电话号码。";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                model.Phone = this.txtPhone.Text.Trim();
                model.Person = this.txtPerson.Text.Trim();
                model.Sort = Convert.ToInt32(this.txtSort.Text.Trim());   
                if (ViewState["ID"] != null)//更新
                {
                    model.ID = Convert.ToInt32(ViewState["ID"].ToString());
                    model.Numstr = ViewState["NumStr"].ToString();
                    bll.Amend(model);
                }
                else//添加
                {
                    string str = DateTime.Now.ToFileTime().ToString();
                    Random rand = new Random();
                    model.Numstr = String.Format("YX{0}Ram{1}", str, rand.Next(10000, 99999));
                    bll.Add(model);
                }
                this.ltlMsg.Text = "操作成功，已保存该信息";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
            catch
            {
                this.ltlMsg.Text = "操作失败，请查看数据格式是否符合要求";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
            }

        }
    }
}
