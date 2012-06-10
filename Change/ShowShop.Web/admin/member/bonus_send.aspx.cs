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

namespace ShowShop.Web.admin.member
{
    public partial class bonus_send : System.Web.UI.Page
    {
        ShowShop.BLL.Member.MemberAccount merberBll = new ShowShop.BLL.Member.MemberAccount();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitWebControl();
                ViewState["M"] = "1";
                string strId = Request.QueryString["strId"];
                string opreate = Request.QueryString["Opreate"]; //记录是添加还减少
                ViewState["Opreate"] = opreate;
                if (strId != null && strId != "")
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
                    this.rabtnCheckUser.Checked = true;
                    ViewState["M"] = "3"; //记录指定用户
                }
            }
        }

        #region 验证
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtCapital, "输入数字将作为金额", "isint", "必填", "该项必须为数字类型");
            ChangeHope.WebPage.WebControl.Validate(this.txtReason, "输入扣发奖金的原因", "isnull", "必填", "该项为必填项");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
            MemberRankBind();
        }
        #endregion

        #region 绑定
        protected void MemberRankBind()
        {
            ShowShop.BLL.Member.MemberRank bll = new ShowShop.BLL.Member.MemberRank();
            List<ShowShop.Model.Member.MemberRank> model = bll.GetAllMemberRank();
            cbxlMemberRank.DataSource = model;
            cbxlMemberRank.DataTextField = "Name";
            cbxlMemberRank.DataValueField = "Id";
            cbxlMemberRank.DataBind();
        }
        #endregion

        #region 操作
        protected void lbSave_Click(object sender, EventArgs e)
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
                noteModel.BuckleOrAdd = 1;  //减
            }
            noteModel.NoteName = adminInfo.AdminName;
            noteModel.NoteType = 1; //资金
            noteModel.NoteDate = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
            noteModel.Causation = this.txtReason.Text.Trim().ToString();
            noteModel.BosomNote = this.txtRcord.Text.Trim().ToString();
            //全部用户
            if (ViewState["M"].ToString() == "1")
            {
                List<ShowShop.Model.Member.MemberAccount> accountList = memberBll.GetAll("");
                foreach (ShowShop.Model.Member.MemberAccount item in accountList)
                {
                    switch (ViewState["Opreate"].ToString())
                    {
                        case "add":
                            item.Capital = Convert.ToDecimal(item.Capital) + Convert.ToDecimal(this.txtCapital.Text.Trim());
                            break;
                        case "allay":
                            if (Convert.ToDecimal(this.txtCapital.Text.Trim()) < Convert.ToDecimal(item.Capital))
                            {
                                item.Capital = Convert.ToDecimal(item.Capital) - Convert.ToDecimal(this.txtCapital.Text.Trim());
                            }
                            else
                            {
                                this.ltlMsg.Text = "减少的奖金数量大于系统记录的数量";
                                this.pnlMsg.Visible = true;
                                this.pnlMsg.CssClass = "actionErr";
                                return;
                            }
                            break;
                        default:
                            break;
                    }
                    memberBll.Update(item);
                    noteModel.UserID = Convert.ToInt32(item.UID);
                    noteModel.Username = item.UserId;
                    noteModel.TicketCount = Convert.ToDecimal(this.txtCapital.Text.Trim());
                    noteBll.Add(noteModel);
                }
            }
            //指定用户组
            if (ViewState["M"].ToString() == "2")
            {         
                string typeId=this.cbxlMemberRank.SelectedValue;
                   List<ShowShop.Model.Member.MemberAccount> accountList = merberBll.GetAll("UserGroup=" + typeId);
                            foreach (ShowShop.Model.Member.MemberAccount item in accountList)
                            {
                                switch (ViewState["Opreate"].ToString())
                                {
                                    case "add":
                                        item.Capital = Convert.ToDecimal(item.Capital) + Convert.ToDecimal(this.txtCapital.Text.Trim());
                                        break;
                                    case "allay":
                                        if (Convert.ToDecimal(this.txtCapital.Text.Trim()) < Convert.ToDecimal(item.Capital))
                                        {
                                            item.Capital = Convert.ToDecimal(item.Capital) - Convert.ToDecimal(this.txtCapital.Text.Trim());
                                        }
                                        else
                                        {
                                            this.ltlMsg.Text = "减少的奖金数量大于系统记录的数量";
                                            this.pnlMsg.Visible = true;
                                            this.pnlMsg.CssClass = "actionErr";
                                            return;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                memberBll.Update(item);
                                noteModel.UserID = Convert.ToInt32(item.UID);
                                noteModel.Username = item.UserId;
                                noteModel.TicketCount = Convert.ToDecimal(this.txtCapital.Text.Trim());
                                noteBll.Add(noteModel);
                            }
             }
            //指定用户
            if (ViewState["M"].ToString() == "3")
            {
                string assigner = this.txtName.Text.Trim();
                String[] name = assigner.Split(',');
                int con = name.Length;
                for (int i = 0; i < con; i++)
                {
                    string userName = name[i].ToString();
                    List<ShowShop.Model.Member.MemberAccount> accountList = memberBll.GetAll("UserId = '" + userName + "'");
                    foreach (ShowShop.Model.Member.MemberAccount item in accountList)
                    {
                        switch (ViewState["Opreate"].ToString())
                        {
                            case "add":
                                item.Capital = Convert.ToDecimal(item.Capital) + Convert.ToDecimal(this.txtCapital.Text.Trim());
                                break;
                            case "allay":
                                if (Convert.ToDecimal(this.txtCapital.Text.Trim()) < Convert.ToDecimal(item.Capital))
                                {
                                    item.Capital = Convert.ToDecimal(item.Capital) - Convert.ToDecimal(this.txtCapital.Text.Trim());
                                }
                                else
                                {
                                    this.ltlMsg.Text = "减少的奖金数量大于系统记录的数量";
                                    this.pnlMsg.Visible = true;
                                    this.pnlMsg.CssClass = "actionErr";
                                    return;
                                }
                                break;
                            default:
                                break;
                        }
                        memberBll.Update(item);
                        noteModel.UserID = Convert.ToInt32(item.UID);
                        noteModel.Username = item.UserId;
                        noteModel.TicketCount = Convert.ToDecimal(this.txtCapital.Text.Trim());
                        noteBll.Add(noteModel);
                    }
                }
            }
            Response.Redirect("messge.aspx?Key=编辑奖金成功！");
        }
        #endregion

        #region 操作类型
        protected void rabtnAllUser_CheckedChanged(object sender, EventArgs e)
        {
            ViewState["M"] = "1";
        }

        protected void rabtnMemberGroup_CheckedChanged(object sender, EventArgs e)
        {
            ViewState["M"] = "2";
        }

        protected void rabtnCheckUser_CheckedChanged(object sender, EventArgs e)
        {
            ViewState["M"] = "3";
        }

        #endregion
    }
}
