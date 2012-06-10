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
    public partial class product_trans_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("003005001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormString("id") != string.Empty)
                {
                    if (ShowShop.Common.PromptInfo.Message("003005003") != "ok")
                    {
                        string types = Request.Form["Option"].Trim();
                        string StrID = ChangeHope.WebPage.PageRequest.GetFormString("id");
                        if (types == "del")
                        {
                            Del(StrID);
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

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        protected string GetList()
        {

            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Order.OrderTransfer bll = new ShowShop.BLL.Order.OrderTransfer();
            ChangeHope.DataBase.DataByPage dataPage = bll.GetList();
            //第一步先添加表头
            table.AddHeadCol("", "<input type=\"checkbox\" id=\"chkAll\" onclick=\"CheckAll(this.form)\" alt=\"全选/取消\" />选择");
            table.AddHeadCol("", "订单号");
            table.AddHeadCol("", "前所有者");
            table.AddHeadCol("", "过户给");
            table.AddHeadCol("", "过户费");
            table.AddHeadCol("", "手续费付款人");
            table.AddHeadCol("", "操作人");
            table.AddHeadCol("", "操作时间");
            table.AddRow();
            //添加表的内容
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    table.AddCol("<input ID=\"cBox\" type=\"checkbox\" value=\"" + dataPage.DataReader["id"].ToString() + "\" />");
                    table.AddCol(dataPage.DataReader["orderid"].ToString());
                    table.AddCol(dataPage.DataReader["username"].ToString() == "1" ? "退货" : "发货");
                    table.AddCol(dataPage.DataReader["transfername"].ToString());
                    table.AddCol(dataPage.DataReader["poundage"].ToString());
                    table.AddCol(dataPage.DataReader["poundagepaymentperson"].ToString());
                    table.AddCol(dataPage.DataReader["notename"].ToString());
                    table.AddCol(dataPage.DataReader["uptime"].ToString());
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
            ShowShop.BLL.Order.OrderTransfer bll = new ShowShop.BLL.Order.OrderTransfer();
            bll.Delete(id);
            Response.Write("ok");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.lblList.Text = GetList();
        }
    }
}
