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
    public partial class member_useful : System.Web.UI.Page
    {
        ShowShop.BLL.Member.MemberAccount memberBll = new ShowShop.BLL.Member.MemberAccount();
        ShowShop.BLL.Member.MemberRank rankBll = new ShowShop.BLL.Member.MemberRank();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                InitWebControl();
                ViewState["time"] = "4";
                string uid = ChangeHope.WebPage.PageRequest.GetQueryString("uid");
                ViewState["uid"] = uid;
                string opreate = ChangeHope.WebPage.PageRequest.GetQueryString("Opreate");
                ViewState["Opreate"] = opreate;
                if(uid!=""&&uid!=null){
                    ShowShop.Model.Member.MemberAccount model = memberBll.GetModel(Convert.ToInt32(uid));
                    this.lblName.Text = model.UserId.ToString();
                    this.lblPoint.Text = model.Points.ToString();
                    this.lblCapital.Text = model.Capital.ToString();
                    this.lblCoupon.Text = model.Coupons.ToString();
                    this.lblGroup.Text = rankBll.GetModel(Convert.ToInt32(model.UserGroup)).Name.ToString();
                    TimeSpan oldtime = new TimeSpan(Convert.ToDateTime(System.DateTime.Now.ToShortDateString()).Ticks);
                    TimeSpan newtime = new TimeSpan(Convert.ToDateTime(model.PeriodOfValidity).Ticks);
                    TimeSpan tag = oldtime.Subtract(newtime).Duration();
                    this.lblValidity.Text = tag.Days.ToString();
                }
            }
        }

        #region 验证与初始化
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtQuestion,"请输入编辑有效期的原因","isnull","必填","该项为必填项");
            ChangeHope.WebPage.WebControl.SetDate(this.txtManageTime);
            ChangeHope.WebPage.WebControl.Validate(this.txtManageTime,"设置该权限过期时间","isnull","必填","该项为必填项");
            this.txtManageTime.Text = System.DateTime.Now.ToShortDateString();
        }
        #endregion

        #region 操作方式
        protected void RadValidity_CheckedChanged(object sender, EventArgs e)
        {
            ViewState["time"] = "4";
        }

        protected void RadZero_CheckedChanged(object sender, EventArgs e)
        {
            ViewState["time"] = "5";
        }
        #endregion

        //执行操作
        protected void btnOk_Click(object sender, EventArgs e)
        {
            ShowShop.Model.Admin.AdminInfo adminInfo = (ShowShop.Model.Admin.AdminInfo)ShowShop.Common.AdministrorManager.Get();
            ShowShop.BLL.Member.UserInfoNote noteBll = new ShowShop.BLL.Member.UserInfoNote();
            ShowShop.Model.Member.UserInfoNote noteModel = new ShowShop.Model.Member.UserInfoNote();
            ShowShop.Model.Member.MemberAccount account = memberBll.GetModel(Convert.ToInt32(ViewState["uid"]));
            TimeSpan oldtime = new TimeSpan(Convert.ToDateTime(account.PeriodOfValidity).Ticks); //记录旧日期
            noteModel.NoteName = adminInfo.AdminName;
            noteModel.NoteType = 2;
            noteModel.NoteDate = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
            noteModel.Causation = this.txtQuestion.Text.Trim().ToString();
            noteModel.BosomNote = this.txtLog.Text.Trim().ToString();
            DateTime periodOfValidity=System.DateTime.Now;
            if (ViewState["time"].ToString() == "4")
            {
                if (ViewState["Opreate"].ToString() == "add")
                {
                    noteModel.BuckleOrAdd = 0;  //添加
                    if (Convert.ToDateTime(this.txtManageTime.Text) > Convert.ToDateTime(account.PeriodOfValidity))
                    {
                        periodOfValidity = Convert.ToDateTime(this.txtManageTime.Text);
                    }
                    else
                    {
                        this.ltlMsg.Text = "增加的有效期小于系统记录的有效期！";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }

                }
                else
                {
                    noteModel.BuckleOrAdd = 1; //减少
                    if (Convert.ToDateTime(this.txtManageTime.Text) < Convert.ToDateTime(account.PeriodOfValidity))
                    {
                       periodOfValidity= Convert.ToDateTime(this.txtManageTime.Text);
                    }
                    else
                    {
                        this.ltlMsg.Text = "减少的有效期大于系统记录的有效期！";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
            }
            else
            {   //有效期归0
                periodOfValidity = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
            }
            memberBll.Amend(account.UID, "PeriodOfValidity", periodOfValidity);
            TimeSpan newtime = new TimeSpan(Convert.ToDateTime(account.PeriodOfValidity).Ticks);
            TimeSpan gap = oldtime.Subtract(newtime).Duration();
            noteModel.TicketCount = Convert.ToInt32(gap.Days);
            noteModel.UserID = Convert.ToInt32(account.UID);
            noteModel.Username = account.UserId;
            int count=noteBll.Add(noteModel);
            if (count > 0)
            {
                this.ltlMsg.Text = "编辑有效期成功！";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
            else
            {
                this.ltlMsg.Text = "编辑有效期失败！";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
                return;
            }
        }
    }
}
