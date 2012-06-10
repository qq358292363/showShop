using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.IDAL.OrderCard
{
    public interface IOrderCardInfo
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.OrderCard.OrderCardInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Amend(ShowShop.Model.OrderCard.OrderCardInfo model);
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
        ShowShop.Model.OrderCard.OrderCardInfo GetModelID(int id);
        /// <summary>
        /// 根据冲值卡卡号
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        ShowShop.Model.OrderCard.OrderCardInfo GetModelByCardNumber(string cardNumber);
        /// <summary>
        /// 所有数据
        /// </summary>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList();
        

        ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions);

        ShowShop.Model.OrderCard.OrderCardInfo GetModelProductID(int ProductId);
        #endregion  成员方法
    }
}
