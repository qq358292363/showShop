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
    public partial class articlechannel_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!this.Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("009001001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormString("id") != string.Empty)
                {
                    string types = Request.Form["Option"].Trim();
                    string id = ChangeHope.WebPage.PageRequest.GetFormString("id");
                    if (types == "del")
                    {
                        if (ShowShop.Common.PromptInfo.Message("009001003") != "ok")
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

                string chanelid = ChangeHope.WebPage.PageRequest.GetString("q_chanelid");
                GetParentChannel(chanelid);
                this.lnkAddChannel.NavigateUrl = "articlechannel_edit.aspx?chanelid=" + chanelid;
                GetList();
            }
        }

        private void GetList()
        {
            ShowShop.BLL.SystemInfo.ArticleChannel bll = new ShowShop.BLL.SystemInfo.ArticleChannel();
            this.lblView.Text = bll.GetList();
            bll = null;
        }

        public void GetParentChannel(string channelid)
        {
            ShowShop.BLL.SystemInfo.ArticleChannel bll = new ShowShop.BLL.SystemInfo.ArticleChannel();
            StringBuilder text = new StringBuilder();
            SortedList hashtable = bll.GetChannel(channelid);
            foreach (DictionaryEntry de in hashtable)
            {
                text.Append(" → <a href='?q_chanelid="+de.Key.ToString()+"'>" + de.Value.ToString()+"</a>");
            }
            hashtable.Clear();
            hashtable = null;
            this.link.Text = text.ToString().Substring(2);
            bll = null;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        private void Del(string id)
        {
            ShowShop.BLL.SystemInfo.ArticleChannel bll = new ShowShop.BLL.SystemInfo.ArticleChannel();
            if (bll.HasChild(Convert.ToInt32(id))) //判断旗下是否有子频道
            {
                Response.Write("haschild");
                return;
            }
            ShowShop.BLL.SystemInfo.Article abll = new ShowShop.BLL.SystemInfo.Article();
            if (abll.ExistByCid(Convert.ToInt32(id))) //判断该频道下是否有文章
            {
                Response.Write("hasarticel");
                return;
            }
            bll.Delete(id);
            Response.Write("ok");
        }
    }
}
