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
using System.Text;

namespace ShowShop.Web.admin.include
{
    public partial class sparepartproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int spId = ChangeHope.WebPage.PageRequest.GetInt("sparepartId");
                if (spId >-1)
                {
                    this.hfSparepartID.Value = spId.ToString();
                }
                if (Request.Form["Option"] != null && !Request.Form["Option"].Trim().Equals("")
                      && Request.Form["ID"] != null && !Request.Form["ID"].Trim().Equals(""))
                {
                    string types = Request.Form["Option"].Trim();
                    if (types == "SpareartProduct")
                    {
                        string strProductId = ChangeHope.WebPage.PageRequest.GetFormString("ID");
                        int sparepartId = ChangeHope.WebPage.PageRequest.GetFormInt("SparepartId");
                        this.GetSparepartProductInfo(strProductId, sparepartId);
                    }
                    Response.End();
                    return;
                }
                this.GetList();
            }
        }

        private void GetSparepartProductInfo(string strProductId,int sparepartId)
        {
            StringBuilder shtml = new StringBuilder();
            ShowShop.BLL.Product.ProductInfo bll = new ShowShop.BLL.Product.ProductInfo();
            DataTable dt = bll.DTGetListWhere(" and pro_ID in (" + strProductId + ")");
            shtml.Append("<table widht='100%'>");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    shtml.Append("<tr style='height:22px'>");
                    shtml.Append("<td><a href=\"javascript:delSparepartProductId(" + dt.Rows[i]["pro_ID"].ToString() + "," + sparepartId + ")\">删除</a></td>");
                    shtml.Append("<td width=\"40%\"><span title='" + dt.Rows[i]["pro_Name"].ToString() + "'>" + ChangeHope.Common.StringHelper.SubString(dt.Rows[i]["pro_Name"].ToString(), 20) + "</span></td>");
                    shtml.Append("<td width=\"50%\"><span title=\"" + dt.Rows[i]["pro_Synopsis"].ToString() + "\">" + ChangeHope.Common.StringHelper.SubString(dt.Rows[i]["pro_Synopsis"].ToString(), 30) + "</span></td>");
                    shtml.Append("</tr>");
                }
            }
            shtml.Append("</table>");
            Response.Write(shtml.ToString());
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        protected void GetList()
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Product.ProductInfo data = new ShowShop.BLL.Product.ProductInfo();
            ChangeHope.DataBase.DataByPage dataPage = data.GetList();
            //第一步先添加表头
            table.AddHeadCol("10%","序号");
            table.AddHeadCol("20%","货号");
            table.AddHeadCol("65%", "商品名称");
            table.AddHeadCol("10%", "库存");
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
                    table.AddCol(No + "<input ID=\"cBox\" type=\"checkbox\" value=\"" + dataPage.DataReader["pro_ID"].ToString() + "\" />");
                    table.AddCol(dataPage.DataReader["pro_NO"].ToString());
                    table.AddCol("" + dataPage.DataReader["pro_Name"].ToString() + "");
                    table.AddCol(string.Format("{0}{1}", dataPage.DataReader["pro_Stock"].ToString(), dataPage.DataReader["pro_Unit"].ToString()));
                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            this.Literal1.Text = view;
        }

        protected void lbSearch_Click1(object sender, EventArgs e)
        {
            GetList();
        }
    }
}
