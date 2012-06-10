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
using System.Threading;

namespace ShowShop.Web.admin.accessories
{
    public partial class backdatabase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("012011006");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty)
                {
                    string type = ChangeHope.WebPage.PageRequest.GetFormString("Option");
                    switch (type)
                    {
                        case "delFile":
                            ShowShop.Common.PromptInfo.Popedom("012011003", "对不起，您没有权限进行删除");
                            string filepath = ChangeHope.WebPage.PageRequest.GetFormString("path");
                            delFile(filepath);
                            break;
                    }
                    Response.End();
                    return;
                }
                if (ChangeHope.WebPage.PageRequest.GetString("fileName") != string.Empty)
                {
                    this.DownLoad(ChangeHope.WebPage.PageRequest.GetString("fileName"));
                }
                Get();
            }
        }

        #region 显示文件
        /// <summary>
        /// 显示文件目录
        /// </summary>
        public void Get()
        {
            string str_lujing = "~\\backdatabase";
            DirectoryInfo[] ChildDirectory;                         
            FileInfo[] NewFileInfo;                               
            DirectoryInfo FatherDirectory = new DirectoryInfo(Server.MapPath(str_lujing)); 
            ChildDirectory = FatherDirectory.GetDirectories("*.*"); 
            NewFileInfo = FatherDirectory.GetFiles();               
            string str_html = "<table width=\"100%\" id=\"tablist\"  cellspacing=\"0\" cellpadding=\"0\" border=\"1\" bordercolorlight=\"#DDDDDD\""
            + "class=\"datatable\" bordercolordark=\"#FFFFFF\"><tr class='TrTitle' bgcolor='#78B9E6' style='color: White' height='25'><th width='25%'>文件名</th><th width='10%'>类型</th><th width='10%'>大小</th>"
            + "<th width='20%'>创建时间</th><th width='10%'>操作</th></tr>";
            foreach (FileInfo fi in NewFileInfo)//显示文件
            {
                if (fi.Name.Contains(".dat"))
                {
                    string strh1 = "<tr height='25'><td><img src='../images/img/html.gif' />" + fi.Name + "</td><td>" + fi.Extension + "文件</td><td  align='center'>" + fi.Length + "字节</td><td  align='center'>"
                    + fi.LastWriteTimeUtc + "</td><td><a href=\"?fileName=" + (fi.Name) + "\">下载</a>&nbsp;<a href=\"javascript:DelFile('backdatabase\\\\" + (fi.Name) + "')\">删除</a></td></tr>";
                    str_html += strh1;
                }
            }
            str_html += "</table>";
            this.litBackDataBase.Text = str_html;
        }
        #endregion

        #region 备份数据库
        protected void btnBackDataBase_Click(object sender, EventArgs e)
        {
            string dataBaseName =DateTime.Now.ToString("yy-MM-dd") + "DatabaseBackup_" + ChangeHope.Common.DEncryptHelper.GetRandWord(8) + ".dat";
            string FileName = Request.MapPath(Request.ApplicationPath + "\\backdatabase") + "\\" + dataBaseName + "";
            if (!ChangeHope.Common.NetWorkHelper.DbBackup(FileName))
            {
                ChangeHope.WebPage.Script.Alert("备份数据库时出错,\n\n请用数据库管理工具管理数据库备份和恢复.");
                return;
            }
            int loopCount = 0;
            while ((!File.Exists(FileName)) && (loopCount < 10))
            {
                Thread.Sleep(1000);
                loopCount++;
            }
            
        }
        #endregion

        #region 下载数据库
        protected void DownLoad(string FileName)
        {
            FileName = Request.MapPath(Request.ApplicationPath + "\\backdatabase") + "\\" + FileName + "";
            FileStream fs = File.Open(FileName, FileMode.Open, FileAccess.Read);
            byte[] content = new byte[fs.Length];
            fs.Read(content, 0, (int)fs.Length);
            fs.Close();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "UTF-8";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            Response.ContentType = "application/oct-stream";
            Response.AppendHeader("content-disposition", "Attachment; filename=" + Server.UrlEncode(FileName));
            Response.BinaryWrite(content);
            Response.Flush();
            Response.Write(FileName);
            Response.Redirect("backdatabase.aspx");
            Response.End();
        }
        #endregion

        #region 删除文件
        protected void delFile(string path)
        {
            ChangeHope.Common.FileHelper fh = new ChangeHope.Common.FileHelper();
            if (fh.DeleteFile(Server.MapPath("~\\" + path)))
            {
                Response.Write("ok");
            }
            else
            {
                Response.Write("删除失败！");
            }
        }
        #endregion
    }
}
