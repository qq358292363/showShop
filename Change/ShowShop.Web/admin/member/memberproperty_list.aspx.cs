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

namespace ShowShop.Web.admin.member
{
    public partial class memberproperty_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("001003001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormInt("id") > 0)
                {
                    
                    string types = Request.Form["Option"].Trim();
                    int id = ChangeHope.WebPage.PageRequest.GetFormInt("id");
                    if (types == "del")
                    {
                        if (ShowShop.Common.PromptInfo.Message("001003003") != "ok")
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
                        if (ShowShop.Common.PromptInfo.Message("001003004") != "ok")
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
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Member.MemberPropety data = new ShowShop.BLL.Member.MemberPropety();
            ChangeHope.DataBase.DataByPage dataPage = data.GetList();
            //第一步先添加表头
            table.AddHeadCol("5%", "序号");
            table.AddHeadCol("15%", "属性名称");
            table.AddHeadCol("25%", "所属值");
            table.AddHeadCol("10%", "所属类型");
            table.AddHeadCol("5%", "排序");
            table.AddHeadCol("10%", "是否必填");
            table.AddHeadCol("10%", "操作");
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
                    table.AddCol(dataPage.DataReader["filed"].ToString());
                    //table.AddCol(ProductClassName(dataPage.DataReader["cid"].ToString()));
                    table.AddCol(dataPage.DataReader["datavalue"].ToString());
                    table.AddCol(Type(dataPage.DataReader["type"].ToString()));
                    table.AddCol(string.Format("<input id='sort{0}' value='{1}' size='3' onblur='Sort({0},{1})'/>", dataPage.DataReader["id"].ToString(), dataPage.DataReader["sort"].ToString()));
                    table.AddCol(string.Format("<img src='../images/{0}.gif'/>", dataPage.DataReader["isrequire"].ToString()));
                    table.AddCol(string.Format("<a href=member_custom_edit.aspx?id={0}>编辑</a> <a href='#' onclick='Del({0})'>删除</a>", dataPage.DataReader["id"].ToString()));

                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return view;
        }
        protected string Type(string value)
        {
            string reStr = string.Empty;
            switch (value)
            {
                case "1":
                    reStr = "下拉列表";
                    break;
                case "2":
                    reStr = "单选";
                    break;
                case "3":
                    reStr = "多选";
                    break;
                case "4":
                    reStr = "单行文本";
                    break;
                case "5":
                    reStr = "多行文本";
                    break;
            }
            return reStr;
        }
        //protected string ProductClassName(string strId)
        //{
        //    string reStr = string.Empty;
        //    string str = "暂无归类";
        //    if (!string.IsNullOrEmpty(strId))
        //    {
        //        ShowShop.BLL.Product.Productclass dll = new ShowShop.BLL.Product.Productclass();
        //        DataTable dt = dll.GetMoreThanClassName(strId);
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            if (!string.IsNullOrEmpty(reStr))
        //            {
        //                reStr = reStr + "," + dt.Rows[i]["name"].ToString();
        //            }
        //            else
        //            {
        //                reStr = dt.Rows[i]["name"].ToString();
        //            }
        //        }
        //        if (!string.IsNullOrEmpty(reStr))
        //        {
        //            str = reStr;
        //        }
        //    }
        //    return str;
        //}

        private void del(int id)
        {
                ShowShop.BLL.Member.MemberPropety bll = new ShowShop.BLL.Member.MemberPropety();
                bll.Delete(id);
                Response.Write("ok");
           
        }

        private void sort(int id, int Sort)
        {
            
            ShowShop.BLL.Member.MemberPropety bll = new ShowShop.BLL.Member.MemberPropety();
            bll.Amend(id, "sort", Sort);
            Response.Write("ok");
        }
    }
}
