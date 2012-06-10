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
    public partial class collection_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("012009001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormString("id") != string.Empty)
                {
                    
                    string types = Request.Form["Option"].Trim();
                    string StrID = ChangeHope.WebPage.PageRequest.GetFormString("id");
                    if (types == "del")
                    {
                        if(ShowShop.Common.PromptInfo.Message("012009003")!="ok")
                        {
                        Del(StrID);
                        }
                        else
                        {
                         Response.Write("no");
                        }
                    }

                    Response.End();
                    return;
                }
                this.lblList.Text = GetList();
            }
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        protected string GetList()
        {

            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Accessories.Collection bll = new ShowShop.BLL.Accessories.Collection();
            ChangeHope.DataBase.DataByPage dataPage = bll.GetList();
            //第一步先添加表头
            table.AddHeadCol("", "<input type=\"checkbox\" id=\"chkAll\" onclick=\"CheckAll(this.form)\" alt=\"全选/取消\" />选择");
            table.AddHeadCol("", "商品名称");
            table.AddHeadCol("", "收藏用户");
            table.AddHeadCol("", "收藏时间");
            table.AddHeadCol("", "操作");
            table.AddRow();
            //添加表的内容
            if (dataPage.DataReader != null)
            {
                int curpage = ChangeHope.WebPage.PageRequest.GetInt("pageindex");
                if (curpage < 0)
                {
                    curpage = 1;
                }
                int count = 0;
                while (dataPage.DataReader.Read())
                {
                    count++;
                    string No = (15 * (curpage - 1) + count).ToString();
                    table.AddCol("<input ID=\"cBox\" type=\"checkbox\" value=\"" + dataPage.DataReader["id"].ToString() + "\" />");
                    table.AddCol(GetProductName(dataPage.DataReader["collectionid"].ToString()));
                    table.AddCol(dataPage.DataReader["collectionname"].ToString());
                    table.AddCol(dataPage.DataReader["collectiondate"].ToString());
                    table.AddCol(string.Format("<a href='javascript:void(0)' onclick='Del({0})'>删除</a>", dataPage.DataReader["id"].ToString()));
                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return view;
        }

        /// <summary>
        /// 根据商品ID得到商品名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetProductName(string id)
        {
            try
            {
                ShowShop.BLL.Product.ProductInfo bll = new ShowShop.BLL.Product.ProductInfo();
                ShowShop.Model.Product.ProductInfo model = bll.GetModel(Convert.ToInt32(id));
                return "<a href=\"../../ProductContent.aspx?ID=" + id + "\" title=\"查看该商品\" target=\"_blank\">" + model.ProductName + "</a>";
            }
            catch
            {
                return "查询相关商品出错";
            }
        }

        private void Del(string id)
        {
                ShowShop.BLL.Accessories.Collection bll = new ShowShop.BLL.Accessories.Collection();
                bll.Delete(id);
                Response.Write("ok");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.lblList.Text = GetList();
        }
    }
}
