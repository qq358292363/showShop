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
    public partial class product_comment_list : System.Web.UI.Page
    {
        ShowShop.BLL.Accessories.CommentInfo commentBll = new ShowShop.BLL.Accessories.CommentInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("012005001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormString("id") != "")
                {
                    string types = Request["Option"].Trim();
                    string id = ChangeHope.WebPage.PageRequest.GetFormString("id"); 
                    ShowShop.BLL.Accessories.CommentReply commentRBll=new ShowShop.BLL.Accessories.CommentReply();

                    if (ShowShop.Common.PromptInfo.Message("012005003") != "ok")
                    {
                    if (types == "del")
                    {
                            commentBll.Delete(Convert.ToInt32(id));
                            commentRBll.AllDelete(id);
                    }
                    if (types == "delAll")
                    {
                        commentBll.DeleteAll(id);
                        commentRBll.AllDelete(id);
                    }
                    }
                    else
                    {
                        Response.Write("no");
                    }
                    Response.End();
                    return;
                }
                this.lblList.Text = GetList();
            }
        }

        protected string GetList()
        {
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ChangeHope.DataBase.DataByPage dataPage = commentBll.GetList();
            table.AddHeadCol("", "<input id=\"chall\" type=\"checkbox\" onclick=\"SelectAll(chall)\" />全选");
            table.AddHeadCol("","评论对象");
            table.AddHeadCol("","评论标题");
            table.AddHeadCol("","评论时间");
            table.AddHeadCol("","操作");
            table.AddRow();
            
            if(dataPage.DataReader!=null)
            {
                while(dataPage.DataReader.Read())
                {
                    table.AddCol("<input id=\"cbTm\"  type=\"checkbox\" value=" + dataPage.DataReader["id"] + " />");
                    table.AddCol(GetProductNameById(Convert.ToInt32(dataPage.DataReader["commentid"]),Convert.ToInt32(dataPage.DataReader["type"])));
                    table.AddCol(dataPage.DataReader["title"].ToString());
                    table.AddCol(dataPage.DataReader["commenttime"].ToString());
                    table.AddCol("<a href=\"product_comment_revert.aspx?w_d_commentid=" + dataPage.DataReader["id"].ToString() + "\">回复</a>&nbsp;<a href=\"#\" onclick='Del(" + dataPage.DataReader["id"] + ")'>删除</a>&nbsp;<a href=\"product_comment_see.aspx?commentId=" + dataPage.DataReader["id"].ToString() + "\">查看</a>");
                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return view;
        }
        private string GetProductNameById(int id,int commentTypeId)
        {
            string reStr = string.Empty;
            if (commentTypeId == 1)
            {
                ShowShop.BLL.Product.ProductInfo productBll = new ShowShop.BLL.Product.ProductInfo();
                ShowShop.Model.Product.ProductInfo info = productBll.GetModel(id);
                if (info != null)
                {
                    reStr="<span style='color:red;'>(商品)</span>"+ChangeHope.Common.StringHelper.SubStringAndAppend(info.ProductName.ToString(), 15, "...");
                }
            }
            else if (commentTypeId == 2)
            {
               // ShowShop.BLL.Shop.Shop shopbll = new ShowShop.BLL.Shop.Shop();
              //  ShowShop.Model.Shop.Shop shopmode = shopbll.GetModelById(id);
                //if (shopmode != null)
                //{
                //    reStr = "<span style='color:red;'>(店铺)</span>" + ChangeHope.Common.StringHelper.SubStringAndAppend(shopmode.Shopname, 15, "...");;
                //}
            }
            return reStr;

        }

        protected void butSearch_Click(object sender, EventArgs e)
        {
            this.lblList.Text = GetList();
        }

    }
}
