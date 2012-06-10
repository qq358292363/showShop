using System;
using System.Data;
using System.Collections.Generic;
namespace ShowShop.IDAL.Accessories
{
    public interface IAdvertiseManage
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Accessories.AdvertiseManage model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Amend(ShowShop.Model.Accessories.AdvertiseManage model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int Id);

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
        ShowShop.Model.Accessories.AdvertiseManage GetModelByID(int id);

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        List<ShowShop.Model.Accessories.AdvertiseManage> GetAll();

        /// <summary>
        /// 所有数据
        /// </summary>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList();
    }
}
