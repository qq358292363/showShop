﻿using System;
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
    public partial class topsearchesseting_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("012004002","对不起，您没有权限进行编辑");
                ShowShop.Common.PromptInfo.Popedom("012004004","对不起，您没有权限进行编辑");
                InitWebControl();
                int id = ChangeHope.WebPage.PageRequest.GetQueryInt("id");
                if (id > 0)
                {
                    BindInfo(id);
                    ViewState["id"] = id;
                }
            }
        }

        #region 验证
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtName, "输入该热门搜索的词", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtSort, "输入数字做为该热门搜索词的排序", "isint", "必填", "该项必须为数字类型");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }
        #endregion

        #region 信息绑定
        protected void BindInfo(int id)
        {
            ShowShop.BLL.Accessories.Top_Searches tsbll = new ShowShop.BLL.Accessories.Top_Searches();
            ShowShop.Model.Accessories.Top_Searches tsmodel = tsbll.GetModelID(id);
            if (tsmodel != null)
            {
                this.txtName.Text = tsmodel.Name;
                this.txtSort.Text = tsmodel.Sort.ToString();
                this.rdolstIsShow.SelectedValue = tsmodel.IsShow.ToString();
            }
        }
        #endregion

        #region 保存信息
        protected void lbutSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void Save()
        {
            ShowShop.Model.Accessories.Top_Searches  tsmodel= new ShowShop.Model.Accessories.Top_Searches();
            ShowShop.BLL.Accessories.Top_Searches  tsbll= new ShowShop.BLL.Accessories.Top_Searches();
            tsmodel.Name = this.txtName.Text;
            tsmodel.Sort =int.Parse(this.txtSort.Text);
            tsmodel.IsShow =int.Parse(this.rdolstIsShow.SelectedValue);
            if (ViewState["id"] == null)
            {
                if (tsbll.Add(tsmodel) > 0)
                {
                    this.txtName.Text = string.Empty;
                    this.ltlMsg.Text = "操作成功，已保存该信息";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionOk";
                }
            }
            else
            {
                tsmodel.ID = Convert.ToInt32(ViewState["id"].ToString());
                if (tsbll.Update(tsmodel) > 0)
                {
                    this.ltlMsg.Text = "操作成功，已修改该信息";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionOk";
                }
            }
        }
        #endregion


    }
}
