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
using System.Collections.Generic;

namespace ShowShop.Web.admin.product
{
    public partial class productbrand_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = ChangeHope.WebPage.PageRequest.GetInt("id");
                if (id > 0)
                {
                    BandInfo(id);
                }
                InitWebControl();
                if (ViewState["ID"] != null)
                {
                    ShowShop.Common.PromptInfo.Popedom("001002004", "对不起，您没有权限进行编辑");
                }
                else
                {
                    ShowShop.Common.PromptInfo.Popedom("001002002", "对不起，您没有权限进行新增");
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
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            ChangeHope.WebPage.WebControl.Validate(this.txtName, "输入商品名称的名称,您可以对商品进行品牌归类", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtSort, "输入数字将作为显示的排列顺序", "isint", "必填", "该项为必填项");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }
        protected void BandInfo(int id)
        {
            ShowShop.BLL.Product.ProductBrand bll = new ShowShop.BLL.Product.ProductBrand();
            ShowShop.Model.Product.ProductBrand model = bll.GetModelID(id);
            this.txtName.Text = model.Name;
            this.txtSort.Text = model.Sort.ToString();
            ViewState["ID"] = model.ID;
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
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            ShowShop.BLL.Product.ProductBrand bll = new ShowShop.BLL.Product.ProductBrand();
            ShowShop.Model.Product.ProductBrand model = new ShowShop.Model.Product.ProductBrand();

            model.Name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(txtSort.Text.Trim()))
            {
                model.Sort = 0;
            }
            else
            {
                model.Sort = Convert.ToInt32(txtSort.Text.Trim());
            }
            if (ViewState["ID"] != null)
            {
                model.ID = int.Parse(ViewState["ID"].ToString());
                bll.Update(model);
                ChangeHope.WebPage.BasePage.PageRight("信息已修改。", "productbrand_list.aspx");
            }
            else
            {
                int bId = bll.Add(model);
                if (bId > 0)
                {
                    ChangeHope.WebPage.BasePage.PageRight("信息已保存，您还可以继续添加。", "productbrand_edit.aspx");
                }
            }
        }
    }
}
