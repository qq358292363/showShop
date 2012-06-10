using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Product
{
    public class ProductAuction
    {
        #region "member variant"
        private int _id;
        private string _auctionname;
        private string _description;
        private int _productid;
        private DateTime? _starttime;
        private DateTime? _endtime;
        private decimal? _price;
        private decimal? _pricerange;
        private decimal? _deposit;
        private string _productname;
        private int? _putoutid;
        private int? _putouttypeid;
        #endregion

        #region "Constructor"
        /// <summary>
        /// 构造一个空的新的数据访问对象
        /// </summary>
        /// <remarks></remarks>
        public ProductAuction()
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
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 与数据库基本列_auctionname相对应的公共属性, Caption:拍卖名称
        /// </summary>
        public string AuctionName
        {
            get { return _auctionname; }
            set { _auctionname = value; }
        }
        /// <summary>
        /// 与数据库基本列Description相对应的公共属性, Caption:描述
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// 与数据库基本列ProductID相对应的公共属性, Caption:商品ID
        /// </summary>
        public int ProductID
        {
            get { return _productid; }
            set { _productid = value; }
        }
        /// <summary>
        /// 与数据库基本列StartTime相对应的公共属性, Caption:拍卖开始时间
        /// </summary>
        /// <remarks></remarks>
        public DateTime? StartTime
        {
            get { return _starttime; }
            set { _starttime = value; }
        }

        /// <summary>
        /// 与数据库基本列EndTime相对应的公共属性, Caption:拍卖结束时间
        /// </summary>
        /// <remarks></remarks>
        public DateTime? EndTime
        {
            get { return _endtime; }
            set { _endtime = value; }
        }

        /// <summary>
        /// 起拍价
        /// </summary>
        public decimal? Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 加价幅度
        /// </summary>
        public decimal? PriceRange
        {
            set { _pricerange = value; }
            get { return _pricerange; }
        }
        /// <summary>
        /// 保证金
        /// </summary>
        public decimal? Deposit
        {
            set { _deposit = value; }
            get { return _deposit; }
        }
        /// <summary>
        /// 商品名称
        /// 
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 发布人ID
        /// </summary>
        public int? PutoutID
        {
            get { return _putoutid; }
            set { _putoutid = value; }
        }
        /// <summary>
        /// 发布人类型
        /// </summary>
        public int? PutoutTypeID
        {
            get { return _putouttypeid; }
            set { _putouttypeid = value; }
        }
        #endregion
    }
}
