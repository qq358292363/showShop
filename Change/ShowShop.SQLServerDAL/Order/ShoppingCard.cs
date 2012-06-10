using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Order;
using ChangeHope.DataBase;
namespace ShowShop.SQLServerDAL.Order
{
    /// <summary>
    /// 数据访问类ShoppingCard。
    /// </summary>
    public class ShoppingCard : IShoppingCard
    {
        private string tableName = "yxs_cart";
        public ShoppingCard()
        {
            tableName = "yxs_cart";
        }
        #region  成员方法
        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="uID"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, Object value)
        {
            string sequel = "Update " + tableName + " set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + " where id=@Id ";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@Value", value), new SqlParameter("@Id", id) };
            object obj = ChangeHope.DataBase.SQLServerHelper.GetSingle(sequel, paras);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tableName);
            strSql.Append(" where id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;
            
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteCartkey(string cartkey)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tableName);
            strSql.Append(" where cartkey=@cartkey ");
            SqlParameter[] parameters = {
					new SqlParameter("@cartkey", SqlDbType.VarChar,50)};
            parameters[0].Value = cartkey;

            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除个人购物车数据
        /// </summary>
        public void Delete(string UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_profiles");
            strSql.Append(" where username=@username ");
            string sql = "delete from yxs_cart where uniqueid in (select uniqueid from yxs_profiles where username=@username)";
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,256)};
            parameters[0].Value = UserId;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
            SQLServerHelper.ExecuteSql(sql, parameters);
        }

        /// <summary>
        /// 查询购物车产品
        /// </summary>
        /// <returns></returns>
        public DataByPage GetCartProduct(string uniqueid)
        {
            string sql = "[select] yxs_product.pro_ID,yxs_product.pro_Name,yxs_product.pro_ShopPrice,yxs_product.pro_RatingDiscount,yxs_cart.quantity,yxs_cart.addtime [from] yxs_cart inner join yxs_product on yxs_product.pro_ID=yxs_cart.productid [where] yxs_cart.uniqueid=" + uniqueid + " [order by] pro_Id desc";
            ChangeHope.DataBase.DataByPage datapage = new DataByPage();
            datapage.Sql = sql;
            datapage.GetRecordSetByPage();
            return datapage;
        }
        /// <summary>
        /// 查询购物车
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public DataByPage GetProfilesList(string condition)
        {
            string sql = "[select] * [from] yxs_profiles [where] 1=1" + condition + " [order by] uniqueid desc";
            ChangeHope.DataBase.DataByPage datapage = new DataByPage();
            datapage.Sql = sql;
            datapage.GetRecordSetByPage();
            return datapage;
        }


        #endregion  成员方法
    }
}

