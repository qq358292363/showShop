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

namespace ShowShop.Web.admin.accessories
{
    public partial class leaveword_reply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("012003006","对不起，您没有权限进行回复");
                if (ChangeHope.WebPage.PageRequest.GetInt("id") > 0)
                {
                    BandInfo(ChangeHope.WebPage.PageRequest.GetInt("id"));
                }
            }
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void Save()
        {
            ShowShop.BLL.Accessories.Leaveword bll = new ShowShop.BLL.Accessories.Leaveword();
            ShowShop.Model.Accessories.Leaveword model = new ShowShop.Model.Accessories.Leaveword();
            model.ID = Convert.ToInt32(ViewState["id"].ToString());
            model.Type = Convert.ToInt32(ViewState["type"].ToString());
            model.UserName = ViewState["username"].ToString();
            model.Telephone = ViewState["tel"].ToString();
            model.QQ = ViewState["qq"].ToString();
            model.MSN = ViewState["msn"].ToString();
            model.Email = ViewState["email"].ToString();
            model.IP = ViewState["ip"].ToString();
            model.IsRegUser = Convert.ToInt32(ViewState["isreg"].ToString());
            model.AddDate = Convert.ToDateTime(ViewState["adddate"].ToString());
            model.IsRead = Convert.ToInt32(ViewState["isread"].ToString());
            model.IsAuditing = Convert.ToInt32(ViewState["isauditing"].ToString());
            model.StoreId = Convert.ToInt32(ViewState["storeid"].ToString());
            //需要更新的信息
            model.Title = this.txtTitle.Text;
            model.IsReply = Convert.ToInt32(this.rabIsReply.SelectedValue);
            model.Content = this.txtContent.Text;
            model.ReplyContent = this.txtReplyContent.Text;
            model.ReplyDate = DateTime.Now;
            model.Address = ViewState["address"].ToString();
            bll.Amend(model);
            this.ltlMsg.Text = "操作成功，已回复该信息！";
            this.pnlMsg.Visible = true;
            this.pnlMsg.CssClass = "actionOk";
        }

        /// <summary>
        /// 显示编辑信息
        /// </summary>
        /// <param name="id"></param>
        protected void BandInfo(int id)
        {
            ShowShop.BLL.Accessories.Leaveword bll = new ShowShop.BLL.Accessories.Leaveword();
            ShowShop.Model.Accessories.Leaveword model = bll.GetModelByID(id);
            this.txtTitle.Text = model.Title;
            this.txtContent.Text = model.Content;
            this.rabIsReply.SelectedValue = model.IsReply.ToString();
            this.txtReplyContent.Text = model.ReplyContent;
            ViewState["id"] = model.ID.ToString();
            ViewState["type"] = model.Type.ToString();
            ViewState["username"] = model.UserName;
            ViewState["tel"] = model.Telephone;
            ViewState["qq"] = model.QQ;
            ViewState["msn"] = model.MSN;
            ViewState["email"] = model.Email;
            ViewState["ip"] = model.IP;
            ViewState["isreg"] = model.IsRegUser.ToString();
            ViewState["adddate"] = model.AddDate.ToString();
            ViewState["isread"] = model.IsRead.ToString();
            ViewState["repdate"] = model.ReplyDate.ToString();
            ViewState["isauditing"] = model.IsAuditing.ToString();
            ViewState["storeid"] = model.StoreId.ToString();

        }
    }
}
