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

namespace ShowShop.Web.admin.product
{
    public partial class product_specialspecification : System.Web.UI.Page
    {
        protected string Color ="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Form["Option"] != null && !Request.Form["Option"].Trim().Equals("")
                  && Request.Form["ID"] != null && !Request.Form["ID"].Trim().Equals(""))
                {
                    string types = Request.Form["Option"].Trim();
                    if (types == "delAlbum")
                    {
                        string id = ChangeHope.WebPage.PageRequest.GetFormString("ID");
                        this.DelAlbum(id);
                    }
                    Response.End();
                    return;
                }
                int productId = ChangeHope.WebPage.PageRequest.GetQueryInt("productId");
                int specificationId = ChangeHope.WebPage.PageRequest.GetQueryInt("id");
                string specificationValue = ChangeHope.WebPage.PageRequest.GetQueryString("val");
                string specificationName = ChangeHope.WebPage.PageRequest.GetQueryString("spec");
                this.speProperty.Text = specificationName + "--" + specificationValue;
                this.HyperLink1.NavigateUrl = "product_specialspecification_list.aspx?id=" + productId;
                this.HyperLink2.NavigateUrl = "product_specialspecification_list.aspx?id=" + productId;
                this.SpecificationValue.Text = specificationValue;
                this.BindInfo(productId, specificationId, 1);
            }
        }

        #region 删除相册图片
        private void DelAlbum(string Alubmid)
        {
            ShowShop.BLL.Product.ProductAlbum pabll = new ShowShop.BLL.Product.ProductAlbum();
            ShowShop.Model.Product.ProductAlbum pamodel = pabll.GetModelID(Convert.ToInt32(Alubmid));
            pabll.Delete(Convert.ToInt32(Alubmid));
            if (pamodel != null)
            {
                ChangeHope.Common.FileHelper fh = new ChangeHope.Common.FileHelper();
                if (!string.IsNullOrEmpty(pamodel.OriginalAddress))
                {
                    fh.DeleteFile(Server.MapPath("~//" + pamodel.OriginalAddress));
                }
                if (!string.IsNullOrEmpty(pamodel.ThumbnailAddress))
                {
                    fh.DeleteFile(Server.MapPath("~//" + pamodel.ThumbnailAddress));
                }
                Response.Write(this.BindPhoto(pamodel.SpecificaticationSignId));
            }
        }
        #endregion

        #region 绑定信息
        private void BindInfo(int ProductID,int SpecificaticationSignId,int IsSpecialspecificationsSign)
        {
            ShowShop.BLL.Product.ProductAlbum bll = new ShowShop.BLL.Product.ProductAlbum();
            DataTable dt = bll.GetProAlbumAll(ProductID, SpecificaticationSignId, IsSpecialspecificationsSign);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["OriginalAddress"].ToString().Contains("#"))
                {
                    this.TitleColor.Value = dt.Rows[0]["OriginalAddress"].ToString().Replace("#", "");
                    this.rblSpecSign.SelectedValue = "1";
                    this.ColorSign.Style.Value = "display:";
                    this.ColorAddressImages.Style.Value = "display:none";
                    Color = dt.Rows[0]["OriginalAddress"].ToString().Replace("#", "");
                }
                else
                {
                    ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
                    this.SignImages.Text = "<img width='20px' alt='上传的图标' height='20px' src='" +sp.DummyPaht+ dt.Rows[0]["OriginalAddress"].ToString() + "'>";
                    this.rblSpecSign.SelectedValue = "2";
                    this.ColorSign.Style.Value = "display:none";
                    this.ColorAddressImages.Style.Value = "display:";
                    ViewState["ColorSignImages"] = dt.Rows[0]["OriginalAddress"].ToString();
                }
                ViewState["ID"] = dt.Rows[0]["id"].ToString();
                this.litaAlbum.Text =this.BindPhoto(Convert.ToInt32(dt.Rows[0]["id"].ToString()));
            }

        }
        #endregion

        #region 绑定商品相册
        private string BindPhoto(int id)
        {
            StringBuilder shtml = new StringBuilder();
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            ShowShop.BLL.Product.ProductAlbum bll = new ShowShop.BLL.Product.ProductAlbum();
            DataTable dts = bll.GetProAlbumAll(0, id, 1);
            StringBuilder str = new StringBuilder();
            int j = 1;
            shtml.Append("<table border='0'>");
            shtml.Append("<tr>");
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                shtml.Append("<td align='center'><img width=\"100px\" height=\"100px\" src=\"" + sp.DummyPaht + dts.Rows[i]["originaladdress"].ToString() + "\"/><br/><br/><span onclick=\"DelProAlbum(" + dts.Rows[i]["id"].ToString() + ");\"  style=\"cursor:hand;width:45px\" >删除</span></td>");
                if (j % 6 == 0)
                {
                    shtml.Append("</tr><tr>");
                }
                j++;
            }
            shtml.Append("</tr></table>");
            return shtml.ToString();
        }
        #endregion

        #region 商品相册
        /// <summary>
        /// 上传商品相册图
        /// </summary>
        /// <param name="albumthumbnail"></param>
        /// <param name="ImagesThumbnailsWidth"></param>
        /// <param name="ImagesThumbnailsHeight"></param>
        /// <param name="WhetherWater"></param>
        /// <param name="ImageWatermarkTransparent"></param>
        /// <param name="TextWatermarkTransparent"></param>
        /// <param name="WatermarkPosition"></param>
        /// <param name="WatermarkImage"></param>
        /// <param name="WatermarkText"></param>
        /// <param name="TextOrImagesWatermark"></param>
        protected string Album(int ImagesThumbnailsWidth, int ImagesThumbnailsHeight, bool WhetherWater, int ImageWatermarkTransparent, int TextWatermarkTransparent, string WatermarkPosition, string WatermarkImage, string WatermarkText, string TextOrImagesWatermark, bool IsModfiy, int SignId)
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            string gomessage = "";
            ShowShop.BLL.Product.ProductInfo bll = new ShowShop.BLL.Product.ProductInfo();
            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            ShowShop.BLL.Product.ProductAlbum pabll = new ShowShop.BLL.Product.ProductAlbum();
            ShowShop.Model.Product.ProductAlbum pamodel = new ShowShop.Model.Product.ProductAlbum();
            string[] rd = null;
            string des = ChangeHope.WebPage.PageRequest.GetFormString("description");
            if (!string.IsNullOrEmpty(des))
            {
                rd = des.Split(',');//获得图片描述的文本框字符串数组，为对应的图片的描述
            }
            if (files.Count > 1)//说明图片大小和格式都没问题
            {
                ShowShop.BLL.Product.ProductAlbum PGBLL = new ShowShop.BLL.Product.ProductAlbum();
                ShowShop.Model.Product.ProductAlbum PGModel = new ShowShop.Model.Product.ProductAlbum();
                int autouFile=files.Count;
                ChangeHope.Common.UploadProcesedImages wm = new ChangeHope.Common.UploadProcesedImages();
                ChangeHope.Common.UploadFile uf = new ChangeHope.Common.UploadFile();
                string AlbumThumbnailSave = "/yxuploadfile/product/albumthumbnail";
                string AlbumOriginalSave = "/yxuploadfile/product/albumoriginal";
                string AlbumThumbnail = string.Empty;
                string AlbumOriginal = string.Empty;
                string Message = string.Empty;
                uf.ExtensionLim = ".gif,.jpg,.jpeg,.bmp";
                uf.FileLengthLim = sp.ImageSize;
                for (int i = 1; i < files.Count; i++)
                {
                    uf.MyFile = files[i];
                    uf.SavePath = AlbumOriginalSave;
                    if (uf.HTMLUpLoad())
                    {
                        if (uf.HaveLoad)
                        {
                            AlbumOriginal = uf.FilePath;
                            //原图缩略图
                            wm.SourceImagePath = AlbumOriginal;
                            wm.ThumbnailImagePath = AlbumOriginalSave;
                            wm.ThumbnailImageWidth = ImagesThumbnailsWidth;
                            wm.ThumbnailImageHeight = ImagesThumbnailsHeight;
                            if (wm.ToThumbnailImage())
                            {
                                AlbumThumbnail = wm.FilePath;
                            }
                            else
                            {
                                gomessage += "<br>" + wm.Message;

                            }
                        }
                        else
                        {
                            gomessage += "<br>" + uf.Message;
                        }
                        if (WhetherWater)
                        {
                            //原图水印
                            if (!string.IsNullOrEmpty(AlbumOriginal))
                            {
                                wm.SourceImagePath = AlbumOriginal;
                                wm.ImageDeaphaneity = float.Parse(ImageWatermarkTransparent.ToString());
                                wm.Diaphaneity = TextWatermarkTransparent;
                                switch (WatermarkPosition)
                                {
                                    case "1":
                                        wm.WaterMarkAlign = ChangeHope.Common.ImageAlign.LeftTop;
                                        break;
                                    case "2":
                                        wm.WaterMarkAlign = ChangeHope.Common.ImageAlign.LeftBottom;
                                        break;
                                    case "3":
                                        wm.WaterMarkAlign = ChangeHope.Common.ImageAlign.RightTop;
                                        break;
                                    case "4":
                                        wm.WaterMarkAlign = ChangeHope.Common.ImageAlign.RightBottom;
                                        break;
                                    case "5":
                                        wm.WaterMarkAlign = ChangeHope.Common.ImageAlign.CenterTop;
                                        break;
                                    case "9":
                                        wm.WaterMarkAlign = ChangeHope.Common.ImageAlign.Center;
                                        break;
                                    case "7":
                                        wm.WaterMarkAlign = ChangeHope.Common.ImageAlign.CenterBottom;
                                        break;
                                }
                                if (TextOrImagesWatermark == "0")
                                {
                                    //图片水印
                                    if (!string.IsNullOrEmpty(WatermarkImage))
                                    {
                                        wm.WaterMarkImagePath = WatermarkImage;
                                    }
                                    else
                                    {
                                        gomessage += "<br>" + "操作失败，上传图片水印失败，请确认系统设置水印图片是否存在。";
                                    }
                                }
                                else
                                {
                                    //文字水印
                                    if (!string.IsNullOrEmpty(WatermarkText))
                                    {
                                        wm.WaterMarkText = WatermarkText;
                                    }
                                    else
                                    {
                                        gomessage += "<br>" + "操作失败，上传图片水印失败，请确认系统设置水印文字是否存在。";
                                    }
                                }
                                wm.SaveWaterMarkImagePath = AlbumOriginalSave;
                                if (wm.ToWaterMark())
                                {
                                    AlbumOriginal = wm.FilePath;
                                }
                                else
                                {
                                    gomessage += "<br>" + "操作失败，" + wm.Message + "";
                                }
                            }
                            //原图缩略图水印
                            if (!string.IsNullOrEmpty(AlbumThumbnail))
                            {
                                wm.SourceImagePath = AlbumThumbnail;
                                wm.ImageDeaphaneity = float.Parse(ImageWatermarkTransparent.ToString());
                                wm.Diaphaneity = TextWatermarkTransparent;
                                switch (WatermarkPosition)
                                {
                                    case "1":
                                        wm.WaterMarkAlign = ChangeHope.Common.ImageAlign.LeftTop;
                                        break;
                                    case "2":
                                        wm.WaterMarkAlign = ChangeHope.Common.ImageAlign.LeftBottom;
                                        break;
                                    case "3":
                                        wm.WaterMarkAlign = ChangeHope.Common.ImageAlign.RightTop;
                                        break;
                                    case "4":
                                        wm.WaterMarkAlign = ChangeHope.Common.ImageAlign.RightBottom;
                                        break;
                                    case "5":
                                        wm.WaterMarkAlign = ChangeHope.Common.ImageAlign.CenterTop;
                                        break;
                                    case "9":
                                        wm.WaterMarkAlign = ChangeHope.Common.ImageAlign.Center;
                                        break;
                                    case "7":
                                        wm.WaterMarkAlign = ChangeHope.Common.ImageAlign.CenterBottom;
                                        break;
                                }
                                if (TextOrImagesWatermark == "0")
                                {
                                    //图片水印
                                    if (!string.IsNullOrEmpty(WatermarkImage))
                                    {
                                        wm.WaterMarkImagePath = WatermarkImage;
                                    }
                                    else
                                    {
                                        gomessage += "<br>" + "操作失败，上传图片水印失败，请确认系统设置水印图片是否存在。";
                                    }
                                }
                                else
                                {
                                    //文字水印
                                    if (!string.IsNullOrEmpty(WatermarkText))
                                    {
                                        wm.WaterMarkText = WatermarkText;
                                    }
                                    else
                                    {
                                        gomessage += "<br>" + "操作失败，上传图片水印失败，请确认系统设置水印文字是否存在。";
                                    }
                                }
                                wm.SaveWaterMarkImagePath = AlbumThumbnailSave;
                                if (wm.ToWaterMark())
                                {
                                    AlbumThumbnail = wm.FilePath;
                                }
                                else
                                {
                                    gomessage += "<br>" + "操作失败，" + wm.Message + "";
                                }
                            }

                        }
                    }
                    pamodel.Productid = 0;
                    pamodel.OriginalAddress = AlbumOriginal;
                    pamodel.ThumbnailAddress = AlbumThumbnail;
                    pamodel.IsSpecialspecificationsSign = 1;
                    pamodel.SpecificaticationSignId = SignId;
                    pamodel.Description = "";
                    if (AlbumThumbnail != string.Empty)
                    {
                        pabll.Add(pamodel);
                    }
                }

            }
            return gomessage;
        }
        #endregion

        #region 保存信息
        protected void button2_Click(object sender, EventArgs e)
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            bool WhetherWater = sp.IsWatermark;
            string ThumbnailSavePath = "/yxuploadfile/product/thumbnail";
            int ThumbnailsHeight = sp.ThumbnailsHeight;
            int ThumbnailsWidth = sp.ThumbnailsWidth;
            int ImagesThumbnailsHeight = sp.ImagesThumbnailsHeight;
            int ImagesThumbnailsWidth = sp.ImagesThumbnailsWidth;
            int TextWatermarkTransparent = sp.TextWatermarkTransparent;
            int ImageWatermarkTransparent = sp.ImageWatermarkTransparent;
            string TextOrImagesWatermark = sp.TextOrImagesWatermark;
            string WatermarkText = sp.WatermarkText;
            string WatermarkImage = sp.WatermarkImage;
            string WatermarkPosition = sp.WatermarkPosition;
            string Original = string.Empty;
            string OriginalThumbnails = string.Empty;
            string ThumbnailsImage = string.Empty;

            int productId = ChangeHope.WebPage.PageRequest.GetQueryInt("productId");
            int specificationId = ChangeHope.WebPage.PageRequest.GetQueryInt("id");
            string colorSign = "";
            if (this.rblSpecSign.SelectedValue == "2")
            {
                if (this.fuColorSign.PostedFile.ContentLength > 2)
                {
                    ChangeHope.Common.UploadFile uf = new ChangeHope.Common.UploadFile();
                    uf.ExtensionLim = ".gif,.jpg,.jpeg,.bmp";
                    uf.FileLengthLim = sp.ImageSize;
                    uf.PostedFile = this.fuColorSign;
                    uf.SavePath = ThumbnailSavePath;

                    if (uf.Upload())
                    {
                        if (uf.HaveLoad)
                        {
                            colorSign = uf.FilePath;
                        }
                    }
                    else
                    {
                        this.ltlMsg.Text = "操作失败，" + uf.Message + "";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionOk";
                        return;
                    }
                }
                else
                {
                    if (ViewState["ID"] != null && ViewState["ColorSignImages"] != null)
                    {
                        colorSign = ViewState["ColorSignImages"].ToString();
                    }
                }
            }
            else
            {
                colorSign="#"+this.TitleColor.Value;
            }

            ShowShop.BLL.Product.ProductAlbum bll = new ShowShop.BLL.Product.ProductAlbum();
            ShowShop.Model.Product.ProductAlbum model = new ShowShop.Model.Product.ProductAlbum();
            model.Productid = productId;
            model.OriginalAddress = colorSign;
            model.IsSpecialspecificationsSign = 1;
            model.SpecificaticationSignId=specificationId;
            model.ThumbnailAddress = "";
            model.Description = "";
            int signId = 0;
            if (ViewState["ID"] != null)
            {
                model.ID = Convert.ToInt32(ViewState["ID"]);
                bll.Update(model);
                signId = Convert.ToInt32(ViewState["ID"]);
            }
            else
            {
                signId = bll.Add(model);
            }
            if (signId > 0)
            {
                string AlbumInfo = Album(ImagesThumbnailsWidth, ImagesThumbnailsHeight, WhetherWater, ImageWatermarkTransparent, TextWatermarkTransparent, WatermarkPosition, WatermarkImage, WatermarkText, TextOrImagesWatermark, true, signId);
                
                    ChangeHope.WebPage.BasePage.PageRight("操作成功。", "product_specialspecification_list.aspx?id=" + productId + "&putoutType=0");
            }
        }
        #endregion
    }
}
