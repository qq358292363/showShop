using System;
using System.Text;
using ShowShop.IDAL.Admin;
namespace ShowShop.DALFactory
{
    public sealed partial class DataAccess
    {
        /// <summary>
        /// 用户登陆日志
        /// </summary>
        /// <returns></returns>
        public static IAdminLoginLog CreateAdminLoginLog()
        {
            return (IAdminLoginLog)CreateObject("Admin.AdminLoginLog");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IAdministrators CreateAdministrators()
        {
            return (IAdministrators)CreateObject("Admin.Administrators");
        }
    }
}
