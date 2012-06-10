using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.IDAL.SystemInfo
{
   public interface ITerraceManage
   {
       #region 成员方法
       /// <summary>
       /// 增加
       /// </summary>
       int Add(ShowShop.Model.SystemInfo.TerraceManage model);
       /// <summary>
       /// 修改
       /// </summary>
       void Update(ShowShop.Model.SystemInfo.TerraceManage model);
       /// <summary>
       /// 删除
       /// </summary>
       /// <param name="id"></param>
       void Delete(int id);
       /// <summary>
       /// 批量删除
       /// </summary>
       /// <param name="id"></param>
       void DeleteAll(string id);
       /// <summary>
       /// 根据ID得到实体
       /// </summary>
       ShowShop.Model.SystemInfo.TerraceManage GetModelById(int id);
       ShowShop.Model.SystemInfo.TerraceManage GetModelByName(string name);
       /// <summary>
       /// 分页
       /// </summary>
       ChangeHope.DataBase.DataByPage GetAllList();

       ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions);
       #endregion
   }
}
