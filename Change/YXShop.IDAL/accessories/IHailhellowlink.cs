using System;
using System.Data;
using System.Collections.Generic;
namespace ShowShop.IDAL.Accessories
{
    public interface IHailhellowlink
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Accessories.Hailhellowlink model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Amend(ShowShop.Model.Accessories.Hailhellowlink model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int id);
        void DeleteAll(string ids);
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
        ShowShop.Model.Accessories.Hailhellowlink GetModelByID(int id);

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        List<ShowShop.Model.Accessories.Hailhellowlink> GetAll();

        /// <summary>
        /// 所有数据
        /// </summary>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList();

         /// <summary>
        /// 前台标签所有记录
        /// </summary>
        /// <remarks></remarks>
        ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions);
    }
}
