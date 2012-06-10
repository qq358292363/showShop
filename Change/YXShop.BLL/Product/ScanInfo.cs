using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Product;
using ShowShop.DALFactory;

namespace ShowShop.BLL.Product
{
    public class ScanInfo
    {
        public ScanInfo()
        {
        }
        private readonly IScanInfo dal = DataAccess.CreateScanInfo();

        #region database operation
        public void Add(ShowShop.Model.Product.ScanInfo model)
        {
            List<ShowShop.Model.Product.ScanInfo> infoList = dal.GetListByWhere(" uid="+model.Uid);
            if(infoList.Count > 10)
            {
                dal.Delete(infoList[Convert.ToInt32(infoList.Count-1)].Id);
            }
            bool flag=true;
            foreach (ShowShop.Model.Product.ScanInfo item in infoList)
            {
                if(item.ProductId==model.ProductId)
                {
                    flag = false;
                    break;
                }
            }
            if(flag)
            {
                dal.Add(model);
            }
  
        }
        public void Delete(int id)
        {
            dal.Delete(id);
        }

        #endregion

        #region database load
        public List<ShowShop.Model.Product.ScanInfo> GetListByWhere(string where)
        {
            return dal.GetListByWhere(where);
        }

        #endregion
    }
}
