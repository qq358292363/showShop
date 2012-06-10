using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.SQLServerDAL
{
    public class DbBase
    {
        protected string Pre;
        public DbBase()
        {
            Pre = ChangeHope.Common.ServerInfo.GetDataTablePrefix();
        }
    }
}
