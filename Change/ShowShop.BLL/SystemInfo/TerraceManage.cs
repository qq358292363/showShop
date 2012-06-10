using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.SystemInfo;
using ShowShop.DALFactory;

namespace ShowShop.BLL.SystemInfo
{
   public class TerraceManage
   {
       private readonly ITerraceManage dal = DataAccess.CreateTerrace();
       public TerraceManage()
       {
       }
       #region "DataBase Operation"
       /// <summary>
        /// 添加
        /// </summary>
       public int Add(ShowShop.Model.SystemInfo.TerraceManage model)
       {
           return dal.Add(model);
       }
        /// <summary>
        /// 修改
        /// </summary>  
       public void Update(ShowShop.Model.SystemInfo.TerraceManage model)
       {
           dal.Update(model);
       }
       /// <summary>
        /// 删除
        /// </summary>
       public void Delete(int id)
       {
           dal.Delete(id);
       }
       /// <summary>
       /// 批量删除
       /// </summary>
       /// <param name="id"></param>
       public void DeleteAll(string id)
       {
           dal.DeleteAll(id);
       }
       #endregion

       #region "Data Load"
       /// <summary>
        /// 根据ID得实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public ShowShop.Model.SystemInfo.TerraceManage GetModelById(int id)
       {
           return dal.GetModelById(id);
       }
       public ShowShop.Model.SystemInfo.TerraceManage GetModelByName(string name)
       {
           return dal.GetModelByName(name);
       }
       /// <summary>
        /// 无条件分页
        /// </summary>
        /// <returns></returns>
       public ChangeHope.DataBase.DataByPage GetAllList()
       {
           return dal.GetAllList();
       }

       public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
       {
           return dal.GetList(orderfield, pagesize, Conditions);
       }
       #endregion
   }
}
