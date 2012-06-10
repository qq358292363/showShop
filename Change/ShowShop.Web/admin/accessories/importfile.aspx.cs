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
using System.IO;
using ChangeHope.Common;

namespace ShowShop.Web.admin.accessories
{
    public partial class importfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void butUpFile_Click(object sender, EventArgs e)
        {
            ChangeHope.Common.UploadFile uf = new ChangeHope.Common.UploadFile();
            uf.ExtensionLim = ".jpe|.jpeg|.jpg|.gif|.png|.tif|.tiff|.bmp";
            uf.FileLengthLim = 4000;
            uf.PostedFile = this.fufile;
            uf.SavePath = this.path.Value;
            uf.FileSaveMethod = "d";
            if (uf.Upload())
            {
                if (uf.HaveLoad)
                {
                    this.ltlMsg.Text = "操作成功，上传文件以保存.";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionOk";
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
    }
}
