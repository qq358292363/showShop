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

namespace ShowShop.Web.admin.systeminfo
{
    public partial class bannerchannel_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string[] dirs = Directory.GetDirectories(@"D:\");//路径  
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                }  

                InitWebControls();
            }
        }

        private void InitWebControls()
        {
            ShowShop.BLL.SystemInfo.ArticleChannel bll = new ShowShop.BLL.SystemInfo.ArticleChannel();
            string channelid = ChangeHope.WebPage.PageRequest.GetQueryString("channelid");
            bll.GetDropList(this.ddlChannel, channelid);
            bll = null;
            ChangeHope.WebPage.WebControl.Validate(this.txtName, "频道名称，频道下面可以设置子频道,频道名称设置为4~10个字符", "isnull_4_10", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtProjectName, "比如是文章的话，项目就是文章或者新闻或者通讯等", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtProjectUtil, "该频道的文章的单位，比如是文章的话就是X篇，通讯的话就是X条等", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtTemplate, "该频道的网页模板，按照要求制定，选择文件夹", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtMeteKey, "该频道的文章的单位，比如是文章的话就是X篇，通讯的话就是X条等", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtMeteDescription, "该频道的文章的单位，比如是文章的话就是X篇，通讯的话就是X条等", "isnull", "必填", "该项为必填项");
            this.ckbType.Items[0].Attributes.Add("onclick", "changetype(this.value)");
            this.ckbType.Items[1].Attributes.Add("onclick","changetype(this.value)");
            this.ckbType.Items[2].Attributes.Add("onclick","changetype(this.value)");
            this.Form.Attributes.Add("onsubmit", "return CheckForm();");
            GetMemberRank();
        }
        private void GetMemberRank()
        {
            ShowShop.BLL.Member.MemberRank bll = new ShowShop.BLL.Member.MemberRank();
            System.Data.DataTable tb = bll.GetList();

            foreach (System.Data.DataRow row in tb.Rows)
            {
                this.ckbPower.Items.Add(new ListItem(row["Name"].ToString(), row["Id"].ToString()));
            }
            tb.Dispose();
            tb = null;
        }

    }
}
