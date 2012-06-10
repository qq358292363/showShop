using System;
namespace ShowShop.Model.Order
{
    [Serializable]
    public class RefundMent
    {
        public RefundMent()
        { }

        #region Model
        private int id;
        private string orderid;
        private string username;
        private DateTime? paymentdate;
        private decimal? poundage;
        private decimal? refundmentmoney;
        private string refundmentmode;
        private string remark;
        private string informmode;
        private DateTime? notedate;
        private string notename;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId
        {
            set { orderid = value; }
            get { return orderid; }
        }
        /// <summary>
        /// 收货人
        /// </summary>
        public string UserName
        {
            set { username = value; }
            get { return username; }
        }
        /// <summary>
        /// 退款时间
        /// </summary>
        public DateTime? PaymentDate
        {
            set { paymentdate = value; }
            get { return paymentdate; }
        }
        /// <summary>
        /// 手续费
        /// </summary>
        public decimal? PoundAge
        {
            set { poundage = value; }
            get { return poundage; }
        }
        /// <summary>
        /// 退款金额
        /// </summary>
        public decimal? RefundMentMoney
        {
            set { refundmentmoney = value; }
            get { return refundmentmoney; }
        }
        /// <summary>
        /// 退款方式
        /// </summary>
        public string RefundMentMode
        {
            set { refundmentmode = value; }
            get { return refundmentmode; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { remark = value; }
            get { return remark; }
        }
        /// <summary>
        /// 通知方式
        /// </summary>
        public string InformMode
        {
            set { informmode = value; }
            get { return informmode; }
        }
        /// <summary>
        /// 记录日期
        /// </summary>
        public DateTime? NoteDate
        {
            set { notedate = value; }
            get { return notedate; }
        }
        /// <summary>
        /// 记录人
        /// </summary>
        public string NoteName
        {
            set { notename = value; }
            get { return notename; }
        }
        #endregion Model
    }
}
