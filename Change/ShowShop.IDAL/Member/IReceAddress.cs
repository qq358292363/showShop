using System;
using System.Data;
using System.Collections.Generic;
namespace ShowShop.IDAL.Member
{
    public interface IReceAddress
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Member.ReceAddress model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Amend(ShowShop.Model.Member.ReceAddress model);

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
        /// 判断是否存在默认收货地址
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        int checkDefault(int uid, int state);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.Member.ReceAddress GetModelByID(int id);

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        List<ShowShop.Model.Member.ReceAddress> GetAll();

        /// <summary>
        /// 得到指定条件的所有短消息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        List<ShowShop.Model.Member.ReceAddress> GetAll(string strWhere);

        /// <summary>
        /// 根据用户ID和信息状态得到短消息列表
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="state">0 草稿箱  1 收件箱 2 发件箱 3 废件箱</param>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList(string strWhere);
        /// <summary>
        /// 所有数据
        /// </summary>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList();
    }
}
