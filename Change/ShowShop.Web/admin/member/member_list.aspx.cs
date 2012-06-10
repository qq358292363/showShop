using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace ShowShop.Web.admin.member
{
    public partial class member_list : System.Web.UI.Page
    {   

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("008001001");
                InitWebControl();
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormString("id") != "")
                {
                    ShowShop.BLL.Member.MemberAccount memberBll = new ShowShop.BLL.Member.MemberAccount();
                    string types = Request["Option"].Trim();
                    string id = ChangeHope.WebPage.PageRequest.GetFormString("id");
                    if (types == "del")
                    {
                        if (ShowShop.Common.PromptInfo.Message("008001003") != "ok")
                        {
                            memberBll.DeleteAll(id);
                        }
                        else
                        {
                            Response.Write("no");
                        }
                    }
                    if (types == "locked")
                    {
                        
                        if (ShowShop.Common.PromptInfo.Message("008001006") != "ok")
                        {
                        memberBll.LockAddUnLock(id,false);
                        }
                        else
                        {
                            Response.Write("no");
                        }
                    }
                    if (types == "Unlocked")
                    {
                        
                        if (ShowShop.Common.PromptInfo.Message("008001006") != "ok")
                        {
                        memberBll.LockAddUnLock(id,true);
                        }
                        else
                        {
                            Response.Write("no");
                        }

                    }
                    Response.End();
                    return;
                }
                GetList();
            }
        }

        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.SetDropDownList(this.w_d_UserType, "code", "content", "yxs_code_usertype",true);
            ChangeHope.WebPage.WebControl.SetDropDownList(this.w_d_UserGroup, "id", "name", "yxs_memberrank",true);
        }
        private void GetList()
        {
            this.ltlview.Text = this.GetListInfo();
        }
        
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            GetList();
        }
        protected string GetListInfo()
        {
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            ChangeHope.DataBase.DataByPage datapage = bll.GetList();
            ChangeHope.WebPage.DataTable table = new ChangeHope.WebPage.DataTable();
            table.DataReader = datapage.DataReader;
            table.RowHead = "选择/5%,会员名称/12%,会员类型/8%,会员等级/8%,资金余额/10%,点券/12%,有效期/13%,积分/12%,是否冻结/10%,操作/12%";
            table.RowText = "<input type=\"checkbox\" name=\"checkboxid\" value=\"{0}\">$UID,<a href='member_view.aspx?uid={1}'>{0}</a>$UserId|uid,UserTypeContent,UserGroupContent,￥{0}$Capital,{0}点点券$Coupons,PeriodOfValidity,{0}点积分$Points,<script>GetStat('{0}');</script>$state,<a href='#'onclick=\"DelAll({0})\">删除</a>  <a href='member_edit.aspx?uid={0}'>编辑</a>$uid";
            string view = table.GetDataTable() + datapage.PageToolBar;
            datapage.Dispose();
            datapage = null;
            table = null;
            return view;
        }
    }
}
