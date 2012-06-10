using System;
namespace ShowShop.Model.Order
{
    [Serializable]
    public class ConsignMent
    {
        public ConsignMent()
        { }

        #region Model
        private int id;
        private string orderid;
        private string username;
        private DateTime? consignmentdate;
        private string expresscompany;
        private string expressoddnumbers;
        private string consignmentpeople;
        private string remark;
        private string bosomnote;
        private string informmode;
        private DateTime? notedate;
        private string notename;
        private int? received;
        private int? consignmenttype;
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
        /// 发货日期
        /// </summary>
        public DateTime? ConsignMentDate
        {
            set { consignmentdate = value; }
            get { return consignmentdate; }
        }
        /// <summary>
        /// 快递公司
        /// </summary>
        public string ExpressCompany
        {
            set { expresscompany = value; }
            get { return expresscompany; }
        }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string ExpressOddNumbers
        {
            set { expressoddnumbers = value; }
            get { return expressoddnumbers; }
        }
        /// <summary>
        /// 经手人
        /// </summary>
        public string ConsignMentPeople
        {
            set { consignmentpeople = value; }
            get { return consignmentpeople; }
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
        /// <summary>
        /// 是否签收 0未签收 1已签收
        /// </summary>
        public int? Received
        {
            set { received = value; }
            get { return received; }
        }
        /// <summary>
        /// 是发货 0   还是退货 1
        /// </summary>
        public int? ConsignMentType
        {
            set { consignmenttype = value; }
            get { return consignmenttype; }
        }
        #endregion Model

    }
}
