using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Text;
using System.Web.SessionState;

namespace ShowShop.Web.controls
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class consigneeaddress : IHttpHandler, IRequiresSessionState 
    {

        public void ProcessRequest(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            if (context.Session["MemberID"] != null)
            {
               int uid = Convert.ToInt32(HttpContext.Current.Session["MemberID"]);
                ShowShop.BLL.Member.ReceAddress rabll = new ShowShop.BLL.Member.ReceAddress();
                ChangeHope.DataBase.DataByPage db = rabll.GetList(" uid="+uid+"");
                if (db.DataReader != null)
                {
                    context.Response.ContentType = "text/plain";
                    sb.Append("<table border=\"0\" width=\"98%\"  cellpadding=\"1\" cellspacing=\"1\">");
                    sb.Append("<tr><td></td></tr>");
                    sb.Append("<tr>");
                    sb.Append("<td height=\"60px\"><fieldset><legend><span style=\"font-weight:bold;font-size:14px\">选择收货地址</span></legend><%=Proviecs %><span id=\"City\">");
                    sb.Append("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
                    sb.Append("<tr>");
                    sb.Append("<td align=\"center\"><strong><span style='font-size:12px'>收货人</span></strong></td>");
                    sb.Append("<td align=\"center\"><strong><span style='font-size:12px'>收货地址</span></strong></td>");
                    sb.Append("</tr>");
                    while (db.DataReader.Read())
                    {
                        sb.Append("<tr>");
                        sb.Append("<td><a href='#' onClick='javascript:Consignee(" + db.DataReader["id"].ToString() + ");closeWithIframe();'>" + db.DataReader["username"].ToString() + "</a></td>");
                        sb.Append("<td><a href=''>" + db.DataReader["address"].ToString() + "</a></td>");
                        sb.Append(" </tr>");
                    }
                    sb.Append("</table>");
                    sb.Append("</span></fieldset> </td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td><span id=\"MainConent\"></span></td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");
                }
            }
            else
            {
                sb.Append("没有收货信息!");
            }
            context.Response.Write(sb.ToString());
            }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
