using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.Member;
using ShowShop.DALFactory;
using ShowShop.IDAL.Member;
namespace ShowShop.BLL.Member
{
    /// <summary>
    /// 短消息
    /// </summary>
    public class Message
    {
        private readonly IMessage dal = DataAccess.CreateMessage();
        public Message()
        { }

        #region "DataBase Operation"
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(ShowShop.Model.Member.Message model)
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
        public void Amend(ShowShop.Model.Member.Message model)
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
        public ShowShop.Model.Member.Message GetModelByID(int id)
        {
            return dal.GetModelByID(id);
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Member.Message> GetAll()
        {
            return dal.GetAll();

        }

        /// <summary>
        /// 得到指定条件的所有短消息 不加 where
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ShowShop.Model.Member.Message> GetAll(string strWhere)
        {
            return dal.GetAll(strWhere);
        }
        /// <summary>
        /// 根据用户ID和信息状态得到短消息列表
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="state">0 草稿箱  1 收件箱 2 发件箱 3 废件箱</param>
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
