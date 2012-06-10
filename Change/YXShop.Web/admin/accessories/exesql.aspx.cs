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
    public partial class exesql : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowShop.Common.PromptInfo.Popedom("012011007");
        }

        protected void butExeSql_Click(object sender, EventArgs e)
        {
            string sqlText = this.txtExeSql.Text;
                object obj = ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sqlText);
            if (obj == null)
            {
                this.ltlMsg.Text = "操作失败，运行指定的SQL语句执行失败!";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
            else
            {
                this.ltlMsg.Text = "操作成功，运行指定的SQL语句.";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
                this.txtExeSql.Text = string.Empty;
            }
        }

    }
}
