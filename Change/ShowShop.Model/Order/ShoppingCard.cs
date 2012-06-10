using System;
namespace ShowShop.Model.Order
{
    /// <summary>
    /// 实体类ShoppingCard 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ShoppingCard
    {
        public ShoppingCard()
        { }
        #region Model
        private int _id;
        private string _proid;
        private string _userid;
        private string _quantity;
        private string _payment;
        private string _paymentzip;
        private string _otherparas;
        private string _remark;
        private DateTime? _shoppingdate;
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
        public string ProId
        {
            set { _proid = value; }
            get { return _proid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Payment
        {
            set { _payment = value; }
            get { return _payment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PaymentZip
        {
            set { _paymentzip = value; }
            get { return _paymentzip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OtherParas
        {
            set { _otherparas = value; }
            get { return _otherparas; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ShoppingDate
        {
            set { _shoppingdate = value; }
            get { return _shoppingdate; }
        }
        #endregion Model

    }
}

