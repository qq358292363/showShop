﻿using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.Accessories;
using ShowShop.DALFactory;
using ShowShop.IDAL.Accessories;

namespace ShowShop.BLL.Accessories
{
    public class Hailhellowlink
    {
        private readonly IHailhellowlink dal = DataAccess.CreateHailhellowlink();
        public Hailhellowlink()
        { }

        #region "DataBase Operation"
        /// <summary>
        /// 添加一条新的友情链接
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(ShowShop.Model.Accessories.Hailhellowlink model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(int id)
        {
            dal.Delete(id);
        }
        public void DeleteAll(string ids)
        {
            dal.DeleteAll(ids);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Amend(ShowShop.Model.Accessories.Hailhellowlink model)
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
        public ShowShop.Model.Accessories.Hailhellowlink GetModelByID(int id)
        {
            return dal.GetModelByID(id);
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Accessories.Hailhellowlink> GetAll()
        {
            return dal.GetAll();

        }

        /// <summary>
        /// 得到所有记录
        /// </summary>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            return dal.GetList();
        }

         /// <summary>
        /// 前台标签所有记录
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
        {
            return dal.GetList(orderfield, pagesize, Conditions);
        }

        #endregion
    }
}
