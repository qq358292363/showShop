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

namespace ShowShop.Web.admin.product
{
    public partial class product_comment_revert : System.Web.UI.Page
    {
        ShowShop.BLL.Accessories.CommentInfo commentBll = new ShowShop.BLL.Accessories.CommentInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormString("id") != "")
            {
                string types = Request["Option"].Trim();
                string id = ChangeHope.WebPage.PageRequest.GetFormString("id");
                ShowShop.BLL.Accessories.CommentReply commentRBll = new ShowShop.BLL.Accessories.CommentReply();
                if (types == "del")
                {
                    commentRBll.Delete(Convert.ToInt32(id));
                }
                Response.End();
                return;
            }
            if(!IsPostBack)
            {
                InitWebControl();
                string id = ChangeHope.WebPage.PageRequest.GetQueryString("w_d_commentid");
                if(id!=null&&id!="")
                {
                    ShowShop.Model.Accessories.CommentInfo model = commentBll.GetModelID(Convert.ToInt32(id));
                    if(model!=null)
                    {
                        this.litName.Text = model.Title.ToString();
                    }
                }
                GetList();
            }
        }

        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtReply,"请输入回复内容","isnull","必填","该项为必填项");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }

        protected void butSave_Click(object sender, EventArgs e)
        {
            ShowShop.BLL.Accessories.CommentReply replyBll = new ShowShop.BLL.Accessories.CommentReply();
            ShowShop.Model.Accessories.CommentReply reply = new ShowShop.Model.Accessories.CommentReply();
            ShowShop.Model.Admin.AdminInfo adminModel = (ShowShop.Model.Admin.AdminInfo)ShowShop.Common.AdministrorManager.Get();
            reply.CommentID = ChangeHope.WebPage.PageRequest.GetQueryInt("w_d_commentid");
            reply.UID = adminModel.AdminId;
            reply.Content = this.txtReply.Text.Trim().ToString();
            reply.ReplyTime = Convert.ToDateTime(System.DateTime.Now);
            int count = replyBll.Add(reply);
            if (count > 0)
            {
                this.ltlMsg.Text = "操作成功，已回复该信息";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
            else
            {
                this.ltlMsg.Text = "操作失败";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
            }
        }

        protected void GetList()
        {
            ShowShop.BLL.Accessories.CommentReply rebll = new ShowShop.BLL.Accessories.CommentReply();
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ChangeHope.DataBase.DataByPage dataPage = rebll.GetList();
            table.AddHeadCol("", "回复内容");
            table.AddHeadCol("", "回复时间");
            table.AddHeadCol("", "操作");
            table.AddRow();

            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    table.AddCol(dataPage.DataReader["content"].ToString());
                    table.AddCol(dataPage.DataReader["replytime"].ToString());
                    table.AddCol("<a href=\"#\" onclick='Del(" + dataPage.DataReader["rid"] + ")'>删除</a>");
                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            this.lblList.Text = view;
        }
    }
}
