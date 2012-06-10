using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.IDAL.Member
{
   public interface IIntegral
    {
       int Add(ShowShop.Model.Member.Integral model);
       int GetInteSumByUid(int uid);
       int GetInteSumByUid(int uid,int type);
       List<ShowShop.Model.Member.Integral> GetListByWhere(string where);
       ChangeHope.DataBase.DataByPage GetList(string strWhere);
    }
}
