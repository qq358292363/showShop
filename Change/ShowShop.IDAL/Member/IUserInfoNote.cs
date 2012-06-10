using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.IDAL.Member
{
   public interface IUserInfoNote
    {  
       /// <summary>
       /// 添加
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       int Add(ShowShop.Model.Member.UserInfoNote model);
       /// <summary>
       /// 根据日期及其他条件删除
       /// </summary>
       /// <param name="strdate"></param>
       /// <param name="where"></param>
       void Delete(string where);
       /// <summary>
       /// 得到实体
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       ShowShop.Model.Member.UserInfoNote GetModelById(int id);
       /// <summary>
       /// 根据会员ID与交易类型查所有
       /// </summary>
       /// <param name="userId"></param>
       /// <param name="type"></param>
       /// <returns></returns>
       ChangeHope.DataBase.DataByPage GetListByIdAndType(int userId,int type);
       /// <summary>
       /// 根据不同条件分页
       /// </summary>
       /// <param name="where"></param>
       /// <returns></returns>
       ChangeHope.DataBase.DataByPage GetListByWhere(string where);
    }
}
