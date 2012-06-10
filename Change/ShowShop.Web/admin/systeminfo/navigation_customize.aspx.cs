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
using ShowShop.BLL;

namespace ShowShop.Web.admin.systeminfo
{
    public partial class navigation_customize : System.Web.UI.Page
    {
        ShowShop.BLL.SystemInfo.ArticleChannel bllarticle = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("001002002", "对不起，您没有权限进行编辑");
                ShowShop.Common.PromptInfo.Popedom("001002004", "对不起，您没有权限进行编辑");
                if (ChangeHope.WebPage.PageRequest.GetInt("id") > 0)
                {
                    BandInfo(ChangeHope.WebPage.PageRequest.GetInt("id"));
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
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            this.txtContentRegion1.Attributes.Add("readonly", "readonly");
            this.txtContentRegion1.Attributes.Add("onclick", "selectFile('Productclass',new Array(" + this.hfcConentRegion1.ClientID + "," + this.txtContentRegion1.ClientID + "),310,450,'" + sp.DummyPaht + "');");
            ChangeHope.WebPage.WebControl.Validate(this.txtField, "输入导航的名称", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtSort, "输入数字将作为显示的排列顺序", "isint", "必填", "该项为必填项");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
            this.txtContentRegion1.Attributes.Add("readonly", "readonly");

            ShowShop.Common.SysParameter sp2 = new ShowShop.Common.SysParameter();
            this.txtContentRegion2.Attributes.Add("readonly", "readonly");
            this.txtContentRegion2.Attributes.Add("onclick", "selectFile('Productclass',new Array(" + this.hfcContentRegion2.ClientID + "," + this.txtContentRegion2.ClientID + "),310,450,'" + sp2.DummyPaht + "');");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
            this.txtContentRegion2.Attributes.Add("readonly", "readonly");

            bllarticle= new ShowShop.BLL.SystemInfo.ArticleChannel();
            string channelid = ChangeHope.WebPage.PageRequest.GetQueryString("channelid");
            bllarticle.GetDropList(this.ddlContentRegion3, channelid);

            //ShowShop.Common.SysParameter sp3 = new ShowShop.Common.SysParameter();
            //this.ddlContentRegion3.Attributes.Add("readonly", "readonly");
            //this.ddlContentRegion3.Attributes.Add("onclick", "selectFile('Productclass',new Array(" + this.hfcContentRegion3.ClientID + "," + this.ddlContentRegion3.ClientID + "),310,450,'" + sp3.DummyPaht + "');");
            
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
            this.ddlContentRegion3.Attributes.Add("readonly", "readonly");
        }
        protected void BandInfo(int id)
        {
            ShowShop.BLL.SystemInfo.Navigation bll = new ShowShop.BLL.SystemInfo.Navigation();
            ShowShop.Model.SystemInfo.Navigation model = bll.GetModelID(id);
            bllarticle = new ShowShop.BLL.SystemInfo.ArticleChannel();
            if (model.Type == 1)
            {
                this.rdtype1.Checked = true;
                this.txtContentRegion1.Text = model.Contentregion;
                this.txtContentRegion2.Text = model.Contentregion;
                this.ddlContentRegion3.SelectedValue = bllarticle.GetArticleName(model.Contentregion);

            }
            else if (model.Type == 2)
            {
                this.rdtype2.Checked = true;
                this.txtContentRegion1.Text = model.Contentregion;
                this.txtContentRegion2.Text = model.Contentregion;
                this.ddlContentRegion3.SelectedValue = bllarticle.GetArticleName(model.Contentregion);

            }
            else if (model.Type == 3)
            {
                this.rdtype3.Checked = true;
                this.txtContentRegion1.Text = model.Contentregion;
                this.txtContentRegion2.Text = model.Contentregion;
                this.ddlContentRegion3.SelectedValue = bllarticle.GetArticleName(model.Contentregion);
            }
            this.txtField.Text = model.Filed;
            this.txtLink.Text = model.Link;
            this.txtSort.Text = model.Sort.ToString();
            if (model.Isshow == 1)
            {
                this.ddlIsShow.SelectedIndex = 0;
            }
            else
            {
                this.ddlIsShow.SelectedIndex = 1;
            }
            if (model.Isnewwindow == 1)
            {
                this.ddlIsNewWindow.SelectedIndex = 0;
            }
            else
            {
                this.ddlIsNewWindow.SelectedIndex = 1;
            }
            if (model.Part == 1)
            {
                this.ddlPart.SelectedIndex = 0;
            }
            else if (model.Part == 2)
            {
                this.ddlPart.SelectedIndex = 1;
            }
            else
            {
                this.ddlPart.SelectedIndex = 2;
            }
                ViewState["ID"] = model.Id;
        }
        /// <summary>
        /// 获取分类名称
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        protected string ProductClassName(string strId)
        {
            string reStr = string.Empty;
            if (!string.IsNullOrEmpty(strId))
            {
                ShowShop.BLL.Product.Productclass dll = new ShowShop.BLL.Product.Productclass();
                DataTable dt = dll.GetMoreThanClassName(strId);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(reStr))
                    {
                        reStr = reStr + "," + dt.Rows[i]["name"].ToString();
                    }
                    else
                    {
                        reStr = dt.Rows[i]["name"].ToString();
                    }
                }
            }
            return reStr;
        }
        /// <summary>
        /// 保存信息
        /// </summary>
        protected void Save()
        {
            ShowShop.BLL.SystemInfo.Navigation bll = new ShowShop.BLL.SystemInfo.Navigation();
            ShowShop.Model.SystemInfo.Navigation model = new ShowShop.Model.SystemInfo.Navigation();
            bllarticle = new ShowShop.BLL.SystemInfo.ArticleChannel();
            //model.Id = !string.IsNullOrEmpty(hfcid.Value.Trim()) ? hfcid.Value.Trim() : "0";
            model.Filed = this.txtField.Text.Trim();
            if (this.rdtype1.Checked && !string.IsNullOrEmpty(txtContentRegion1.Text))
            {
                model.Type = 1;
                model.Contentregion = txtContentRegion1.Text;
            }
            else if (this.rdtype2.Checked && !string.IsNullOrEmpty(txtContentRegion2.Text))
            {
                model.Type = 2;
                model.Contentregion = txtContentRegion2.Text;
            }
            else if (this.rdtype3.Checked && !string.IsNullOrEmpty(ddlContentRegion3.SelectedValue))
            {
                model.Type = 3;
                model.Contentregion = bllarticle.GetArticleName(ddlContentRegion3.SelectedValue);//把id转换成导航类型
            }

    
            model.Isshow = ChangeHope.Common.StringHelper.StringToInt(this.ddlIsShow.SelectedValue);
            model.Isnewwindow = ChangeHope.Common.StringHelper.StringToInt(this.ddlIsNewWindow.SelectedValue);
            model.Sort = ChangeHope.Common.StringHelper.StringToInt(txtSort.Text.Trim());
            model.Part = ChangeHope.Common.StringHelper.StringToInt(ddlPart.SelectedValue);
            model.Link = this.txtLink.Text;
            
            if (ViewState["ID"] != null)
            {
                model.Id = int.Parse(ViewState["ID"].ToString());
                bll.Update(model);
                //BandInfo(int.Parse(ViewState["ID"].ToString()));
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

        protected void ddlContentRegion3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddlContentRegion3.SelectedValue = this.ddlContentRegion3.SelectedItem.Value;
        }
    }
}
