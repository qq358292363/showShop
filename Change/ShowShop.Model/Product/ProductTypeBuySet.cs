using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Product
{
    public class ProductTypeBuySet
    {
        #region "member variant"
        private int id;
        private int typeId;
        private string profix;
        private string buysetName;
        private int buysetType;
        private string buysetValue;
        private int sort;
        #endregion

        #region "Constructor"
        /// <summary>
        /// 构造一个空的新的数据访问对象
        /// </summary>
        /// <remarks></remarks>
        public ProductTypeBuySet()
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
        /// 与数据库基本列TypeId相对应的公共属性, Caption:商品类型ID
        /// </summary>
        public int TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }
        /// <summary>
        /// 与数据库基本列Prefix相对应的公共属性, Caption:表名前缀
        /// </summary>
        public string Prefix
        {
            get { return profix; }
            set { profix = value; }
        }
        /// <summary>
        /// 与数据库基本列BuySetName相对应的公共属性, Caption:购买必需项名称
        /// </summary>
        public string BuySetName
        {
            get { return buysetName; }
            set { buysetName = value; }
        }

        /// <summary>
        /// 与数据库基本列BuySetType相对应的公共属性, Caption:购买必需项类型
        /// </summary>
        /// <remarks></remarks>
        public int BuySetType
        {
            get { return buysetType; }
            set { buysetType = value; }
        }

        /// <summary>
        /// 与数据库基本列BuySetValue相对应的公共属性, Caption:购买必需项值
        /// </summary>
        /// <remarks></remarks>
        public string BuySetValue
        {
            get { return buysetValue; }
            set { buysetValue = value; }
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
