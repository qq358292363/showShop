using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Member;
using ShowShop.DALFactory;

namespace ShowShop.BLL.Member
{
   public class Integral
    {
       private readonly IIntegral dal = DataAccess.CreateIntegral();

       public int Add(ShowShop.Model.Member.Integral model)
       {
           if (model.IntegralClass != 1)
           {
               model.OrderId = string.Empty;
           }
          return  dal.Add(model);
       }
       /// <summary>
       /// 根据用户统计积分总数
       /// </summary>
       /// <param name="uid"></param>
       /// <returns></returns>
       public int GetInteSumByUid(int uid)
       {
           return dal.GetInteSumByUid(uid);
       }
       /// <summary>
       /// 根据uid和积分来源类别得到积分总和
       /// </summary>
       /// <param name="uid"></param>
       /// <param name="type"></param>
       /// <returns></returns>
       public int GetInteSumByUid(int uid, int type)
       {
           return dal.GetInteSumByUid(uid, type);
       }
        /// <summary>
        /// 根据条件查集合 按获得积分时间排序
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
       public List<ShowShop.Model.Member.Integral> GetListByWhere(string where)
       {
           return dal.GetListByWhere(where);
       }

       /// <summary>
       /// 根据条件得到分页数据
       /// </summary>
       /// <param name="strWhere"></param>
       /// <returns></returns>
       public ChangeHope.DataBase.DataByPage GetList(string strWhere)
       {
           return dal.GetList(strWhere);
       }
    }
}
