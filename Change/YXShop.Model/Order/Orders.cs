using System;
namespace ShowShop.Model.Order
{
    /// <summary>
    /// 实体类Orders 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Orders
    {
        public Orders()
        { }
        #region Model
        private int _id;
        private string _orderid;
        private string _userid;
        private string _receiverid;
        private DateTime? _shopdate;
        private DateTime? _orderdate;
        private string _consigneerealname;
        private string _consigneename;
        private string _consigneephone;
        private string _consigneeprovince;
        private string _consigneeaddress;
        private string _consigneezip;
        private string _consigneetel;
        private string _consigneefax;
        private string _consigneeemail;
        private string _whethercouandinte;
        private decimal? _parvalueandinte;
        private string _paymenttype;
        private decimal? _payment;
        private decimal? _courier;
        private decimal? _totalprice;
        private decimal? _factprice;
        private int? _invoice;
        private string _remark;
        private int? _orderstatus;
        private string _saleuserid;
        private string _saleusertype;
        private string _businessmanid;
        private decimal? _carriage;
        private int? _paymentstatus;
        private int? _ogisticsstatus;
        private int? _ordertype;
        private int? _isOrderNormal;
        /// <summary>
        /// Id
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 购买者ID
        /// </summary>
        public string UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 该订单接收人员ID。（该项暂时没有用，后续开发中使用）
        /// </summary>
        public string ReceiverId
        {
            set { _receiverid = value; }
            get { return _receiverid; }
        }
        /// <summary>
        /// 购买时间
        /// </summary>
        public DateTime? ShopDate
        {
            set { _shopdate = value; }
            get { return _shopdate; }
        }
        /// <summary>
        /// 下订单时间
        /// </summary>
        public DateTime? OrderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }
        /// <summary>
        /// 收货人真实姓名(订单填写时)
        /// </summary>
        public string ConsigneeRealName
        {
            set { _consigneerealname = value; }
            get { return _consigneerealname; }
        }
        /// <summary>
        /// 购买者姓名
        /// </summary>
        public string ConsigneeName
        {
            set { _consigneename = value; }
            get { return _consigneename; }
        }
        /// <summary>
        /// 收货人电话
        /// </summary>
        public string ConsigneePhone
        {
            set { _consigneephone = value; }
            get { return _consigneephone; }
        }
        /// <summary>
        /// 收货人所在的省市编码
        /// </summary>
        public string ConsigneeProvince
        {
            set { _consigneeprovince = value; }
            get { return _consigneeprovince; }
        }
        /// <summary>
        /// 收货人联系地址
        /// </summary>
        public string ConsigneeAddress
        {
            set { _consigneeaddress = value; }
            get { return _consigneeaddress; }
        }
        /// <summary>
        /// 收货人邮政编码
        /// </summary>
        public string ConsigneeZip
        {
            set { _consigneezip = value; }
            get { return _consigneezip; }
        }
        /// <summary>
        /// 收货人电话
        /// </summary>
        public string ConsigneeTel
        {
            set { _consigneetel = value; }
            get { return _consigneetel; }
        }
        /// <summary>
        /// 收货人传真
        /// </summary>
        public string ConsigneeFax
        {
            set { _consigneefax = value; }
            get { return _consigneefax; }
        }
        /// <summary>
        /// 收货人电子邮件
        /// </summary>
        public string ConsigneeEmail
        {
            set { _consigneeemail = value; }
            get { return _consigneeemail; }
        }
        /// <summary>
        /// 是否使用优惠与积分(0为普通,1为优惠券,2为积分)
        /// </summary>
        public string WhetherCouAndinte
        {
            set { _whethercouandinte = value; }
            get { return _whethercouandinte; }
        }
        /// <summary>
        /// 优惠面值与积分
        /// </summary>
        public decimal? ParvalueAndInte
        {
            set { _parvalueandinte = value; }
            get { return _parvalueandinte; }
        }
        /// <summary>
        /// 支付类型:(2为在线支付,1为银行支付,0预付款支付)
        /// </summary>
        public string PaymentType
        {
            set { _paymenttype = value; }
            get { return _paymenttype; }
        }
        /// <summary>
        /// 付款方式
        /// </summary>
        public decimal? Payment
        {
            set { _payment = value; }
            get { return _payment; }
        }
        /// <summary>
        ///运费
        /// </summary>
        public decimal? Courier
        {
            set { _courier = value; }
            get { return _courier; }
        }
        /// <summary>
        /// 订单价
        /// </summary>
        public decimal? TotalPrice
        {
            set { _totalprice = value; }
            get { return _totalprice; }
        }
        /// <summary>
        /// 实际金额
        /// </summary>
        public decimal? FactPrice
        {
            set { _factprice = value; }
            get { return _factprice; }
        }
        /// <summary>
        /// 发票(0不需发票,1'2....代表发票类型)
        /// </summary>
        public int? Invoice
        {
            set { _invoice = value; }
            get { return _invoice; }
        }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// OrderStatus
        /// </summary>
        public int? OrderStatus
        {
            set { _orderstatus = value; }
            get { return _orderstatus; }
        }
        /// <summary>
        /// 卖家编号
        /// </summary>
        public string SaleUserID
        {
            set { _saleuserid = value; }
            get { return _saleuserid; }
        }
        /// <summary>
        /// 0是管理员,1是个人会员
        /// </summary>
        public string SaleUserType
        {
            set { _saleusertype = value; }
            get { return _saleusertype; }
        }
        /// <summary>
        /// 店铺的ID
        /// </summary>
        public string BusinessmanID
        {
            set { _businessmanid = value; }
            get { return _businessmanid; }
        }
        /// <summary>
        ///  配送方式
        /// </summary>
        public decimal? Carriage
        {
            set { _carriage = value; }
            get { return _carriage; }
        }
        /// <summary>
        /// 付款情况
        /// </summary>
        public int? PaymentStatus
        {
            set { _paymentstatus=value; }
            get {return  _paymentstatus; }
        }
        /// <summary>
        /// 送货状态
        /// </summary>
        public int? OgisticsStatus
        {
            set { _ogisticsstatus = value; }
            get { return _ogisticsstatus; }
        }
        /// <summary>
        /// 订单类型:0普通订单,1拍卖转成订单,2团购转成订单
        /// </summary>
        public int? OrderType
        {
            set { _ordertype = value; }
            get { return _ordertype; }
        }
        /// <summary>
        /// 0表示正常,1表为暂停处理
        /// </summary>
        public int? IsOrderNormal
        {
            set { _isOrderNormal = value; }
            get { return _isOrderNormal; }
        }
        #endregion Model

    }
}

