using System;
namespace ShowShop.Model.SystemInfo
{
    /// <summary>
    /// 实体类Provinces 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Provinces
    {
        public Provinces()
        { }
        #region Model
        private int _id;
        private string _cityname;
        private string _cityenglishname;
        private int? _parentid;
        private string _parentpath;
        private int? _depth;
        private int? _orderid;
        private int? _child;
        private int? _isuse;
        private DateTime? _adddate;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CityName
        {
            set { _cityname = value; }
            get { return _cityname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CityEnglishName
        {
            set { _cityenglishname = value; }
            get { return _cityenglishname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ParentId
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParentPath
        {
            set { _parentpath = value; }
            get { return _parentpath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Depth
        {
            set { _depth = value; }
            get { return _depth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Child
        {
            set { _child = value; }
            get { return _child; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsUse
        {
            set { _isuse = value; }
            get { return _isuse; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        #endregion Model

    }
}

