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
    public partial class order_transfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("005001014","对不起，您没有权限进行过户");
                int id = ChangeHope.WebPage.PageRequest.GetQueryInt("OrderId");
                InitWebControl();
                this.OrderInfoBind(this.GetOrderId(id));
            }
        }

        #region 验证
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtTransferName, "输入将要过户给的用户账号", "isnull", "必填", "该项不能为空");
            ChangeHope.WebPage.WebControl.Validate(this.txtPoundAge, "输入手续费金额", "isint", "必填", "该项只能为数字");
            ChangeHope.WebPage.WebControl.Validate(this.txtRemark, "输入备注信息", "isnull", "必填", "该项不能为空");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }
        #endregion

        /// <summary>
        /// 订单信息初始化
        /// </summary>
        protected void OrderInfoBind(string orderId)
        {
            ShowShop.BLL.Order.Orders bll = new ShowShop.BLL.Order.Orders();
            ShowShop.Model.Order.Orders model = bll.GetModel(orderId);
            if (model != null)
            {
                this.lblUserId.Text = model.UserId;
                this.lblUserName.Text = model.ConsigneeName;
                this.lblOrderId.Text = model.OrderId;
            }
        }

        /// <summary>
        /// 根据ID得到订单号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetOrderId(int id)
        {
            ShowShop.BLL.Order.Orders bll = new ShowShop.BLL.Order.Orders();
            ShowShop.Model.Order.Orders model = bll.GetModel(id);
            if (model != null)
            {
                return model.OrderId;
            }
            else
            {
                return string.Empty;
            }
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            ShowShop.BLL.Member.MemberAccount memberBll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.BLL.Order.Orders orderBll = new ShowShop.BLL.Order.Orders();
            ShowShop.Model.Order.Orders orderModel = orderBll.GetModel(this.lblOrderId.Text);
            decimal memberCapital = 0;
            ShowShop.Model.Admin.AdminInfo adminInfo = (ShowShop.Model.Admin.AdminInfo)ShowShop.Common.AdministrorManager.Get();
            if (!memberBll.Exists(this.txtTransferName.Text.Trim()))
            {
                this.ltlMsg.Text = "过户失败，不存在用户：" + this.txtTransferName.Text.Trim();
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
                return;
            }

            ShowShop.BLL.Order.OrderTransfer bll = new ShowShop.BLL.Order.OrderTransfer();
            ShowShop.Model.Order.OrderTransfer model = new ShowShop.Model.Order.OrderTransfer();
            model.OrderId = this.lblOrderId.Text;
            model.UserName = this.lblUserName.Text;
            model.TransferName = this.txtTransferName.Text;
            model.PoundAge = Convert.ToDecimal(this.txtPoundAge.Text);
            model.Remark = this.txtRemark.Text;
            model.NoteDate = DateTime.Now;
            model.NoteName = adminInfo.AdminName;
            model.UpTime = DateTime.Now;

            #region 计算用户余额 是否能支付过户费
            if (this.rabPoundPay.SelectedValue == "0") //订单当前所有者 支付手续费
            {
                ShowShop.Model.Member.MemberAccount memberModel = memberBll.GetModel(this.lblUserId.Text.Trim());
                if (memberModel.Capital > Convert.ToDecimal(this.txtPoundAge.Text))
                {
                    memberCapital = Convert.ToDecimal(memberModel.Capital - Convert.ToDecimal(this.txtPoundAge.Text));
                }
                else
                {
                    this.ltlMsg.Text = "过户失败，" + this.lblUserId.Text.Trim() + " 资金余额不足";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
                //更改用户资金状况
                memberBll.Amend(memberModel.UID, "Capital", memberCapital);
                model.PoundAgePayMentPerson = this.lblUserId.Text;
            }
            else  //过户对象
            {
                ShowShop.Model.Member.MemberAccount memberModel = memberBll.GetModel(this.txtTransferName.Text.Trim());
                if (memberModel.Capital > Convert.ToDecimal(this.txtPoundAge.Text))
                {
                    memberCapital = Convert.ToDecimal(memberModel.Capital - Convert.ToDecimal(this.txtPoundAge.Text));
                }
                else
                {
                    this.ltlMsg.Text = "过户失败，" + this.txtTransferName.Text.Trim() + " 资金余额不足";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionErr";
                    return;
                }
                //更改用户资金状况
                memberBll.Amend(memberModel.UID, "Capital", memberCapital);
                model.PoundAgePayMentPerson = this.txtTransferName.Text;
            }
          
            #endregion

            try
            {
                //把原订单所属用户改为现在的用户
                orderModel.UserId = this.txtTransferName.Text.Trim();
                orderBll.Update(orderModel);
                bll.Add(model);
                this.ltlMsg.Text = "操作成功，已保存该信息";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
            catch
            {
                this.ltlMsg.Text = "操作失败！";
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
