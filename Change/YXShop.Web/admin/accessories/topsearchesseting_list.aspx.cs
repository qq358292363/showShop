﻿using System;
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

namespace ShowShop.Web.admin.accessories
{
    public partial class topsearchesseting_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("012004001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormInt("id") > 0)
                {
                    string types = Request.Form["Option"].Trim();
                    int id = ChangeHope.WebPage.PageRequest.GetFormInt("id");
                    if (types == "del")
                    {
                        if(ShowShop.Common.PromptInfo.Message("012004003")!="ok")
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
                        if (ShowShop.Common.PromptInfo.Message("012004004") != "ok")
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
            ShowShop.BLL.Accessories.Top_Searches data = new ShowShop.BLL.Accessories.Top_Searches();
            ChangeHope.DataBase.DataByPage dataPage = data.GetList();
            //第一步先添加表头
            table.AddHeadCol("10%", "序号");
            table.AddHeadCol("40%", "名称");
            table.AddHeadCol("15%", "排序");
            table.AddHeadCol("20%", "状态");
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
                    table.AddCol("No."+No);
                    table.AddCol("<span style='cursor:hand');\">" + dataPage.DataReader["name"].ToString() + "</span>");
                    table.AddCol(string.Format("<input id='sort{0}' value='{1}' size='5' onblur='Sort({0},{1})'/>", dataPage.DataReader["id"].ToString(), dataPage.DataReader["sort"].ToString()));
                    table.AddCol(string.Format("<img src='../images/{0}.gif'/>", dataPage.DataReader["isshow"].ToString()));
                    table.AddCol(string.Format("<a href=topsearchesseting_edit.aspx?id={0}>编辑</a> <a href='#' onclick='Del({0})'>删除</a>", dataPage.DataReader["id"].ToString()));

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
          
            ShowShop.BLL.Accessories.Top_Searches bll = new ShowShop.BLL.Accessories.Top_Searches();
            bll.Delete(id);
                Response.Write("ok");
           
        }

        private void sort(int id, int Sort)
        {
                ShowShop.BLL.Accessories.Top_Searches bll = new ShowShop.BLL.Accessories.Top_Searches();
                if (bll.Amend(id, "sort", Sort) > 0)
                {
                    Response.Write("ok");
                }
           
        }
    }
}

