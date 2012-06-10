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
using ShowShop.BLL.Admin;

namespace ShowShop.Web.admin.member
{
    public partial class member_changedata : System.Web.UI.Page
    {
        ShowShop.BLL.Member.MemberAccount memberBll = new ShowShop.BLL.Member.MemberAccount();
        ShowShop.BLL.Member.MemberRank rankBll = new ShowShop.BLL.Member.MemberRank();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                InitWebControl();
                string uid = ChangeHope.WebPage.PageRequest.GetQueryString("uid");
                ViewState["uid"] = uid;
                if(uid!=null&&uid!=""){
                    ShowShop.Model.Member.MemberAccount model = memberBll.GetModel(Convert.ToInt32(uid));
                    this.lblName.Text = model.UserId;
                    this.lblCapital.Text = model.Capital.ToString();
                    this.lblCoupons.Text = model.Coupons.ToString();
                    this.lblPoints.Text = model.Points.ToString();
                    this.lblGroup.Text = rankBll.GetModel(Convert.ToInt32(model.UserGroup)).Name.ToString();
                    TimeSpan oldtime = new TimeSpan(Convert.ToDateTime(model.PeriodOfValidity).Ticks);
                    TimeSpan newtime = new TimeSpan(Convert.ToDateTime(this.txtManageTime.Text).Ticks);
                    TimeSpan gap = oldtime.Subtract(newtime).Duration();
                    this.lblDay.Text = gap.Days.ToString();
                }
            }


        }


        #region 验证与初始化
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtCapital,"请输入兑换有效期支出的资金","isint","必填","该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtQuestion, "请输入编辑有效期的原因", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.SetDate(this.txtManageTime);
            ChangeHope.WebPage.WebControl.Validate(this.txtManageTime, "设置该权限过期时间", "isdata", "必填", "该项为必填项");
            this.txtManageTime.Text = System.DateTime.Now.ToShortDateString();
        }
        #endregion

        #region 执行
        //执行
        protected void btnWork_Click(object sender, EventArgs e)
        {
            ShowShop.Model.Admin.AdminInfo adminInfo = (ShowShop.Model.Admin.AdminInfo)ShowShop.Common.AdministrorManager.Get();
            ShowShop.BLL.Member.UserInfoNote noteBll = new ShowShop.BLL.Member.UserInfoNote();
            ShowShop.Model.Member.UserInfoNote noteModel = new ShowShop.Model.Member.UserInfoNote();
            ShowShop.Model.Member.MemberAccount account = memberBll.GetModel(Convert.ToInt32(ViewState["uid"]));
            noteModel.NoteName = adminInfo.AdminName;
            noteModel.NoteDate = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
            noteModel.Causation = this.txtQuestion.Text.Trim().ToString();
            noteModel.BosomNote = this.txtLog.Text.Trim().ToString();
            TimeSpan oldtime=new TimeSpan(Convert.ToDateTime(account.PeriodOfValidity).Ticks);
            if (Convert.ToDateTime(this.txtManageTime.Text) > Convert.ToDateTime(account.PeriodOfValidity))
            {
                if (Convert.ToDecimal(account.Capital) > Convert.ToDecimal(this.txtCapital.Text))
                {
                    memberBll.Amend(account.UID, "PeriodOfValidity", this.txtManageTime.Text);
                    memberBll.Amend(account.UID, "Capital", Convert.ToDecimal(account.Capital) - Convert.ToDecimal(this.txtCapital.Text));
                    noteModel.UserID = Convert.ToInt32(account.UID);
                    noteModel.Username = account.UserId;
                    TimeSpan newtime = new TimeSpan(Convert.ToDateTime(this.txtManageTime.Text).Ticks);
                    TimeSpan tag = oldtime.Subtract(newtime).Duration();
                    //记录有效期
                    noteModel.BuckleOrAdd = 0;
                    noteModel.NoteType = 2;
                    noteModel.TicketCount = Convert.ToDecimal(tag.Days);
                    noteBll.Add(noteModel);
                    //记录资金支出
                    noteModel.BuckleOrAdd = 1;
                    noteModel.NoteType = 1;
                    noteModel.TicketCount = Convert.ToDecimal(this.txtCapital.Text);
                    noteBll.Add(noteModel);
                    this.ltlMsg.Text = "兑换有效期成功";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionOk";
                    return;
                }
                else
                {
                    this.ltlMsg.Text = "你帐户金额小于支付的金额，请您冲值。";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
            }
            else
            {
                this.ltlMsg.Text = "你兑换的日期小于系统记录的日期";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
                return;
            }
        }
        #endregion
    }
}
