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
using System.Collections.Generic;

namespace ShowShop.Web.admin.include
{
    public partial class memberpriceset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string shopPrice = ChangeHope.WebPage.PageRequest.GetString("shopPrice");
                string memberPrice = ChangeHope.WebPage.PageRequest.GetString("MemberPrice");
                string txtContrl = ChangeHope.WebPage.PageRequest.GetString("txtContrl");
                this.hfContrl.Value = txtContrl;
               this.GetMemberRankList(shopPrice, memberPrice);
            }
        }
        protected void GetMemberRankList(string ShopPrice, string MemberPrice)
        {
            if (ShopPrice == "")
            {
                ShopPrice = "0.00";
            }
            string[] strMemberPrice = MemberPrice.Split('|');
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Member.MemberRank data = new ShowShop.BLL.Member.MemberRank();
            List<ShowShop.Model.Member.MemberRank> list = data.GetAllMemberRank();
            //第一步先添加表头
            table.AddHeadCol("30%", "会员等级");
            table.AddHeadCol("40%", "价格");
            table.AddHeadCol("30%", "默认");
            table.AddRow();
            //添加表的内容
            if (list.Count > 0)
            {
                int col = 0;
                foreach (ShowShop.Model.Member.MemberRank va in list)
                {
                    col++;
                    table.AddCol("<input type='hidden' id='rankId" + col + "' name ='rankId" + col + "' value='" + va.Id + "'/>" + va.Name);
                    if(MemberPrice!=""&&MemberPrice!=string.Empty)
                    {
                    foreach (string mp in strMemberPrice)
                    {
                        string[] memberPr = mp.Split(',');
                        if (memberPr[0].ToString()==va.Id.ToString())
                        {
                            table.AddCol("<input type='text' name='rankName" + col + "' id='rankName" + col + "' value='" + memberPr [1]+ "'/>");
                        }
                    }
                    }
                    else
                    {
                        table.AddCol("<input type='text' name='rankName" + col + "' id='rankName" + col + "'/>");
                    }
                    table.AddCol(((Convert.ToDouble(ShopPrice) * Convert.ToDouble(va.Discount)) / 100).ToString("f2"));
                    table.AddRow();
                }
                this.hfMemberPrice.Value = col.ToString();
            }
            string view = table.GetTable();
            this.Literal1.Text = view;
        }
    }
}
