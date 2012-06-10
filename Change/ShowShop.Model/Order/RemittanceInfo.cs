using System;
namespace ShowShop.Model.Order
{
    /// <summary>
    /// 实体类yxs_remittanceinfo 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class RemittanceInfo
    {
        public RemittanceInfo()
        { }

        #region Model
        private int id;
        private string orderid;
        private string username;
        private DateTime? remittancedate;
        private decimal? remittancemoney;
        private int? remintancebank;
        private decimal? presentticket;
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
        /// 客户账号
        /// </summary>
        public string UserName
        {
            set { username = value; }
            get { return username; }
        }
        /// <summary>
        /// 汇款日期
        /// </summary>
        public DateTime? RemittanceDate
        {
            set { remittancedate = value; }
            get { return remittancedate; }
        }
        /// <summary>
        /// 汇款金额
        /// </summary>
        public decimal? RemittanceMoney
        {
            set { remittancemoney = value; }
            get { return remittancemoney; }
        }
        /// <summary>
        /// 汇款银行ID
        /// </summary>
        public int? RemintanceBank
        {
            set { remintancebank = value; }
            get { return remintancebank; }
        }
        /// <summary>
        /// 赠送的多少点券
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
        /// 通知方式
        /// </summary>
        public string InformMode
        {
            set { informmode = value; }
            get { return informmode; }
        }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime? NoteDate
        {
            set { notedate = value; }
            get { return notedate; }
        }
        /// <summary>
        /// 录入人
        /// </summary>
        public string NoteName
        {
            set { notename = value; }
            get { return notename; }
        }
        #endregion Model
    }
}
