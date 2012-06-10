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
    public partial class member_outfund : System.Web.UI.Page
    {
        ShowShop.BLL.Member.MemberAccount memberBll = new ShowShop.BLL.Member.MemberAccount();
        ShowShop.BLL.Member.MemberRank rankBll = new ShowShop.BLL.Member.MemberRank();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                InitWebControl();
                string uid = ChangeHope.WebPage.PageRequest.GetQueryString("uid");
                ViewState["uid"] = uid;
                if(uid!=null&&uid!=""){
                    ShowShop.Model.Member.MemberAccount model = memberBll.GetModel(Convert.ToInt32(uid));
                    this.lblName.Text = model.UserId.ToString();
                    this.lblCapital.Text = model.Capital.ToString();
                }
            }
        }

        #region 验证与初始化
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtPayMoney, "请输入支出入的资金，必须是数字", "isint", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtWhy, "请输入支出的原因", "isnull", "必填", "该项为必填项");
        }
        #endregion

        #region 执行
        //执行
        protected void BtnWork_Click(object sender, EventArgs e)
        {
            ShowShop.Model.Admin.AdminInfo adminInfo = (ShowShop.Model.Admin.AdminInfo)ShowShop.Common.AdministrorManager.Get();
            ShowShop.BLL.Member.UserInfoNote noteBll = new ShowShop.BLL.Member.UserInfoNote();
            ShowShop.Model.Member.UserInfoNote noteModel = new ShowShop.Model.Member.UserInfoNote();
            ShowShop.Model.Member.MemberAccount model = memberBll.GetModel(Convert.ToInt32(ViewState["uid"]));
            noteModel.NoteName = adminInfo.AdminName;
            noteModel.NoteType = 1;
            noteModel.NoteDate = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
            noteModel.Causation = this.txtWhy.Text.Trim().ToString();
            noteModel.BosomNote = this.txtLog.Text.Trim().ToString();
            noteModel.BuckleOrAdd = 1;
            try
            {
                if (Convert.ToDecimal(model.Capital) > Convert.ToDecimal(this.txtPayMoney.Text))
                {
                    memberBll.Amend(model.UID, "Capital", Convert.ToDecimal(model.Capital) - Convert.ToDecimal(this.txtPayMoney.Text));
                    noteModel.UserID = Convert.ToInt32(model.UID);
                    noteModel.Username = model.UserId;
                    noteModel.TicketCount = Convert.ToDecimal(this.txtPayMoney.Text);
                    int count = noteBll.Add(noteModel);
                    if (count > 0)
                    {
                        this.ltlMsg.Text = "支出金额成功！";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionOk";
                    }
                    else
                    {
                        this.ltlMsg.Text = "支出金额失败！";
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                }
                else
                {
                    this.ltlMsg.Text = "抱歉您的资金小于你要支出的金额！请冲值！";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
            }
            catch
            {
                this.ltlMsg.Text = "请输入数字作为金额";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
                return;
            }
           
        }
        #endregion
    }
}
