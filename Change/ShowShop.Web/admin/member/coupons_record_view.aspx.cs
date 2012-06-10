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

namespace ShowShop.Web.admin.member
{
    public partial class coupons_record_view : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CouBind();
            }
        }

        protected void CouBind()
        {
            int id = ChangeHope.WebPage.PageRequest.GetQueryInt("id");
            ShowShop.BLL.Member.UserInfoNote bll = new ShowShop.BLL.Member.UserInfoNote();
            ShowShop.Model.Member.UserInfoNote model = bll.GetModelById(id);

            this.lblUserId.Text = GetUserID(Convert.ToInt32(model.UserID));
            this.lblNoteName.Text = model.NoteName;
            if (model.BuckleOrAdd.ToString() == "0")
            {
                this.lblticketCountIn.Text = model.TicketCount.ToString();
                this.lblticketCountOut.Text = "0";
            }
            else
            {
                this.lblticketCountIn.Text = "0";
                this.lblticketCountOut.Text = model.TicketCount.ToString();
            }
            GetType(model.NoteType.ToString());
            this.lblCausation.Text = model.Causation;
            this.lblBosomNote.Text = model.BosomNote;
        }

        protected void GetType(string type)
        {
            string mode = string.Empty;
            switch (type)
            {
                case "0":
                    mode = "点卷";
                    break;
                case "1":
                    mode = "资金";
                    break;
                case "2":
                    mode = "有效期";
                    break;
            }
            this.lblType1.Text = mode;
            this.lblType2.Text = mode;
            this.lblType3.Text = mode;
        }

        protected string GetUserID(int uid)
        {
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.Model.Member.MemberAccount model = bll.GetModel(uid);
            if (model != null)
            {
                return model.UserId;
            }
            else
            {
                return "无该用户";
            }
        }
    }
}
