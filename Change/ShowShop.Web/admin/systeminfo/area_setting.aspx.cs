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
    public partial class area_setting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormString("id") != string.Empty)
            {
                string types = Request.Form["Option"].Trim();
                int id = ChangeHope.WebPage.PageRequest.GetFormInt("id");
                if (types == "del")
                {
                    if (ShowShop.Common.PromptInfo.Message("010004003") != "ok")
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
                ShowShop.Common.PromptInfo.Popedom("010004001");
                GetList();
            }
        }

        private void GetList()
        {
            //生成列表
            ShowShop.BLL.SystemInfo.Provinces bll = new ShowShop.BLL.SystemInfo.Provinces();
            this.Literal1.Text = bll.GetList();
            //生成菜单
            int w_d_parentid = ChangeHope.WebPage.PageRequest.GetInt("w_d_parentid");
            this.tool.Text = tool.Text + bll.GetToolBar(w_d_parentid);
            bll = null;
        }
        private void Del(int id)
        {
            ShowShop.BLL.SystemInfo.Provinces bll = new ShowShop.BLL.SystemInfo.Provinces();
           DataTable dt=bll.GetChid(id.ToString());
           if (dt.Rows.Count > 0)
           {
               Response.Write("请地区下还有地区，请删除下级地区！");
           }
           else
           {
               bll.Delete(id);
               Response.Write("ok");
           }
        }
        
    }
}
