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

namespace ShowShop.Web.admin.order
{
    public partial class order_leave_reply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   

            int id = ChangeHope.WebPage.PageRequest.GetQueryInt("id");
            if (!IsPostBack)
            {
                BindInfo(id);
            }
        }

        protected void BindInfo(int id)
        {
            ShowShop.BLL.Order.OrderLeave bll = new ShowShop.BLL.Order.OrderLeave();
            ShowShop.Model.Order.OrderLeave model =bll.GetModelByID(id);
            ViewState["OrderId"] = model.OrderId;
            List<ShowShop.Model.Order.OrderLeave> list = bll.GetAll("orderid='" + model.OrderId + "'");
            if (list.Count == 1)
            {
                this.lblMemberId.Text = this.GetUserIdByuId(Convert.ToInt32(list[0].MemberId));
                this.lblCreateDate.Text = list[0].CreateDate.ToString();
                this.txtContent.Text = list[0].Content;
            }
            else if (list.Count == 2)
            {
                if (list[0].State == 1)//如果第一条是用户发布的
                {
                    this.lblMemberId.Text = this.GetUserIdByuId(Convert.ToInt32(list[0].MemberId));
                    this.lblCreateDate.Text = list[0].CreateDate.ToString();
                    this.txtContent.Text = list[0].Content;
                    this.txtReplyContent.Text = list[1].Content;
                    ViewState["ID"] = list[1].ID.ToString();
                }
                else if (list[1].State == 1)
                {
                    this.lblMemberId.Text = this.GetUserIdByuId(Convert.ToInt32(list[1].MemberId));
                    this.lblCreateDate.Text = list[1].CreateDate.ToString();
                    this.txtContent.Text = list[1].Content;
                    this.txtReplyContent.Text = list[0].Content;
                    ViewState["ID"] = list[0].ID.ToString();
                }
            }
            ChangeHope.WebPage.WebControl.Validate(this.txtReplyContent, "输入回复的内容", "isnull", "必填", "该项为必填项");
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
            ShowShop.Model.Order.OrderLeave model = new ShowShop.Model.Order.OrderLeave();
            model.OrderId = ViewState["OrderId"].ToString();
            model.CreateDate = DateTime.Now;
            model.Content = this.txtReplyContent.Text.Trim();
            model.State = 0;
            model.MemberId = -1;
            try
            {
                if (ViewState["ID"] != null) //表示修改管理员回复的信息
                {
                    model.ID = Convert.ToInt32(ViewState["ID"].ToString());
                    bll.Amend(model);
                    this.ltlMsg.Text = "操作成功，已修改该信息";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionOk";
                }
                else
                {
                    bll.Add(model);
                    this.ltlMsg.Text = "操作成功，已回复该信息";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionOk";
                }
            }
            catch
            {
                this.ltlMsg.Text = "操作失败";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
            }
            finally
            {
                bll = null;
                model = null;
            }
        }
    }
}
