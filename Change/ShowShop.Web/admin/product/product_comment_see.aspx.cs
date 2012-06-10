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
    public partial class product_comment_see : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string id = ChangeHope.WebPage.PageRequest.GetQueryString("commentId");
                if(id!=null&&id!="")
                {
                    GetModelById(Convert.ToInt32(id));
                }
            }
        }

        private void GetModelById(int id)
        {
            ShowShop.BLL.Accessories.CommentInfo commentBll = new ShowShop.BLL.Accessories.CommentInfo();
            ShowShop.Model.Accessories.CommentInfo model = commentBll.GetModelID(id);
            if(model!=null)
            {
                this.litName.Text = model.Title.ToString();
                this.litLable.Text = model.Tag.ToString();
                this.litTime.Text = model.CommentTime.ToString();
                this.litAgainst.Text = model.Againstnum.ToString();
                this.litContent.Text = model.ContentList.ToString();
                this.litSupNum.Text = model.SupportNum.ToString();
                this.litFlower.Text = model.FlowerNum.ToString();
            }
        }
    }
}
