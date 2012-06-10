using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.SystemInfo;
using ShowShop.DALFactory;
using System.Data;

namespace ShowShop.BLL.SystemInfo
{
    public class PostArea
    {
        private readonly IPostArea dal = DataAccess.CreatePostArea();
        public PostArea()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.SystemInfo.PostArea model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ShowShop.Model.SystemInfo.PostArea model)
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
        public ShowShop.Model.SystemInfo.PostArea GetModelID(int id)
        {

            return dal.GetModelID(id);
        }

        public ShowShop.Model.SystemInfo.PostArea GetModelByAreaID(int id)
        {
            return dal.GetModelByAreaID(id);
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

        /// <summary>
        /// 跟据商品分类ID查询属性
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetProperty(string cid)
        {
            return dal.GetProperty(cid);
        }

        /// <summary>
        /// 跟据配送方式ID查询对应的配送区域列表
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetAreasByPostMethod(int cid)
        {
            return dal.GetAreasByPostMethod(cid);
        }

        public ChangeHope.DataBase.DataByPage GetAreasBy(string Condits)
        {
            return dal.GetAreasBy(Condits);
        }

        /// <summary>
        /// 获取第一条数据
        /// </summary>
        /// <returns></returns>
        //public ShowShop.Model.Member.memberproperty GetFirstData()
        //{
        //    return dal.GetFirstData();
        //}

       
        #endregion  成员方法

        public List<ShowShop.Model.SystemInfo.PostArea> GetPostMethodByAreaId(string Borough,string strWhere)
        {
            return dal.GetPostMethodByAreaId(Borough,strWhere);
        }
    }
}
