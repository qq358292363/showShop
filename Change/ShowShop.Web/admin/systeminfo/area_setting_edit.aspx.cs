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
    public partial class area_setting_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("010004002","对不起，您没有权限进行编辑");
                ShowShop.Common.PromptInfo.Popedom("010004004","对不起，您没有权限进行编辑");
                InitWebControl();
                int id = ChangeHope.WebPage.PageRequest.GetInt("id");
                if (id > 0)
                {
                    GetModel();
                }
                else
                {
                    id = ChangeHope.WebPage.PageRequest.GetInt("parentid");
                    SetParentCity(id);
                }
                
            }
        }
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtCityEnglishName,"该省市的英文名称或者汉语拼音","isnull","必填","该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtCityName, "该省市的名称", "isnull", "必填", "该项为必填项");
            this.Form.Attributes.Add("onsubmit","return CheckForm()");
        }
        private void GetModel()
        {
            int id = ChangeHope.WebPage.PageRequest.GetInt("id");
            ShowShop.BLL.SystemInfo.Provinces bll = new ShowShop.BLL.SystemInfo.Provinces();
            Model.SystemInfo.Provinces model = bll.GetModel(id);
            if (model != null)
            {
                this.txtId.Value = model.Id.ToString();
                this.txtCityName.Text = model.CityName;
                this.txtCityEnglishName.Text = model.CityEnglishName;
                this.ckbIsUse.SelectedValue = model.IsUse.ToString();
                SetParentCity(ChangeHope.Common.StringHelper.StringToInt(model.ParentId.ToString()));
            }
            model = null;
            bll = null;
        }

        private void SetParentCity(int id)
        {
            ShowShop.BLL.SystemInfo.Provinces bll = new ShowShop.BLL.SystemInfo.Provinces();
            Model.SystemInfo.Provinces model = bll.GetModel(id);
            if (model != null)
            {
                this.ddlParentId.Items.Clear();
                this.ddlParentId.Items.Add(new ListItem( model.CityName+"["+model.CityEnglishName+"]",model.Id.ToString()));
                this.txtDepth.Value= (ChangeHope.Common.StringHelper.StringToInt(model.Depth.ToString()) + 1).ToString();
                this.txtParentPath.Value = model.ParentPath + ","+id;
            }
            else
            {
                this.ddlParentId.Items.Clear();
                this.ddlParentId.Items.Add(new ListItem("省、自治区、直辖市", "0"));
                this.txtDepth.Value = "1";
                this.txtParentPath.Value = "0";
            }
            model = null;
            bll = null;
           this.returnLink.NavigateUrl="area_setting.aspx?w_d_parentid=" +id;
           this.returnLinkBottom.NavigateUrl = "area_setting.aspx?w_d_parentid=" + id;
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            ShowShop.BLL.SystemInfo.Provinces bll = new ShowShop.BLL.SystemInfo.Provinces();
            Model.SystemInfo.Provinces model = new ShowShop.Model.SystemInfo.Provinces();
            try
            {
                model.AddDate = System.DateTime.Now;
                model.Child = 0;
                model.CityEnglishName = this.txtCityEnglishName.Text;
                model.CityName = this.txtCityName.Text;
                model.Depth = ChangeHope.Common.StringHelper.StringToInt(this.txtDepth.Value);
                model.Id = ChangeHope.Common.StringHelper.StringToInt(this.txtId.Value);
                model.IsUse = ChangeHope.Common.StringHelper.StringToInt(this.ckbIsUse.SelectedValue);

                model.ParentId = ChangeHope.Common.StringHelper.StringToInt(this.ddlParentId.SelectedValue);
                model.OrderID = bll.GetChildCount(model.ParentId.ToString());
                model.ParentPath = this.txtParentPath.Value;
                if (model.Id > 0)
                {
                    model.Child = bll.GetChildCount(model.Id.ToString());
                    bll.Update(model);
                }
                else
                {
                    this.txtId.Value = bll.Add(model).ToString();
                }
                model = null;
                bll = null;
                this.ltlMsg.Text = "保存成功！";
                this.pnlMsg.CssClass = "actionOk";
            }
            catch {
                this.ltlMsg.Text = "保存失败！";
                this.pnlMsg.CssClass = "actionErr";
            }
            finally {
                this.pnlMsg.Visible = true;
                model = null;
                bll = null;
            }

        }
    }
}
