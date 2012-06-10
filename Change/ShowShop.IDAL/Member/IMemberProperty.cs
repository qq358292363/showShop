using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ShowShop.IDAL.Member
{
    public interface IMemberProperty
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Member.memberproperty model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(ShowShop.Model.Member.memberproperty model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.Member.memberproperty GetModelID(int id);
        /// <summary>
        /// 所有数据
        /// </summary>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList();
        /// <summary>
        /// 修改某一个字段的值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        int Amend(int id, string columnName, Object value);
        /// <summary>
        /// 跟据商品分类ID查询属性
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        DataTable GetProperty(string cid);



        //ShowShop.Model.Member.memberproperty GetFirstData();

        
    }
}
