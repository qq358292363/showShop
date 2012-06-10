using System;
namespace ShowShop.Model.Order
{
    /// <summary>
    /// 实体类OrderProduct 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class OrderProduct
    {
        public OrderProduct()
        { }
        #region Model
        private int _id;
        private int? _orderid;
        private int? _proid;
        private string _proclass;
        private string _proname;
        private string _proimg;
        private decimal? _proprice;
        private decimal? _pronum;
        private DateTime? _addtime;
        private string _prootherpara;
        private string specification;
        private string fittingsProductId;
        private string fittingsProductCount;
        private string fittingsProductPrice;
        private int fittingsId;
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
        public int? OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProId
        {
            set { _proid = value; }
            get { return _proid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProClass
        {
            set { _proclass = value; }
            get { return _proclass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProName
        {
            set { _proname = value; }
            get { return _proname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProImg
        {
            set { _proimg = value; }
            get { return _proimg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ProPrice
        {
            set { _proprice = value; }
            get { return _proprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ProNum
        {
            set { _pronum = value; }
            get { return _pronum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProOtherPara
        {
            set { _prootherpara = value; }
            get { return _prootherpara; }
        }


        /// <summary>
        /// 
        /// </summary>
        public string Specification
        {
            set { specification = value; }
            get { return specification; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string FittingsProductId
        {
            set { fittingsProductId = value; }
            get { return fittingsProductId; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string FittingsProductCount
        {
            set { fittingsProductCount = value; }
            get { return fittingsProductCount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string FittingsProductPrice
        {
            set { fittingsProductPrice = value; }
            get { return fittingsProductPrice; }
        }

        public int FittingsId
        {
            set { fittingsId = value; }
            get { return fittingsId; }
        }
        #endregion Model

    }
}

