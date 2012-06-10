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
    public partial class userinandexp_view_single : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("003001001");
                ExpBind();
            }
        }

        protected void ExpBind()
        {
            int id = ChangeHope.WebPage.PageRequest.GetQueryInt("id");
            ShowShop.BLL.Member.UserinAndExp bll = new ShowShop.BLL.Member.UserinAndExp();
            ShowShop.Model.Member.UserinAndExp model = bll.GetModelByID(id);
            this.lblAdsumMoneyDate.Text = model.AdsumMoneyDate.ToString();
            this.lblUserID.Text = model.UserId;
            this.lblUserName.Text = GetUserName(Convert.ToInt32(model.UID));
            this.lblRemitMode.Text = GetRemitMode(model.RemitMode.ToString());
            if (model.InComeandExpState.ToString() == "0")
            {
                this.lblAdsumMoneyIn.Text = model.AdsumMoney.ToString();
                this.lblAdsumMoneyOut.Text = "0";
            }
            else
            {
                this.lblAdsumMoneyIn.Text = "0";
                this.lblAdsumMoneyOut.Text = model.AdsumMoney.ToString();
            }
            this.lblRemitBank.Text = model.RemitBank;
            this.lblState.Text = model.State == 0 ? "确认" : "未确认";
            this.lblNoteName.Text = model.NoteName;
            this.lblNoteDate.Text = model.NoteDate.ToString();
            this.lblRemitBank.Text = model.Remark;
            this.lblBosomNote.Text = model.BosomNote;
        }

        protected string GetUserName(int uid)
        {
            ShowShop.BLL.Member.MemberInfo bll = new ShowShop.BLL.Member.MemberInfo();
            ShowShop.Model.Member.MemberInfo model =bll.GetModel(uid);
            if (model != null &&　model.TrueName!=null)
            {
                return model.TrueName;
            }
            else
            {
                return "未填写真实姓名";
            }
        }

        /// <summary>
        /// 判断支付类型
        /// </summary>
        /// <param name="remitmode"></param>
        /// <returns></returns>
        protected string GetRemitMode(string remitmode)
        {
            string mode = string.Empty;
            switch (remitmode)
            {
                case "1":
                    mode = "银行汇款";
                    break;
                case "2":
                    mode = "虚拟货币";
                    break;
                case "3":
                    mode = "现金支付";
                    break;
            }
            return mode;
        }
    }
}
