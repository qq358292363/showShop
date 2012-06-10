using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Accessories;
using ShowShop.DALFactory;

namespace ShowShop.BLL.Accessories
{
    public class CommentForm
    {
        private readonly ICommentForm dal = DataAccess.CreateCommentForm();
        public CommentForm()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Accessories.CommentForm model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ShowShop.Model.Accessories.CommentForm model)
        {
            return dal.Update(model);
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
        public ShowShop.Model.Accessories.CommentForm GetModelID(int id)
        {

            return dal.GetModelID(id);
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

        #endregion  成员方法
    }
}
