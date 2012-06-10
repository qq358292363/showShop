using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace ShowShop.Web.admin.systeminfo
{
    public partial class site_sysinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                DateTime timeBegin = DateTime.Now;
                //获取系统信息
                GetServerInfo();
                CheckObject();
                DateTime timeEnd = DateTime.Now;
                this.ltlTimes.Text = (timeEnd - timeBegin).TotalMilliseconds.ToString() + "毫秒";
            }
        }

        private void GetServerInfo()
        {
            this.ltlServerName.Text = Server.MachineName;
            this.ltlServerIP.Text = Request.ServerVariables["LOCAL_ADDR"];
            this.ltlServerDomain.Text = Request.ServerVariables["SERVER_NAME"];
            this.ltlServerPort.Text = Request.ServerVariables["SERVER_PORT"];
            this.ltlServerTime.Text = System.DateTime.Now.ToString();
            this.ltlServerIISVersion.Text = Request.ServerVariables["SERVER_SOFTWARE"].Equals("") ? "未知的服务器版本" : Request.ServerVariables["SERVER_SOFTWARE"];
            this.ltlServerOvertime.Text = Server.ScriptTimeout.ToString() + "秒";
            this.ltlServerPath.Text = Request.ServerVariables["APPL_PHYSICAL_PATH"];
            this.ltlServerNetVersion.Text = System.Environment.Version.ToString();
            this.ltlOSVersion.Text = System.Environment.OSVersion.ToString();

            this.ltlSessionCount.Text = this.Session.Count.ToString();
            this.ltlApplactionCount.Text = this.Application.Count.ToString();
            this.ltlCPUCount.Text = System.Environment.ProcessorCount.ToString();
            #region "获取版本信息"
            //获取本系统的版本
            bool netIsFine = true;
            string url = System.Configuration.ConfigurationManager.AppSettings["UpdateAdress"].ToString() + "vesion.html";
            string lastestVesion = string.Empty;
            if (lastestVesion.Equals("-1"))
            {
                lastestVesion = "网络存在异常";
                netIsFine = false;
            }
            string vesion = ChangeHope.Common.ServerInfo.VersionInformation();
            this.lbLatestVesion.Text = lastestVesion;
            this.lbVesion.Text = vesion;
            if (netIsFine)
            {
                if (lastestVesion.Equals(vesion))
                {
                    this.lbLatestVesion.Text += "&nbsp;已经最新版本，无需更新";
                }
                else
                {
                    this.lbLatestVesion.Text += "&nbsp;<input id=\"UpdateTemlete\" type=\"checkbox\" value=\"1\"/>是否更新模版&nbsp;<a href=\"#\" onclick=\"UpdateThePacket()\">不是最新版，请升级</a>";
                }
            }
            else
            {
                this.lbLatestVesion.Text += "网络异常，无法获取数据";
            }
            #endregion
        }
        private void CheckObject()
        {
            this.ltlAccess.Text = CreateObject("ADODB.RecordSet");
            this.ltlASPCN.Text = CreateObject("aspcn.Upload");
            this.ltlASPMail.Text = CreateObject("Persits.MailSender");
            this.ltlASPUpload.Text = CreateObject("Persits.Upload");
            this.ltlCDONTS.Text = CreateObject("CDONTS.NewMail");
            this.ltlFSO.Text = CreateObject("Scripting.FileSystemObject");
            this.ltlJMAIL.Text = CreateObject("JMail.SMTPMail");
            this.ltlLyfUpload.Text = CreateObject("LyfUpload.UploadFile");
        }
        private string CreateObject(string objName)
        {
            try
            {
                object obj = Server.CreateObject(objName);
                obj = null;
                return "<font color='Green'>已安装</font>";
            }
            catch (Exception)
            {
                return "<font color='Red'>未安装</font>";
            }
        }
    }
}
