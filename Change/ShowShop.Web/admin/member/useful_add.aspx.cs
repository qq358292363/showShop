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
using System.Collections.Generic;
using ShowShop.BLL.Admin;
using System.Web.UI.MobileControls;

namespace ShowShop.Web.admin.member
{
    public partial class useful_add : System.Web.UI.Page
    {   
        ShowShop.BLL.Member.MemberAccount merberBll=new ShowShop.BLL.Member.MemberAccount();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("008001007","对不起，您没有权限进行编辑有效期");
                InitWebControl();
                ViewState["time"] = "4";
                ViewState["M"] = "1";
                string strId = Request.QueryString["strId"];
                string opreate = Request.QueryString["Opreate"];
                ViewState["Opreate"] = opreate;
                if (strId != null&&strId!="")
                {
                    string[] id = strId.Split(',');
                    int ln = id.Length;
                    string str = "";
                    for (int i = 0; i < id.Length; i++)
                    {
                        if (!id[i].Trim().Equals(""))
                        {
                            try
                            {
                                ShowShop.Model.Member.MemberAccount meber = merberBll.GetModel(Convert.ToInt32(id[i]));
                                if (meber != null)
                                {
                                    str += meber.UserId + ",";
                                }
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                    try
                    {
                        this.txtName.Text = str.Substring(0, (str.Length - 1));
                    }
                    catch
                    {

                    }
                    this.RadioButton3.Checked = true;
                    ViewState["M"] = "3"; //记录指定用户
                }
            }
        }

        #region 验证与初始化
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.SetDate(this.txtManageTime);
            ChangeHope.WebPage.WebControl.Validate(this.txtManageTime, "该权限的过期时间", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtWhy, "填写备注原因", "isnull", "必填", "该项为必填项");
            this.txtManageTime.Text = System.DateTime.Now.ToShortDateString().ToString();
            GetItem();
        }
        #endregion

        #region 绑定用户类型
        public void GetItem()
        {
            ShowShop.BLL.Member.MemberRank bll = new ShowShop.BLL.Member.MemberRank();
            List<ShowShop.Model.Member.MemberRank> model = bll.GetAllMemberRank();
            cbxlMemberRank.DataSource = model;
            cbxlMemberRank.DataTextField = "Name";
            cbxlMemberRank.DataValueField = "Id";
            cbxlMemberRank.DataBind();
        }
        #endregion

        #region 添加/减少
        //批量事件(添加与减少)
        protected void BtnWork_Click(object sender, EventArgs e)
        {
            ShowShop.Model.Admin.AdminInfo adminInfo = (ShowShop.Model.Admin.AdminInfo)ShowShop.Common.AdministrorManager.Get(); 
            ShowShop.BLL.Member.MemberAccount memberBll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.BLL.Member.UserInfoNote noteBll = new ShowShop.BLL.Member.UserInfoNote();
            ShowShop.Model.Member.UserInfoNote noteModel = new ShowShop.Model.Member.UserInfoNote();
            if (ViewState["Opreate"].ToString().Equals("add"))
            {
                noteModel.BuckleOrAdd = 0;  //添加
            }
            else
            {
                noteModel.BuckleOrAdd = 1;  //减少
            }
            noteModel.NoteName = adminInfo.AdminName;
            noteModel.NoteType = 2;
            noteModel.NoteDate = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
            noteModel.Causation = this.txtWhy.Text.Trim().ToString();
            noteModel.BosomNote = this.txtLog.Text.Trim().ToString();
            //所有会员
            if (ViewState["M"].ToString() == "1")
            {
                List <ShowShop.Model.Member.MemberAccount> accountList= memberBll.GetAll("");
                foreach (ShowShop.Model.Member.MemberAccount item in accountList)
                {
                    TimeSpan oldtime = new TimeSpan(Convert.ToDateTime(item.PeriodOfValidity).Ticks);
                    if (ViewState["time"].ToString() == "4")
                    {
                        switch (ViewState["Opreate"].ToString())
                        {    
                            case "add":
                                if (Convert.ToDateTime(this.txtManageTime.Text) > Convert.ToDateTime(item.PeriodOfValidity))
                                {
                                    item.PeriodOfValidity = Convert.ToDateTime(this.txtManageTime.Text);
                                }
                                else
                                {
                                    this.ltlMsg.Text = "添加的有效期小于系统记录的有效期！";
                                    this.pnlMsg.Visible = true;
                                    this.pnlMsg.CssClass = "actionErr";
                                    return;
                                }
                                break;
                            case "allay":
                                if (Convert.ToDateTime(this.txtManageTime.Text) < Convert.ToDateTime(item.PeriodOfValidity))
                                {
                                    item.PeriodOfValidity = Convert.ToDateTime(this.txtManageTime.Text);
                                }
                                else 
                                {
                                    this.ltlMsg.Text = "减少的有效期大于系统记录的有效期！";
                                    this.pnlMsg.Visible = true;
                                    this.pnlMsg.CssClass = "actionErr";
                                    return;
                                }
                                break;
                            default:
                                break;
                        }
                       
                    }
                    else
                    {   //归0
                        item.PeriodOfValidity = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());                       
                    }
                    memberBll.Update(item);         
                    TimeSpan newtime=new TimeSpan(Convert.ToDateTime(this.txtManageTime.Text).Ticks);
                    TimeSpan gap=oldtime.Subtract(newtime).Duration();
                    noteModel.TicketCount=Convert.ToDecimal(gap.Days);
                    noteModel.UserID = Convert.ToInt32(item.UID);
                    noteModel.Username = item.UserId;
                    noteBll.Add(noteModel);
                }
                            
            }
            //指定会员组
            if (ViewState["M"].ToString() == "2")
            {   //获取会员类型
                string typeId = this.cbxlMemberRank.SelectedValue;
                List<ShowShop.Model.Member.MemberAccount> accountList = merberBll.GetAll("UserGroup="+typeId);
                foreach (ShowShop.Model.Member.MemberAccount item in accountList)
                {
                                TimeSpan oldtime = new TimeSpan(Convert.ToDateTime(item.PeriodOfValidity).Ticks);
                                if (ViewState["time"].ToString() == "4")
                                {

                                    switch (ViewState["Opreate"].ToString())
                                    {
                                        case "add":
                                            if (Convert.ToDateTime(this.txtManageTime.Text) > Convert.ToDateTime(item.PeriodOfValidity))
                                            {
                                                item.PeriodOfValidity = Convert.ToDateTime(this.txtManageTime.Text);
                                            }
                                            else
                                            {
                                                this.ltlMsg.Text = "添加的有效期小于系统记录的有效期！";
                                                this.pnlMsg.Visible = true;
                                                this.pnlMsg.CssClass = "actionErr";
                                                return;
                                            }
                                            break;
                                        case "allay":
                                            if (Convert.ToDateTime(this.txtManageTime.Text) < Convert.ToDateTime(item.PeriodOfValidity))
                                            {
                                                item.PeriodOfValidity = Convert.ToDateTime(this.txtManageTime.Text);
                                            }
                                            else
                                            {
                                                this.ltlMsg.Text = "减少的有效期大于系统记录的有效期！";
                                                this.pnlMsg.Visible = true;
                                                this.pnlMsg.CssClass = "actionErr";
                                                return;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {   //归0
                                    item.PeriodOfValidity = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                                }
                                memberBll.Update(item);             
                                TimeSpan newtime = new TimeSpan(Convert.ToDateTime(this.txtManageTime.Text).Ticks);
                                TimeSpan gap = oldtime.Subtract(newtime).Duration();
                                noteModel.TicketCount = Convert.ToDecimal(gap.Days);
                                noteModel.UserID = Convert.ToInt32(item.UID);
                                noteModel.Username = item.UserId;
                                noteBll.Add(noteModel);
                 }                                 
            }
            //指定用户
            if(ViewState["M"].ToString() =="3")
            {
                string assigner= this.txtName.Text.Trim();
                String[] name = assigner.Split(',');
                int con = name.Length;
                for (int i = 0; i < con; i++)
                {
                    string userName = name[i].ToString();
                    List<ShowShop.Model.Member.MemberAccount> accountList = memberBll.GetAll("UserId = '" + userName + "'");
                    foreach (ShowShop.Model.Member.MemberAccount item in accountList)
                    {
                        TimeSpan oldtime = new TimeSpan(Convert.ToDateTime(item.PeriodOfValidity).Ticks);
                        if (ViewState["time"].ToString() == "4")
                        {
                            switch (ViewState["Opreate"].ToString())
                            {
                                case "add":
                                    if (Convert.ToDateTime(this.txtManageTime.Text) > Convert.ToDateTime(item.PeriodOfValidity))
                                    {
                                        item.PeriodOfValidity = Convert.ToDateTime(this.txtManageTime.Text);
                                    }
                                    else
                                    {
                                        this.ltlMsg.Text = "添加的有效期小于系统记录的有效期！";
                                        this.pnlMsg.Visible = true;
                                        this.pnlMsg.CssClass = "actionErr";
                                        return;
                                    }
                                    break;
                                case "allay":
                                    if (Convert.ToDateTime(this.txtManageTime.Text) < Convert.ToDateTime(item.PeriodOfValidity))
                                    {
                                        item.PeriodOfValidity = Convert.ToDateTime(this.txtManageTime.Text);
                                    }
                                    else
                                    {
                                        this.ltlMsg.Text = "减少的有效期大于系统记录的有效期！";
                                        this.pnlMsg.Visible = true;
                                        this.pnlMsg.CssClass = "actionErr";
                                        return;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {   //归0
                            item.PeriodOfValidity = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                        }
                        memberBll.Update(item);                     
                        TimeSpan newtime = new TimeSpan(Convert.ToDateTime(this.txtManageTime.Text).Ticks);
                        TimeSpan gap = oldtime.Subtract(newtime).Duration();
                        noteModel.TicketCount = Convert.ToDecimal(gap.Days);
                        noteModel.UserID = Convert.ToInt32(item.UID);
                        noteModel.Username = item.UserId;
                        noteBll.Add(noteModel);
                    }
                }
            }
            this.ltlMsg.Text = "编辑有效期成功！";
            this.pnlMsg.Visible = true;
            this.pnlMsg.CssClass = "actionOk";

        }
        #endregion

        #region 指定操作类别

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ViewState["M"] = "1";
        }
        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ViewState["M"] = "2";
        }
        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ViewState["M"] = "3";
        }
        protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            ViewState["time"] = "4";
        }
        protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            ViewState["time"] = "5";
        }
        #endregion
    }
}
