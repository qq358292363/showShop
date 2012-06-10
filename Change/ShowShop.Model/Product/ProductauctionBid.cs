using System;
namespace ShowShop.Model.Product
{
    /// <summary>
    /// 实体类ProductauctionBid 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ProductauctionBid
    {
        public ProductauctionBid()
        { }
        #region Model
        private int _id;
        private string _uid;
        private string _orderno;
        private int? _product;
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
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string uid
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string orderno
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? product
        {
            set { _product = value; }
            get { return _product; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? datetime
        {
            set { _datetime = value; }
            get { return _datetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? count
        {
            set { _count = value; }
            get { return _count; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? state
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? provinces
        {
            set { _provinces = value; }
            get { return _provinces; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? city
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? borough
        {
            set { _borough = value; }
            get { return _borough; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zip
        {
            set { _zip = value; }
            get { return _zip; }
        }
        #endregion Model

    }
}

