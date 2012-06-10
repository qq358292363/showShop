using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Product
{
    public class ProductTypeParameter
    {
         #region "member variant"
        private int id;
        private int typeId;
        private int parId;
        private string profix;
        private string parameterName;
        private int parameterType;
        private string parameterValue;
        private int sort;
        #endregion

        #region "Constructor"
        /// <summary>
        /// 构造一个空的新的数据访问对象
        /// </summary>
        /// <remarks></remarks>
        public ProductTypeParameter()
        {
        }
        #endregion

        #region "Property"
        /// <summary>
        /// 与数据库基本列id相对应的公共属性, Caption:id
        /// </summary>
        /// <remarks></remarks>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 与数据库基本列TypeID相对应的公共属性, Caption:商品类型ID
        /// </summary>
        public int TypeID
        {
            get { return typeId; }
            set { typeId = value; }
        }
        /// <summary>
        /// 与数据库基本列ParID相对应的公共属性, Caption:商品参数ID
        /// </summary>
        public int ParID
        {
            get { return parId; }
            set { parId = value; }
        }
        /// <summary>
        /// 与数据库基本列Prefix相对应的公共属性, Caption:表名前缀
        /// </summary>
        public string Prefix
        {
            get { return Prefix; }
            set { Prefix = value; }
        }
        /// <summary>
        /// 与数据库基本列ParameterName相对应的公共属性, Caption:参数名称
        /// </summary>
        public string ParameterName
        {
            get { return parameterName; }
            set { parameterName = value; }
        }

        /// <summary>
        /// 与数据库基本列ParameterType相对应的公共属性, Caption:参数类型
        /// </summary>
        /// <remarks></remarks>
        public int ParameterType
        {
            get { return parameterType; }
            set { parameterType = value; }
        }

        /// <summary>
        /// 与数据库基本列ParameterValue相对应的公共属性, Caption:参数值
        /// </summary>
        /// <remarks></remarks>
        public string ParameterValue
        {
            get { return parameterValue; }
            set { parameterValue = value; }
        }
       
        /// <summary>
        /// 与数据库基本列Sort相对应的公共属性, Caption:排列顺序
        /// </summary>
        /// <remarks></remarks>
        public int Sort
        {
            get { return sort; }
            set { sort = value; }
        }

        #endregion
    }
}
