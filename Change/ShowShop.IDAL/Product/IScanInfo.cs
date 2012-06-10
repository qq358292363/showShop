using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.IDAL.Product
{
   public interface IScanInfo
    {
       int Add(ShowShop.Model.Product.ScanInfo model);
       void Delete(int id);
       List<ShowShop.Model.Product.ScanInfo> GetListByWhere(string where);
       
    }
}
