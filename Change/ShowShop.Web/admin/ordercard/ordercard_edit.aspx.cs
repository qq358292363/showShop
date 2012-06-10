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

namespace ShowShop.Web.admin.ordercard
{
    public partial class ordercard_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("008004002","对不起，您没有权限进行编辑");
                ShowShop.Common.PromptInfo.Popedom("008004004","对不起，您没有权限进行编辑");
                if (ChangeHope.WebPage.PageRequest.GetString("id") != "")
                {
                    BandInfo(Convert.ToInt32(ChangeHope.WebPage.PageRequest.GetString("id")));
                }
                InitWebControl();
            }
        }
        /// <summary>
        /// 验证
        /// </summary>
        private void InitWebControl()
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            this.txtProduct.Attributes.Add("readonly", "readonly");
            this.txtProduct.Attributes.Add("onclick", "selectFile('OrderCardProduct',new Array(" + this.hfid.ClientID + "," + this.txtProduct.ClientID + "),310,450,'" + sp.DummyPaht + "');");
            ChangeHope.WebPage.WebControl.SetDate(this.txtEndTime);
            ChangeHope.WebPage.WebControl.Validate(this.txtFaceValue, "输入点卡面值", "isfloat", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtEndTime, "输入截止日期", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtPrice, "输入出售的价格", "ifisfloat", "选填", "该项为选填项，必须为数字和带小数。");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void BandInfo(int id)
        {
            ShowShop.BLL.OrderCard.OrderCardInfo bll = new ShowShop.BLL.OrderCard.OrderCardInfo();
            ShowShop.Model.OrderCard.OrderCardInfo model = bll.GetModelID(id);
            if (model != null)
            {
                this.rbCardType.SelectedValue = model.Type;
                this.rblIsShopSale.SelectedValue = model.IsWhetherSale.ToString();
                if (model.IsWhetherSale.ToString() == "1")
                {
                    this.OptionProduct.Style.Value = "display:";
                    string Name=ProductName(model.ProductID.ToString());
                    if (Name!="")
                    {
                        this.txtProduct.Text = Name;
                        this.hfid.Value = model.ProductID.ToString();
                    }
                }
                this.brlmode.Enabled = false;
                this.txtCardNumber.Text = model.CardNumber;
                this.txtPassword.Text = model.JOCW_Password;
                this.txtFaceValue.Text = model.FaceValue.ToString();
                this.txtPoint.Text = model.Point.ToString();
                this.ddty.SelectedValue = model.Unit;
                this.txtPrice.Text = model.Price.ToString();
                this.txtEndTime.Text = model.ExpirationDate.ToString();
                this.txtBusinessAgent.Text = model.BusinessAgent;
                ViewState["ID"] = model.ID;
                ViewState["PassWord"] = model.JOCW_Password;
                ViewState["UserName"] = model.UserName;
                ViewState["CardNumber"] = model.CardNumber;
                ViewState["FullMoneyDate"] = model.FullMoneyDate;
                ViewState["WhetherRelease"] = model.WhetherRelease;
            }
        }
        protected string ProductName(string ProductId)
        {
            string reStr = string.Empty;
            string str = "";
            if (!string.IsNullOrEmpty(ProductId))
            {
                ShowShop.BLL.Product.ProductInfo dll = new ShowShop.BLL.Product.ProductInfo();
                ShowShop.Model.Product.ProductInfo model = dll.GetModel(Convert.ToInt32(ProductId));
                if (model != null)
                {
                    str = model.ProductName;
                }
            }
            return str;
        }
        /// <summary>
        /// 保存信息
        /// </summary>
        protected void Save()
        {
            string addManner = this.brlmode.SelectedValue;
            string CardNo = this.txtCardNumber.Text;
            string CardPassWord = this.txtPassword.Text;
            string BatchCard = this.txtBatch.Text;
            if (addManner == "1")
            {
                if (string.IsNullOrEmpty(CardNo))
                {
                    this.ltlMsg.Text = "操作失败，卡号不能为空。";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
                if (string.IsNullOrEmpty(CardPassWord))
                {
                    this.ltlMsg.Text = "操作失败，密码不能为空。";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
            }
            else if (addManner == "2")
            {
                if (string.IsNullOrEmpty(BatchCard))
                {
                    this.ltlMsg.Text = "操作失败，格式文本不能为空。";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
            }


            if (txtFaceValue.Text.Trim()!="")
            {
                if(!ChangeHope.Common.ValidateHelper.IsMoney(txtFaceValue.Text.Trim()))
                {
                    this.ltlMsg.Text = "操作失败，请输入正确面值。";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
                if(float.Parse(txtFaceValue.Text.Trim())<=0)
                {
                    this.ltlMsg.Text = "操作失败，面值小于或等于0。";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
            }
            if (txtPoint.Text.Trim()!="")
            {
                if(!ChangeHope.Common.ValidateHelper.IsMoney(txtPoint.Text.Trim()))
                {
                    this.ltlMsg.Text = "操作失败，请输入正确数量。";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
                if(float.Parse(txtPoint.Text.Trim())<=0)
                {
                    this.ltlMsg.Text = "操作失败，数量小于或等于0。";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
            }
            if (txtPrice.Text.Trim()!="")
            {
                if(!ChangeHope.Common.ValidateHelper.IsMoney(txtPrice.Text.Trim()))
                {
                    this.ltlMsg.Text = "操作失败，请输入正确价格。";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
                if(float.Parse(txtPrice.Text.Trim())<=0)
                {
                    this.ltlMsg.Text = "操作失败，价格小于或等于0。";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
            }
            ShowShop.BLL.OrderCard.OrderCardInfo bll = new ShowShop.BLL.OrderCard.OrderCardInfo();
            ShowShop.Model.OrderCard.OrderCardInfo model = new ShowShop.Model.OrderCard.OrderCardInfo();
            TryCode.SymmetricMethod pw = new TryCode.SymmetricMethod();
            string isProductID =this.rblIsShopSale.SelectedValue;
            if (addManner == "1")
            {
                if (ViewState["CardNumber"] == null)
                {
                    ChangeHope.DataBase.DataByPage db = bll.GetList("[order by] id asc", 1, " and cardnumber=" + CardNo + "");
                    if (db.DataReader != null)
                    {
                        this.ltlMsg.Text = "操作失败，卡号和密码重复，请重新输入。";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionOk";
                        return;
                    }
                }
                model.ProductID = (isProductID == "1" && this.hfid.Value != string.Empty) ? Convert.ToInt32(this.hfid.Value) : 0;
                model.IsWhetherSale = int.Parse(isProductID);
                model.Type = this.rbCardType.Text;
                model.CardNumber = CardNo;
                model.Password = CardPassWord;
                model.FaceValue = Convert.ToDecimal(this.txtFaceValue.Text);
                model.Point = this.txtPoint.Text;
                model.Unit = this.ddty.SelectedValue;
                model.ExpirationDate = Convert.ToDateTime(this.txtEndTime.Text);
                model.BusinessAgent = this.txtBusinessAgent.Text;
                model.CreateDate = System.DateTime.Now;
                model.Appearance = 0;
                model.Price = this.txtPrice.Text.Trim() != "" ? Convert.ToDecimal(this.txtPrice.Text.Trim()) : 0;
                model.UpdateDate = System.DateTime.Now;
                
                if (ViewState["ID"] == null)
                {
                    model.WhetherRelease = 0;
                    model.FullMoneyDate =Convert.ToDateTime("1753-01-01");
                    model.UserName = "admin";
                    if (bll.Add(model) != 0)
                    {
                        this.hfid.Value = string.Empty;
                        this.ltlMsg.Text = "操作成功，添加信息保存成功。";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionOk";
                    }
                }
                else
                {
                    model.ID = Convert.ToInt32(ViewState["ID"].ToString());
                    model.WhetherRelease = Convert.ToInt32(ViewState["WhetherRelease"].ToString());
                    model.UserName = ViewState["UserName"].ToString();
                    model.FullMoneyDate = Convert.ToDateTime(ViewState["FullMoneyDate"].ToString());
                    if (bll.Update(model) != 0)
                    {
                        this.hfid.Value = string.Empty;
                        this.ltlMsg.Text = "操作成功，修改信息保存成功。";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionOk";
                    }
                }
            }
            else if (addManner == "2")
            {
                string str = "", strs = "", sp = "";
                str = BatchCard.Replace("\n", ",");
                string[] StringArray = str.Split(',');
                if (this.tbSp.Text.Trim() != string.Empty)
                {
                    sp = this.tbSp.Text.Trim();
                }
                else
                {
                    sp = "|";
                }

                for (int i = 0; i < StringArray.Length; i++)
                {

                    strs = StringArray[i];
                    if (strs != string.Empty)
                    {
                        if (strs.IndexOf(sp) > 0)
                        {
                            string[] slingArray = strs.Replace(sp, ",").Split(',');
                            ChangeHope.DataBase.DataByPage db = bll.GetList("[order by] id asc", 1, " and cardnumber=" + slingArray[0] + "");
                            if(db.DataReader!=null)
                            {
                                break;
                            }
                            if (db.DataReader != null)
                            {
                                this.ltlMsg.Text = "操作失败，卡号和密码重复，请重新输入。";
                                this.pnlMsg.Visible = true;
                                this.pnlMsg.CssClass = "actionOk";
                                return;
                            }
                            model.ProductID = (isProductID == "1" && this.txtProduct.Text.Trim() != string.Empty) ? Convert.ToInt32(this.hfid.Value) : 0;
                            model.IsWhetherSale = int.Parse(isProductID);
                            model.Type = this.rbCardType.Text;

                            model.CardNumber = slingArray[0];
                            model.Password = slingArray[1];
                            model.FaceValue = Convert.ToDecimal(this.txtFaceValue.Text);
                            model.Point = this.txtPoint.Text;
                            model.Unit = this.ddty.SelectedValue;
                            model.ExpirationDate = Convert.ToDateTime(this.txtEndTime.Text);
                            model.BusinessAgent = this.txtBusinessAgent.Text;
                            model.CreateDate = System.DateTime.Now;
                            model.Appearance = 0;
                            model.Price = this.txtPrice.Text.Trim() != "" ? Convert.ToDecimal(this.txtPrice.Text.Trim()) : 0;
                            model.WhetherRelease = 0;
                            model.UpdateDate = System.DateTime.Now;
                            model.UserName = "admin";
                            model.FullMoneyDate = Convert.ToDateTime("1753-01-01");
                            bll.Add(model);
                        }
                    }
                }
                this.ltlMsg.Text = "操作成功，信息保存成功。";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
        }
    }
}
