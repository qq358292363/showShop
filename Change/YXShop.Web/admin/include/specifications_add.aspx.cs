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
using System.Text.RegularExpressions;

namespace ShowShop.Web.admin.include
{
    public partial class specifications_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string vTypes = ChangeHope.WebPage.PageRequest.GetString("type");
                if (vTypes == "1")
                {
                    this.panOne.Visible = true;
                    this.panTow.Visible = false;
                }
                else
                {
                    this.panOne.Visible = false;
                    this.panTow.Visible = true;
                }
                if (Request.Form["Option"] != null && !Request.Form["Option"].Trim().Equals("")
                                      && Request.Form["Name"] != null && !Request.Form["Name"].Trim().Equals(""))
                {
                    string types = Request.Form["Option"].Trim();
                    if (types == "SpecificationsProduct")
                    {
                        string name = ChangeHope.WebPage.PageRequest.GetFormString("Name");
                        string value = Request.Form["Value"];
                        this.SpecificationsProduct(name, value);
                    }
                    Response.End();
                    return;
                }
            }
        }

        #region The first load specifications
        private void SpecificationsProduct(string Name, string Value)
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            Regex vaRegex = new Regex(@"\r\n");
            string[] sv =vaRegex.Split(Value);
            StringBuilder shtml = new StringBuilder();
            shtml.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
            shtml.Append("<tr height=\"24px\" bgcolor=\"#FFFFFF\">");
            shtml.Append("<td>&nbsp;&nbsp;<span style=\"font-weight:bold;font-size:14px;\">规格</span>");
            shtml.Append("<input type=\"hidden\" name=\"SpeGroupCount\" id=\"SpeGroupCount\" value=\"1\" />");
            shtml.Append("<input type=\"hidden\" name=\"SpecificationRows\" id=\"SpecificationRows\" value=\"" + sv.Length+ "\" />");
            shtml.Append("</td>");
            shtml.Append("</tr>");
            shtml.Append("<tr bgcolor=\"#EBEDE8\" height=\"22px\">");
            shtml.Append("<td>&nbsp;&nbsp;<a href=\"javascript:showPath('AddSpecifications',document.getElementById('SpecificationsAddress'),'开启规格',650,250,'" + sp.DummyPaht + "');\">添加规格</a>  <a href='javascript:CloseSpecifications();'>关闭规格</a></td>");
            shtml.Append("</tr>");
            shtml.Append("<tr>");
            shtml.Append("<td bgcolor=\"#BAC9C6\" height='2px'>");
            shtml.Append("</td>");
            shtml.Append("</tr>");
            shtml.Append("<tr>");
            shtml.Append("<td>");
            shtml.Append("<span id=\"SpecificationsContent\">");
            shtml.Append("<table id=\"SpecificationTable\" width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
            shtml.Append("<tr bgcolor=\"#F5F5F5\" height=\"22px\">");
            shtml.Append("<td style=\"font-weight:bold; text-align:center; width:156px\">货号</td>");
            shtml.Append("<span id=\"SpeTitle\">");
            shtml.Append("<td style=\"font-weight:bold; text-align:center;\" >");
            shtml.Append("<input type=\"hidden\" name=\"SpecificationsName1\" id=\"SpecificationsName1\" value=\"" + Name + "\" />");
            shtml.Append("<input type=\"hidden\" name=\"SpecificationsValue1\" id=\"SpecificationsValue1\" value=\"" + Value + "\" />");
            shtml.Append("" + Name + "");
            shtml.Append("</td>");
            shtml.Append("</span>");
            shtml.Append("<td style=\"font-weight:bold;\">库存</td>");
            shtml.Append("<td style=\"font-weight:bold;\">积分</td>");
            shtml.Append("<td style=\"font-weight:bold;\">价格</td>");
            shtml.Append("<td>操作</td>");
            shtml.Append("</tr>");
            for (int i = 0; i < sv.Length; i++)
            {
                shtml.Append("<tr id=\"trSpeRows" + i + "\">");
                shtml.Append("<td>");
                shtml.Append("<input type=\"hidden\" name=\"SpeValRows" + i + "\" id=\"SpeValRows" + i + "\" value=\"" + i + "\"/>");
                shtml.Append("<span id=\"spanSpeValue" + i + "\"><input type=\"hidden\" name=\"SpeValue" + i + "\" id=\"SpeValue" + i + "\" value=\"" + sv[i].Replace("\r", "") + "\"/></span>");
                shtml.Append("<input type=\"text\" name=\"SpeItemNo" + i + "\" id=\"SpeItemNo" + i + "\" />");
                shtml.Append("</td>");
                shtml.Append("<span id=\"SpeValueGroup" + i + "\">");
                shtml.Append("<td style=\"text-align:center;\">" + sv[i].Replace("\r", "") + "</td>");
                shtml.Append("</span>");
                shtml.Append("<td><input type=\"text\" class=\"short_input\" name=\"SpeStock" + i + "\" id=\"SpeStock" + i + "\" /></td>");
                shtml.Append("<td><input type=\"text\" class=\"short_input\" name=\"SpeIntegral" + i + "\" id=\"SpeIntegral" + i + "\" /></td>");
                shtml.Append("<td>");
                shtml.Append("<input type=\"text\" class=\"short_input\" name=\"SpeShopPrice" + i + "\" id=\"SpeShopPrice" + i + "\" />");
                shtml.Append("<input type=\"hidden\" class=\"short_input\" name=\"SpeMemberPrice" + i + "\" id=\"SpeMemberPrice" + i + "\" />");
                shtml.Append("</td>");
                shtml.Append("<td><a href=\"javascript:showPath('SetMemberPrice',document.getElementById('SpecificationsAddress'),'设置会员价',650,250,'" + sp.DummyPaht + "','SpeShopPrice" + i + ";SpeMemberPrice" + i + "');\">会员价</a> <a href='javascript:DelSpecificationRow(" + i + ")'>删除</a></td>");
                shtml.Append("</tr>");
            }
            shtml.Append("</table>");
            shtml.Append("</span>");
            shtml.Append("</td>");
            shtml.Append("</tr>");
            shtml.Append("</table>");

            Response.Write(shtml.ToString());
        }
        #endregion
    }
}
