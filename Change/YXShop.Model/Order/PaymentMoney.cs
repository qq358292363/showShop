using System;
namespace ShowShop.Model.Order
{
    [Serializable]
    public class PaymentMoney
    {
        public PaymentMoney()
        {
        }
        #region Model
        private int id;
        private string orderid;
        private string username;
        private DateTime? gatheringdate;
        private decimal? gatheringmoney;
        private decimal? presentticket;
        private string remark;
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
        /// 下单人
        /// </summary>
        public string UserName
        {
            set { username = value; }
            get { return username; }
        }
        /// <summary>
        /// 收款日期
        /// </summary>
        public DateTime? GatheringDate
        {
            set { gatheringdate = value; }
            get { return gatheringdate; }
        }
        /// <summary>
        /// 收款金额
        /// </summary>
        public decimal? GatheringMoney
        {
            set { gatheringmoney = value; }
            get { return gatheringmoney; }
        }
        /// <summary>
        /// 送点券(默认为0)
        /// </summary>
        public decimal? PresentTicket
        {
            set { presentticket = value; }
            get { return presentticket; }
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
        /// 记录时间
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
