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
    public partial class productbrand_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("001002001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormInt("id") > 0)
                {
                    
                    string types = Request.Form["Option"].Trim();
                    int id = ChangeHope.WebPage.PageRequest.GetFormInt("id");
                    if (types == "del")
                    {
                        if (ShowShop.Common.PromptInfo.Message("001002003") != "ok")
                        {
                            del(id);
                        }
                        else
                        {
                            Response.Write("no");
                        }
                    }
                    else if (types == "sort")
                    {
                        if (ShowShop.Common.PromptInfo.Message("001002004") != "ok")
                        {
                        int Num = ChangeHope.WebPage.PageRequest.GetFormInt("sort");
                        sort(id, Num);
                        }
                        else
                        {
                            Response.Write("no");
                        }
                    }
                    Response.End();
                    return;
                }
                this.Literal1.Text = GetList();
            }
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        protected string GetList()
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Product.ProductBrand data = new ShowShop.BLL.Product.ProductBrand();
            ChangeHope.DataBase.DataByPage dataPage = data.GetList();
            //第一步先添加表头
            table.AddHeadCol("5%", "序号");
            table.AddHeadCol("25%", "品牌名称");
            table.AddHeadCol("25%", "排序");
            table.AddHeadCol("25%", "操作");
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
                    table.AddCol(string.Format("<input id='sort{0}' value='{1}' size='5' onblur='Sort({0},{1})'/>", dataPage.DataReader["bid"].ToString(), dataPage.DataReader["sort"].ToString()));
                    table.AddCol(string.Format("<a href=productbrand_edit.aspx?id={0}>编辑</a> <a href='#' onclick='Del({0})'>删除</a>", dataPage.DataReader["bid"].ToString()));

                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return view;
        }

        private void del(int id)
        {
            ShowShop.BLL.Product.ProductBrand bll = new ShowShop.BLL.Product.ProductBrand();
            ShowShop.Model.Product.ProductBrand model = bll.GetModelID(id);
            if (model != null)
            {
                bll.Delete(id);
            }
            Response.Write("ok");
        }

        private void sort(int id, int Sort)
        {
            ShowShop.BLL.Product.ProductBrand bll = new ShowShop.BLL.Product.ProductBrand();
            bll.Amend(id, "sort", Sort);
            Response.Write("ok");
        }
    }
}
