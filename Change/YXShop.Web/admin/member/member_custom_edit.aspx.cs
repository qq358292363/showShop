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
    public partial class member_custom_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("001003002", "对不起，您没有权限进行编辑");
                ShowShop.Common.PromptInfo.Popedom("001003004", "对不起，您没有权限进行编辑");
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
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            //this.txtProductClass.Attributes.Add("readonly", "readonly");
            //this.txtProductClass.Attributes.Add("onclick", "selectFile('Productclass',new Array(" + this.hfcid.ClientID + "," + this.txtProductClass.ClientID + "),310,450,'" + sp.DummyPaht + "');");
            ChangeHope.WebPage.WebControl.Validate(this.txtName, "输入商品的属性名称,您再添加商品时会自动加载该属性.", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtSort, "输入数字将作为显示的排列顺序", "isint", "必填", "该项为必填项");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }
        protected void BindInfo(int id)
        {
            ShowShop.BLL.Member.MemberPropety bll = new ShowShop.BLL.Member.MemberPropety();
            ShowShop.Model.Member.memberproperty model = bll.GetModelID(id);
            if (model != null)
            {
                //this.hfcid.Value = model.CID.ToString();
                this.txtName.Text = model.Filed;
                this.txtDataValue.Text = model.Datavalue;
                this.txtSort.Text = model.Sort.ToString();
                this.ddlType.SelectedValue = model.Type.ToString();
                this.rdolstIsRequire.SelectedValue = model.IsRequire.ToString();
                //this.txtProductClass.Text = MemberClassName(model.CID.ToString());
                if (model.Type.ToString() == "4" || model.Type.ToString() == "5")
                {
                    this.trDatavalue.Style.Value = "display:none";
                }
                ViewState["ID"] = model.ID;
            }

        }

        
        /// <summary>
        /// 获取分类名称
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        //protected string MemberClassName(string strId)
        //{
        //    string reStr = string.Empty;
        //    if (!string.IsNullOrEmpty(strId))
        //    {
        //        ShowShop.BLL.Member.Memberclass dll = new ShowShop.BLL.Member.Memberclass();
        //        DataTable dt = dll.GetMoreThanClassName(strId);
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            if (!string.IsNullOrEmpty(reStr))
        //            {
        //                reStr = reStr + "," + dt.Rows[i]["name"].ToString();
        //            }
        //            else
        //            {
        //                reStr = dt.Rows[i]["name"].ToString();
        //            }
        //        }
        //    }
        //    return reStr;
        //}
        private void Save()
        {
            ShowShop.BLL.Member.MemberPropety bll = new ShowShop.BLL.Member.MemberPropety();
            ShowShop.Model.Member.memberproperty model = new ShowShop.Model.Member.memberproperty();
            //model.CID = this.hfcid.Value != string.Empty ? this.hfcid.Value : "0";
            model.Filed = this.txtName.Text;
            model.Datavalue = this.txtDataValue.Text;
            model.IsRequire = ChangeHope.Common.StringHelper.StringToInt(this.rdolstIsRequire.SelectedValue);
            model.Type = ChangeHope.Common.StringHelper.StringToInt(this.ddlType.SelectedValue);
            model.Sort = ChangeHope.Common.StringHelper.StringToInt(this.txtSort.Text);
            if (ViewState["ID"] != null)
            {
                model.ID = ChangeHope.Common.StringHelper.StringToInt(ViewState["ID"].ToString());
                bll.Update(model);
                this.ltlMsg.Text = "操作成功，已保存该信息";
                this.BindInfo(ChangeHope.Common.StringHelper.StringToInt(ViewState["ID"].ToString()));
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
