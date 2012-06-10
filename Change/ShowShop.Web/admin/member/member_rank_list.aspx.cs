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
    public partial class member_rank_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("008003001");
                ShowShop.BLL.Member.MemberRank bll = new ShowShop.BLL.Member.MemberRank();
                int id = ChangeHope.WebPage.PageRequest.GetQueryInt("id");
                if(id>0)
                {
                    ShowShop.Common.PromptInfo.Popedom("008003003","对不起，您没有权限进行删除");
                    bll.Delete(id);
                }
                this.lblList.Text = bll.GetView();
                bll = null;
            }
        }
    }
}
