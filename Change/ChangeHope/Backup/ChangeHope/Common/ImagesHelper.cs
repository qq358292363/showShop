namespace ChangeHope.Common
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Web;

    public class ImagesHelper
    {
        public void CreateCheckImage(string checkCode)
        {
            if ((checkCode != null) && !(checkCode.Trim() == string.Empty))
            {
                Bitmap image = new Bitmap((int) Math.Ceiling((double) (checkCode.Length * 12.5)), 0x16);
                Graphics graphics = Graphics.FromImage(image);
                try
                {
                    int num;
                    Random random = new Random();
                    graphics.Clear(Color.White);
                    for (num = 0; num < 0x19; num++)
                    {
                        int num2 = random.Next(image.Width);
                        int num3 = random.Next(image.Width);
                        int num4 = random.Next(image.Height);
                        int num5 = random.Next(image.Height);
                        graphics.DrawLine(new Pen(Color.Silver), num2, num4, num3, num5);
                    }
                    Font font = new Font("Arial", 12f, FontStyle.Italic | FontStyle.Bold);
                    LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                    graphics.DrawString(checkCode, font, brush, (float) 2f, (float) 2f);
                    for (num = 0; num < 100; num++)
                    {
                        int x = random.Next(image.Width);
                        int y = random.Next(image.Height);
                        image.SetPixel(x, y, Color.FromArgb(random.Next()));
                    }
                    graphics.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                    MemoryStream stream = new MemoryStream();
                    image.Save(stream, ImageFormat.Gif);
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.ContentType = "image/Gif";
                    HttpContext.Current.Response.BinaryWrite(stream.ToArray());
                }
                finally
                {
                    graphics.Dispose();
                    image.Dispose();
                }
            }
        }
    }
}

