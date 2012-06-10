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

namespace ShowShop.Web.admin.accessories
{
    public partial class commentform_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("012005002","对不起，您没有权限进行编辑");
                ShowShop.Common.PromptInfo.Popedom("012005004","对不起，您没有权限进行编辑");
                if (ChangeHope.WebPage.PageRequest.GetInt("id") > 0)
                {
                    BindInfo(ChangeHope.WebPage.PageRequest.GetInt("id"));
                }
                InitWebControl();
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
            ChangeHope.WebPage.WebControl.Validate(this.txtName, "输入评论项名称,您再制定点评表单时使用.", "isnull", "必填", "该项为必填项");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }
        protected void BindInfo(int id)
        {
            ShowShop.BLL.Accessories.CommentForm bll = new ShowShop.BLL.Accessories.CommentForm();
            ShowShop.Model.Accessories.CommentForm model = bll.GetModelID(id);
            if (model != null)
            {
                this.txtName.Text = model.Filed;
                this.txtDataValue.Text = model.Datavalue;
                this.ddlType.SelectedValue = model.Type.ToString();
                this.rdolstIsRequire.SelectedValue = model.IsRequire.ToString();
                if (model.Type.ToString() == "4" || model.Type.ToString() == "5")
                {
                    this.trDatavalue.Style.Value = "display:none";
                }
                ViewState["ID"] = model.ID;
            }

        }
        private void Save()
        {
            ShowShop.BLL.Accessories.CommentForm bll = new ShowShop.BLL.Accessories.CommentForm();
            ShowShop.Model.Accessories.CommentForm model = new ShowShop.Model.Accessories.CommentForm();
            model.Filed = this.txtName.Text;
            model.Datavalue = this.txtDataValue.Text;
            model.IsRequire = ChangeHope.Common.StringHelper.StringToInt(this.rdolstIsRequire.SelectedValue);
            model.Type = ChangeHope.Common.StringHelper.StringToInt(this.ddlType.SelectedValue);
            if (ViewState["ID"] != null)
            {
                model.ID = ChangeHope.Common.StringHelper.StringToInt(ViewState["ID"].ToString());
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

