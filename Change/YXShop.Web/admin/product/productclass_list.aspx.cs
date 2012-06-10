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
using System.Text;

namespace ShowShop.Web.admin.product
{
    public partial class productclass_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowShop.Common.PromptInfo.Popedom("001001001");
            if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormInt("id") > 0)
            {
               
                string types = Request.Form["Option"].Trim();
                int id = ChangeHope.WebPage.PageRequest.GetFormInt("id");
                if (types == "del")
                {
                    if (ShowShop.Common.PromptInfo.Message("001001003") != "ok")
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
                    if (ShowShop.Common.PromptInfo.Message("001001004") != "ok")
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
            if (!Page.IsPostBack)
            {
                this.tool.Text = GetToolBar(ChangeHope.WebPage.PageRequest.GetInt("w_d_fatherid"));
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
            ShowShop.BLL.Product.Productclass data = new ShowShop.BLL.Product.Productclass();
            ChangeHope.DataBase.DataByPage dataPage = data.GetList();
            //第一步先添加表头
            table.AddHeadCol("5%", "序号");
            table.AddHeadCol("35%", "分类名称");
           // table.AddHeadCol("25%", "商品类型");
            table.AddHeadCol("10%", "排序");
           // table.AddHeadCol("5%", "状态");
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
                    table.AddCol(string.Format("<a href='?w_d_fatherid={0}'>{1}</a>", dataPage.DataReader["cid"].ToString(), dataPage.DataReader["name"].ToString()));
                  //  table.AddCol(dataPage.DataReader["TypeName"].ToString());
                    table.AddCol(string.Format("<input id='sort{0}' value='{1}' size='5' onblur='Sort({0},{1})'/>", dataPage.DataReader["cid"].ToString(), dataPage.DataReader["sort"].ToString()));
                   // table.AddCol(string.Format("<img src='../images/{0}.gif' alt='推荐与否'/>", dataPage.DataReader["isrecommend"].ToString()));
                    table.AddCol(string.Format("<a href=productclass_edit.aspx?id={0}>编辑</a> <a href='#' onclick='Del({0})'>删除</a> <a href=productclass_edit.aspx?fatherid={0}>添加子分类</a>", dataPage.DataReader["cid"].ToString()));

                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return view;
        }
        /// <summary>
        /// 导航
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetToolBar(int id)
        {
            StringBuilder toolbar = new StringBuilder();
            toolbar.AppendLine("<a href='?w_d_fatherid=0'>顶级分类</a>");
            ShowShop.BLL.Product.Productclass data = new ShowShop.BLL.Product.Productclass();
            ShowShop.Model.Product.Productclass model = data.GetModelID(id);
            if (model != null)
            {
                string Currently=string.Format(">> <a href='?w_d_fatherid={0}'>{1}</a>  ", model.ID, model.Name);
                string[] parentPath =model.Parentpath.Split(',');
                for (int i = 0; i < parentPath.Length; i++)
                {
                    model = data.GetModelID(Convert.ToInt32(parentPath[i]));
                    if (model != null)
                    {
                        toolbar.AppendFormat(">> <a href='?w_d_fatherid={0}'>{1}</a>  ", model.ID, model.Name);
                    }
                }
                toolbar.Append(Currently);
            }
            toolbar.Append("&nbsp;|&nbsp;<a href='productclass_edit.aspx?fatherid=" + id + "'>添加同分类</a>");
            return toolbar.ToString();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        private void del(int id)
        {
            ShowShop.BLL.Product.Productclass bll = new ShowShop.BLL.Product.Productclass();
            DataTable dt = bll.GetFatherList(id);
            if (dt.Rows.Count > 0)
            {
                Response.Write("该分类还有下级分类,请删除下级分类！");
            }
            else
            {
                bll.Delete(id);
            }
        }
        /// <summary>
        /// 修改排列顺序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sort"></param>
        private void sort(int id, int sort)
        {
            ShowShop.BLL.Product.Productclass bll = new ShowShop.BLL.Product.Productclass();
            bll.Amend(id, "sort", sort);
            Response.Write("ok");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.Literal1.Text = GetList();
        }
    }
}
