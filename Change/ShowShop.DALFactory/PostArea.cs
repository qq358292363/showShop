using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.SystemInfo;

namespace ShowShop.DALFactory
{
    public sealed partial class DataAccess
    {
    /// <summary>
        /// 导航
        /// </summary>
        /// <returns></returns>
         public static IPostArea CreatePostArea()
        {
            return (IPostArea)CreateObject("SystemInfo.PostArea");
        }

    }
}
