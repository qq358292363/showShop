using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.Accessories;
using ShowShop.DALFactory;
using ShowShop.IDAL.Accessories;

namespace ShowShop.BLL.Accessories
{
    /// <summary>
    /// 广告管理业务逻辑层
    /// </summary>
    public class AdvertiseManage
    {
        private readonly IAdvertiseManage dal = DataAccess.CreateAdvertiseManage();
        public AdvertiseManage()
        { }

        #region  成员方法

        /// <summary>
        /// 添加一条新广告
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(ShowShop.Model.Accessories.AdvertiseManage model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Amend(ShowShop.Model.Accessories.AdvertiseManage model)
        {
            dal.Amend(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(int Id)
        {
            dal.Delete(Id);
        }

        /// <summary>
        /// 更新任意一个列
        /// </summary>
        /// <param name="id"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, object value)
        {
            return dal.Amend(id, columnName, value);
        }

        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShowShop.Model.Accessories.AdvertiseManage GetModelByID(int id)
        {
            return dal.GetModelByID(id);
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Accessories.AdvertiseManage> GetAll()
        {
            return dal.GetAll();
        }

        /// <summary>
        /// 得到所有数据
        /// </summary>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            return dal.GetList();
        }

        #endregion
    }
}
