using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Member;
using ShowShop.DALFactory;

namespace ShowShop.BLL.Member
{
   public class UserInfoNote
    {
       private readonly IUserInfoNote dal = DataAccess.CreateInfoNote();
       /// <summary>
       /// 添加
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public int Add(ShowShop.Model.Member.UserInfoNote model)
       {
           return dal.Add(model);
       }
       /// <summary>
       /// 根据日期与其他条件删除
       /// </summary>
       /// <param name="strdate"></param>
       /// <param name="where"></param>
       public void Delete(string where)
       {
           dal.Delete(where);
       }

       /// <summary>
       /// 得到实体
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public ShowShop.Model.Member.UserInfoNote GetModelById(int id)
       {
           return dal.GetModelById(id);
       }

       /// <summary>
       /// 根据用户ID和操作类型
       /// </summary>
       /// <param name="userId"></param>
       /// <param name="type"></param>
       /// <returns></returns>
       public ChangeHope.DataBase.DataByPage GetListByIdAndType(int userId, int type)
       {
           return dal.GetListByIdAndType(userId,type);
       }
         /// <summary>
        /// 根据不同条件查
        /// </summary> 
       public ChangeHope.DataBase.DataByPage GetListByWhere(string where)
       {
           return dal.GetListByWhere(where);
       }
    }
}
