using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Product
{
    public class ProductTypeProperty
    {
        #region "member variant"
        private int id;
        private int typeId;
        private string profix;
        private string properyName;
        private string properyEnglishName;
        private int properyType;
        private string properyValue;
        private int propertyClass;
        private int sort;
        #endregion

        #region "Constructor"
        /// <summary>
        /// 构造一个空的新的数据访问对象
        /// </summary>
        /// <remarks></remarks>
        public ProductTypeProperty()
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
        /// 与数据库基本列Prefix相对应的公共属性, Caption:表名前缀
        /// </summary>
        public string Prefix
        {
            get { return Prefix; }
            set { Prefix = value; }
        }
        /// <summary>
        /// 与数据库基本列PropertyName相对应的公共属性, Caption:属性名称
        /// </summary>
        public string PropertyName
        {
            get { return properyName; }
            set { properyName = value; }
        }
        /// <summary>
        /// 与数据库基本列PropertyEnglishName相对应的公共属性, Caption:属性别名
        /// </summary>
        /// <remarks></remarks>
        public string PropertyEnglishName
        {
            get { return properyEnglishName; }
            set { properyEnglishName = value; }
        }

        /// <summary>
        /// 与数据库基本列PropertyType相对应的公共属性, Caption:属性类型
        /// </summary>
        /// <remarks></remarks>
        public int PropertyType
        {
            get { return properyType; }
            set { properyType = value; }
        }

        /// <summary>
        /// 与数据库基本列PropertyValue相对应的公共属性, Caption:属性值
        /// </summary>
        /// <remarks></remarks>
        public string PropertyValue
        {
            get { return properyValue; }
            set { properyValue = value; }
        }
        /// <summary>
        /// 与数据库基本列PropertyClass相对应的公共属性, Caption:类型
        /// </summary>
        public int PropertyClass
        {
            get { return propertyClass; }
            set { propertyClass = value; }
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
