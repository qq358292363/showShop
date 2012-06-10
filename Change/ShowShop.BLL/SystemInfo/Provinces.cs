using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.SystemInfo;
using ShowShop.DALFactory;
using ShowShop.IDAL.SystemInfo;
using System.Text;
namespace ShowShop.BLL.SystemInfo
{
    /// <summary>
    /// 业务逻辑类Provinces 的摘要说明。
    /// </summary>
    public class Provinces
    {
        private readonly IProvinces dal = DataAccess.CreateProvinces();
        public Provinces()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.SystemInfo.Provinces model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ShowShop.Model.SystemInfo.Provinces model)
        {
            dal.Update(model);
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
        public ShowShop.Model.SystemInfo.Provinces GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        public string GetList()
        {
           
            ChangeHope.DataBase.DataByPage dataPage = dal.GetList();
            ChangeHope.WebPage.DataTable table = new ChangeHope.WebPage.DataTable();
            table.RowHead = "序号/5%,城市名称/20%,英文名称/20%,状态/5%,添加时间/20%,排序/10%,操作/20%";
            table.RowText = "{0}$@allnum,<a href='?w_d_parentid={0}'>{1}</a>$Id|CityName,CityEnglishName,<img src='../images/{0}.gif'/>$IsUse,AddDate,<a href=# onclick='Sort({0});'>↑</a> <a href=# onclick='Sort({0});'>↓</a>$Id,<a href=area_setting_edit.aspx?id={0}>编辑</a> <a href='javascript:DelArea({0})'>删除</a> <a href=area_setting_edit.aspx?parentid={0}>添加子城市</a>$Id";
            table.DataReader = dataPage.DataReader;
            string view = table.GetDataTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            table = null;

            return view;

        }
        public string GetToolBar(int id)
        {
            return dal.GetToolBar(id);
        }
        public int GetChildCount(string id)
        {
            return dal.GetChildCount(id);
        }
        public string GetChidNode(string parentid)
        {
            StringBuilder json = new StringBuilder();
            System.Data.SqlClient.SqlDataReader reader = dal.GetChidNode(parentid);
            int num = 0;
            if (reader!=null)
            {
                while (reader.Read())
                {
                    if (num !=0)
                    {
                        json.Append(",");
                    }
                    json.Append("{code:\"" + reader[0] + "\",content:\"" + reader[1] + "\"}");
                    num++;
                }
            }
            return "{\"city\":["+json.ToString()+"]}";
        }
       
        public DataTable GetChid(string parentid)
        {
            return dal.GetChid(parentid);
        }

        public System.Data.SqlClient.SqlDataReader GetChidNodeReader(string parentid)
        {
            return dal.GetChidNode(parentid);
        }

        public DataTable ProvincesStr(string IdStr)
        {
            return dal.ProvincesStr(IdStr);
        }
        #endregion  成员方法
    }
}

