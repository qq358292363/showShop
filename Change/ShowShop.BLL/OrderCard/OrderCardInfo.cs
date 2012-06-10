using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.OrderCard;
using ShowShop.DALFactory;

namespace ShowShop.BLL.OrderCard
{
    public class OrderCardInfo
    {
         private readonly IOrderCardInfo dal = DataAccess.CreateOrderCardInfo();
         public OrderCardInfo()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.OrderCard.OrderCardInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ShowShop.Model.OrderCard.OrderCardInfo model)
        {
            return dal.Amend(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            dal.Delete(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.OrderCard.OrderCardInfo GetModelID(int id)
        {

            return dal.GetModelID(id);
        }
         /// <summary>
        /// 根据卡号查询
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public ShowShop.Model.OrderCard.OrderCardInfo GetModelByCardNumber(string cardNumber)
        {
            return dal.GetModelByCardNumber(cardNumber);
        }
        /// <summary>
        /// 所有数据
        /// </summary>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            return dal.GetList();
        }
        /// <summary>
        /// 前台标签查询所有数据
        /// </summary>
        /// <param name="orderfield"></param>
        /// <param name="pagesize"></param>
        /// <param name="Conditions"></param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
        {
            return dal.GetList(orderfield, pagesize, Conditions);
        }
        /// <summary>
        /// 修改任一字段值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, Object value)
        {
            return dal.Amend(id, columnName, value);
        }

        public ShowShop.Model.OrderCard.OrderCardInfo GetModelProductID(int ProductId)
        {
            return dal.GetModelProductID(ProductId);
        }
        #endregion  成员方法
    }
}

