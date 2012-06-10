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
    public partial class shortmessge_send : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //初始化时 uid传参数
                GetUserID();
                InitWebControl();
                MemberRankBind();
            }
        }

        #region 验证
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtTitle, "输入短消息的标题", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtContent, "输入短消息的内容", "isnull", "必填", "该项为必填项");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }
        #endregion

        #region 信息绑定
        protected void MemberRankBind()
        {
            ShowShop.BLL.Member.MemberRank bll = new ShowShop.BLL.Member.MemberRank();
            List<ShowShop.Model.Member.MemberRank> model = bll.GetAllMemberRank();
            cbxlMemberRank.DataSource = model;
            cbxlMemberRank.DataTextField = "Name";
            cbxlMemberRank.DataValueField = "Id";
            cbxlMemberRank.DataBind();
        }

        protected void GetUserID()
        {
            int uid = ChangeHope.WebPage.PageRequest.GetQueryInt("uid");
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.Model.Member.MemberAccount model = bll.GetModel(uid);
            txtUserName.Text = model.UserId;
            ShowShop.Model.Admin.AdminInfo adminModel = (ShowShop.Model.Admin.AdminInfo)ShowShop.Common.AdministrorManager.Get();
            this.txtAdminName.Text = adminModel.AdminName;
        }
        #endregion

        #region 短消息发送
        /// <summary>
        /// 接受者的 主键ID 和 账号
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="userid"></param>
        protected void SendMessage(int uid, string userid)
        {
            
            ShowShop.BLL.Member.MailReceiver ReceBll = new ShowShop.BLL.Member.MailReceiver();
            ShowShop.Model.Member.MailReceiver ReceModel = new ShowShop.Model.Member.MailReceiver();
            ShowShop.BLL.Member.MemberAccount bll =new ShowShop.BLL.Member.MemberAccount();
            if (!bll.Exists(userid))
            {
                this.ltlMsg.Text = "不存在用户：" + userid;
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
                return;
            }
            ReceModel.ReceiverId = uid;
            ReceModel.Receiver = userid;
            ReceModel.ReceiveTime = DateTime.Now;
            ReceModel.Stat = 0;
            ReceModel.IsRead = 0;
            ReceModel.Title = this.txtTitle.Text;
            ReceModel.Body = this.txtContent.Text;
            ReceModel.Sender = this.txtAdminName.Text;
            ReceBll.Add(ReceModel);
           
        }
        #endregion

        protected void lbSave_Click(object sender, EventArgs e)
        {
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            List<ShowShop.Model.Member.MemberAccount> model = new List<ShowShop.Model.Member.MemberAccount>();
            //发送给全体
            if (rabtnAllUser.Checked)
            {
                model = bll.GetAll(" 1=1");
                for (int i = 0; i < model.Count; i++)
                {
                    if (!bll.Exists(model[i].UserId))
                    {
                        this.ltlMsg.Text = "不存在用户：" + model[i].UserId;
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                    SendMessage(Convert.ToInt32(model[i].UID), model[i].UserId);
                }
                this.ltlMsg.Text = "操作成功，已向所有用户发送该信息！";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
                
            }
            //发送会员组
            else if (rabtnMemberGroup.Checked)
            {
                string rankID = string.Empty;
                for (int i = 0; i < cbxlMemberRank.Items.Count; i++)
                {
                    if (cbxlMemberRank.Items[i].Selected)
                    {
                        rankID += cbxlMemberRank.Items[i].Value + ",";
                    }
                }
                if (rankID == string.Empty)
                {
                    this.ltlMsg.Text = "请选择要发送到的会员组";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
                rankID = rankID.Substring(0, rankID.LastIndexOf(','));
                model = bll.GetAll(" UserGroup in(" + rankID + ")");
                for (int i = 0; i < model.Count; i++)
                {
                    if (!bll.Exists(model[i].UserId))
                    {
                        this.ltlMsg.Text = "不存在用户：" + model[i].UserId;
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                    SendMessage(Convert.ToInt32(model[i].UID), model[i].UserId);
                }
                this.ltlMsg.Text = "操作成功，已向指定用户组发送该信息！";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
            //指定用户名  
            else if (rabtnCheckUser.Checked)
            {
                string uid = this.txtUserName.Text.Trim();
                if (uid.Length == 0)
                {
                    this.ltlMsg.Text = "请输入要发送到的会员";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
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
                    if (!bll.Exists(model[i].UserId))
                    {
                        this.ltlMsg.Text = "不存在用户：" + model[i].UserId;
                        this.pnlMsg.Visible = true;
                        this.pnlMsg.CssClass = "actionErr";
                        return;
                    }
                    SendMessage(Convert.ToInt32(model[i].UID), model[i].UserId);
                }
                this.ltlMsg.Text = "操作成功，已向指定用户发送该信息！";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
        }
    }
}
