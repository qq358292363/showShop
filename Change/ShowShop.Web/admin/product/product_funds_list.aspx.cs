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
    public partial class product_funds_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowShop.Common.PromptInfo.Popedom("003001001");
            if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormInt("id") > 0)
            {           
                string Option = Request.Form["Option"].Trim();
                int id = ChangeHope.WebPage.PageRequest.GetFormInt("id");
                if (Option == "del")
                {
                    
                    Del(id.ToString(),ShowShop.Common.PromptInfo.Message("003001003"));
                }
                else if (Option == "SetState")
                {
                    
                    SetState(id,ShowShop.Common.PromptInfo.Message("003001006"));

                }
                Response.End();
                return;
            }
            if (!Page.IsPostBack)
            {   
                this.lblList.Text = this.GetList();
                this.lblCount.Text = this.GetCount();
            }
        }

        protected string GetCount()
        {
            string count = string.Empty;
            count = "当前页面列表 总支出：<font color=\"blue\">" + GetCount(" 1=1")[1] + "</font>元  总收入：<font color=\"blue\">" + GetCount(" 1=1")[0] + "</font>元";
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

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        protected string GetList()
        {
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Member.UserinAndExp bll = new ShowShop.BLL.Member.UserinAndExp();
            ChangeHope.DataBase.DataByPage dataPage = bll.GetList(" 1=1");
            //第一步先添加表头
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
                while (dataPage.DataReader.Read())
                {
                    string option = string.Empty;
                    if (dataPage.DataReader["state"].ToString() == "0")
                    {
                        option = string.Format("<a href=../member/userinandexp_view_single.aspx?id={0}>查看</a>", dataPage.DataReader["id"].ToString());
                    }
                    else 
                    {
                        option = string.Format("<a href=../member/userinandexp_view_single.aspx?id={0}>查看</a> <a href='javascript:void(0)' onclick='Del({0})'>删除</a> <a href='javascript:void(0)' onclick='SetState({0})'>确认</a>", dataPage.DataReader["id"].ToString());
                    }
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

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        private void Del(string id, string message)
        {
            if (message != "ok")
            {
                ShowShop.BLL.Member.UserinAndExp bll = new ShowShop.BLL.Member.UserinAndExp();
                bll.Delete(id);
                Response.Write("ok");
            }
            else
            {
                Response.Write("no");
            }
        }

        private void SetState(int id,string message)
        {
            if (message != "ok")
            {
            ShowShop.BLL.Member.UserinAndExp bll = new ShowShop.BLL.Member.UserinAndExp();
            bll.Amend(id, "state", 0);
            Response.Write("ok");
             }
            else
            {
                Response.Write("no");
            }
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
    }
}
