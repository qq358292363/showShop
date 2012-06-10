using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.Order;
using ShowShop.DALFactory;
using ShowShop.IDAL.Order;
namespace ShowShop.BLL.Order
{
    /// <summary>
    /// 退款
    /// </summary>
    public class RefundMent
    {
        private readonly IRefundMent dal = DataAccess.CreateRefundMent();
        public RefundMent()
        { }

        #region  "DataBase Operation"
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Order.RefundMent model)
        {
            return dal.Add(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Amend(ShowShop.Model.Order.RefundMent model)
        {
            dal.Amend(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string id)
        {
            dal.Delete(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, object value)
        {
            return dal.Amend(id, columnName, value);
        }
        #endregion

        #region  "Data Load"
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Order.RefundMent GetModelByID(int id)
        {
            return dal.GetModelByID(id);
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Order.RefundMent> GetAll()
        {
            return dal.GetAll();
        }

        /// <summary>
        /// 得到指定条件的所有集合
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ShowShop.Model.Order.RefundMent> GetAll(string strWhere)
        {
            return dal.GetAll(strWhere);
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
        /// 分页列表
        /// </summary>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            return dal.GetList();
        }
        #endregion
    }
}
