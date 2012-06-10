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
using System.Text;

namespace ShowShop.Web.admin.accessories
{
    public partial class advertise_edit : System.Web.UI.Page
    {
        protected string adsType = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("012001002","对不起，您没有权限进行编辑");
                ShowShop.Common.PromptInfo.Popedom("012001004","对不起，您没有权限进行编辑");
                adsType = ChangeHope.WebPage.PageRequest.GetQueryString("type") == "" ? "0" : ChangeHope.WebPage.PageRequest.GetQueryString("type");                
                ViewState["adtype"] = adsType;
                this.CheckType(adsType);
                InitWebControl();
                GetModel();           
            }
        }

        protected void GetModel()
        {
            #region 显示要编辑的数据
            if (ChangeHope.WebPage.PageRequest.GetQueryInt("Ads_ID") > 0)
            {
                ShowShop.BLL.Accessories.AdvertiseManage bll = new ShowShop.BLL.Accessories.AdvertiseManage();
                ShowShop.Model.Accessories.AdvertiseManage model = new ShowShop.Model.Accessories.AdvertiseManage();
                model = bll.GetModelByID(Convert.ToInt32(Request["Ads_ID"].ToString()));
                this.txtName.Text = model.Name;
                this.txtPower.Text = model.Power.ToString();
                this.txtBrowseCount.Text = model.BrowseCount.ToString();
                this.txtClickCount.Text = model.ClickCount.ToString();
                this.dpStart.Text = Convert.ToDateTime(model.OverdueTime).ToShortDateString();
                this.chxExamine.Checked = model.Examine == 1 ? true : false;
                this.chxClickCount.Checked = model.StatClick == 1 ? true : false;
                this.chxBorwsCount.Checked = model.StatBrowse == 1 ? true : false;
                if (model.Adtype == 0)
                {
                    this.pnlType1.Visible = true;
                    this.txtWidth1.Text = model.SizeBreadth;
                    this.txtHeight1.Text = model.Hight;
                    this.txtLinkAddress.Text = model.LinkAddress;
                    this.txtHint1.Text = model.Hint;
                    this.rdolstTarget1.SelectedValue = model.BackgorTarget.ToString();
                    this.txtContent1.Text = model.Advertisecont;
                    this.txtUpspread1.Text = model.UpspreadAdd;
                    ViewState["adtype2"] = model.Adtype.ToString();
                    ViewState["picAddress"] = model.UpspreadAdd;
                }
                else if (model.Adtype == 1)
                {
                    this.pnlType1.Visible = false;
                    this.pnlType2.Visible = true;
                    this.txtWidth2.Text = model.SizeBreadth;
                    this.txtHeight2.Text = model.Hight;
                    this.rlistTarget2.SelectedValue = model.BackgorTarget.ToString();
                    this.chxClickCount.Enabled = false;
                    this.txtClickCount.Enabled = false;
                    ViewState["adtype2"] = model.Adtype.ToString();
                    ViewState["picAddress"] = model.UpspreadAdd;
                    
                }
                else if (model.Adtype == 2)
                {
                    this.pnlType1.Visible = false;
                    this.pnlType2.Visible = false;
                    this.pnlType3.Visible = true;
                    this.txtContent3.Text = model.Advertisecont;
                    this.chxClickCount.Enabled = false;
                    this.txtClickCount.Enabled = false;
                    ViewState["adtype2"] = model.Adtype.ToString();
                   
                }
                else if (model.Adtype == 3)
                {
                    this.pnlType4.Visible = true;
                    this.pnlType1.Visible = false;
                    this.pnlType2.Visible = false;
                    this.pnlType3.Visible = false;
                    this.txtWidth4.Text = model.SizeBreadth;
                    this.txtHeight4.Text = model.Hight;
                    this.txtLinkAddress4.Text = model.LinkAddress;
                    this.txtHint4.Text = model.Hint;
                    this.rlistTarget4.SelectedValue = model.BackgorTarget.ToString();
                    this.txtContent4.Text = model.Advertisecont;
                    this.txtUpspread4.Text = model.UpspreadAdd;
                    ViewState["adtype2"] = model.Adtype.ToString();
                    ViewState["picAddress"] = model.UpspreadAdd;
                }
            }
            #endregion

            #region 添加数据
            else
            {
                this.dpStart.Text = DateTime.Now.ToShortDateString();
                this.txtClickCount.Text = "0";
                this.txtBrowseCount.Text = "0";
            }
            #endregion

        }

        #region 验证
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtName, "输入广告的名称", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtContent3, "输入广告的文本内容", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtHeight1, "输入数字将作为图片广告的高", "isint", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtWidth1, "输入数字将作为图片广告的宽", "isint", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtPower, "此项为版位广告随机显示时的优先权，权重越大显示机会越大", "isint", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtBrowseCount, "输入数字将作为广告浏览次数", "isint", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtClickCount, "输入数字将作为广告点击次数", "isint", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtHeight2, "输入数字将作为动画广告的高", "isint", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtWidth2, "输入数字将作为动画广告的宽", "isint", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtHeight4, "输入数字将作为幻灯片广告的高", "isint", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtWidth4, "输入数字将作为幻灯片广告的宽", "isint", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtLinkAddress4, "输入广告要链接到的地址", "ishttpurl", "必填", "该项必须为网络地址格式");
            ChangeHope.WebPage.WebControl.Validate(this.txtLinkAddress, "输入广告要链接到的地址", "ishttpurl", "必填", "该项必须为网络地址格式");
            ChangeHope.WebPage.WebControl.SetDate(this.dpStart);
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }
        #endregion

        #region 判断广告类型 只有图片类型才统计点击数

        protected void CheckType(string type)
        {
            if (type == "0")
            {
                this.pnlType1.Visible = true;
                this.pnlType2.Visible = false;
                this.pnlType3.Visible = false;
                this.pnlType4.Visible = false;
                this.chxClickCount.Enabled = true;
                this.txtClickCount.Enabled = true;
            }
            else if (type == "1")
            {
                this.pnlType1.Visible = false;
                this.pnlType3.Visible = false;
                this.pnlType2.Visible = true;
                this.pnlType4.Visible = false;
                this.chxClickCount.Enabled = false;
                this.txtClickCount.Enabled = false;
            }
            else if (type == "2")
            {
                this.pnlType1.Visible = false;
                this.pnlType2.Visible = false;
                this.pnlType3.Visible = true;
                this.pnlType4.Visible = false;
                this.chxClickCount.Enabled = false;
                this.txtClickCount.Enabled = false;
            }
            else if (type == "3")
            {
                this.pnlType1.Visible = false;
                this.pnlType2.Visible = false;
                this.pnlType3.Visible = false;
                this.pnlType4.Visible = true;
                this.chxClickCount.Enabled = false;
                this.txtClickCount.Enabled = false;
            }
        }
        #endregion

        #region 图片广告 图片上传
        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                ChangeHope.Common.UploadFile uf = new ChangeHope.Common.UploadFile();
                uf.ExtensionLim = ".gif,.jpg,.jpeg,.bmp";
                uf.FileLengthLim = 4000;
                uf.PostedFile = this.FileUpload1;

                uf.SavePath = "/yxuploadfile/accessories/advertise";
                if (uf.Upload())
                {
                    if (uf.HaveLoad)
                    {
                        if (txtUpspread1.Text == "")
                        {
                            this.txtUpspread1.Text = uf.FilePath;
                        }
                        else
                        {
                            this.txtUpspread1.Text = txtUpspread1.Text.ToString() + "|" + uf.FilePath;
                        }
                    }
                    else
                    {
                        this.ltlMsg.Text = "操作失败，" + uf.Message + "";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                else
                {
                    this.ltlMsg.Text = "操作失败，" + uf.Message + "";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
            }
        }
        #endregion

        #region 删除一张图片

        /// <summary>
        /// 删除一张图片
        /// </summary>
        /// <param name="arrPicList"></param>
        /// <returns></returns>
        protected string delPic(string PicList)
        {
            String[] arrPic = PicList.Split('|');
            string strList = "";
            if (arrPic.Length == 1 || arrPic.Length < 1)
            {
                strList = "";
            }
            else
            {
                for (int i = 0; i < arrPic.Length - 1; i++)
                {

                    string arrTenp1 = arrPic[i].ToString();
                    string arrTenp2;
                    if (i > 0)
                    {
                        arrTenp2 = arrPic[i].ToString();
                    }
                    else
                    {
                        arrTenp2 = arrPic[i].ToString();
                    }
                    if (i == 0)
                    {
                        strList = arrTenp1;
                    }
                    else
                    {
                        if (strList == "")
                        {
                            strList = arrTenp1;
                        }
                        else
                        {
                            strList = strList + "|" + arrTenp1;
                        }
                    }
 
                }
            }
            return strList;
        }

        /// <summary>
        ///删除图片广告 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelPic_Click(object sender, EventArgs e)
        {
            txtUpspread1.Text = this.delPic(txtUpspread1.Text.ToString());
        }
        #endregion

        #region 幻灯片广告图片上传
        protected void btnUploadSlide_Click(object sender, EventArgs e)
        {
            if (FileUpload3.HasFile)
            {
                //原图
                ChangeHope.Common.UploadFile uf = new ChangeHope.Common.UploadFile();
                uf.ExtensionLim = ".gif,.jpg,.jpeg,.bmp";
                uf.FileLengthLim = 4000;
                uf.PostedFile = this.FileUpload3;
                //暂时存放在这里
                uf.SavePath = "/yxuploadfile/accessories/advertise";
                if (uf.Upload())
                {
                    if (uf.HaveLoad)
                    {
                        if (txtUpspread4.Text == "")
                        {
                            this.txtUpspread4.Text = uf.FilePath;
                        }
                        else
                        {
                            this.txtUpspread4.Text = txtUpspread4.Text.ToString() + "|" + uf.FilePath;
                        }
                    }
                    else
                    {
                        this.ltlMsg.Text = "操作失败，" + uf.Message + "";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                else
                {
                    this.ltlMsg.Text = "操作失败，" + uf.Message + "";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
            }
        }
        #endregion

        #region 删除一张幻灯片广告图片
        protected void btnDelSlide_Click(object sender, EventArgs e)
        {
            this.txtUpspread4.Text = this.delPic(this.txtUpspread4.Text.ToString());                  
        }
        #endregion

        #region 保存操作
        private void Save()
        {
          
            ShowShop.BLL.Accessories.AdvertiseManage bll = new ShowShop.BLL.Accessories.AdvertiseManage();
            ShowShop.Model.Accessories.AdvertiseManage model = new ShowShop.Model.Accessories.AdvertiseManage();
            model.Name = this.txtName.Text.Trim();
            model.Power = this.txtPower.Text.Length == 0 ? 0 : Convert.ToInt32(this.txtPower.Text.Trim());
            model.BrowseCount = this.txtBrowseCount.Text.Length == 0 ? 0 : Convert.ToInt32(this.txtBrowseCount.Text.Trim());
            model.ClickCount = this.txtClickCount.Text.Length == 0 ? 0 : Convert.ToInt32(this.txtClickCount.Text.Trim());
            try
            {
                model.OverdueTime = Convert.ToDateTime(this.dpStart.Text.Trim());
            }
            catch
            {
                this.ltlMsg.Text = "请输入正确的时间格式，最好通过选择器选择日期";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
                return;
            }

            model.Examine = this.chxExamine.Checked ? 1 : 0;
            model.StatClick = this.chxClickCount.Checked ? 1 : 0;
            model.StatBrowse = this.chxBorwsCount.Checked ? 1 : 0;

            #region 修改操作
            if (Request["Ads_ID"] != null)
            {
                int id = Convert.ToInt32(Request["Ads_ID"].ToString());
                if (ViewState["adtype"] != null)
                {
                    //图片
                    if (ViewState["adtype"].ToString() == "0")
                    {
                        model.SizeBreadth = txtWidth1.Text.Trim();
                        model.Hight = txtHeight1.Text.Trim();
                        model.LinkAddress = txtLinkAddress.Text.Trim();
                        model.Hint = txtHint1.Text.Trim();
                        //打开方式
                        model.BackgorTarget = Convert.ToInt32(this.rdolstTarget1.SelectedValue);
                        model.Advertisecont = txtContent1.Text.Trim();
                        model.Adtype = 0;
                        model.ID = id;
                        if (txtUpspread1.Text != "")
                        {
                            model.UpspreadAdd = this.txtUpspread1.Text.ToString();
                        }
                        else
                        {
                            model.UpspreadAdd = ViewState["picAddress"].ToString();
                        }
                        bll.Amend(model);
                        this.ltlMsg.Text = "操作成功，已保存该信息";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionOk";
                    }
                    //动画
                    else if (ViewState["adtype"].ToString() == "1")
                    {
                        ViewState["adtype2"] = "1";
                        string Upspread = string.Empty;

                        if (FileUpload2.HasFile)
                        {
                            ChangeHope.Common.UploadFile uf = new ChangeHope.Common.UploadFile();
                            uf.ExtensionLim = ".gif,.swf";
                            uf.FileLengthLim = 4000;
                            uf.PostedFile = this.FileUpload2;
                            uf.SavePath = "/yxuploadfile/accessories/advertise";
                            if (uf.Upload())
                            {
                                if (uf.HaveLoad)
                                {
                                    Upspread = uf.FilePath;
                                }
                                else
                                {
                                    this.ltlMsg.Text = "操作失败，" + uf.Message + "";
                                    this.pnlMsg.Visible = true;
                                    this.pnlMsg.CssClass = "actionErr";
                                    return;
                                }
                            }
                            else
                            {
                                this.ltlMsg.Text = "操作失败，" + uf.Message + "";
                                this.pnlMsg.Visible = true;
                                this.pnlMsg.CssClass = "actionErr";
                                return;
                            }
                        }
                        model.SizeBreadth = this.txtWidth2.Text.Trim();
                        model.Hight = this.txtHeight2.Text.Trim();
                        model.LinkAddress = "";
                        model.Hint = "";
                        model.BackgorTarget = Convert.ToInt32(this.rlistTarget2.SelectedValue);
                        model.Advertisecont = "";
                        model.UpspreadAdd = Upspread;
                        model.Adtype = 1;
                        model.ID = id;
                        bll.Amend(model);
                        this.ltlMsg.Text = "操作成功，已保存该信息";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionOk";
                    }
                    //文本
                    else if (ViewState["adtype"].ToString() == "2")
                    {
                        model.LinkAddress = "";
                        model.Hint = "";
                        model.SizeBreadth = "";
                        model.Hight = "";
                        model.BackgorTarget = 0;
                        model.UpspreadAdd = "";
                        model.Adtype = 2;
                        model.Advertisecont = this.txtContent3.Text.Trim();
                        model.ID = id;
                        bll.Amend(model);
                        this.ltlMsg.Text = "操作成功，已保存该信息";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionOk";
                    }
                    //幻灯片
                    else if (ViewState["adtype"].ToString() == "3")
                    {
                        model.SizeBreadth = this.txtWidth4.Text.Trim();
                        model.Hight = this.txtHeight4.Text.Trim();
                        model.LinkAddress = this.txtLinkAddress4.Text.Trim();
                        model.Hint = this.txtHint4.Text.Trim();
                        model.BackgorTarget = Convert.ToInt32(this.rlistTarget4.SelectedValue);
                        model.Advertisecont = this.txtContent4.Text.Trim();
                        if (this.txtUpspread1.Text != "")
                        {
                            model.UpspreadAdd = this.txtUpspread4.Text.ToString();
                        }
                        else
                        {
                            model.UpspreadAdd = ViewState["picAddress"].ToString();
                        }
                        model.Adtype = 3;
                        model.ID = id;
                        bll.Amend(model);
                        this.ltlMsg.Text = "操作成功，已保存该信息";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionOk";
                    }
                }

            }
            #endregion
            #region 增加操作
            else
            {
                #region 图片类型广告
                if (ViewState["adtype"] == null || ViewState["adtype"].ToString() == "0")
                {
                    model.SizeBreadth = this.txtWidth1.Text.Trim();
                    model.Hight = this.txtHeight1.Text.Trim();
                    model.LinkAddress = this.txtLinkAddress.Text.Trim();
                    model.Hint = this.txtHint1.Text.Trim();
                    //打开方式
                    model.BackgorTarget = Convert.ToInt32(this.rdolstTarget1.SelectedValue);
                    model.Advertisecont = this.txtContent1.Text.Trim();
                    model.UpspreadAdd = this.txtUpspread1.Text.ToString();
                    model.Adtype = 0;
                    bll.Add(model);
                    this.ltlMsg.Text = "操作成功，已保存该信息";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionOk";
                }
                #endregion

                #region 动画类型广告
                else if (ViewState["adtype"].ToString() == "1")
                {
                    string Upspread = string.Empty;
                    if (FileUpload2.HasFile)
                    {
                        ChangeHope.Common.UploadFile uf = new ChangeHope.Common.UploadFile();
                        uf.ExtensionLim = ".gif,.swf";
                        uf.FileLengthLim = 4000;
                        uf.PostedFile = this.FileUpload2;
                        uf.SavePath = "/yxuploadfile/accessories/advertise";
                        if (uf.Upload())
                        {
                            if (uf.HaveLoad)
                            {
                                Upspread = uf.FilePath;
                            }
                            else
                            {
                                this.ltlMsg.Text = "操作失败，" + uf.Message + "";
                                this.pnlMsg.Visible = true;
                                this.pnlMsg.CssClass = "actionErr";
                                return;
                            }
                        }
                        else
                        {
                            this.ltlMsg.Text = "操作失败，" + uf.Message + "";
                            this.pnlMsg.Visible = true;
                            this.pnlMsg.CssClass = "actionErr";
                            return;
                        }
                    }
                    model.SizeBreadth = this.txtWidth2.Text.Trim();
                    model.Hight = this.txtHeight2.Text.Trim();
                    model.LinkAddress = "";
                    model.Hint = "";
                    model.BackgorTarget = Convert.ToInt32(this.rlistTarget2.SelectedValue);
                    model.Advertisecont = "";
                    model.UpspreadAdd = Upspread;
                    model.Adtype = 1;
                    bll.Add(model);
                    this.ltlMsg.Text = "操作成功，已保存该信息";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionOk";
                }
                #endregion

                #region 文本类型广告
                else if (ViewState["adtype"].ToString() == "2")
                {
                    model.LinkAddress = "";
                    model.Hint = "";
                    model.SizeBreadth = "";
                    model.Hight = "";
                    model.BackgorTarget = 0;
                    model.UpspreadAdd = "";
                    model.Adtype = 2;
                    model.Advertisecont = this.txtContent3.Text.Trim();
                    bll.Add(model);
                    this.ltlMsg.Text = "操作成功，已保存该信息";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionOk";
                }
                #endregion

                #region 幻灯片类型广告
                else if (ViewState["adtype"].ToString() == "3")
                {
                    model.SizeBreadth = this.txtWidth4.Text.Trim();
                    model.Hight = this.txtHeight4.Text.Trim();
                    model.LinkAddress = this.txtLinkAddress4.Text.Trim();
                    model.Hint = this.txtHint4.Text.Trim();
                    model.BackgorTarget = Convert.ToInt32(this.rlistTarget4.SelectedValue);
                    model.Advertisecont = this.txtContent4.Text.Trim();
                    model.UpspreadAdd = this.txtUpspread4.Text.ToString();
                    model.Adtype = 3;
                    bll.Add(model);
                    this.ltlMsg.Text = "操作成功，已保存该信息";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionOk";
                }
                #endregion
            }
            #endregion
        }
        #endregion
        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
      

    }
}
