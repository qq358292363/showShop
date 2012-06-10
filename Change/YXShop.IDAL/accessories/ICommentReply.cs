using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.IDAL.Accessories
{
    public interface ICommentReply
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Accessories.CommentReply model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Amend(ShowShop.Model.Accessories.CommentReply model);
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
        ShowShop.Model.Accessories.CommentReply GetModelID(int id);
        /// <summary>
        /// 所有数据
        /// </summary>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList();

        ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions);

        void AllDelete(string commentid);
    }
}
