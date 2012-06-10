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

namespace ShowShop.Web.admin.ordercard
{
    public partial class ordercard_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("008004001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormInt("id") > 0)
                {
                   
                    string types = Request.Form["Option"].Trim();
                    int id = ChangeHope.WebPage.PageRequest.GetFormInt("id");
                    if (types == "del")
                    {
                        if (ShowShop.Common.PromptInfo.Message("008004003") != "ok")
                        {
                            del(id);
                        }
                        else
                        {
                            Response.Write("no");
                        }
                    }
                    Response.End();
                    return;
                }
                this.Literal1.Text = GetList();
            }
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        protected string GetList()
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.OrderCard.OrderCardInfo data = new ShowShop.BLL.OrderCard.OrderCardInfo();
            ChangeHope.DataBase.DataByPage dataPage = data.GetList();
            //第一步先添加表头
            table.AddHeadCol("4%", "序号");
            table.AddHeadCol("11%", "类型");
            table.AddHeadCol("15%", "卡号");
            table.AddHeadCol("5%", "面值");
            table.AddHeadCol("5%", "点数");
            table.AddHeadCol("14%", "所属商品");
            table.AddHeadCol("8%", "状态");
            table.AddHeadCol("10%", "截止日期");
            table.AddHeadCol("9%", "使用会员");
            table.AddHeadCol("10%", "获取时间");
            table.AddHeadCol("15%", "操作");
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
                    table.AddCol(No);
                    table.AddCol(dataPage.DataReader["type"].ToString() == "1" ? "本商城充值卡" : "其它公司充值卡");
                    table.AddCol(dataPage.DataReader["cardnumber"].ToString());
                    table.AddCol(dataPage.DataReader["facevalue"].ToString());
                    table.AddCol(dataPage.DataReader["point"].ToString() + dataPage.DataReader["unit"].ToString());
                    table.AddCol(dataPage.DataReader["iswebsitersale"].ToString() == "1" ? ProductName(dataPage.DataReader["productid"].ToString()) : "不通过商城出售");
                    table.AddCol(Convert.ToDateTime(dataPage.DataReader["expirationdate"].ToString()) < System.DateTime.Now ? "已失效" : this.State(dataPage.DataReader["whetherRelease"].ToString(), dataPage.DataReader["productid"].ToString()));
                    table.AddCol(Convert.ToDateTime(dataPage.DataReader["expirationdate"].ToString()).ToString("yyyy-MM-dd"));
                    table.AddCol(dataPage.DataReader["username"].ToString());
                    table.AddCol(Convert.ToDateTime(dataPage.DataReader["fullmoneydate"].ToString()) != Convert.ToDateTime("1753-01-01") ? Convert.ToDateTime(dataPage.DataReader["fullmoneydate"].ToString()).ToString("yyyy-MM-dd") : "");

                    table.AddCol(string.Format("<a href=ordercard_edit.aspx?id={0}>编辑</a> <a href='#' onclick='Del({0})'>删除</a>", dataPage.DataReader["id"].ToString()));

                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return view;
        }
        #region 状态
        protected string State(string id, string productid)
        {
            string strs = "";
            if (productid != "0")
            {
                switch (id)
                {
                    case "0":
                        strs = "<span style='color:#00FF00'>未使用</span>";
                        break;
                    case "1":
                        strs = "<span style='color:#666666'>已使用</span>";
                        break;

                }
            }
            else
            {
                switch (id)
                {
                    case "0":
                        strs = "<span style='color:red'>未售出</span>";
                        break;
                    case "2":
                        strs = "<span style='color:#666666'>已售出</span>";
                        break;
                    case "1":
                        strs = "<span style='color:#FF0000'>已使用</span>";
                        break;
                }
            }
            return strs.ToString();
        }
        #endregion
        protected string ProductName(string ProductId)
        {
            string reStr = string.Empty;
            string str = "未找到商品";
            if (!string.IsNullOrEmpty(ProductId))
            {
                ShowShop.BLL.Product.ProductInfo dll = new ShowShop.BLL.Product.ProductInfo();
                ShowShop.Model.Product.ProductInfo model = dll.GetModel(Convert.ToInt32(ProductId));
                if (model != null)
                {
                    str = model.ProductName;
                }
            }
            return str;
        }

        private void del(int id)
        {
            
                ShowShop.BLL.OrderCard.OrderCardInfo bll = new ShowShop.BLL.OrderCard.OrderCardInfo();
                ShowShop.Model.OrderCard.OrderCardInfo model = bll.GetModelID(id);
                if (model != null)
                {
                    bll.Delete(id);
                }
                Response.Write("ok");
           
        }

        protected void lbSearch_Click(object sender, EventArgs e)
        {
            this.Literal1.Text = GetList();
        }


    }
}
