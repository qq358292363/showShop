using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ShowShop.Model.Admin;

namespace ShowShop.Common
{
    public class AdministrorManager
    {
        public static bool CheckAdmin()
        {
            AdminInfo admin = (AdminInfo)Get();
            if (admin == null)
            {
                SysParameter sp = new SysParameter();
                ChangeHope.WebPage.Script.Alert("提示：您未登陆或登陆时间已过期，转向登录页面");
                ChangeHope.WebPage.Script.ParentPageRedirect(sp.DummyPaht + "admin/index.aspx");
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 获取存储在Session或Cookie中Admin的信息
        /// </summary>
        /// <returns></returns>
        public static AdminInfo Get()
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            if (sp.IsSession)
            {
                if (HttpContext.Current.Session["Admin"] != null)
                {
                    return (AdminInfo)HttpContext.Current.Session["Admin"];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                string AdminId = ChangeHope.Common.Cookies.getCookie("AdminId", "Value");
                if (AdminId != null)
                {
                    string AdminName = ChangeHope.Common.Cookies.getCookie("AdminName", "Value");
                    string AdminPowerType = ChangeHope.Common.Cookies.getCookie("AdminPowerType", "Value");
                    string AdminRole = ChangeHope.Common.Cookies.getCookie("AdminRole", "Value");
                    AdminInfo model = new AdminInfo();
                    model.AdminId = int.Parse(AdminId);
                    model.AdminName = AdminName;
                    model.AdminPowerType = AdminPowerType;
                    model.AdminRole = AdminRole;
                    return model;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 清除存储在Session或Cookie中Admin的信息
        /// </summary>
        /// <returns></returns>
        public static void DelAdminInfo()
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            if (sp.IsSession)
            {
                if (HttpContext.Current.Session["Admin"] != null)
                {
                    HttpContext.Current.Session.Abandon();
                }
            }
            else
            {
                string AdminId = ChangeHope.Common.Cookies.getCookie("AdminId", "Value");
                if (AdminId != null)
                {
                    HttpCookie cookieAdminId = HttpContext.Current.Request.Cookies["AdminId"];
                    cookieAdminId.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(cookieAdminId);

                    HttpCookie cookieAdminName = HttpContext.Current.Request.Cookies["AdminName"];
                    cookieAdminName.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(cookieAdminName);

                    HttpCookie cookieAdminPowerType = HttpContext.Current.Request.Cookies["AdminPowerType"];
                    cookieAdminPowerType.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(cookieAdminPowerType);

                    HttpCookie cookieAdminRole = HttpContext.Current.Request.Cookies["AdminRole"];
                    cookieAdminRole.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(cookieAdminRole);
                }
            }
        }
        /// <summary>
        /// 把Admin信息存储在Session或Cookies中
        /// </summary>
        /// <param name="adminInfo"></param>
        public static void Set(ShowShop.Model.Admin.AdminInfo adminInfo)
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            if (adminInfo == null)
            {
                if (HttpContext.Current.Session["Admin"] != null)
                {
                    HttpContext.Current.Session.Remove("Admin");
                }
            }
            else
            {
                if (sp.IsSession)
                {
                    HttpContext.Current.Session["Admin"] = adminInfo;
                }
                else
                {
                    double Time = 20000;
                    ChangeHope.Common.Cookies.setCookie("AdminId", adminInfo.AdminId.ToString(), Time);
                    ChangeHope.Common.Cookies.setCookie("AdminName", adminInfo.AdminName, Time);
                    ChangeHope.Common.Cookies.setCookie("AdminPowerType", adminInfo.AdminPowerType, Time);
                    ChangeHope.Common.Cookies.setCookie("AdminRole", adminInfo.AdminRole, Time);
                }
            }
        }
    }
}
