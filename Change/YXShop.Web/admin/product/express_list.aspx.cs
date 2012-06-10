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
    public partial class express_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("004002001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormInt("id") > 0)
                {
                    string types = Request.Form["Option"].Trim();
                    int id = ChangeHope.WebPage.PageRequest.GetFormInt("id");
                    if (types == "del")
                    {
                        if(ShowShop.Common.PromptInfo.Message("004002003")!="ok")
                        {
                        Del(id.ToString());
                        }
                        else
                        {
                         Response.Write("no");
                        }
                    }
                    else if (types == "sort")
                    {

                        if (ShowShop.Common.PromptInfo.Message("004002004") != "ok")
                        {
                        //优先级
                        int Num = ChangeHope.WebPage.PageRequest.GetFormInt("SortID");
                        SetSort(id, Num);
                        }
                        else
                        {
                            Response.Write("no");
                        }
                    }
                    Response.End();
                    return;
                }

                this.lblList.Text = GetList();
            }
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        protected string GetList()
        {

            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Product.Express bll = new ShowShop.BLL.Product.Express();
            ChangeHope.DataBase.DataByPage dataPage = bll.GetList();
            //第一步先添加表头
            table.AddHeadCol("", "序号");
            table.AddHeadCol("", "名称");
            table.AddHeadCol("", "联系人");
            table.AddHeadCol("", "电话");
            table.AddHeadCol("", "优先级");
            table.AddHeadCol("", "操作");
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
                    table.AddCol(dataPage.DataReader["person"].ToString());
                    table.AddCol(dataPage.DataReader["phone"].ToString());
                    table.AddCol(string.Format("<input id='txtSort{0}' value='{1}' size='5' onblur='SetSort({0})'/>", dataPage.DataReader["id"].ToString(), dataPage.DataReader["sort"].ToString()));
                    table.AddCol(string.Format("<a href=express_edite.aspx?id={0}>编辑</a> <a href='javascript:void(0)' onclick='Del({0})'>删除</a>", dataPage.DataReader["id"].ToString()));
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
        private void Del(string id)
        {
           
            ShowShop.BLL.Product.Express bll = new ShowShop.BLL.Product.Express();
            bll.Delete(id);
            Response.Write("ok");
           
        }

        /// <summary>
        /// 修改优先级
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sort"></param>
        private void SetSort(int id, int sort)
        {
            
            ShowShop.BLL.Product.Express bll = new ShowShop.BLL.Product.Express();
            bll.Amend(id, "sort", sort);
            Response.Write("ok");
            
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            this.lblList.Text = GetList();
        }
    }
}
