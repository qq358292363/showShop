using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Collections.Generic;

namespace ShowShop.Web.controls
{
    public partial class area : System.Web.UI.Page
    {
        protected string Proviecs;
        ShowShop.BLL.SystemInfo.Provinces datab = new ShowShop.BLL.SystemInfo.Provinces();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.Form["Option"] != null && !Request.Form["Option"].Trim().Equals("")
              && Request.Form["CityId"] != null && !Request.Form["CityId"].Trim().Equals(""))
            {
                string types = Request.Form["Option"].Trim();
                string CityId = Request.Form["CityId"].Trim();
                if (types == "ConMain")
                {
                    this.CitySelect(CityId);
                }
                Response.End();
                return;
            }
            if (Request.Form["Option1"] != null && !Request.Form["Option1"].Trim().Equals("")
              && Request.Form["CityId"] != null && !Request.Form["CityId"].Trim().Equals(""))
            {
                string types1 = Request.Form["Option1"].Trim();
                string CityId = Request.Form["CityId"].Trim();
                if (types1 == "ConMain")
                {
                    this.Content(CityId);
                }
                Response.End();
                return;
            }
            if (!IsPostBack)
            {
                Proviecs = this.ProviecsSelect("0");
            }
        }
        #region 省 市 Select
        private void CitySelect(string id)
        {
            System.Data.SqlClient.SqlDataReader reader = datab.GetChidNodeReader(id);
            StringBuilder shtml = new StringBuilder();
            if (reader != null)
            {
                shtml.Append("<select id=\"Proviecs\"  onchange=\"Calm(this.value)\">");
                shtml.Append("<option value=\"0\">请选择该地区</option>");
                while (reader.Read())
                {
                    shtml.Append("<option value=\"" + reader["Id"].ToString() + "\">" + reader["CityName"].ToString() + "</option>");
                }
                shtml.Append("</select>");
            }
            Response.Write(shtml.ToString());
        }
        protected string ProviecsSelect(string id)
        {
            System.Data.SqlClient.SqlDataReader reader = datab.GetChidNodeReader(id);
            StringBuilder shtml = new StringBuilder();
            if (reader != null)
            {
                shtml.Append("<select id=\"Proviecs\" onchange=\"City(this.value)\">");
                shtml.Append("<option value=\"0\">全国</option>");
                while (reader.Read())
                {
                    shtml.Append("<option value=\"" + reader["Id"].ToString() + "\">" + reader["CityName"].ToString() + "</option>");
                }
            }
            shtml.Append("</select>");
            return shtml.ToString();
        }
        #endregion

        #region 详细选择
        protected void Content(string id)
        {
            string strTitle = "";
            System.Data.SqlClient.SqlDataReader reader = datab.GetChidNodeReader(id);
            if (id != "0")
            {
                ShowShop.Model.SystemInfo.Provinces model = datab.GetModel(Convert.ToInt32(id));
                if (model!=null)
                {
                    strTitle = model.CityName;
                }
            }
            StringBuilder shtml = new StringBuilder();
            if (reader != null)
            {
                shtml.Append("<fieldset width='95%'><legend><span style=\"font-weight:bold;font-size:14px\">" + strTitle + "</span></legend>");
                shtml.Append("<table width='100%'>");
                shtml.Append("<tr height='24px'>");
                int i = 1;
                while (reader.Read())
                {
                    shtml.Append("<td width=\"20%\"><a target='_parent' href='../controls/cookie.aspx?ConversionCity=" + reader["Id"].ToString() + "'>" + reader["CityName"].ToString() + "</a></td>");
                    if (i % 5 == 0)
                    {
                        shtml.Append("</tr><tr height='24px'>");
                    }
                    i++;
                }
                shtml.Append("</tr>");
                shtml.Append("</table>");
                shtml.Append("</fieldset>");
            }
            Response.Write(shtml.ToString());
        }
        #endregion
    }
}
