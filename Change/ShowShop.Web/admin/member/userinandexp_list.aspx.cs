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

namespace ShowShop.Web.admin.member
{
    public partial class userinandexp_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("008005001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormInt("id") > 0)
                {
                    string Option = Request.Form["Option"].Trim();
                    int id = ChangeHope.WebPage.PageRequest.GetFormInt("id");
                    if (Option == "del")
                    {
                        if(ShowShop.Common.PromptInfo.Message("008005003")!="ok")
                        {
                          Del(id.ToString());
                        }
                        else
                        {
                         Response.Write("no");
                        }
                    }
                    else if (Option == "SetState")
                    {
                        if (ShowShop.Common.PromptInfo.Message("008005004") != "ok")
                        {
                           SetState(id);
                         }
                        else
                        {
                         Response.Write("no");
                        }
                    }
                    Response.End();
                    return;
                }

                string  type = ChangeHope.WebPage.PageRequest.GetQueryString("type");
                if (type != "" && type != null)
                {
                    Cache["type"] = type;
                }
                this.lblList.Text = GetListByType(Cache["type"].ToString());
                this.lblCount.Text = GetCountByType(Cache["type"].ToString());
                InitWebControl();
            }
        }

        #region 日期
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.SetDate(this.w_d_adsummoneydate);
        }
        #endregion

        #region 统计
        protected string GetCountByType(string type)
        {
            string count = string.Empty;
            switch (type)
            {
                case "all":
                    count = "当前页面列表 总支出：<font color=\"blue\">" + GetCount(" 1=1")[1] + "</font>元  总收入：<font color=\"blue\">" + GetCount(" 1=1")[0] + "</font>元";
                    break;
                case "sure":
                    count = "当前页面列表 总支出：<font color=\"blue\">" + GetCount(" state=0")[1] + "</font>元  总收入：<font color=\"blue\">" + GetCount(" state=0")[0] + "</font>元";
                    break;
                case "cancel":
                    count = "当前页面列表 总支出：<font color=\"blue\">" + GetCount(" state=1")[1] + "</font>元  总收入：<font color=\"blue\">" + GetCount(" state=1")[0] + "</font>元"; 
                    break;
                case "in":
                    count = "当前页面列表 总收入：<font color=\"blue\">" + GetCount(" incomeandexpstate=0")[0] + "</font>元"; 
                    break;
                case "out":
                    count = "当前页面列表 总支出：<font color=\"blue\">" + GetCount(" incomeandexpstate=1")[1] + "</font>元"; 
                    break;
            }
            return count;
        }

        protected string[] GetCount(string strWhere)
        {
            string[] arrCount = new string[2];
            decimal inMoney = 0;
            decimal outMoney = 0;
            ShowShop.BLL.Member.UserinAndExp bll = new ShowShop.BLL.Member.UserinAndExp();
            ChangeHope.DataBase.DataByPage dataPage = bll.GetList(strWhere);
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    if (dataPage.DataReader["incomeandexpstate"].ToString() == "0")
                    {
                        inMoney += Convert.ToDecimal(dataPage.DataReader["adsummoney"]);
                    }
                    else
                    {
                        outMoney += Convert.ToDecimal(dataPage.DataReader["adsummoney"]);
                    }
                }
            }
            arrCount[0] = inMoney.ToString();
            arrCount[1] = outMoney.ToString();
            return arrCount;
        }
        #endregion

        #region 列表
        protected string GetListByType(string type)
        {
            string list = string.Empty;
            switch (type)
            {
                case "all":
                    list = GetList(" 1=1");
                    break;
                case "in":
                    list = GetList(" incomeandexpstate=0");
                    break;
                case "out":
                    list = GetList(" incomeandexpstate=1");
                    break;
                case "sure":
                    list = GetList(" state=0");
                    break;
                case "cancel":
                    list = GetList(" state=1");
                    break;
            }
            return list;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        protected string GetList(string strWhere)
        {
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Member.UserinAndExp bll = new ShowShop.BLL.Member.UserinAndExp();
            ChangeHope.DataBase.DataByPage dataPage = bll.GetList(strWhere);
            //第一步先添加表头
            table.AddHeadCol("", "序号");
            table.AddHeadCol("", "到款时间");
            table.AddHeadCol("", "会员账号");
            table.AddHeadCol("", "交易方式");
            table.AddHeadCol("", "收入金额");
            table.AddHeadCol("", "支出金额");
            table.AddHeadCol("", "银行名称");
            table.AddHeadCol("", "备注/说明");
            table.AddHeadCol("", "是否确认");
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
                    string option = string.Empty;
                    if (dataPage.DataReader["state"].ToString() == "0")
                    {
                        option = string.Format("<a href=userinandexp_view_single.aspx?id={0}>查看</a>", dataPage.DataReader["id"].ToString());
                    }
                    else
                    {
                        option = string.Format("<a href=userinandexp_view_single.aspx?id={0}>查看</a> <a href='javascript:void(0)' onclick='Del({0})'>删除</a> <a href='javascript:void(0)' onclick='SetState({0})'>确认</a>", dataPage.DataReader["id"].ToString());
                    }
                    table.AddCol(No);
                    table.AddCol(Convert.ToDateTime(dataPage.DataReader["adsummoneydate"].ToString()).ToShortDateString());
                    table.AddCol(dataPage.DataReader["userid"].ToString());
                    table.AddCol(GetRemitMode(dataPage.DataReader["remitmode"].ToString()));
                    table.AddCol(dataPage.DataReader["incomeandexpstate"].ToString() == "0" ? dataPage.DataReader["adsummoney"].ToString() : string.Empty);
                    table.AddCol(dataPage.DataReader["incomeandexpstate"].ToString() == "1" ? dataPage.DataReader["adsummoney"].ToString() : string.Empty);
                    table.AddCol(dataPage.DataReader["remitbank"].ToString());
                    table.AddCol(dataPage.DataReader["remark"].ToString());
                    table.AddCol(dataPage.DataReader["state"].ToString() == "0" ? "确认" : "未确认");
                    table.AddCol(option);
                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return view;
        }
        #endregion

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        private void Del(string id)
        {
          
            ShowShop.BLL.Member.UserinAndExp bll = new ShowShop.BLL.Member.UserinAndExp();
            bll.Delete(id);
          

        }

        private void SetState(int id)
        {
           
                ShowShop.BLL.Member.UserinAndExp bll = new ShowShop.BLL.Member.UserinAndExp();
                bll.Amend(id, "state", 0);
                Response.Write("ok");
            
        }

        /// <summary>
        /// 判断支付类型
        /// </summary>
        /// <param name="remitmode"></param>
        /// <returns></returns>
        protected string GetRemitMode(string remitmode)
        {
            string mode = string.Empty;
            switch (remitmode)
            {
                case "1":
                    mode = "银行汇款";
                    break;
                case "2":
                    mode = "虚拟货币";
                    break;
                case "3":
                    mode = "现金支付";
                    break;
            }
            return mode;
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            this.lblList.Text = GetListByType(ChangeHope.WebPage.PageRequest.GetQueryString("type"));
            this.lblCount.Text = GetCountByType(ChangeHope.WebPage.PageRequest.GetQueryString("type"));
        }
    }
}
