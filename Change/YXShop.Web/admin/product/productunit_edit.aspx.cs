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
    public partial class productunit_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
              
                if (ChangeHope.WebPage.PageRequest.GetInt("id") > 0)
                {
                    BandInfo(ChangeHope.WebPage.PageRequest.GetInt("id"));
                }
                InitWebControl();

                if (ViewState["ID"] != null)
                {
                     ShowShop.Common.PromptInfo.Popedom("001004004","对不起，您没有权限进行编辑");
                }
                else
                {
                    ShowShop.Common.PromptInfo.Popedom("001004002", "对不起，您没有权限进行新增");
                }
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Save();
        }
        /// <summary>
        /// 验证
        /// </summary>
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtName, "输入商品名称的名称,您可以对商品进行品牌归类", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtSort, "输入数字将作为显示的排列顺序", "isint", "必填", "该项为必填项");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }

        protected void BandInfo(int id)
        {
            ShowShop.BLL.Product.ProductUnit bll = new ShowShop.BLL.Product.ProductUnit();
            ShowShop.Model.Product.ProductUnit model = bll.GetModelID(id);
            this.txtName.Text = model.Name;
            this.txtSort.Text = model.Sort.ToString();
            ViewState["ID"] = model.ID;
        }
        protected void Save()
        {
            ShowShop.BLL.Product.ProductUnit bll = new ShowShop.BLL.Product.ProductUnit();
            ShowShop.Model.Product.ProductUnit model = new ShowShop.Model.Product.ProductUnit();
            model.Name = txtName.Text.Trim();
            model.Sort = ChangeHope.Common.StringHelper.StringToInt(txtSort.Text.Trim());
            if (ViewState["ID"] != null)
            {
                model.ID = int.Parse(ViewState["ID"].ToString());
                bll.Update(model);
                this.ltlMsg.Text = "操作成功，已保存该信息";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
            else
            {
                bll.Add(model);
                this.ltlMsg.Text = "操作成功，已保存该信息";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
        }
    }
}
