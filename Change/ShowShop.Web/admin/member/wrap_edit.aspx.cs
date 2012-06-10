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
    public partial class wrap_edit : System.Web.UI.Page
    {
        ShowShop.BLL.Member.MemberAccount merberBll = new ShowShop.BLL.Member.MemberAccount();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("008001009", "对不起，您没有权限进行编辑");
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
                    this.RadioButton3.Checked = true;
                    ViewState["M"] = "3"; //记录指定用户
                }
            }
        }


        #region 验证与初始化
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtWrap, "请填写点卷数量", "isint", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtWhy, "请填写备注原因", "isnull", "必填", "该项为必填项");
            MemberRankBind();
        }
        #endregion

        #region 绑定用户类型

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

        #region 操作类型
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
        #endregion

        #region 批量操作（添加/减少）
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
                noteModel.BuckleOrAdd = 1;  //减
            }
            noteModel.NoteName = adminInfo.AdminName;
            noteModel.NoteType = 0;//点卷
            noteModel.NoteDate = Convert.ToDateTime(System.DateTime.Now);
            noteModel.Causation = this.txtWhy.Text.Trim().ToString();
            noteModel.BosomNote = this.txtLog.Text.Trim().ToString();
            //全部用户
            if (ViewState["M"].ToString() == "1")
            {
                List<ShowShop.Model.Member.MemberAccount> accountList = memberBll.GetAll("");
                foreach (ShowShop.Model.Member.MemberAccount item in accountList)
                {
                    switch (ViewState["Opreate"].ToString())
                    {
                        case "add":
                            item.Coupons = Convert.ToDecimal(item.Coupons) + Convert.ToDecimal(this.txtWrap.Text.Trim());
                            break;
                        case "allay":
                            if (Convert.ToDecimal(this.txtWrap.Text.Trim())<Convert.ToDecimal(item.Coupons) )
                            {
                                item.Coupons = Convert.ToDecimal(item.Coupons)-Convert.ToDecimal(this.txtWrap.Text.Trim());
                            }
                            else
                            {
                                this.ltlMsg.Text = "减少的点卷数量大于系统记录的数量！";
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
                    noteModel.TicketCount = Convert.ToDecimal(this.txtWrap.Text.Trim());
                    noteBll.Add(noteModel);
                }
            }
            //指定用户组
            if (ViewState["M"].ToString() == "2")
            {              
                    //获取会员类型
                string typeId = this.cbxlMemberRank.SelectedValue;
                List<ShowShop.Model.Member.MemberAccount> accountList = merberBll.GetAll("UserGroup=" + typeId);
                foreach (ShowShop.Model.Member.MemberAccount item in accountList)
                {
                        switch (ViewState["Opreate"].ToString())
                        {
                                    case "add":
                                        item.Coupons = Convert.ToDecimal(item.Coupons) + Convert.ToDecimal(this.txtWrap.Text.Trim());
                                        break;
                                    case "allay":
                                        if (Convert.ToDecimal(this.txtWrap.Text.Trim()) < Convert.ToDecimal(item.Coupons))
                                        {
                                            item.Coupons = Convert.ToDecimal(item.Coupons) - Convert.ToDecimal(this.txtWrap.Text.Trim());
                                        }
                                        else
                                        {
                                            this.ltlMsg.Text = "减少的点卷数量大于系统记录的数量！";
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
                                noteModel.TicketCount = Convert.ToDecimal(this.txtWrap.Text.Trim());
                                noteBll.Add(noteModel);                              
                 }
                                            
            }
            //指定用户
            if (ViewState["M"].ToString() == "3")
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
                         switch (ViewState["Opreate"].ToString())
                                {
                                    case "add":
                                        item.Coupons = Convert.ToDecimal(item.Coupons) + Convert.ToDecimal(this.txtWrap.Text.Trim());
                                        break;
                                    case "allay":
                                        if (Convert.ToDecimal(this.txtWrap.Text.Trim()) < Convert.ToDecimal(item.Coupons))
                                        {
                                            item.Coupons = Convert.ToDecimal(item.Coupons) - Convert.ToDecimal(this.txtWrap.Text.Trim());
                                        }
                                        else
                                        {
                                            this.ltlMsg.Text = "减少的点卷数量大于系统记录的数量！";
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
                                noteModel.TicketCount = Convert.ToDecimal(this.txtWrap.Text.Trim());
                                noteBll.Add(noteModel);         
                    }
                }
            }
            this.ltlMsg.Text = "编辑点卷成功！";
            this.pnlMsg.Visible = true;
            this.pnlMsg.CssClass = "actionOk";
        }
        #endregion

    }
}
