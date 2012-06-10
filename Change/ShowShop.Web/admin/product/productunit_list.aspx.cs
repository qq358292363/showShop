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

namespace ShowShop.Web.admin.product
{
    public partial class productunit_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowShop.Common.PromptInfo.Popedom("001004001");
            if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormInt("id") > 0)
            {
               
                string types = Request.Form["Option"].Trim();
                int id = ChangeHope.WebPage.PageRequest.GetFormInt("id");
                if (types == "del")
                {
                    if (ShowShop.Common.PromptInfo.Message("001004003") != "ok")
                    {
                        del(id);
                    }
                    else
                    {
                        Response.Write("no");
                    }
                }
                Response.End();
                return;
            }
            if (!Page.IsPostBack)
            {
                this.Literal1.Text = GetList();
            }
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        protected string GetList()
        {
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Product.ProductUnit data = new ShowShop.BLL.Product.ProductUnit();
            ChangeHope.DataBase.DataByPage dataPage = data.GetList();
            //第一步先添加表头
            table.AddHeadCol("5%", "序号");
            table.AddHeadCol("25%", "单位名称");
            table.AddHeadCol("10%", "排序");
            table.AddHeadCol("20%", "操作");
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
                    table.AddCol(dataPage.DataReader["name"].ToString());
                    table.AddCol(string.Format("{0}", dataPage.DataReader["sort"].ToString()));
                    table.AddCol(string.Format("<a href=productunit_edit.aspx?id={0}>编辑</a> <a href='#' onclick='Del({0})'>删除</a>", dataPage.DataReader["id"].ToString()));

                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return view;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        private void del(int id)
        {
            ShowShop.BLL.Product.ProductUnit bll = new ShowShop.BLL.Product.ProductUnit();
            bll.Delete(id);
            Response.Write("ok");
        }
    }
}
