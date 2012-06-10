using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ShowShop.IDAL.Product;

namespace ShowShop.SQLServerDAL.Product
{
    public class ProductAlbum : IProductAlbum
    {
        #region "DataBase Operation"
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <remarks></remarks>
        public int Add(ShowShop.Model.Product.ProductAlbum model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            string sequel = "Insert into [yxs_productalbum](";
            sequel = sequel + "[productid], [thumbnailaddress], [originaladdress], [descriptoin])";
            sequel = sequel + "Values(";
            sequel = sequel + "@productid, @thumbnailaddress,@originaladdress,@descriptoin) Select scope_IDENTITY() ";
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
        /// 删除数据
        /// </summary>
        /// <remarks></remarks>
        public void Delete(int id)
        {
            string sequel = "Delete From [yxs_productalbum]" + this.UpdateWhereSequel;
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel, parameters);
        }
        /// <summary>
        /// 删除商品ID的所有图片
        /// </summary>
        /// <param name="ProductId"></param>
        public void DelAll(string strId)
        {
            string sequel = "Delete From [yxs_productalbum] where productid in (" + strId + ")";
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel);
        }

        /// <summary>
        /// 将一个持久化对象的修改保存到数据库, 并提供事务支持
        /// </summary>
        /// <remarks></remarks>
        public int Amend(ShowShop.Model.Product.ProductAlbum model)
        {
            string sequel = "Update [yxs_productalbum] set  ";
            sequel = sequel + "[productid] =@productid ,[thumbnailaddress] =@thumbnailaddress ,[originaladdress]=@originaladdress ,[descriptoin] =@descriptoin";
            sequel = sequel + UpdateWhereSequel;
            object obj = ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel, (SqlParameter[])this.ValueParas(model));
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
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="uID"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, Object value)
        {
            string sequel = "Update [yxs_productalbum] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + UpdateWhereSequel;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@Value", value), new SqlParameter("@id", id) };
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

        #endregion

        #region "Data Load"
        /// <summary>
        /// 返回数据
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public ShowShop.Model.Product.ProductAlbum GetModel(System.Data.DataRow row)
        {
            ShowShop.Model.Product.ProductAlbum model = new ShowShop.Model.Product.ProductAlbum();
            if (row != null)
            {
                model.ID = int.Parse(row["id"].ToString());
                model.Productid = int.Parse(row["productid"].ToString());
                model.ThumbnailAddress = row["thumbnailaddress"].ToString();
                model.OriginalAddress = row["originaladdress"].ToString();
                model.Description = row["descriptoin"].ToString();
                model.IsSpecialspecificationsSign =int.Parse(row["IsSpecialspecificationsSign"].ToString());
                model.SpecificaticationSignId = int.Parse(row["SpecificaticationSignId"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// ID查询
        /// </summary>
        /// <remarks></remarks>
        public ShowShop.Model.Product.ProductAlbum GetModelID(int id)
        {
            string sequel = SelectSequel + UpdateWhereSequel;
            SqlParameter[] paras = (SqlParameter[])this.ValueIDPara(id);
            DataSet ds = ChangeHope.DataBase.SQLServerHelper.Query(sequel, paras);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 所有记录
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_productalbum [where] 1=1 [order by] id desc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        /// <summary>
        /// 查询商品相册
        /// </summary>
        /// <param name="strId"></param>
        public System.Data.DataTable GetProAlbumAll(int productid, int SpecificaticationSignId, int IsSpecialspecificationsSign)
        {
            string sequel = "select * from [yxs_productalbum] where productid=@productid ";
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@productid", SqlDbType.Int, 4);
            paras[0].Value = productid;
           
            System.Data.DataTable dt = ChangeHope.DataBase.SQLServerHelper.Query(sequel,paras).Tables[0];
            return dt;
        }
        #endregion

        #region "Other function"
        string selectSequel = string.Empty;
        protected string SelectSequel
        {
            get
            {
                if (selectSequel == string.Empty)
                    selectSequel = "Select *,1 PersistStatus  From [yxs_productalbum] ";
                return selectSequel;
            }
            set
            {
                this.selectSequel = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected string UpdateWhereSequel
        {
            get
            {
                return " Where [id] = @id";
            }
        }
        /// <summary>
        /// 该数据访问对象的属性值装载到数据库更新参数数组
        /// </summary>
        /// <remarks></remarks>

        public IDbDataParameter[] ValueParas(ShowShop.Model.Product.ProductAlbum model)
        {
            SqlParameter[] paras = new SqlParameter[5];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@productid", SqlDbType.Int, 4);
            paras[1].Value = model.Productid;
            paras[2] = new SqlParameter("@thumbnailaddress", SqlDbType.VarChar, 1000);
            paras[2].Value = model.ThumbnailAddress;

            paras[3] = new SqlParameter("@originaladdress", SqlDbType.VarChar, 1000);
            paras[3].Value = model.OriginalAddress;
            paras[4] = new SqlParameter("@descriptoin", SqlDbType.VarChar,3000);
            paras[4].Value = model.Description;

            //paras[5] = new SqlParameter("@SpecificaticationSignId", SqlDbType.Int, 4);
            //paras[5].Value = model.SpecificaticationSignId;
            //paras[6] = new SqlParameter("@IsSpecialspecificationsSign", SqlDbType.Int, 4);
            //paras[6].Value = model.IsSpecialspecificationsSign;

            return paras;
        }

        public IDbDataParameter[] ValueIDPara(int id)
        {
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@id", id);
            paras[0].DbType = DbType.Int32;
            return paras;
        }

        #endregion

    }
}
