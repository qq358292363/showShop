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
    public partial class coupons_record_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("008007001");
                string type = ChangeHope.WebPage.PageRequest.GetQueryString("type");
                if (type != "" && type != null)
                {
                    Cache["type"] = type;
                }
                this.lblList.Text = GetListByType(Cache["type"].ToString());
                InitWebControl();
            }
        }

        #region 日期
        private void InitWebControl()
        {
           // ChangeHope.WebPage.WebControl.SetDate(this.w_d_adsummoneydate);
        }
        #endregion

        #region 列表
        protected string GetListByType(string type)
        {
            string list = string.Empty;
            switch (type)
            {
                case "all":
                    list = GetList(" noteType=0");
                    break;
                case "in":
                    list = GetList(" noteType=0 and buckleOrAdd=0");
                    break;
                case "out":
                    list = GetList(" noteType=0 and buckleOrAdd=1");
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
            // noteType =0
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Member.UserInfoNote bll = new ShowShop.BLL.Member.UserInfoNote();
            ChangeHope.DataBase.DataByPage dataPage = bll.GetListByWhere(strWhere);
            //第一步先添加表头
            table.AddHeadCol("", "序号");
            table.AddHeadCol("", "用户账号");
            table.AddHeadCol("", "录入时间");
            table.AddHeadCol("", "增加点卷");
            table.AddHeadCol("", "减少点卷");
            table.AddHeadCol("", "操作员");
            table.AddHeadCol("", "备注/说明");
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
                    table.AddCol(GetUserID(Convert.ToInt32(dataPage.DataReader["userId"].ToString())));
                    table.AddCol(dataPage.DataReader["noteDate"].ToString());
                    table.AddCol(dataPage.DataReader["buckleOrAdd"].ToString() == "0" ? dataPage.DataReader["ticketCount"].ToString() : string.Empty);
                    table.AddCol(dataPage.DataReader["buckleOrAdd"].ToString() == "1" ? dataPage.DataReader["ticketCount"].ToString() : string.Empty);
                    table.AddCol(dataPage.DataReader["noteName"].ToString());
                    table.AddCol(dataPage.DataReader["causation"].ToString());
                    table.AddCol(string.Format("<a href=coupons_record_view.aspx?id={0}>查看</a>", dataPage.DataReader["id"].ToString()));
                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return view;
        }
        #endregion

        protected string GetUserID(int uid)
        {
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.Model.Member.MemberAccount model = bll.GetModel(uid);
            if (model != null)
            {
                return model.UserId;
            }
            else
            {
                return "无该用户";
            }
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            this.lblList.Text = GetListByType(ChangeHope.WebPage.PageRequest.GetQueryString("type"));
        }

        #region 删除
        //删除
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            ShowShop.Common.PromptInfo.Popedom("008007003","对不起，您没有权限进行批量删除");
            ShowShop.BLL.Member.UserInfoNote noteBll = new ShowShop.BLL.Member.UserInfoNote();
            string type = this.radTime.SelectedValue;
            string whereData = string.Empty;
            switch (type)
            {
                case "0":
                    whereData = " day(NoteDate) <= day(getdate())-10 or Month(NoteDate)< Month(getdate()) or year(NoteDate)<year(getdate()) ";
                    break;
                case "1":
                    whereData = " Month(NoteDate) <= Month(getdate())-1 or year(NoteDate)<year(getdate()) ";
                    break;
                case "2":
                    whereData = " Month(NoteDate) <= Month(getdate())-2 or year(NoteDate)<year(getdate()) ";
                    break;
                case "3":
                    whereData = " Month(NoteDate) <= Month(getdate())-3  or year(NoteDate)<year(getdate()) ";
                    break;
                case "4":
                    whereData = " Month(NoteDate) <= Month(getdate())-6 or year(NoteDate)<year(getdate()) ";
                    break;
                case "5":
                    whereData = " year(NoteDate)<=year(getdate())-1 ";
                    break;
                default:
                    break;
            }
            string whereOther = string.Empty;
            switch (Cache["type"].ToString())
            {
                case "all":
                    whereOther = " and 1=1 ";
                    break;
                case "add":
                    whereOther = " and buckleOrAdd=0 and noteType=0 ";
                    break;
                case "make":
                    whereOther = " and buckleOrAdd=1 and noteType=0 ";
                    break;
                default:
                    break;
            }
            string whereAll = whereData + whereOther;
            noteBll.Delete(whereAll);
        }
        #endregion
    }
}
