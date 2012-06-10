using System;
using System.Data;
using System.Collections.Generic;
namespace ShowShop.IDAL.Accessories
{
    public interface ILeaveword
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Accessories.Leaveword model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Amend(ShowShop.Model.Accessories.Leaveword model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(string id);
        void DeleteById(int id);
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
        ShowShop.Model.Accessories.Leaveword GetModelByID(int id);

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        List<ShowShop.Model.Accessories.Leaveword> GetAll();

        /// <summary>
        /// 所有数据
        /// </summary>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList();
        /// <summary>
        /// 根据任何条件得到分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList(string strWhere);
        /// <summary>
        /// 标签分页
        /// </summary>
        /// <param name="orderfield"></param>
        /// <param name="pagesize"></param>
        /// <param name="Conditions"></param>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions);
    }
}
