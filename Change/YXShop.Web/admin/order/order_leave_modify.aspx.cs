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

namespace ShowShop.Web.admin.order
{
    public partial class order_leave_modify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = ChangeHope.WebPage.PageRequest.GetQueryInt("id");
            if (!IsPostBack)
                BindInfo(id);
        }

        protected void BindInfo(int id)
        {
            ShowShop.BLL.Order.OrderLeave bll = new ShowShop.BLL.Order.OrderLeave();
            ShowShop.Model.Order.OrderLeave model = bll.GetModelByID(id);
            if (model != null)
            {
                this.lblMemberId.Text = this.GetUserIdByuId(Convert.ToInt32(model.MemberId));
                this.lblCreateDate.Text = model.CreateDate.ToString();
                this.txtContent.Text = model.Content;
            }
            ChangeHope.WebPage.WebControl.Validate(this.txtContent, "输入反馈的内容", "isnull", "必填", "该项为必填项");
        }

        protected string GetUserIdByuId(int uid)
        {
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.Model.Member.MemberAccount model = bll.GetModel(uid);
            if (model != null)
            {
                return model.UserId;
            }
            else
            {
                return "无此用户";
            }
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            ShowShop.BLL.Order.OrderLeave bll = new ShowShop.BLL.Order.OrderLeave();
            ShowShop.Model.Order.OrderLeave model = bll.GetModelByID(ChangeHope.WebPage.PageRequest.GetQueryInt("id"));
            model.Content = this.txtContent.Text.Trim();
            model.State = 1;
            try
            {
                bll.Amend(model);
                this.ltlMsg.Text = "操作成功，已保存该信息";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
            catch
            {
                this.ltlMsg.Text = "操作失败";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
            }
            finally
            {
                model = null;
                bll = null;
                GC.Collect();
            }
        }
    }
}
