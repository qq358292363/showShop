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

namespace ShowShop.Web.admin.order
{
    public partial class order_shop_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty)
            {
               
                string types = Request.Form["Option"].Trim();
                string id = ChangeHope.WebPage.PageRequest.GetFormString("id");
                if (types == "del")
                {
                    if (ShowShop.Common.PromptInfo.Message("006001003") != "ok")
                    {
                        Delete(id);
                    }
                    else
                    {
                        Response.Write("no");
                    }
                }
                Response.End();
                return;
            }
            if (!this.Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("006001001");
                InitPage();
                GetList();
            }
        }
        private void InitPage()
        {
            ChangeHope.WebPage.WebControl.SetDate(this.w_g_lastupdateddate);
            ChangeHope.WebPage.WebControl.SetDate(this.w_e_lastupdateddate);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        private void Delete(string id)
        {
           
                ShowShop.BLL.Order.ShoppingCard bll = new ShowShop.BLL.Order.ShoppingCard();
                bll.Delete(id);
                bll = null;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        private void GetList()
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Order.ShoppingCard data = new ShowShop.BLL.Order.ShoppingCard();
            ChangeHope.DataBase.DataByPage dataPage = data.GetProfilesList("");
            //第一步先添加表头
            table.AddHeadCol("10%", "序号");
            table.AddHeadCol("50%", "购者名称");
            table.AddHeadCol("25%", "购物时间");
            table.AddHeadCol("15%", "操作");
            table.AddRow();
            //添加表的内容
            if (dataPage.DataReader != null)
            {
                int curpage = ChangeHope.WebPage.PageRequest.GetInt("pageindex");
                if (curpage < 0)
                {
                    curpage = 1;
                }
                int count = 0;
                while (dataPage.DataReader.Read())
                {
                    count++;
                    string No = (15 * (curpage - 1) + count).ToString();
                    table.AddCol(No);
                    table.AddCol(string.Format("<a href='order_shop_view.aspx?q_uniqueid={1}&UserName={0}'>{0}</a>", dataPage.DataReader["username"].ToString(), dataPage.DataReader["uniqueid"].ToString()));
                    table.AddCol(dataPage.DataReader["lastupdateddate"].ToString());
                    table.AddCol(string.Format("<a href='#' onclick=\"Del('{0}')\">删除</a>", dataPage.DataReader["username"].ToString()));
                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            this.ltlList.Text = view;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetList();
        }
    }
}
