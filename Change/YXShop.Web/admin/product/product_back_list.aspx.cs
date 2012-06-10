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
    public partial class product_back_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("003003001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormString("id") != string.Empty)
                {
                    
                    string types = Request.Form["Option"].Trim();
                    string StrID = ChangeHope.WebPage.PageRequest.GetFormString("id");
                    if (types == "del")
                    {
                        if (ShowShop.Common.PromptInfo.Message("003003003") != "ok")
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
            ShowShop.BLL.Order.ConsignMent bll = new ShowShop.BLL.Order.ConsignMent();
            ChangeHope.DataBase.DataByPage dataPage = bll.GetList();
            //第一步先添加表头
            table.AddHeadCol("", "<input type=\"checkbox\" id=\"chkAll\" onclick=\"CheckAll(this.form)\" alt=\"全选/取消\" />选择");
            table.AddHeadCol("", "订单号");
            table.AddHeadCol("", "类型");
            table.AddHeadCol("", "客户名");
            table.AddHeadCol("", "快递公司");
            table.AddHeadCol("", "快递单号");
            table.AddHeadCol("", "操作人");
            table.AddHeadCol("", "经手人");
            table.AddHeadCol("", "是否签收");
            table.AddRow();
            //添加表的内容
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    table.AddCol("<input ID=\"cBox\" type=\"checkbox\" value=\"" + dataPage.DataReader["id"].ToString() + "\" />");
                    table.AddCol(dataPage.DataReader["orderid"].ToString());
                    table.AddCol(dataPage.DataReader["consignmenttype"].ToString() == "1" ? "退货" : "发货");
                    table.AddCol(dataPage.DataReader["username"].ToString());
                    table.AddCol(dataPage.DataReader["expresscompany"].ToString());
                    table.AddCol(dataPage.DataReader["expressoddnumbers"].ToString());
                    table.AddCol(dataPage.DataReader["notename"].ToString());
                    table.AddCol(dataPage.DataReader["consignmentpeople"].ToString());
                    table.AddCol(string.Format("<img src='../images/{0}.gif' alt=''/>", dataPage.DataReader["received"].ToString()));
                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return view;
        }
        private void Del(string id)
        {
            
                ShowShop.BLL.Order.ConsignMent bll = new ShowShop.BLL.Order.ConsignMent();
                bll.Delete(id);
                Response.Write("ok");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.lblList.Text = GetList();
        }
    }
}
