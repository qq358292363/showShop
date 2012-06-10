namespace ChangeHope.Common
{
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Web;

    public class UploadProcesedImages
    {
        internal string _savewatermarkimagepath;
        internal string _sourceimagepath;
        internal int _thumbnailImageHeight;
        internal string _thumbnailimagepath;
        internal int _thumbnailimagewidth;
        internal ImageAlign _watermarkalign;
        internal string _watermarkimagepath;
        internal string _watermarktext;
        internal readonly string AllowExt = ".jpe|.jpeg|.jpg|.gif|.png|.tif|.tiff|.bmp";
        internal int diaphaneity;
        private string filePath = "";
        private static Hashtable htmimes = new Hashtable();
        internal float imageDeaphaneity;
        private string message = "";

        internal bool CheckValidExt(string sExt)
        {
            string[] strArray = this.AllowExt.Split(new char[] { '|' });
            foreach (string str in strArray)
            {
                if (str.ToLower() == sExt)
                {
                    return true;
                }
            }
            return false;
        }

        private static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo info in imageEncoders)
            {
                if (info.MimeType == mimeType)
                {
                    return info;
                }
            }
            return null;
        }

        internal void GetWaterMarkXY(out int wm_x, out int wm_y, int s_imagewidth, int s_imageheight, int wm_imagewidth, int wm_imageheight)
        {
            if (this.WaterMarkAlign == ImageAlign.LeftTop)
            {
                wm_x = 10;
                wm_y = 10;
            }
            else if (this.WaterMarkAlign == ImageAlign.LeftBottom)
            {
                wm_x = 10;
                wm_y = (s_imageheight - wm_imageheight) - 10;
            }
            else if (this.WaterMarkAlign == ImageAlign.RightTop)
            {
                wm_x = (s_imagewidth - wm_imagewidth) - 10;
                wm_y = 10;
            }
            else if (this.WaterMarkAlign == ImageAlign.RightBottom)
            {
                wm_x = (s_imagewidth - wm_imagewidth) - 10;
                wm_y = (s_imageheight - wm_imageheight) - 10;
            }
            else if (this.WaterMarkAlign == ImageAlign.Center)
            {
                wm_x = (s_imagewidth - wm_imagewidth) / 2;
                wm_y = (s_imageheight - wm_imageheight) / 2;
            }
            else if (this.WaterMarkAlign == ImageAlign.CenterBottom)
            {
                wm_x = (s_imagewidth - wm_imagewidth) / 2;
                wm_y = (s_imageheight - wm_imageheight) - 10;
            }
            else if (this.WaterMarkAlign == ImageAlign.CenterTop)
            {
                wm_x = (s_imagewidth - wm_imagewidth) / 2;
                wm_y = 10;
            }
            else
            {
                wm_x = (s_imagewidth - wm_imagewidth) - 10;
                wm_y = (s_imageheight - wm_imageheight) - 10;
            }
        }

        public bool ToThumbnailImage()
        {
            if (this.SourceImagePath.ToString() == string.Empty)
            {
                throw new NullReferenceException("SourceImagePath is null!");
            }
            string sExt = this.SourceImagePath.Substring(this.SourceImagePath.LastIndexOf(".")).ToLower();
            if (!this.CheckValidExt(sExt))
            {
                this.message = "文件格式不正确,支持的格式有[ " + this.AllowExt + " ]";
                return false;
            }
            Image image = Image.FromFile(HttpContext.Current.Server.MapPath("~/" + this.SourceImagePath), false);
            Bitmap bitmap = new Bitmap(this.ThumbnailImageWidth, this.ThumbnailImageHeight);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(image, new Rectangle(0, 0, this.ThumbnailImageWidth, this.ThumbnailImageHeight), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            image.Dispose();
            try
            {
                string str2 = (this.ThumbnailImagePath == null) ? this.SourceImagePath : this.ThumbnailImagePath;
                Random random = new Random();
                string str3 = "YX" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "_" + random.Next().ToString() + sExt;
                bitmap.Save(HttpContext.Current.Server.MapPath("~/" + str2) + @"\" + str3);
                if (str2.Substring(0, 1) == "/")
                {
                    str2 = str2.Substring(1, str2.Length - 1);
                }
                this.filePath = str2 + "/" + str3;
                return true;
            }
            catch (Exception exception)
            {
                this.message = exception.Message;
            }
            finally
            {
                bitmap.Dispose();
                graphics.Dispose();
            }
            return false;
        }

        public bool ToWaterMark()
        {
            Exception exception;
            Random random;
            string str3;
            int num10;
            int num11;
            FileHelper helper = new FileHelper();
            string str = (this.SaveWaterMarkImagePath == null) ? this.SourceImagePath : this.SaveWaterMarkImagePath;
            string sExt = this.SourceImagePath.Substring(this.SourceImagePath.LastIndexOf(".")).ToLower();
            if (this.SourceImagePath.ToString() == string.Empty)
            {
                throw new NullReferenceException("SourceImagePath is null!");
            }
            if (!this.CheckValidExt(sExt))
            {
                this.message = "原图片文件格式不正确,支持的格式有[ " + this.AllowExt + " ]";
                return false;
            }
            FileStream stream = File.OpenRead(HttpContext.Current.Server.MapPath("~/" + this.SourceImagePath));
            Image original = Image.FromStream(stream, true);
            stream.Close();
            int width = original.Width;
            int height = original.Height;
            float horizontalResolution = original.HorizontalResolution;
            float verticalResolution = original.VerticalResolution;
            Bitmap image = new Bitmap(original, width, height);
            original.Dispose();
            image.SetResolution(72f, 72f);
            Graphics graphics = Graphics.FromImage(image);
            try
            {
                if ((this.WaterMarkText != null) && (this.WaterMarkText.Trim().Length > 0))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, width, height, GraphicsUnit.Pixel);
                    int[] numArray = new int[] { 0x10, 14, 12, 10, 8, 6, 4 };
                    Font font = null;
                    SizeF ef = new SizeF(0f, 0f);
                    for (int i = 0; i < numArray.Length; i++)
                    {
                        font = new Font("arial", (float) numArray[i], FontStyle.Bold);
                        ef = graphics.MeasureString(this.WaterMarkText, font);
                        if (((ushort) ef.Width) < ((ushort) width))
                        {
                            break;
                        }
                    }
                    numArray = null;
                    float y = (height - ((int) (height * 0.05000000074505806))) - (ef.Height / 2f);
                    float x = width / 2;
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    graphics.DrawString(this.WaterMarkText, font, new SolidBrush(Color.FromArgb(0x99, 0, 0, 0)), new PointF(x + 1f, y + 1f), format);
                    graphics.DrawString(this.WaterMarkText, font, new SolidBrush(Color.FromArgb(this.Diaphaneity, 0xff, 0xff, 0xff)), new PointF(x, y), format);
                    format.Dispose();
                }
            }
            catch (Exception exception1)
            {
                exception = exception1;
                this.message = exception.Message;
            }
            finally
            {
                graphics.Dispose();
            }
            if ((this.WaterMarkImagePath == null) || (this.WaterMarkImagePath.Trim() == string.Empty))
            {
                random = new Random();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "_" + random.Next().ToString() + sExt;
                string str4 = HttpContext.Current.Server.MapPath("~/" + str);
                image.Save(str4 + @"\" + str3);
                helper.DeleteFile(HttpContext.Current.Server.MapPath("~/" + this.SourceImagePath));
                if (str.Substring(0, 1) == "/")
                {
                    str = str.Substring(1, str.Length - 1);
                }
                this.filePath = str + "/" + str3;
                return true;
            }
            Image image2 = Image.FromFile(HttpContext.Current.Server.MapPath("~/" + this.WaterMarkImagePath));
            int num8 = image2.Width;
            int num9 = image2.Height;
            if ((width < num8) || (height < (num9 * 2)))
            {
                random = new Random();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "_" + random.Next().ToString() + sExt;
                image.Save(HttpContext.Current.Server.MapPath("~/" + str) + @"\" + str3);
                helper.DeleteFile(HttpContext.Current.Server.MapPath("~/" + this.SourceImagePath));
                if (str.Substring(0, 1) == "/")
                {
                    str = str.Substring(1, str.Length - 1);
                }
                this.filePath = str + "/" + str3;
                return true;
            }
            Bitmap bitmap2 = new Bitmap(image);
            image.Dispose();
            bitmap2.SetResolution(horizontalResolution, verticalResolution);
            Graphics graphics2 = Graphics.FromImage(bitmap2);
            ImageAttributes imageAttr = new ImageAttributes();
            ColorMap map = new ColorMap();
            map.OldColor = Color.FromArgb(0xff, 0, 0xff, 0);
            map.NewColor = Color.FromArgb(0, 0, 0, 0);
            imageAttr.SetRemapTable(new ColorMap[] { map }, ColorAdjustType.Bitmap);
            float[][] newColorMatrix = new float[5][];
            float[] numArray3 = new float[5];
            numArray3[0] = 1f;
            newColorMatrix[0] = numArray3;
            numArray3 = new float[5];
            numArray3[1] = 1f;
            newColorMatrix[1] = numArray3;
            numArray3 = new float[5];
            numArray3[2] = 1f;
            newColorMatrix[2] = numArray3;
            numArray3 = new float[5];
            numArray3[3] = this.ImageDeaphaneity;
            newColorMatrix[3] = numArray3;
            numArray3 = new float[5];
            numArray3[4] = 1f;
            newColorMatrix[4] = numArray3;
            imageAttr.SetColorMatrix(new ColorMatrix(newColorMatrix), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            this.GetWaterMarkXY(out num10, out num11, width, height, num8, num9);
            graphics2.DrawImage(image2, new Rectangle(num10, num11, num8, num9), 0, 0, num8, num9, GraphicsUnit.Pixel, imageAttr);
            imageAttr.ClearColorMatrix();
            imageAttr.ClearRemapTable();
            image2.Dispose();
            graphics2.Dispose();
            try
            {
                random = new Random();
                str3 = "YXShop" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "_" + random.Next().ToString() + sExt;
                bitmap2.Save(HttpContext.Current.Server.MapPath("~/" + str) + @"\" + str3);
                helper.DeleteFile(HttpContext.Current.Server.MapPath("~/" + this.SourceImagePath));
                if (str.Substring(0, 1) == "/")
                {
                    str = str.Substring(1, str.Length - 1);
                }
                this.filePath = str + "/" + str3;
                return true;
            }
            catch (Exception exception2)
            {
                exception = exception2;
                this.message = exception.Message;
            }
            finally
            {
                bitmap2.Dispose();
            }
            return false;
        }

        public int Diaphaneity
        {
            get
            {
                return this.diaphaneity;
            }
            set
            {
                this.diaphaneity = value;
            }
        }

        public string FilePath
        {
            get
            {
                return this.filePath;
            }
            set
            {
                this.filePath = value;
            }
        }

        public float ImageDeaphaneity
        {
            get
            {
                return this.imageDeaphaneity;
            }
            set
            {
                this.imageDeaphaneity = value;
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }
        }

        public string SaveWaterMarkImagePath
        {
            get
            {
                return this._savewatermarkimagepath;
            }
            set
            {
                this._savewatermarkimagepath = value;
            }
        }

        public string SourceImagePath
        {
            get
            {
                return this._sourceimagepath;
            }
            set
            {
                this._sourceimagepath = value;
            }
        }

        public int ThumbnailImageHeight
        {
            get
            {
                return this._thumbnailImageHeight;
            }
            set
            {
                this._thumbnailImageHeight = value;
            }
        }

        public string ThumbnailImagePath
        {
            get
            {
                return this._thumbnailimagepath;
            }
            set
            {
                this._thumbnailimagepath = value;
            }
        }

        public int ThumbnailImageWidth
        {
            get
            {
                return this._thumbnailimagewidth;
            }
            set
            {
                this._thumbnailimagewidth = value;
            }
        }

        public ImageAlign WaterMarkAlign
        {
            get
            {
                return this._watermarkalign;
            }
            set
            {
                this._watermarkalign = value;
            }
        }

        public string WaterMarkImagePath
        {
            get
            {
                return this._watermarkimagepath;
            }
            set
            {
                this._watermarkimagepath = value;
            }
        }

        public string WaterMarkText
        {
            get
            {
                return this._watermarktext;
            }
            set
            {
                this._watermarktext = value;
            }
        }
    }
}

