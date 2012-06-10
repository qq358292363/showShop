using System;
using System.Collections.Generic;
using System.Text;

namespace ShowShop.Model.Product
{
    public class Productclass
    {
        #region "member variant"
        private int _id;
        private int _productTypeId=0;
        private string _name;
        private Nullable<Int32> _fatherid;
        private Nullable<Int32> _sort;
        private string _description = string.Empty;
        private string _parentpath = string.Empty;
        private int _isrecommend;
        private string _sectiontemplate;
        private string _listtemplate;
        private string _contenttemplate;
        
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
        /// 与数据库基本列ProductTypeId相对应的公共属性, Caption:商品类型ID
        /// </summary>
        /// <remarks></remarks>
        public int ProductTypeId
        {
            get { return _productTypeId; }
            set { _productTypeId = value; }
        }
        /// <summary>
        /// 与数据库基本列Isrecommend相对应的公共属性, Caption:Isrecommend
        /// </summary>
        public int Isrecommend
        {
            get { return _isrecommend; }
            set { _isrecommend = value; }
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

        /// <summary>
        /// 与数据库基本列Fatherid相对应的公共属性, Caption:Fatherid
        /// </summary>
        /// <remarks></remarks>
        public Nullable<Int32> Fatherid
        {
            get { return _fatherid; }
            set { _fatherid = value; }
        }
        /// <summary>
        /// 与数据库基本列Sort相对应的公共属性, Caption:Sort
        /// </summary>
        /// <remarks></remarks>
        public Nullable<Int32> Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
        /// <summary>
        /// 与数据库基本列Description相对应的公共属性, Caption:Description
        /// </summary>
        /// <remarks></remarks>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// 与数据库基本列Parentpath相对应的公共属性, Caption:Parentpath
        /// </summary>
        /// <remarks></remarks>
        public string Parentpath
        {
            get { return _parentpath; }
            set { _parentpath = value; }
        }

        public string Sectiontemplate
        {
            get { return _sectiontemplate; }
            set { _sectiontemplate = value; }
        }

        public string Listtemplate
        {
            get { return _listtemplate; }
            set { _listtemplate = value; }
        }

        public string Contenttemplate
        {
            get { return _contenttemplate; }
            set { _contenttemplate = value; }
        }
        #endregion

        #region "Constructor"
        /// <summary>
        /// 构造一个空的新的数据访问对象
        /// </summary>
        /// <remarks></remarks>
        public Productclass()
        {
        }
        #endregion

    }
}
