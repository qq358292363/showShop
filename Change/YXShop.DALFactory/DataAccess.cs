using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ShowShop.DALFactory
{
    public sealed partial class DataAccess
    {
        private static readonly string dalPath = System.Configuration.ConfigurationSettings.AppSettings["DAL"];

        /// <summary>
        /// 根据ClassName创建类
        /// </summary>
        /// <param name="className">类名称</param>
        /// <returns></returns>
        public static object CreateObject(string className)
        {
            try
            {
                return Assembly.Load(dalPath).CreateInstance(dalPath + "." + className);
            }
            catch
            {
                return null;
            }
        }
    }
}
