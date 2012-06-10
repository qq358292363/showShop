using System;
using System.Data;
using System.Collections.Generic;
namespace ShowShop.IDAL.Member
{
    public interface IUserinAndExp
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Member.UserinAndExp model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Amend(ShowShop.Model.Member.UserinAndExp model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(string id);

        /// <summary>
        /// 任意修改一个字段
        /// </summary>
        /// <param name="id"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        int Amend(int id, string columnName, Object value);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.Member.UserinAndExp GetModelByID(int id);

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        List<ShowShop.Model.Member.UserinAndExp> GetAll();

        /// <summary>
        /// 得到指定条件的所有短消息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        List<ShowShop.Model.Member.UserinAndExp> GetAll(string strWhere);

        /// <summary>
        /// 所有数据
        /// </summary>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList(string strWhere);
    }
}
