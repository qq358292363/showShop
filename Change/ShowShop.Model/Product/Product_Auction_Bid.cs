using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ShowShop.Model.Product
{
    /// <summary>
    /// 实体类ProductauctionBid 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Product_Auction_Bid
    {
        #region "Constructor"
        /// <summary>
        /// 构造一个空的新的数据访问对象
        /// </summary>
        /// <remarks></remarks>
        public Product_Auction_Bid()
        { }
        #endregion

        #region "member variant"
        private int _id;
        private string _uid;
        private string _orderno;
        private int? _productid;
        private decimal? _price;
        private DateTime? _datetime;
        private int? _count;
        private int? _state;
        private int? _provinces;
        private int? _city;
        private int? _borough;
        private string _address;
        private string _tel;
        private string _phone;
        private string _zip;
        private string _username;
        #endregion

        #region "Property"
        /// <summary>
        /// 与数据库基本列id相对应的公共属性, Caption:id
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 与数据库基本列uid相对应的公共属性, Caption:用户ID
        /// </summary>
        public string uid
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 与数据库基本列orderno相对应的公共属性, Caption:订单号
        /// </summary>
        public string orderno
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        /// <summary>
        /// 与数据库基本列productid相对应的公共属性, Caption:商品ID
        /// </summary>
        public int? productid
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 与数据库基本列price相对应的公共属性, Caption:出价金额
        /// </summary>
        public decimal? price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 与数据库基本列datetime相对应的公共属性, Caption:出价时间
        /// </summary>
        public DateTime? datetime
        {
            set { _datetime = value; }
            get { return _datetime; }
        }
        /// <summary>
        /// 与数据库基本列count相对应的公共属性, Caption:数量
        /// </summary>
        public int? count
        {
            set { _count = value; }
            get { return _count; }
        }
        /// <summary>
        /// 与数据库基本列state相对应的公共属性, Caption:状态
        /// </summary>
        public int? state
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 与数据库基本列provinces相对应的公共属性, Caption:省份ID
        /// </summary>
        public int? provinces
        {
            set { _provinces = value; }
            get { return _provinces; }
        }
        /// <summary>
        /// 与数据库基本列city相对应的公共属性, Caption:市ID
        /// </summary>
        public int? city
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 与数据库基本列borough相对应的公共属性, Caption:区ID
        /// </summary>
        public int? borough
        {
            set { _borough = value; }
            get { return _borough; }
        }
        /// <summary>
        /// 与数据库基本列address相对应的公共属性, Caption:街道详细地址
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 与数据库基本列tel相对应的公共属性, Caption:联系电话
        /// </summary>
        public string tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 与数据库基本列phone相对应的公共属性, Caption:联系手机
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 与数据库基本列zip相对应的公共属性, Caption:邮编
        /// </summary>
        public string zip
        {
            set { _zip = value; }
            get { return _zip; }
        }
        /// <summary>
        /// 与数据库基本列username相对应的公共属性, Caption:收货人
        /// </summary>
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        #endregion Model

    }
}


