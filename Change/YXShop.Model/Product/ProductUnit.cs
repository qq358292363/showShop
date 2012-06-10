using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Product
{
    public class ProductUnit
    {
        #region "member variant"
        private int _id;
        private string _name;
        private Nullable<Int32> _sort;
        #endregion

        #region "Property"
        /// <summary>
        /// 与数据库基本列ID相对应的公共属性, Caption:ID
        /// </summary>
        /// <remarks></remarks>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 与数据库基本列Name相对应的公共属性, Caption:Name
        /// </summary>
        /// <remarks></remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Nullable<Int32> Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
        #endregion

        #region "Constructor"
        /// <summary>
        /// 构造一个空的新的数据访问对象
        /// </summary>
        /// <remarks></remarks>
        public ProductUnit()
        {
        }
        #endregion
    }
}
