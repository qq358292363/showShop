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
    public partial class member_detail_date : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                ShowShop.Common.PromptInfo.Popedom("008006001");
                InitWebControl();
                string type = ChangeHope.WebPage.PageRequest.GetQueryString("type");
                if(type!=""&&type!=null){
                    Cache["type"] = type;
                }           
                string where=string.Empty;
                switch(Cache["type"].ToString()){
                    case "all":
                        where = "";
                        break;
                    case "add":
                        where =" buckleOrAdd=0 and noteType=2 ";
                        break;
                    case "make":
                        where = " buckleOrAdd=1 and noteType=2 ";
                        break;
                    default:
                        break;
                }
                this.LitDate.Text = GetListByWhere(where); 
            }
        }

        #region 初始化
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.SetDate(this.txtStartTime);
            ChangeHope.WebPage.WebControl.SetDate(this.txtEndTime);
        }
        #endregion

        #region 绑定Table
        /// <summary>
        /// 绑定TABLE 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>

        public string GetListByWhere(string  where)
        {
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Member.UserInfoNote noteBll = new ShowShop.BLL.Member.UserInfoNote();
            ChangeHope.DataBase.DataByPage dataPage = noteBll.GetListByWhere(where);
            table.AddHeadCol("","用户名");
            table.AddHeadCol("","时间");
            table.AddHeadCol("","添加日期");
            table.AddHeadCol("","减少日期");
            table.AddHeadCol("","操作人员");
            table.AddHeadCol("","备注/原因");
            table.AddHeadCol("","操作");
            table.AddRow();
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    table.AddCol(dataPage.DataReader["userName"].ToString());
                    table.AddCol(dataPage.DataReader["noteDate"].ToString());
                    table.AddCol(dataPage.DataReader["buckleOrAdd"].ToString() == "0" ? dataPage.DataReader["ticketCount"].ToString() : "");
                    table.AddCol(dataPage.DataReader["buckleOrAdd"].ToString() == "1" ? dataPage.DataReader["ticketCount"].ToString() : "");
                    table.AddCol(dataPage.DataReader["noteName"].ToString());
                    table.AddCol(dataPage.DataReader["causation"].ToString());
                    table.AddCol("<a href='coupons_record_view.aspx?id=" + dataPage.DataReader["id"].ToString() + "'>查看</a>");
                    table.AddRow();
                }
                string view = table.GetTable() + dataPage.PageToolBar;
                dataPage.Dispose();
                dataPage = null;
                return view;
            }
            else
            {
                return "抱歉没有符合您要求的信息！";
            }
          
        }
        #endregion

        #region 查询
        //查询
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            string timeStart = this.txtStartTime.Text.ToString();
            string timeEnd = this.txtEndTime.Text.ToString();
            string name = this.txtName.Text.Trim().ToString();
            string where = string.Empty;
            switch (Cache["type"].ToString())
            {
                case "all":
                    where = " 1=1 ";
                    break;
                case "add":
                    where = " buckleOrAdd=0 and noteType=2 ";
                    break;
                case "make":
                    where = " buckleOrAdd=1 and noteType=2 ";
                    break;
                default:
                    break;
            }
            string timeWhere = string.Empty;
            if (timeStart != "" && timeEnd != "")
            {
                if (Convert.ToDateTime(timeStart) > Convert.ToDateTime(timeEnd))
                {
                    this.ltlMsg.Text = "起始日期大于结束日期";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                }
                else
                {
                    this.pnlMsg.Visible = false;
                    timeWhere = " and noteDate between '"+timeStart+"' and '"+timeEnd+"' ";
                }
            }
            if (timeStart != "" && timeEnd == "")
            {
                timeWhere = " and noteDate >= '" + timeStart + "' ";
            }
            if(timeStart==""&&timeEnd!=""){

                timeWhere=" and noteDate = '"+timeEnd+"' ";
            }
            string nameWhere=string.Empty;
            if(name!=""){
                nameWhere = " and userName like '%" + name + "%' ";
            }          
            string allWhere = where + timeWhere + nameWhere;           
            this.LitDate.Text =  GetListByWhere(allWhere);
        }

        #endregion

        #region 删除
        //删除
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            ShowShop.Common.PromptInfo.Popedom("008006003","对不起，您没有权限进行批量删除");
            ShowShop.BLL.Member.UserInfoNote noteBll = new ShowShop.BLL.Member.UserInfoNote();
            string type=this.radTime.SelectedValue;
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
                    whereOther = " and buckleOrAdd=0 and noteType=2 ";
                    break;
                case "make":
                    whereOther = " and buckleOrAdd=1 and noteType=2 ";
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
