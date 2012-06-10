using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.Accessories;
using ShowShop.DALFactory;
using ShowShop.IDAL.Accessories;

namespace ShowShop.BLL.Accessories
{
    public class Collection
    {
        private readonly ICollection dal = DataAccess.CreateCollection();
        public Collection()
        { }

         #region "DataBase Operation"
        /// <summary>
        /// 添加一条新的友情链接
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(ShowShop.Model.Accessories.Collection model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(string id)
        {
            dal.Delete(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Amend(ShowShop.Model.Accessories.Collection model)
        {
            dal.Amend(model);
        }


        /// <summary>
        /// 更新任意一个字段
        /// </summary>
        /// <param name="id"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, object value)
        {
            return dal.Amend(id, columnName, value);
        }
        #endregion

        #region "Data Load"
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShowShop.Model.Accessories.Collection GetModelByID(int id)
        {
            return dal.GetModelByID(id);
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Accessories.Collection> GetAll()
        {
            return dal.GetAll();

        }
        /// <summary>
        /// 得到不同条件得到列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 得到所有记录
        /// </summary>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            return dal.GetList();
        }

        #endregion
    }
}
