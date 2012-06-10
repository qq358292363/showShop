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
    public partial class advertise_info_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != "")
                {
                    string delpath = ChangeHope.WebPage.PageRequest.GetFormString("Delpath");
                    string images = ChangeHope.WebPage.PageRequest.GetFormString("images");
                    int adId = ChangeHope.WebPage.PageRequest.GetFormInt("ID");
                   Response.Write(this.DelImages(images, delpath, adId));
                   Response.End();
                   return;
                }
                ChangeHope.WebPage.WebControl.SetDate(this.dpStart_images);
                this.dpStart_images.Text ="2020-01-01";
                ChangeHope.WebPage.WebControl.SetDate(this.dpStart_text);
                this.dpStart_text.Text = "2020-01-01";
                ChangeHope.WebPage.WebControl.SetDate(this.dpStart_flash);
                this.dpStart_flash.Text = "2020-01-01";
                ChangeHope.WebPage.WebControl.SetDate(this.dpStart_Slide);
                this.dpStart_Slide.Text = "2020-01-01";
                int id = ChangeHope.WebPage.PageRequest.GetQueryInt("Ads_ID");
                if (id > 0)
                {
                    this.BindInfo(id);
                }
            }
        }

        #region 删除幻灯片图片
        private string DelImages(string Images,string DelPath,int id)
        {
            ShowShop.BLL.Accessories.AdvertiseManage bll = new ShowShop.BLL.Accessories.AdvertiseManage();
            string[] imagess = Images.Split('|');
            StringBuilder str = new StringBuilder();
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            int j = 1;
            string img = "";
            if (imagess.Length > 0)
            {
                str.Append("<table>");
                for (int i = 0; i < imagess.Length; i++)
                {
                    if (imagess[i] != DelPath && !string.IsNullOrEmpty(imagess[i]))
                    {
                        if (img == "")
                        {
                            img = imagess[i];
                        }
                        else
                        {
                            img += "|" + imagess[i];
                        }
                        str.Append("<td align='center'><img width=\"100px\" height=\"100px\" src=\"" + sp.DummyPaht + imagess[i] + "\"/><br/><br/><span onclick=\"DelImages('" + imagess[i] + "'," + id + ");\"  style=\"cursor:hand;width:45px\" >删除</span></td>");
                        if (j % 6 == 0)
                        {
                            str.Append("</tr><tr>");
                        }
                        j++;
                    }
                    else
                    {
                        ChangeHope.Common.FileHelper fh = new ChangeHope.Common.FileHelper();
                        fh.DeleteFile(Server.MapPath("~\\" + DelPath));
                    }
                }
                bll.Amend(id, "upspreadadd", img);
                str.Append("</table><table><tr><td><input type=\"hidden\" name=\"hfImagesAddress\" id=\"hfImagesAddress\" value=\"" + img + "\" /></td></tr></table>");
            }
            return str.ToString();
        }
        #endregion

        #region 绑定数据
        protected void BindInfo(int id)
        {
            ShowShop.BLL.Accessories.AdvertiseManage bll = new ShowShop.BLL.Accessories.AdvertiseManage();
            ShowShop.Model.Accessories.AdvertiseManage model = bll.GetModelByID(id);
            if (model != null)
            {
                this.hfAdId.Value = model.ID.ToString();
                this.hfAdTypeId.Value = model.Adtype.ToString();
                ViewState["Images"] = model.UpspreadAdd;
                switch (model.Adtype)
                {
                    case 0:
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript1", "<script>$('ctl00_workspace_TabTitle2').className='tabtitle';</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript2", "<script>$('ctl00_workspace_TabTitle0').className='titlemouseover';</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript3", "<script>$('ctl00_workspace_TabTitle1').className='tabtitle';</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript4", "<script>$('ctl00_workspace_TabTitle3').className='tabtitle';</script>");
                        this.tab0.Style.Value = "display:block";
                        this.tab1.Style.Value = "display:none";
                        this.tab2.Style.Value = "display:none";
                        this.tab3.Style.Value = "display:none";
                        this.txt_image_Add_Name.Text = model.Name;
                        this.txt_images_Power.Text = model.Power.ToString();
                        this.txt_images_BrowseCount.Text = model.BrowseCount.ToString();
                        this.txt_images_ClickCount.Text = model.ClickCount.ToString();
                        this.dpStart_images.Text = model.OverdueTime.ToString();
                        this.chx_images_Examine.Checked = model.Examine == 1 ? true : false;
                        this.chx_images_ClickCount.Checked = model.StatClick == 1 ? true : false;
                        this.chx_images_BorwsCount.Checked = model.StatBrowse == 1 ? true : false;
                        this.txt_images_Width.Text = model.SizeBreadth.ToString();
                        this.txt_images_Height.Text = model.Hight.ToString();
                        this.txt_images_LinkAddress.Text = model.LinkAddress;
                        this.txt_images_Hint.Text = model.Hint;
                        this.rdolstTarget1.SelectedValue = model.BackgorTarget.ToString();
                        this.txtContent1.Text = model.Advertisecont;

                        break;
                    case 1:
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript1", "<script>$('ctl00_workspace_TabTitle0').className='tabtitle';</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript2", "<script>$('ctl00_workspace_TabTitle1').className='titlemouseover';</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript3", "<script>$('ctl00_workspace_TabTitle2').className='tabtitle';</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript4", "<script>$('ctl00_workspace_TabTitle3').className='tabtitle';</script>");
                        this.tab0.Style.Value = "display:none";
                        this.tab1.Style.Value = "display:block";
                        this.tab2.Style.Value = "display:none";
                        this.tab3.Style.Value = "display:none";
                        this.txt_flash_Add_Name.Text=model.Name;
                        this.txt_flash_Power.Text = model.Power.ToString();
                        this.txt_flash_BrowseCount.Text = model.BrowseCount.ToString();
                        this.txt_flash_ClickCount.Text = model.ClickCount.ToString();
                        this.dpStart_flash.Text=model.OverdueTime.ToString();
                        this.chx_flash_Examine.Checked = model.Examine == 1 ? true : false;
                        this.chx_flash_ClickCount.Checked = model.StatClick == 1 ? true : false;
                        this.chx_flash_BorwsCount.Checked = model.StatBrowse == 1 ? true : false;
                        this.txt_flash_Width.Text=model.SizeBreadth;
                        this.txt_flash_Height.Text=model.Hight.ToString();
                        this.rlistTarget2.SelectedValue=model.BackgorTarget.ToString();
                        break;
                    case 2:
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript1", "<script>$('ctl00_workspace_TabTitle0').className='tabtitle';</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript2", "<script>$('ctl00_workspace_TabTitle2').className='titlemouseover';</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript3", "<script>$('ctl00_workspace_TabTitle1').className='tabtitle';</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript4", "<script>$('ctl00_workspace_TabTitle3').className='tabtitle';</script>");
                       
                        this.tab0.Style.Value = "display:none";
                        this.tab1.Style.Value = "display:none";
                        this.tab2.Style.Value = "display:block";
                        this.tab3.Style.Value = "display:none";
                        this.txt_text_Add_Name.Text= model.Name;
                        this.txt_text_Power.Text = model.Power.ToString();
                        this.txt_text_BrowseCount.Text = model.BrowseCount.ToString();
                        this.txt_text_ClickCount.Text = model.ClickCount.ToString();
                        this.dpStart_text.Text=model.OverdueTime.ToString();
                        this.chx_text_Examine.Checked = model.Examine == 1 ? true : false;
                        this.chx_text_ClickCount.Checked = model.StatClick == 1 ? true : false;
                        this.chx_text_BorwsCount.Checked = model.StatBrowse == 1 ? true : false;
                        this.txtContent3.Text = model.Advertisecont;
                        break;
                    case 3:
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript4", "<script>$('ctl00_workspace_TabTitle0').className='tabtitle';</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript3", "<script>$('ctl00_workspace_TabTitle3').className='titlemouseover';</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript2", "<script>$('ctl00_workspace_TabTitle1').className='tabtitle';</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript1", "<script>$('ctl00_workspace_TabTitle2').className='tabtitle';</script>");
                        this.tab0.Style.Value = "display:none";
                        this.tab1.Style.Value = "display:none";
                        this.tab2.Style.Value = "display:none";
                        this.tab3.Style.Value = "display:block";
                        this.txt_Slide_Add_Name.Text=model.Name;
                        this.txt_Slide_Power.Text = model.Power.ToString();
                        this.txt_Slide_BrowseCount.Text = model.BrowseCount.ToString();
                        this.txt_Slide_ClickCount.Text = model.ClickCount.ToString();
                        this.dpStart_Slide.Text = model.OverdueTime.ToString();
                        this.chx_Slide_Examine.Checked = model.Examine == 1 ? true : false;
                        this.chx_Slide_ClickCount.Checked = model.StatClick == 1 ? true : false;
                        this.chx_Slide_BorwsCount.Checked = model.StatBrowse == 1 ? true : false;
                        this.txt_Slide_Width.Text=model.SizeBreadth;
                        this.txt_Slide_Height.Text=model.Hight;
                        this.txtLinkAddress4.Text=model.LinkAddress;
                        this.txtHint4.Text = model.Hint;
                        this.rlistTarget4.SelectedValue=model.BackgorTarget.ToString();
                        this.txtContent4.Text = model.Advertisecont;
                        this.litaAlbum.Text =this.SliedAd(model.UpspreadAdd,model.ID);
                        break;
                }
            }
        }

        private string SliedAd(string Address,int id)
        {
            string[] imagess = Address.Split('|');
            StringBuilder str = new StringBuilder();
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            int j = 1;
            if (imagess.Length > 0)
            {
                str.Append("<table><tr><td><input type=\"hidden\" name=\"hfImagesAddress\" id=\"hfImagesAddress\" value=\"" + Address+ "\" /></td></tr></table><table>");
                for (int i = 0; i < imagess.Length; i++)
                {
                    if (!string.IsNullOrEmpty(imagess[i]))
                    {
                        str.Append("<td align='center'><img width=\"100px\" height=\"100px\" src=\"" + sp.DummyPaht + imagess[i] + "\"/><br/><br/><span onclick=\"DelImages('" + imagess[i] + "'," + id + ");\"  style=\"cursor:hand;width:45px\" >删除</span></td>");
                    }
                    if (j % 6 == 0)
                    {
                        str.Append("</tr><tr>");
                    }
                    j++;
                }
                str.Append("</table>");
            }
            return str.ToString();
        }
        #endregion

        #region 添加与修改数据
        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void Save()
        {
            ShowShop.Common.SysParameter sp=new ShowShop.Common.SysParameter();
            ShowShop.BLL.Accessories.AdvertiseManage bll = new ShowShop.BLL.Accessories.AdvertiseManage();
            ShowShop.Model.Accessories.AdvertiseManage model = new ShowShop.Model.Accessories.AdvertiseManage();
            string typeId = this.hfAdTypeId.Value;
            string adId = this.hfAdId.Value;
            switch (typeId)
            {
                case "0"://图片
                    model.Name = this.txt_image_Add_Name.Text.Trim();
                    model.Power = this.txt_images_Power.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txt_images_Power.Text.Trim());
                    model.BrowseCount = this.txt_images_BrowseCount.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txt_images_BrowseCount.Text.Trim());
                    model.ClickCount = this.txt_images_ClickCount.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txt_images_ClickCount.Text.Trim());
                    model.OverdueTime = Convert.ToDateTime(this.dpStart_images.Text.Trim());
                    model.Examine = this.chx_images_Examine.Checked ? 1 : 0;
                    model.StatClick = this.chx_images_ClickCount.Checked ? 1 : 0;
                    model.StatBrowse = this.chx_images_BorwsCount.Checked ? 1 : 0;

                    model.SizeBreadth = txt_images_Width.Text.Trim();
                    model.Hight = txt_images_Height.Text.Trim();
                    model.LinkAddress = txt_images_LinkAddress.Text.Trim();
                    model.Hint = txt_images_Hint.Text.Trim();
                    //打开方式
                    model.BackgorTarget = Convert.ToInt32(this.rdolstTarget1.SelectedValue);
                    model.Advertisecont = txtContent1.Text.Trim();
                    model.Adtype = 0;
                    string images_path = "";
                    if (fu_images.PostedFile.ContentLength > 1)
                    {
                        ChangeHope.Common.UploadFile uf = new ChangeHope.Common.UploadFile();
                        uf.ExtensionLim = ".gif,.jpg,.jpeg,.dmp";
                        uf.FileLengthLim = sp.ImageSize;
                        uf.PostedFile = this.fu_images;
                        uf.SavePath = "/yxuploadfile/accessories/advertise";
                        string errorInfo = "";

                        if (uf.Upload())
                        {
                            if (uf.HaveLoad)
                            {
                                if (!string.IsNullOrEmpty(adId) && ViewState["Images"] != null)
                                {
                                    ChangeHope.Common.FileHelper fh = new ChangeHope.Common.FileHelper();
                                    fh.DeleteFile(Server.MapPath("~\\" + ViewState["Images"].ToString()));
                                }
                                images_path = uf.FilePath;
                            }
                            else
                            {

                                errorInfo = uf.Message;
                            }
                        }
                        else
                        {
                            errorInfo = uf.Message;
                        }
                        if (images_path == "")
                        {
                            this.ltlMsg.Text = "操作失败，" + errorInfo + "";
                            this.pnlMsg.Visible = true;
                            this.pnlMsg.CssClass = "actionErr";
                            return;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(adId) && ViewState["Images"] != null)
                        {
                            images_path = ViewState["Images"].ToString();
                        }
                    }
                    
                    model.UpspreadAdd = images_path;
                    if (string.IsNullOrEmpty(adId))
                    {
                        if (bll.Add(model) > 0)
                        {
                            ChangeHope.WebPage.BasePage.PageRight("图片广告已保存。", "advertise_info_edit.aspx");
                        }
                    }
                    else
                    {
                        model.ID = Convert.ToInt32(adId);
                        bll.Amend(model);
                        ChangeHope.WebPage.BasePage.PageRight("图片广告修改成功。", "advertise_list.aspx");
                    }
                    break;
                case "1"://动画          

                    model.Name = this.txt_flash_Add_Name.Text.Trim();
                    model.Power = this.txt_flash_Power.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txt_flash_Power.Text.Trim());
                    model.BrowseCount = this.txt_flash_BrowseCount.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txt_flash_BrowseCount.Text.Trim());
                    model.ClickCount = this.txt_flash_ClickCount.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txt_flash_ClickCount.Text.Trim());
                    model.OverdueTime = Convert.ToDateTime(this.dpStart_flash.Text.Trim());
                    model.Examine = this.chx_flash_Examine.Checked ? 1 : 0;
                    model.StatClick = this.chx_flash_ClickCount.Checked ? 1 : 0;
                    model.StatBrowse = this.chx_flash_BorwsCount.Checked ? 1 : 0;
                    string flash_path = string.Empty;
                    if (this.fu_flash.PostedFile.ContentLength > 0)
                    {
                        ChangeHope.Common.UploadFile uf_falsh = new ChangeHope.Common.UploadFile();
                        uf_falsh.ExtensionLim = ".gif,.swf";
                        uf_falsh.FileLengthLim = sp.ImageSize;
                        uf_falsh.PostedFile = this.fu_flash;
                        uf_falsh.SavePath = "/yxuploadfile/accessories/advertise";
                        if (uf_falsh.Upload())
                        {
                            if (uf_falsh.HaveLoad)
                            {
                                if (!string.IsNullOrEmpty(adId) && ViewState["Images"] != null)
                                {
                                    ChangeHope.Common.FileHelper fh = new ChangeHope.Common.FileHelper();
                                    fh.DeleteFile(Server.MapPath("~\\" + ViewState["Images"].ToString()));
                                }
                                flash_path = uf_falsh.FilePath;
                            }
                            else
                            {

                                this.ltlMsg.Text = "操作失败，" + uf_falsh.Message + "";
                                this.pnlMsg.Visible = true;
                                this.pnlMsg.CssClass = "actionErr";
                                return;
                            }
                        }
                        else
                        {
                            this.ltlMsg.Text = "操作失败，" + uf_falsh.Message + "";
                            this.pnlMsg.Visible = true;
                            this.pnlMsg.CssClass = "actionErr";
                            return;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(adId) && ViewState["Images"] != null)
                        {
                            flash_path = ViewState["Images"].ToString();
                        }
                    }
                    model.SizeBreadth = this.txt_flash_Width.Text.Trim();
                    model.Hight = this.txt_flash_Height.Text.Trim();
                    model.LinkAddress = "";
                    model.Hint = "";
                    model.BackgorTarget = Convert.ToInt32(this.rlistTarget2.SelectedValue);
                    model.Advertisecont = "";
                    model.UpspreadAdd = flash_path;
                    model.Adtype = 1;
                    if (string.IsNullOrEmpty(adId))
                    {
                        if (bll.Add(model) > 0)
                        {
                            ChangeHope.WebPage.BasePage.PageRight("动画广告已保存。", "advertise_info_edit.aspx");
                        }
                    }
                    else
                    {
                        model.ID = Convert.ToInt32(adId);
                        bll.Amend(model);
                        ChangeHope.WebPage.BasePage.PageRight("动画广告修改成功。", "advertise_list.aspx");
                    }
                    break;
                case "2"://文本
                    model.Name = this.txt_text_Add_Name.Text.Trim();
                    model.Power = this.txt_text_Power.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txt_text_Power.Text.Trim());
                    model.BrowseCount = this.txt_text_BrowseCount.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txt_text_BrowseCount.Text.Trim());
                    model.ClickCount = this.txt_text_ClickCount.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txt_text_ClickCount.Text.Trim());
                    model.OverdueTime = Convert.ToDateTime(this.dpStart_text.Text.Trim());
                    model.Examine = this.chx_text_Examine.Checked ? 1 : 0;
                    model.StatClick = this.chx_text_ClickCount.Checked ? 1 : 0;
                    model.StatBrowse = this.chx_text_BorwsCount.Checked ? 1 : 0;
                    model.LinkAddress = "";
                    model.Hint = "";
                    model.SizeBreadth = "";
                    model.Hight = "";
                    model.BackgorTarget = 0;
                    model.UpspreadAdd = "";
                    model.Adtype = 2;
                    model.Advertisecont = this.txtContent3.Text.Trim();
                    if (string.IsNullOrEmpty(adId))
                    {
                        if (bll.Add(model) > 0)
                        {
                            ChangeHope.WebPage.BasePage.PageRight("文本广告已保存。", "advertise_info_edit.aspx");
                        }
                    }
                    else
                    {
                        model.ID = Convert.ToInt32(adId);
                        bll.Amend(model);
                        ChangeHope.WebPage.BasePage.PageRight("文本广告修改成功。", "advertise_list.aspx");
                    }
                    break;
                case "3"://幻灯片
                    model.Name = this.txt_Slide_Add_Name.Text.Trim();
                    model.Power = this.txt_Slide_Power.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txt_Slide_Power.Text.Trim());
                    model.BrowseCount = this.txt_Slide_BrowseCount.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txt_Slide_BrowseCount.Text.Trim());
                    model.ClickCount = this.txt_Slide_ClickCount.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txt_Slide_ClickCount.Text.Trim());
                    model.OverdueTime = Convert.ToDateTime(this.dpStart_Slide.Text.Trim());
                    model.Examine = this.chx_Slide_Examine.Checked ? 1 : 0;
                    model.StatClick = this.chx_Slide_ClickCount.Checked ? 1 : 0;
                    model.StatBrowse = this.chx_Slide_BorwsCount.Checked ? 1 : 0;

                    model.SizeBreadth = this.txt_Slide_Width.Text.Trim();
                    model.Hight = this.txt_Slide_Height.Text.Trim();
                    model.LinkAddress = this.txtLinkAddress4.Text.Trim();
                    model.Hint = this.txtHint4.Text.Trim();
                    model.BackgorTarget = Convert.ToInt32(this.rlistTarget4.SelectedValue);
                    model.Advertisecont = this.txtContent4.Text.Trim();
                    System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                    string slide_path = "";
                    string slide_error_info = "";
                    if (files.Count > 1)//说明图片大小和格式都没问题
                    {
                        ChangeHope.Common.UploadFile slide_uf = new ChangeHope.Common.UploadFile();
                        slide_uf.ExtensionLim = ".gif,.jpg,.jpeg,.dmp";
                        slide_uf.FileLengthLim = sp.ImageSize;
                        for (int i = 2; i < files.Count; i++)
                        {
                            slide_uf.MyFile = files[i];
                            slide_uf.SavePath = "/yxuploadfile/accessories/advertise";
                            if (slide_uf.HTMLUpLoad())
                            {
                                if (slide_uf.HaveLoad)
                                {
                                    if (slide_path == "")
                                    {

                                        slide_path = slide_uf.FilePath;
                                    }
                                    else
                                    {
                                        slide_path += "|" + slide_uf.FilePath;
                                    }
                                }
                                else
                                {
                                    slide_error_info += slide_uf.Message + "</br>";
                                    break;
                                }
                            }
                            else
                            {
                                slide_error_info += slide_uf.Message + "</br>";
                                break;
                            }
                        }
                        if (!string.IsNullOrEmpty(adId) && ChangeHope.WebPage.PageRequest.GetFormString("hfImagesAddress") != "")
                        {
                            slide_path += "|" + ChangeHope.WebPage.PageRequest.GetFormString("hfImagesAddress");
                        }
                        if (slide_error_info != "")
                        {
                            this.ltlMsg.Text = "操作失败，" + slide_error_info + "";
                            this.pnlMsg.Visible = true;
                            this.pnlMsg.CssClass = "actionErr";
                            return;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(adId) && ChangeHope.WebPage.PageRequest.GetFormString("hfImagesAddress") != "")
                        {
                            slide_path = ChangeHope.WebPage.PageRequest.GetFormString("hfImagesAddress");
                        }
                    }
                    
                    model.UpspreadAdd = slide_path;
                    model.Adtype = 3;
                    if (string.IsNullOrEmpty(adId))
                    {
                        if (bll.Add(model) > 0)
                        {
                            ChangeHope.WebPage.BasePage.PageRight("幻灯片广告已保存。", "advertise_info_edit.aspx");
                        }
                    }
                    else
                    {
                        model.ID = Convert.ToInt32(adId);
                        bll.Amend(model);
                        ChangeHope.WebPage.BasePage.PageRight("幻灯片广告修改成功。", "advertise_list.aspx");
                    }
                    this.ltlMsg.Text = "操作成功，已保存该信息";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionOk";
                    break;
            }
        }
        #endregion
    }
}
