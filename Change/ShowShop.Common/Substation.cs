using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ShowShop.Common
{
    public class Substation
    {
        int cityId = 0;
        string cityName = "总站";//string.Empty;
        string eCityName = string.Empty;
        string isUse = string.Empty;
        string parentPath = "0,";
        public int CityID
        {
            get { return cityId; }
        }
        public string CityName
        {
            get { return cityName; }
        }
        public string ECityName
        {
            get { return eCityName; }
        }
        public int IsUse
        {
            get { return Convert.ToInt32(isUse); }
        }
        public string ParentPath
        {
            get { return parentPath; }
        }

        public Substation()
        {
            string substationInfo =ChangeHope.Common.Cookies.getCookie("Substation", "Value");
            if (substationInfo == null)
            {
                return;
            }
            string[] substationInfoList = HttpUtility.UrlDecode(substationInfo).Split('$');
            cityId = Convert.ToInt32(substationInfoList[0]);
            cityName = substationInfoList[1];
            eCityName = substationInfoList.Length > 2 ? substationInfoList[2] : string.Empty;
            isUse = substationInfoList[3];
            string Pp = substationInfoList.Length > 4 ? substationInfoList[4].ToString() : string.Empty;
            if (cityId == 0)
            {
                parentPath = "0,";
            }
            else
            {
                parentPath = Pp + "," + cityId.ToString();
            }
        }
        public static bool UpdateCityInfo()
        {
            string cityId = string.Empty, substationInfos1 = string.Empty;
            cityId = HttpContext.Current.Request.QueryString["ConversionCity"];
            if (cityId == "0")
            {
                substationInfos1 = string.Format("0{0}总站{0}countrywide{0}1{0}", "$");
                return ChangeHope.Common.Cookies.updateCookies("Substation", substationInfos1,1440);
            }
            if (string.IsNullOrEmpty(cityId))
            {
                return false;
            }
            ShowShop.BLL.SystemInfo.Provinces B_Provinces = new ShowShop.BLL.SystemInfo.Provinces();
            ShowShop.Model.SystemInfo.Provinces listProvinces = B_Provinces.GetModel(int.Parse(cityId));
            if (listProvinces!=null)
            {
                substationInfos1 = string.Format(listProvinces.Id + "{0}" + listProvinces.CityName + "{0}" + listProvinces.CityEnglishName + "{0}" + listProvinces.IsUse + "{0}" + listProvinces.ParentPath, "$");
                return ChangeHope.Common.Cookies.updateCookies("Substation", substationInfos1,1440);
            }
            return false;
        }
    }

    public class TWODomainName
    {

    }
   
}

