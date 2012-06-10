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
    public partial class member_cupons_duty : System.Web.UI.Page
    {
        ShowShop.BLL.Member.MemberAccount memberBll = new ShowShop.BLL.Member.MemberAccount();
        ShowShop.BLL.Member.MemberRank rankBll = new ShowShop.BLL.Member.MemberRank();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                string uid = ChangeHope.WebPage.PageRequest.GetQueryString("uid");
                ViewState["uid"] = uid;
                if(uid!=null&&uid!=""){
                    ShowShop.Model.Member.MemberAccount account = memberBll.GetModel(Convert.ToInt32(uid));
                    this.lblName.Text = account.UserId;
                    this.lblCapital.Text = account.Capital.ToString();
                    this.lblCoupons.Text = account.Coupons.ToString();
                    this.lblPoints.Text = account.Points.ToString();
                    this.lblGroup.Text = rankBll.GetModel(Convert.ToInt32(account.UserGroup)).Name.ToString();
                    TimeSpan oldtime = new TimeSpan(Convert.ToDateTime(account.PeriodOfValidity).Ticks);
                    TimeSpan newtime = new TimeSpan(Convert.ToDateTime(System.DateTime.Now.ToShortDateString()).Ticks);
                    TimeSpan tag = oldtime.Subtract(newtime).Duration();
                    this.lblValidity.Text = tag.Days.ToString();
                }
                InitWebControl();
            }
        }

        #region 验证与初始化
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtCoupons,"请输入兑换的点卷数必须是数字","isint","必填","该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtCapital,"请输入兑换点卷扣除的资金，必须是数字","isint","必填","该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtWhy, "请输入编辑有效期的原因", "isnull", "必填", "该项为必填项");      
        }
        #endregion

        #region 执行
        //执行
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ShowShop.Model.Admin.AdminInfo adminInfo = (ShowShop.Model.Admin.AdminInfo)ShowShop.Common.AdministrorManager.Get();
            ShowShop.BLL.Member.UserInfoNote noteBll = new ShowShop.BLL.Member.UserInfoNote();
            ShowShop.Model.Member.UserInfoNote noteModel = new ShowShop.Model.Member.UserInfoNote();
            ShowShop.Model.Member.MemberAccount model = memberBll.GetModel(Convert.ToInt32(ViewState["uid"]));
            noteModel.NoteName = adminInfo.AdminName;
            noteModel.NoteDate = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
            noteModel.Causation = this.txtWhy.Text.Trim().ToString();
            noteModel.BosomNote = this.txtLog.Text.Trim().ToString();
            if (Convert.ToDecimal(model.Capital) > Convert.ToDecimal(this.txtCapital.Text))
            {
                memberBll.Amend(model.UID, "Coupons", Convert.ToDecimal(model.Coupons) + Convert.ToDecimal(this.txtCoupons.Text));
                memberBll.Amend(model.UID, "Capital", Convert.ToDecimal(model.Capital) - Convert.ToDecimal(this.txtCapital.Text));
                noteModel.UserID = Convert.ToInt32(model.UID);
                noteModel.Username = model.UserId;
                //记录点卷
                noteModel.NoteType = 0;
                noteModel.TicketCount = Convert.ToDecimal(this.txtCoupons.Text);
                noteModel.BuckleOrAdd=0;
                noteBll.Add(noteModel);
                //记录资金
                noteModel.NoteType = 1;
                noteModel.TicketCount = Convert.ToDecimal(this.txtCapital.Text);
                noteModel.BuckleOrAdd = 1;
                noteBll.Add(noteModel);
                this.ltlMsg.Text = "兑换点卷成功！";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
             
            }
            else
            {
                this.ltlMsg.Text = "兑换点卷的资金不足，请您冲值！";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
                return;
            }
        }
        #endregion
    }
}
