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
using System.Text;

namespace ShowShop.Web.admin.systeminfo
{
    public partial class article_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormString("id") != string.Empty)
            {
                string types = Request.Form["Option"].Trim();
                int id = ChangeHope.WebPage.PageRequest.GetFormInt("id");
                if (types == "del")
                {
                    if (ShowShop.Common.PromptInfo.Message("009002003") != "ok")
                    {
                        Del(id);
                    }
                    else
                    {
                        Response.Write("no");
                    }
                }
                Response.End();
                return;
            }
            if(!this.Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("009002001");
                GetList();
                string channel = ChangeHope.WebPage.PageRequest.GetQueryString("w_z_channel");
                GetParentChannel(channel);
                BindChannel();
            }
        }
        protected void BindChannel()
        {
            ShowShop.BLL.SystemInfo.ArticleChannel bll = new ShowShop.BLL.SystemInfo.ArticleChannel();
            string channelid = string.Empty;
            bll.GetDropList(this.w_d_Channel, channelid);
        }
        private void GetList()
        {
            ShowShop.BLL.SystemInfo.Article bll = new ShowShop.BLL.SystemInfo.Article();
            this.ltlview.Text = bll.GetListForTable();
            bll = null;
        }
        public void GetParentChannel(string channelid)
        {
            ShowShop.BLL.SystemInfo.ArticleChannel bll = new ShowShop.BLL.SystemInfo.ArticleChannel();
            StringBuilder text = new StringBuilder();
            SortedList hashtable = bll.GetChannel(channelid);
            text.AppendLine("<a href='article_edit.aspx?channelid=" + channelid + "'><font color='Blue'>添加资讯</font></a>");
            int index = 0;
            //获取父路径
            foreach (DictionaryEntry de in hashtable)
            {
                if (index == 0)
                {
                    text.AppendLine(" ◎ ");
                }
                else
                {
                    text.AppendLine(" → ");
                }
                text.AppendLine("<a href='?w_z_channel=" + de.Key.ToString() + "'>" + de.Value.ToString() + "</a>");
                index++;
            }
            hashtable.Clear();
            hashtable = null;
            
            //获取子路径
            hashtable = bll.GetChildChannel(channelid);

            index = 0;
            foreach (DictionaryEntry de in hashtable)
            {
                if (index == 0)
                {
                    text.AppendLine(" ◎ ");
                }
                else
                {
                    text.AppendLine(" ");
                }
                text.Append("<a href='?w_z_channel=" + de.Key.ToString() + "'><font color='#FF9900'>" + de.Value.ToString() + "</font></a>");
                index++;
            }
            hashtable.Clear();
            hashtable = null;
            this.ltlLink.Text += text.ToString();
            bll = null;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        private void Del(int id)
        {
            ShowShop.BLL.SystemInfo.Article bll = new ShowShop.BLL.SystemInfo.Article();
            bll.Delete(id);
            Response.Write("ok");
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            GetList();
        }

    }
}
