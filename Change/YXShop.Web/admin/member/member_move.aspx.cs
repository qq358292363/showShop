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

namespace ShowShop.Web.admin.member
{
    public partial class member_move : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ChangeHope.WebPage.PageRequest.GetQueryString("strId") != string.Empty)
                {
                    GetUserID();
                }
                MemberRankBind();
            }
        }

        #region 信息绑定
        protected void MemberRankBind()
        {
            ShowShop.BLL.Member.MemberRank bll = new ShowShop.BLL.Member.MemberRank();
            List<ShowShop.Model.Member.MemberRank> model = bll.GetAllMemberRank();
            lbxFrom.DataSource = model;
            lbxFrom.DataTextField = "Name";
            lbxFrom.DataValueField = "Id";
            lbxFrom.DataBind();
            lbxTo.DataSource = model;
            lbxTo.DataTextField = "Name";
            lbxTo.DataValueField = "Id";
            lbxTo.DataBind();
        }

        /// <summary>
        /// 得到初始化时用户的账号串
        /// </summary>
        protected void GetUserID()
        {
            string uid = ChangeHope.WebPage.PageRequest.GetQueryString("strId");
            string userId = string.Empty;
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            List<ShowShop.Model.Member.MemberAccount> model = bll.GetAll(" UID in(" + uid + ")");
            for (int i = 0; i < model.Count; i++)
            {
                userId += model[i].UserId + ",";
            }
            userId = userId.Substring(0, userId.LastIndexOf(','));
            this.txtUserName.Text = userId;
        }
        #endregion

        protected void lbSave_Click(object sender, EventArgs e)
        {
            if (ViewState["to"] == null)
            {
                this.ltlMsg.Text = "请选择您要移动到的目标会员组";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
                return;
            }
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            List<ShowShop.Model.Member.MemberAccount> model = new List<ShowShop.Model.Member.MemberAccount>();
            if (rabtnUser.Checked)
            {
                if (txtUserName.Text.Trim().Length != 0)
                {
                    string uid = this.txtUserName.Text.Trim();
                    if (uid.EndsWith(","))
                    {
                        uid = uid.Substring(0, uid.LastIndexOf(','));
                    }
                    //进行拆分 给每个字段加上单引号
                    string[] arrUid = uid.Split(',');
                    uid = string.Empty;
                    for (int i = 0; i < arrUid.Length; i++)
                    {
                        uid += "'" + arrUid[i] + "'" + ",";
                    }
                    if (uid.EndsWith(","))
                    {
                        uid = uid.Substring(0, uid.LastIndexOf(','));
                    }

                    model = bll.GetAll(" UserId in(" + uid + ")");
                    for (int i = 0; i < model.Count; i++)
                    {
                        bll.Amend(Convert.ToInt32(model[i].UID), "UserGroup", this.lbxTo.SelectedValue);
                    }
                    this.ltlMsg.Text = "操作成功！";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionOk";
                }
                else
                {
                    this.ltlMsg.Text = "请输入您要移动的用户";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
            }
            //按会员组 批量移动
            else if (rabtnGroup.Checked)
            {
                if (ViewState["from"] == null)
                {
                    this.ltlMsg.Text = "请选择您要移动的会员组";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
                bll.UpdateGroup(this.lbxFrom.SelectedValue, this.lbxTo.SelectedValue);
                this.ltlMsg.Text = "操作成功！";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
        }

        protected void lbxTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["to"] = this.lbxTo.SelectedValue;
        }

        protected void lbxFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["from"] = this.lbxFrom.SelectedValue;
        }
    }
}
