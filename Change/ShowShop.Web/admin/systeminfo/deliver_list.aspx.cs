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
    public partial class deliver_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("004001001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormInt("id") > 0)
                {
                    string types = Request.Form["Option"].Trim();
                    int id = ChangeHope.WebPage.PageRequest.GetFormInt("id");
                    if (types == "del")
                    {
                        
                        if(ShowShop.Common.PromptInfo.Message("004001003")!="ok")
                        {
                        SetUse(id);
                        }
                        else
                        {
                         Response.Write("no");
                        }
                    }
                    else if (types == "InsuredCosts")
                    {
                        //优先级
                        if (ShowShop.Common.PromptInfo.Message("004001004") != "ok")
                        {
                        int Num = ChangeHope.WebPage.PageRequest.GetFormInt("InsuredCostsID");
                        SetInsuredCosts(id, Num);
                             }
                        else
                        {
                         Response.Write("no");
                        }
                    }
                    else if (types == "isuse")
                    {
                        if (ShowShop.Common.PromptInfo.Message("004001004") != "ok")
                        {
                        SetIsCOD(id);
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

        private void SetIsCOD(int id)
        {
            ShowShop.BLL.SystemInfo.Deliver bll = new ShowShop.BLL.SystemInfo.Deliver();
            ShowShop.Model.SystemInfo.Deliver model = bll.GetModelByID(id);
            if (model.Isinstallation == 1 && model.IsCOD==0)
            {
                bll.Amend(id, "IsCOD", 1);
                Response.Write("ok");
            }
            else if(model.Isinstallation == 1 && model.IsCOD==1)
            {
                bll.Amend(id, "IsCOD", 0);
                Response.Write("ok");
            }
        }

        ///// <summary>
        ///// 列表
        ///// </summary>
        ///// <returns></returns>
        protected string GetList()
        {

            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.SystemInfo.Deliver bll = new ShowShop.BLL.SystemInfo.Deliver();

            ChangeHope.DataBase.DataByPage dataPage=null;
                dataPage = bll.GetList();

            //第一步先添加表头
            table.AddHeadCol("5%", "序号");
            table.AddHeadCol("15%", "名称");
            table.AddHeadCol("", "描述");
            table.AddHeadCol("10%", "保价费用");
            table.AddHeadCol("15%", "货到付款(是/否)");
            table.AddHeadCol("", "作者");
            table.AddHeadCol("", "版本");
            table.AddHeadCol("14%", "是否已安装");
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
                    table.AddCol(dataPage.DataReader["DistributionName"].ToString());
                    table.AddCol("<span style='line-height:20px'>" + dataPage.DataReader["DistributionDescription"].ToString()+"</span>");
                    table.AddCol(dataPage.DataReader["InsuredCosts"].ToString()=="0"?"无":string.Format("<input id='txtInsuredCosts{0}' value='{1}' size='2' onblur='SetInsuredCosts({0})'/>&nbsp;<span style='font-size:large'>%</font>", dataPage.DataReader["Id"].ToString(), dataPage.DataReader["InsuredCosts"].ToString()));
                    table.AddCol(string.Format("<img src='../images/{0}.gif' style=\"cursor:pointer;\" onclick='SetIsUser({1})' alt='点击改变状态'/>", dataPage.DataReader["IsCOD"].ToString(), dataPage.DataReader["Id"].ToString()));                  
                    
                    
                    table.AddCol(dataPage.DataReader["Author"].ToString());
                    table.AddCol(dataPage.DataReader["Version"].ToString());
                    table.AddCol(dataPage.DataReader["IsInstallation"].ToString() == "0" ? string.Format("<a href='javascript:void(0)' onclick='Del({0})'>点击安装</a>", dataPage.DataReader["Id"].ToString()) : string.Format("<a href='javascript:void(0)' onclick='Del({0})'>卸载</a> <a href=area_list.aspx?delivermode={0}>设置区域</a>", dataPage.DataReader["Id"].ToString()));
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
        //private void Del(string id)
        //{
        //    ShowShop.BLL.SystemInfo.Deliver bll = new ShowShop.BLL.SystemInfo.Deliver();
        //    bll.Delete(id);
        //    Response.Write("ok");
        //}

        /// <summary>
        /// 修改优先级
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sort"></param>
        private void SetInsuredCosts(int id, int InsuredCosts)
        {
            ShowShop.BLL.SystemInfo.Deliver bll = new ShowShop.BLL.SystemInfo.Deliver();
            bll.Amend(id, "InsuredCosts", InsuredCosts);
            Response.Write("ok");
        }

        /// <summary>
        /// 调整是否已安装
        /// </summary>
        /// <param name="id"></param>
        private void SetUse(int id)
        {
            ShowShop.BLL.SystemInfo.Deliver bll = new ShowShop.BLL.SystemInfo.Deliver();
            ShowShop.Model.SystemInfo.Deliver model = bll.GetModelByID(id);
            if (model.Isinstallation == 0)
            {
                bll.Amend(id, "IsInstallation", 1);
                Response.Write("ok");
            }
            else
            {
                bll.Amend(id, "IsInstallation", 0);
                Response.Write("ok");
            }
        }


        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            
            this.lblList.Text = GetList();
        }
        
    }
}
