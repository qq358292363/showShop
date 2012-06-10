using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Common
{
    public class Province
    {
        #region 省份
        #region 省
        public static string Provincess(string AddressID)
        {
            StringBuilder shtml = new StringBuilder();
            ShowShop.BLL.SystemInfo.Provinces pbll = new ShowShop.BLL.SystemInfo.Provinces();
            System.Data.SqlClient.SqlDataReader reader = pbll.GetChidNodeReader("0");
            if (reader != null)
            {
                shtml.Append("<select id=\"Provinces\" readonly=\"true\" name=\"Provinces\" onchange='javascript:Province(this.value)'>");
                
                while (reader.Read())
                {
                    if (reader["Id"].ToString() == AddressID)
                    {
                        shtml.Append("<option value=" + reader["Id"].ToString() + "  selected=\"selected\">" + reader["CityName"].ToString() + "</option> ");
                    }
                    else
                    {
                        shtml.Append("<option value=" + reader["Id"].ToString() + ">" + reader["CityName"].ToString() + "</option> ");
                    }
                }
                shtml.Append("</select>");
            }
            return shtml.ToString();
        }

        public static string Provincess2(string AddressID)
        {
            StringBuilder shtml = new StringBuilder();
            ShowShop.BLL.SystemInfo.Provinces pbll = new ShowShop.BLL.SystemInfo.Provinces();
            System.Data.SqlClient.SqlDataReader reader = pbll.GetChidNodeReader("0");
            if (reader != null)
            {
                shtml.Append("<select id=\"Provinces\" name=\"Provinces\" onchange='javascript:Province2(this.value)'>");
                shtml.Append("<option value='' selected>--请选择--</option>");
                while (reader.Read())
                {
                    if (reader["Id"].ToString() == AddressID)
                    {
                        shtml.Append("<option value=" + reader["Id"].ToString() + "  selected=\"selected\">" + reader["CityName"].ToString() + "</option> ");
                    }
                    else
                    {
                        shtml.Append("<option value=" + reader["Id"].ToString() + ">" + reader["CityName"].ToString() + "</option> ");
                    }
                }
                shtml.Append("</select>");
            }
            return shtml.ToString();
        }
        #endregion

        #region 城
        public static string Provinces_City(string AddressID, string idstr)
        {
            StringBuilder shtml = new StringBuilder();
            if (!string.IsNullOrEmpty(idstr))
            {
                ShowShop.BLL.SystemInfo.Provinces pbll = new ShowShop.BLL.SystemInfo.Provinces();
                System.Data.SqlClient.SqlDataReader reader = pbll.GetChidNodeReader(idstr);
                if (reader != null)
                {
                    shtml.Append("<select id=\"City\" name=\"City\" onchange=\"Citys(this.value)\">");
                    
                    while (reader.Read())
                    {
                        if (reader["Id"].ToString() == AddressID)
                        {
                            shtml.Append("<option value=" + reader["Id"].ToString() + "  selected=\"selected\">" + reader["CityName"].ToString() + "</option> ");
                        }
                        else
                        {
                            shtml.Append("<option value=" + reader["Id"].ToString() + ">" + reader["CityName"].ToString() + "</option> ");
                        }
                    }
                    shtml.Append("</select>");
                }
                else
                {
                    shtml.Append("<select id=\"City\" name=\"City\" onchange=\"Citys(this.value)\">");
                    shtml.Append("<option value='' selected>--请选择--</option> ");
                    shtml.Append("</select>");
                }
            }
            else
            {
                shtml.Append("<select id=\"City\" name=\"City\" onchange=\"Citys(this.value)\">");
                shtml.Append("<option value='' selected>--请选择--</option> ");
                shtml.Append("</select>");
            }
            return shtml.ToString();
        }


        public static string Provinces_City2(string AddressID, string idstr)
        {
            StringBuilder shtml = new StringBuilder();
            if (!string.IsNullOrEmpty(idstr))
            {
                ShowShop.BLL.SystemInfo.Provinces pbll = new ShowShop.BLL.SystemInfo.Provinces();
                System.Data.SqlClient.SqlDataReader reader = pbll.GetChidNodeReader(idstr);
                if (reader != null)
                {
                    shtml.Append("<select id=\"City\" name=\"City\" onchange=\"Citys2(this.value)\">");
                    shtml.Append("<option value='' selected>--请选择--</option> ");
                    while (reader.Read())
                    {
                        if (reader["Id"].ToString() == AddressID)
                        {
                            shtml.Append("<option value=" + reader["Id"].ToString() + "  selected=\"selected\">" + reader["CityName"].ToString() + "</option> ");
                        }
                        else
                        {
                            shtml.Append("<option value=" + reader["Id"].ToString() + ">" + reader["CityName"].ToString() + "</option> ");
                        }
                    }
                    shtml.Append("</select>");
                }
                else
                {
                    shtml.Append("<select id=\"City\" name=\"City\" onchange=\"Citys2(this.value)\">");
                    shtml.Append("<option value='' selected>--请选择--</option> ");
                    shtml.Append("</select>");
                }
            }
            else
            {
                shtml.Append("<select id=\"City\" name=\"City\" onchange=\"Citys2(this.value)\">");
                shtml.Append("<option value='' selected>--请选择--</option> ");
                shtml.Append("</select>");
            }
            return shtml.ToString();
        }
        #endregion

        #region 区
        public static string Provinces_Borough(string AddressID, string idstr)
        {
            StringBuilder shtml = new StringBuilder();
            if (!string.IsNullOrEmpty(idstr))
            {
                ShowShop.BLL.SystemInfo.Provinces pbll = new ShowShop.BLL.SystemInfo.Provinces();
                System.Data.SqlClient.SqlDataReader reader = pbll.GetChidNodeReader(idstr);
                if (reader != null)
                {
                    shtml.Append("<select id=\"borough\" name=\"borough\">");
                    while (reader.Read())
                    {
                        if (reader["Id"].ToString() == AddressID)
                        {
                            shtml.Append("<option value=" + reader["Id"].ToString() + "  selected=\"selected\">" + reader["CityName"].ToString() + "</option> ");
                        }
                        else
                        {
                            shtml.Append("<option value=" + reader["Id"].ToString() + ">" + reader["CityName"].ToString() + "</option> ");
                        }
                    }
                    shtml.Append("</select>");
                }
                else
                {
                    shtml.Append("<select id=\"borough\" name=\"borough\">");
                    shtml.Append("</select>");
                }
            }
            else
            {
                shtml.Append("<select id=\"borough\" name=\"borough\">");
                shtml.Append("</select>");
            }
            return shtml.ToString();
        }


        public static string Provinces_Borough2(string AddressID, string idstr)
        {
            StringBuilder shtml = new StringBuilder();
            if (!string.IsNullOrEmpty(idstr))
            {
                ShowShop.BLL.SystemInfo.Provinces pbll = new ShowShop.BLL.SystemInfo.Provinces();
                System.Data.SqlClient.SqlDataReader reader = pbll.GetChidNodeReader(idstr);
                if (reader != null)
                {
                    shtml.Append("<select id=\"borough\" name=\"borough\">");
                    while (reader.Read())
                    {
                        if (reader["Id"].ToString() == AddressID)
                        {
                            shtml.Append("<option value=" + reader["Id"].ToString() + "  selected=\"selected\">" + reader["CityName"].ToString() + "</option> ");
                        }
                        else
                        {
                            shtml.Append("<option value=" + reader["Id"].ToString() + ">" + reader["CityName"].ToString() + "</option> ");
                        }
                    }
                    shtml.Append("</select>");
                }
                else
                {
                    shtml.Append("<select id=\"borough\" name=\"borough\">");
                    shtml.Append("</select>");
                }
            }
            else
            {
                shtml.Append("<select id=\"borough\" name=\"borough\">");
                shtml.Append("</select>");
            }
            return shtml.ToString();
        }
        #endregion
        #endregion
    }
}
