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
    public partial class deliver_edite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("004001002","对不起，您没有权限进行编辑");
                ShowShop.Common.PromptInfo.Popedom("004001004","对不起，您没有权限进行编辑");
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
            ChangeHope.WebPage.WebControl.Validate(this.txtName, "输入该送货方式的名称", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtInceptPrice, "输入送货方式的价格(元)", "isint", "必填", "必须为数字");
            ChangeHope.WebPage.WebControl.Validate(this.txtInceptWeight, "输入重量(千克)", "isint", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtAddPricelAdder, "例如每增加一千克需要增加的配送费用", "isint", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtAddWeightlAdder, "例如是每增加一千克还是十千克才会<br/>增加一个价格等级", "isint", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtDescription, "输入对该送货方式的描述", "isnull", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtSort, "输入数字做为该送货方式的排序", "isint", "必填", "该项必须为数字类型");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }
        #endregion

        /// <summary>
        /// 显示编辑信息
        /// </summary>
        /// <param name="id"></param>
        protected void BandInfo(int id)
        {
            ShowShop.BLL.Product.Deliver bll = new ShowShop.BLL.Product.Deliver();
            ShowShop.Model.Product.Deliver model = bll.GetModelByID(id);
            this.txtName.Text = model.Name;         
            this.txtInceptPrice.Text = model.InceptPrice.ToString();
            this.txtInceptWeight.Text = model.InceptWeight.ToString();
            this.rblArrivePay.SelectedValue = model.ArrivePay.ToString();
            this.txtDescription.Text = model.Description;
            this.txtAddPricelAdder.Text = model.AddPriceLadder.ToString();
            this.txtAddWeightlAdder.Text = model.AddWeightLadder.ToString();
            this.rblIsSpecial.SelectedValue = model.IsSpecial.ToString();
            this.rblisused.SelectedValue = model.IsUsed.ToString();
            this.txtSort.Text = model.Sort.ToString();
            string[] str = model.BoundPrice.Split('|');
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0)
                {
                    string[] arr0 = str[i].Split(',');
                    for (int j = 0; j < arr0.Length; j++)
                    {
                        this.txtBoundU1.Text = arr0[0];
                        this.txtBoundD1.Text = arr0[1];
                        this.txtBoundP1.Text = arr0[2];
                    }
                }
                else if(i==1)
                {
                    string[] arr1 = str[i].Split(',');
                    for (int j = 0; j < arr1.Length; j++)
                    {
                        this.txtBoundU2.Text = arr1[0];
                        this.txtBoundD2.Text = arr1[1];
                        this.txtBoundP2.Text = arr1[2];
                    }
                }
                else if (i == 2)
                {
                    string[] arr2 = str[i].Split(',');
                    for (int j = 0; j < arr2.Length; j++)
                    {
                        this.txtBoundU3.Text = arr2[0];
                        this.txtBoundD3.Text = arr2[1];
                        this.txtBoundP3.Text = arr2[2];
                    }
                }
                else if (i == 3)
                {
                    string[] arr3 = str[i].Split(',');
                    for (int j = 0; j < arr3.Length; j++)
                    {
                        this.txtBoundU4.Text = arr3[0];
                        this.txtBoundD4.Text = arr3[1];
                        this.txtBoundP4.Text = arr3[2];
                    }
                }
            }
           
            ViewState["ID"] = model.ID.ToString();
            ViewState["PutoutID"] = model.PutoutId.ToString();
            ViewState["PutoutTyID"] = model.PutouttyId.ToString();
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            //try
            //{
                ShowShop.BLL.Product.Deliver bll = new ShowShop.BLL.Product.Deliver();
                ShowShop.Model.Product.Deliver model = new ShowShop.Model.Product.Deliver();
                if (!ChangeHope.Common.ValidateHelper.IsMoney(txtInceptPrice.Text) || !ChangeHope.Common.ValidateHelper.IsNumber(txtInceptWeight.Text) || !ChangeHope.Common.ValidateHelper.IsMoney(txtAddPricelAdder.Text) || !ChangeHope.Common.ValidateHelper.IsMoney(txtAddWeightlAdder.Text) || !ChangeHope.Common.ValidateHelper.IsNumber(txtBoundU1.Text) || !ChangeHope.Common.ValidateHelper.IsNumber(txtBoundD1.Text) || !ChangeHope.Common.ValidateHelper.IsMoney(txtBoundP1.Text))
                {
                    this.ltlMsg.Text = "操作失败，请输入正确的价格或者数字";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
                if (float.Parse(txtInceptPrice.Text) <= 0 || float.Parse(txtInceptWeight.Text) <= 0 || float.Parse(txtAddPricelAdder.Text) <= 0 || float.Parse(txtAddWeightlAdder.Text) <= 0 || float.Parse(txtBoundU1.Text) <= 0 || float.Parse(txtBoundD1.Text) <= 0 || float.Parse(txtBoundP1.Text)<=0 )
                {
                    this.ltlMsg.Text = "操作失败，价格与重量数不能小于或者等于0";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
                model.Name = this.txtName.Text.Trim();
                model.InceptPrice = Convert.ToDecimal(this.txtInceptPrice.Text.Trim());
                model.InceptWeight = Convert.ToDecimal(this.txtInceptWeight.Text.Trim());
                model.ArrivePay = Convert.ToInt32(this.rblArrivePay.SelectedValue);
                model.Description = this.txtDescription.Text.Trim();
                model.AddPriceLadder = Convert.ToDecimal(this.txtAddPricelAdder.Text.Trim());
                model.AddWeightLadder = Convert.ToDecimal(this.txtAddWeightlAdder.Text.Trim());
                model.BoundPrice = GetBoundPrice();
                model.IsSpecial = Convert.ToInt32(this.rblIsSpecial.SelectedValue);
                model.IsUsed = Convert.ToInt32(this.rblisused.SelectedValue);
                model.Sort = Convert.ToInt32(this.txtSort.Text.Trim());
                if (ViewState["ID"] != null)//更新
                {
                    model.ID = Convert.ToInt32(ViewState["ID"].ToString());
                    model.PutoutId = Convert.ToInt32(ViewState["PutoutID"]);
                    model.PutouttyId = Convert.ToInt32(ViewState["PutoutTyID"]);
                    bll.Amend(model);
                }
                else//添加
                {
                    ShowShop.Model.Admin.AdminInfo adminModel = (ShowShop.Model.Admin.AdminInfo)ShowShop.Common.AdministrorManager.Get();
                    //管理员ID
                    model.PutoutId = adminModel.AdminId;
                    model.PutouttyId = 0;
                    bll.Add(model);
                }
                this.ltlMsg.Text = "操作成功，已保存该信息";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            //}
            //catch
            //{
            //    this.ltlMsg.Text = "操作失败，请查看数据格式是否符合要求";
            //    this.pnlMsg.Visible = true;
            //    this.pnlMsg.CssClass = "actionErr";
            //}

        }

        protected string GetBoundPrice()
        {
            string price = string.Empty;
            price += this.txtBoundU1.Text.Trim() + "," + this.txtBoundD1.Text.Trim() + "," + this.txtBoundP1.Text.Trim() + "|";
            price += this.txtBoundU2.Text.Trim() + "," + this.txtBoundD2.Text.Trim() + "," + this.txtBoundP2.Text.Trim() + "|";
            price += this.txtBoundU3.Text.Trim() + "," + this.txtBoundD3.Text.Trim() + "," + this.txtBoundP3.Text.Trim() + "|";
            price += this.txtBoundU4.Text.Trim() + "," + this.txtBoundD4.Text.Trim() + "," + this.txtBoundP4.Text.Trim();
            return price.TrimEnd('|');
        }
    }
}
