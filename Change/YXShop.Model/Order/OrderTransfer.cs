using System;
namespace ShowShop.Model.Order
{
    [Serializable]
    public class OrderTransfer
    {
        public OrderTransfer()
        { }

        #region Model
        private int id;
        private string orderid;
        private string username;
        private string transfername;
        private decimal? poundage;
        private string poundagepaymentperson;
        private string remark;
        private DateTime? notedate;
        private string notename;
        private DateTime? uptime;
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
        /// 客户名
        /// </summary>
        public string UserName
        {
            set { username = value; }
            get { return username; }
        }
        /// <summary>
        /// 要过单的对象
        /// </summary>
        public string TransferName
        {
            set { transfername = value; }
            get { return transfername; }
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
        /// 手续支付者账号ID
        /// </summary>
        public string PoundAgePayMentPerson
        {
            set { poundagepaymentperson = value; }
            get { return poundagepaymentperson; }
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
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpTime
        {
            set { uptime = value; }
            get { return uptime; }
        }
        #endregion Model
    }
}
