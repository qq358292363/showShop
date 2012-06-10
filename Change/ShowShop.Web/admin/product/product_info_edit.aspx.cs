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
using System.Text;
using System.Text.RegularExpressions;
using ChangeHope.Common;
using ShowShop.BLL.Product;

namespace ShowShop.Web.admin.product
{
    public partial class product_info_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // ShowShop.Common.PromptInfo.Popedom("001008001");

            if (!IsPostBack)
            {
                this.litProductBrand.Text = this.BrandList(string.Empty);
                this.bindUnit(string.Empty);
                this.InitWebControl();
                //int productId =;// ChangeHope.WebPage.PageRequest.GetInt("id");
                if (Request["productNo"] != null)
                {
                    this.BindInfo(Convert.ToInt32(Request["productNo"]));
                }
                else
                {
                    ShowShop.BLL.Product.ProductInfo bll = new ShowShop.BLL.Product.ProductInfo();
                    string pro_No = bll.GetMax();
                    lb_ProductNo.Text = (Convert.ToInt32(pro_No) + 1).ToString("000000");
                }
            }
        }
        #region 验证
        /// <summary>
        /// 验证
        /// </summary>
        private void InitWebControl()
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            this.txtProductClass.Attributes.Add("readonly", "readonly");
            this.txtProductClass.Attributes.Add("onclick", "selectFile('Product_info_class',new Array(" + this.hfcid.ClientID + "," + this.txtProductClass.ClientID + "),310,450,'" + sp.DummyPaht + "');");
            ChangeHope.WebPage.WebControl.Validate(this.txtProductName, "输入商品名称的名称", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.SetDate(this.txtFilingTime);
            ChangeHope.WebPage.WebControl.SetDate(this.txtDownTime);
            ChangeHope.WebPage.WebControl.Validate(this.txtFilingTime, "商品在前台展示的开始时间", "ifisnull", "选填", "该项为选填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtDownTime, "商品在前台展示的结束时间", "ifisnull", "选填", "该项为选填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtMarketPrice, "输入市场价格将作为商城价格与市场价格进行对比", "ifisfloat", "选填", "该项为必须为数字");
            ChangeHope.WebPage.WebControl.Validate(this.txtCostPrice, "输入商城价", "ifisfloat", "选填", "该项为必须为数字");
            // ChangeHope.WebPage.WebControl.Validate(this.txtDonateInteg, "用户购买该商品否可以获得的积分数，为0表示购买该商品不赠送积分", "ifisint", "选填", "该项只能输入数字");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }
        #endregion
        #region 加载品牌
        /// <summary>
        /// 修改商品加载品牌
        /// </summary>
        /// <param name="CID"></param>
        /// <param name="BID"></param>
        protected string BrandList(string bid)
        {
            ShowShop.BLL.Product.ProductBrand bll = new ShowShop.BLL.Product.ProductBrand();
            List<ShowShop.Model.Product.ProductBrand> list = null;
            list = bll.GetCommonTypes();
            StringBuilder shtml = new StringBuilder();
            shtml.Append("<select name=\"selBrand\" id=\"selBrand\">");
            shtml.Append("<option value=\"0\">--选择品牌--</option>");
            if (list != null && list.Count > 0)
            {
                foreach (Model.Product.ProductBrand brand in list)
                {
                    shtml.Append("<option value=\"" + brand.ID + "\"");
                    if (brand.ID.ToString() == bid)
                    {
                        shtml.Append(" selected=\"selected\" ");
                    }
                    shtml.Append(">" + brand.Name + "</option>");
                }
            }
            shtml.Append("</select>");
            return shtml.ToString();
        }
        #endregion
        #region 加载商品单位
        protected void bindUnit(string unit)
        {
            ShowShop.BLL.Product.ProductUnit bll = new ShowShop.BLL.Product.ProductUnit();
            ChangeHope.DataBase.DataByPage dataPage = bll.GetList();
            StringBuilder shtml = new StringBuilder();
            shtml.Append("<select name=\"selUnit\" id=\"selUnit\">");
            shtml.Append("<option value=\"0\" selected=\"selected\">--选择单位--</option>");
            if (dataPage.DataReader != null)
            {

                while (dataPage.DataReader.Read())
                {
                    if (dataPage.DataReader["name"].ToString() == unit)
                    {
                        shtml.Append("<option value=\"" + dataPage.DataReader["name"].ToString() + "\" selected=\"selected\">" + dataPage.DataReader["name"].ToString() + "</option>");
                    }
                    else
                    {
                        shtml.Append("<option value=\"" + dataPage.DataReader["name"].ToString() + " \">" + dataPage.DataReader["name"].ToString() + "</option>");
                    }
                }
                dataPage.Dispose();
                dataPage = null;
            }

            shtml.Append("</select>");
            this.litUnit.Text = shtml.ToString();
        }
        #endregion



        #region 删除相册图片
        private void DelAlbum(string Alubmid)
        {
            ShowShop.BLL.Product.ProductAlbum pabll = new ShowShop.BLL.Product.ProductAlbum();
            ShowShop.Model.Product.ProductAlbum pamodel = pabll.GetModelID(Convert.ToInt32(Alubmid));
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
                Response.Write(this.bindAlbum(pamodel.Productid));
            }
            pabll.Delete(Convert.ToInt32(Alubmid));
        }
        #endregion
        #region 绑定商品信息
        protected void BindInfo(int ProductId)
        {
            ShowShop.BLL.Product.ProductInfo bll = new ShowShop.BLL.Product.ProductInfo();
            ShowShop.Model.Product.ProductInfo model = bll.GetModel(ProductId);
            this.hfcid.Value = model.ClassID.ToString();  //商品id  
            #region 商品类别名称
            Productclass proClass = new Productclass();
            ShowShop.Model.Product.Productclass modelClass = proClass.GetModelID(model.ClassID);
            this.txtProductClass.Text = modelClass.Name;
            #endregion
            lb_ProductNo.Text = model.ProductNo;//商品编号
            this.txtProductName.Text = model.ProductName;//商品名称
            this.txtProductAttachName.Text = model.ProductAttachName;//商品附加名称
            this.litProductBrand.Text = this.BrandList(model.BrandID.ToString());//商品品牌
            this.bindUnit(model.Unit);//商品单位
            this.rblIsShelves.SelectedValue = model.IsAuto.ToString();//是否上下架（0下架1上架）
            this.txtFilingTime.Text = model.AutoUp.ToString();//上架时间
            this.txtDownTime.Text = model.AutoDown.ToString();//下架时间
            this.txtMarketPrice.Text = Convert.ToDouble(model.MarketPrice).ToString("f2");//市场价格
            this.txtCostPrice.Text = Convert.ToDouble(model.ShopPrice).ToString("f2");//商城价格
            ViewState["pro_Thumbnail"] = model.Thumbnail;//缩略图
            this.txtDescription.Text = model.Synopsis;//商品简介
            this.txtContent.Value = model.ProductContent;//商品明细
            this.litaAlbum.Text = this.bindAlbum(ProductId);
            ViewState["ID"] = model.ProductID;//商品ID

        }
        #region 绑定商品相册
        protected string bindAlbum(int productid)
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            ShowShop.BLL.Product.ProductAlbum pabll = new ShowShop.BLL.Product.ProductAlbum();
            DataTable dt = pabll.GetProAlbumAll(productid, -1, 0);
            StringBuilder str = new StringBuilder();
            int j = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str.Append("<td align='center'><img width=\"100px\" height=\"100px\" src=\"" + sp.DummyPaht + dt.Rows[i]["originaladdress"].ToString() + "\"/><br/><br/><span onclick=\"DelProAlbum(" + dt.Rows[i]["id"].ToString() + ");\"  style=\"cursor:hand;width:45px\" >删除</span></td>");
                if (j % 6 == 0)
                {
                    str.Append("</tr><tr>");
                }
                j++;
            }

            return str.ToString();
        }
        #endregion

        #endregion

        #region 修改与添加
        protected void butSave_Click(object sender, EventArgs e)
        {
            ShowShop.BLL.Product.ProductInfo bll = new ShowShop.BLL.Product.ProductInfo();
            ShowShop.Model.Product.ProductInfo model = new ShowShop.Model.Product.ProductInfo();
            #region 数据准备
            model.ProductNo = lb_ProductNo.Text.Trim();//商品编号
            model.ProductName = this.txtProductName.Text;//商品名称
            model.ProductAttachName = txtProductAttachName.Text.Trim();//附加名称
            model.ClassID = this.hfcid.Value != "" ? int.Parse(this.hfcid.Value) : 0;//商品类别Id
            model.BrandID = Convert.ToInt32(ChangeHope.WebPage.PageRequest.GetFormString("selBrand"));//品牌
            model.Unit = ChangeHope.WebPage.PageRequest.GetFormString("selUnit") == "0" ? "" : ChangeHope.WebPage.PageRequest.GetFormString("selUnit");//商品单位
            model.MarketPrice = this.txtMarketPrice.Text.Trim() != "" ? Convert.ToDecimal(this.txtMarketPrice.Text.Trim()) : 0;//市场价格
            model.ShopPrice = this.txtCostPrice.Text.Trim() != "" ? Convert.ToDecimal(this.txtCostPrice.Text.Trim()) : 0;//商城价格
            model.Synopsis = this.txtDescription.Text;//商品简介
            model.ProductContent = this.txtContent.Value;//商品明细
            model.AutoUp = this.txtFilingTime.Text.Trim() != "" ? Convert.ToDateTime(this.txtFilingTime.Text.Trim()) : System.DateTime.Now;//上架时间
            model.AutoDown = this.txtDownTime.Text.Trim() != "" ? Convert.ToDateTime(this.txtDownTime.Text.Trim()) : Convert.ToDateTime("2020-01-01");//下架时间
            model.UpdateTime = System.DateTime.Now;//更新时间
            model.IsAuto = Convert.ToInt32(rblIsShelves.SelectedValue);//是否上架

            #endregion
            #region 图片
            string thumbnailPath = System.Configuration.ConfigurationManager.AppSettings["ImgThumbnailPath"].ToString();
            string SavePath = "/imageFile/product/thumbnail";
            string thumbnail = string.Empty;
            if (fuPic.HasFile)
            {
                //原图
                ChangeHope.Common.UploadFile uf = new ChangeHope.Common.UploadFile();
                uf.ExtensionLim = ".gif,.jpg,.jpeg,.bmp";
                uf.FileLengthLim = 1024;
                uf.PostedFile = this.fuPic;
                uf.SavePath = SavePath;
                if (uf.Upload())
                {
                    thumbnail = uf.FilePath;
                }
                else
                {
                    this.ltlMsg.Text = "操作失败，" + uf.Message + "";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionOk";
                    return;
                }
            }
            model.Thumbnail = thumbnail;//缩略图地址
            #endregion
            if (ViewState["ID"] != null)
            {
                ShowShop.Common.PromptInfo.Popedom("001008004", "对不起，您没有编辑权限");
                model.ProductID = Convert.ToInt32(ViewState["ID"].ToString());
                //相册
                string AlbumInfo = Album(100, 100, true, Convert.ToInt32(ViewState["ID"].ToString()));
                string reStr = string.Empty;
                ChangeHope.WebPage.BasePage.PageRight("操作成功，您的已修改该商品信息。", "product_list.aspx?q_PutoutType=", "<li>" + reStr + "</li>");
            }
            else
            {
                ShowShop.Common.PromptInfo.Popedom("001008002", "对不起，您没有新增权限");
                //相册

                int productId = bll.Add(model);
                string AlbumInfo = Album(100, 100, false, productId);
                string reStr = string.Empty;
                if (productId > 0)
                {
                    ChangeHope.WebPage.BasePage.PageRight("操作成功，您的添加的商品信息已保存。", "product_info_edit.aspx?putoutType=", "<li>" + reStr + "</li>");
                }
                else
                {
                    ChangeHope.WebPage.BasePage.PageError("操作失败，您的添加的商品信息保存失败。", "product_info_edit.aspx?putoutType=", "<li>" + reStr + "</li>");
                }
            }
        }
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
        protected string Album(int ImagesThumbnailsWidth, int ImagesThumbnailsHeight, bool IsModfiy, int ProductId)
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            string gomessage = "";
            int proId = 0;
            ShowShop.BLL.Product.ProductInfo bll = new ShowShop.BLL.Product.ProductInfo();
            if (IsModfiy)
            {
                proId = ProductId;
            }
            else
            {
                //if (bll.GetMax() == 0)
                //{
                //    return gomessage = "相册上传失败";
                //}
                //else
                //{
                //    proId = bll.GetMax() + 1;
                //}
            }
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
                int autouFile = files.Count;
                ChangeHope.Common.UploadProcesedImages wm = new ChangeHope.Common.UploadProcesedImages();
                ChangeHope.Common.UploadFile uf = new ChangeHope.Common.UploadFile();
                string AlbumOriginalSave = "/imageFile/product/album";
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
                    }
                    pamodel.Productid = proId;
                    pamodel.OriginalAddress = AlbumOriginal;
                    pamodel.ThumbnailAddress = AlbumThumbnail;
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
        #endregion


    }
}
