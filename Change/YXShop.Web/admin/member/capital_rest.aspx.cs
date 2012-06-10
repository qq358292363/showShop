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

namespace ShowShop.Web.admin.member
{
    public partial class capital_rest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("008005001");
                InitWebControl();
                string type = ChangeHope.WebPage.PageRequest.GetQueryString("type");
                if (type != "" && type != null)
                {
                    Cache["type"] = type;
                }
                this.litMain.Text = GetListByWhere(Cache["type"].ToString());
                this.litFund.Text = GetAllMoneyByType(Cache["type"].ToString());
            }
        }

        #region 日期
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.SetDate(this.w_d_noteDate);
        }
        #endregion

        #region 条件
        private string GetListByWhere(string type)
        {
            string str = string.Empty;
            switch (type)
            {
                case "in":
                    str = GetList(" noteType=1 and buckleOrAdd=0 ");
                    break;
                case "out":
                    str = GetList(" noteType=1 and buckleOrAdd=1 ");
                    break;
                default:
                    break;
            }
            return str;
        }
        #endregion

        #region 绑定
        private string GetList(string where)
        {
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Member.UserInfoNote noteBll = new ShowShop.BLL.Member.UserInfoNote();
            ChangeHope.DataBase.DataByPage dataPage = noteBll.GetListByWhere(where);
            table.AddHeadCol("", "序号");
            table.AddHeadCol("","交易日期");
            table.AddHeadCol("","会员帐号");
            table.AddHeadCol("","收入金额");
            table.AddHeadCol("","支出金额");
            table.AddHeadCol("","操作人员");
            table.AddHeadCol("","备注/原因");
            table.AddHeadCol("","操作");
            table.AddRow();
            if(dataPage.DataReader!=null)
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
                    table.AddCol(dataPage.DataReader["noteDate"].ToString());
                    table.AddCol(dataPage.DataReader["userName"].ToString());
                    table.AddCol(dataPage.DataReader["buckleOrAdd"].ToString()=="0" ? dataPage.DataReader["ticketCount"].ToString() : "");
                    table.AddCol(dataPage.DataReader["buckleOrAdd"].ToString()=="1" ? dataPage.DataReader["ticketCount"].ToString() : "");
                    table.AddCol(dataPage.DataReader["noteName"].ToString());
                    table.AddCol(dataPage.DataReader["causation"].ToString());
                    table.AddCol("<a href='coupons_record_view.aspx?id=" + dataPage.DataReader["id"].ToString() + "'>查看</a>");
                    table.AddRow();
                }

            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return view;
        }
        #endregion

        #region 查询
        //查询
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            this.litMain.Text = GetListByWhere(Cache["type"].ToString());
            this.litFund.Text = GetAllMoneyByType(Cache["type"].ToString());
        }
        #endregion

        #region 资金
        private string GetAllMoneyByType(string type)
        {
            string str = string.Empty;
            ShowShop.BLL.Member.UserInfoNote noteBll = new ShowShop.BLL.Member.UserInfoNote();
            ChangeHope.DataBase.DataByPage dataPage = null;
            decimal money = 0;
            StringBuilder shtml = new StringBuilder();
            switch (type)
            {  
                case "in":
                    shtml.Append("当前页面总收入：");
                    dataPage = noteBll.GetListByWhere(" noteType=1 and buckleOrAdd=0 ");
                    if(dataPage.DataReader!=null)
                    {
                        while(dataPage.DataReader.Read())
                        {
                            money += Convert.ToDecimal(dataPage.DataReader["ticketCount"]);
                        }
                    }
                    break;
                case "out":
                    shtml.Append("当前页面总支出：");
                    dataPage = noteBll.GetListByWhere(" noteType=1 and buckleOrAdd=1 ");
                    if (dataPage.DataReader != null)
                    {
                        while (dataPage.DataReader.Read())
                        {
                            money += Convert.ToDecimal(dataPage.DataReader["ticketCount"]);
                        }
                    }
                    break;
                default:
                    break;
            }
            shtml.Append("<span style='color:Red'>"+money.ToString() + "</span>元");
            return shtml.ToString();
        }
        #endregion
    }
}
