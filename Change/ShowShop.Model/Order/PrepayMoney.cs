using System;
namespace ShowShop.Model.Order
{
    [Serializable]
    public class PrepayMoney
    {
        public PrepayMoney()
        { }

        #region Model
        private int id;
        private string orderid;
        private string username;
        private decimal? payoutmoney;
        private string remark;
        private string bosomnote;
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
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { username = value; }
            get { return username; }
        }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal? PayoutMoney
        {
            set { payoutmoney = value; }
            get { return payoutmoney; }
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
        /// 内部记录
        /// </summary>
        public string BosomNote
        {
            set { bosomnote = value; }
            get { return bosomnote; }
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
