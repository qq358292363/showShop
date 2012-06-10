using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Product;
using System.Data;
using System.Data.SqlClient;

namespace ShowShop.SQLServerDAL.Product
{
    public  class ScanInfo:IScanInfo
    {

        #region database operation

        public int Add(ShowShop.Model.Product.ScanInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_scaninfo( ");
            strSql.Append("uid,productId,scanTime) values ( ");
            strSql.Append("@uid,@productId,@scanTime )");
            SqlParameter[] parameters = (SqlParameter[])this.ValueParam(model);
            return ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(),parameters);
        }

        public void Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  yxs_scaninfo ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters ={
                                           new SqlParameter("@id",SqlDbType.Int,4)
                                      };
            parameters[0].Value = id;
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(),parameters);
        }

        #endregion

        #region

        public List<ShowShop.Model.Product.ScanInfo> GetListByWhere(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from yxs_scaninfo "); 
            if(where!=""&&where!=null)
            {
                strSql.Append(" where "+where+" ");
            }
            strSql.Append("order by scanTime DESC ");
            List<ShowShop.Model.Product.ScanInfo> list =new List<ShowShop.Model.Product.ScanInfo>();
            using(SqlDataReader reader=ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {             
               while(reader.Read())
               {
                   ShowShop.Model.Product.ScanInfo model = new ShowShop.Model.Product.ScanInfo();
                   model.Id = Convert.ToInt32(reader["id"]);
                   model.Uid=(int)reader["uid"];
                   model.ProductId = (int)reader["productId"];
                   model.ScanTime = Convert.ToDateTime(reader["scanTime"]);
                   list.Add(model);
               }
            }
            return list;
            
        }

        #endregion

        #region other function
        public IDbDataParameter[] ValueParam(ShowShop.Model.Product.ScanInfo model)
        {
            SqlParameter[] parameters ={
                                           new SqlParameter("@id",SqlDbType.Int,4),
                                           new SqlParameter("@uid",SqlDbType.Int,4),
                                           new SqlParameter("@productId",SqlDbType.Int,4),
                                           new SqlParameter("@scanTime",SqlDbType.DateTime,8)
                                      };
            parameters[0].Value = model.Id;
            parameters[1].Value = model.Uid;
            parameters[2].Value = model.ProductId;
            parameters[3].Value = model.ScanTime;

            return parameters;

        }
        #endregion
    }
}
