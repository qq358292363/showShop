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
    public partial class role_setmember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("007002006","对不起，您没有权限进行设置");
                int roleid = ChangeHope.WebPage.PageRequest.GetQueryInt("id");
                if (roleid > 0)
                {
                    ViewState["RoleId"] = roleid;
                    ShowShop.BLL.Member.Role bll = new ShowShop.BLL.Member.Role();
                    ShowShop.Model.Member.Role model = bll.GetModelID(roleid);
                    if (model != null)
                    {
                        this.lbRoleName.Text = model.Name;
                        this.lbRoleDescription.Text = model.Description;
                        this.BindInfo(roleid.ToString());
                    }
                }
            }
        }

        protected void BindInfo(string RoleId)
        {
            ShowShop.BLL.Admin.Administrators bll = new ShowShop.BLL.Admin.Administrators();

            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ChangeHope.DataBase.DataByPage dataPage = bll.GetListDB();
            //添加表的内容
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    bool WhetherIN = false;
                    String[] gly = dataPage.DataReader["role"].ToString().Split(',');
                    for (int i = 0; i < gly.Length; i++)
                    {
                        if (gly[i].ToString() == RoleId)
                        {
                            lbOption2.Items.Add(new ListItem(dataPage.DataReader["name"].ToString(), dataPage.DataReader["adminid"].ToString()));
                            WhetherIN = true;
                            break;
                        }
                    }
                    if (!WhetherIN)
                    {
                        lbOption.Items.Add(new ListItem(dataPage.DataReader["name"].ToString(), dataPage.DataReader["adminid"].ToString()));
                    }
                }
            }
        }

        protected void butAddRoleMember_Click(object sender, EventArgs e)
        {
            string ReAddId = this.lbOption.SelectedValue;
            if (ReAddId != string.Empty)
            {
                ShowShop.BLL.Admin.Administrators bll = new ShowShop.BLL.Admin.Administrators();
                ShowShop.Model.Admin.Administrators model = bll.GetModel(int.Parse(ReAddId));
                if (model != null)
                {
                    string RoleStr = model.Role;
                    if (RoleStr != string.Empty && RoleStr != "")
                    {
                        bll.Amend(Convert.ToInt32(model.AdminId), "role", RoleStr + "," + ViewState["RoleId"].ToString());
                    }
                    else
                    {
                        bll.Amend(Convert.ToInt32(model.AdminId), "role", ViewState["RoleId"].ToString());
                    }
                }
                Response.Redirect("role_setmember.aspx?id=" + ViewState["RoleId"].ToString() + "");
            }
        }

        protected void butRemoerMember_Click(object sender, EventArgs e)
        {
            string ReMoveId = this.lbOption2.SelectedValue;
            if (ReMoveId != string.Empty)
            {
                ShowShop.BLL.Admin.Administrators bll = new ShowShop.BLL.Admin.Administrators();
                ShowShop.Model.Admin.Administrators model = bll.GetModel(int.Parse(ReMoveId));
                string AmentStr = string.Empty;
                if (model != null)
                {
                    string[] RoleStr = model.Role.Split(',');
                    for (int i = 0; i < RoleStr.Length; i++)
                    {
                        if (RoleStr[i] != ViewState["RoleId"].ToString())
                        {
                            if (AmentStr == string.Empty)
                            {
                                AmentStr = RoleStr[i];
                            }
                            else
                            {
                                AmentStr = "," + RoleStr[i];
                            }
                        }
                    }
                    bll.Amend(Convert.ToInt32(model.AdminId), "role", AmentStr);
                }
                Response.Redirect("role_setmember.aspx?id=" + ViewState["RoleId"].ToString() + "");
            }
        }

    }
}
