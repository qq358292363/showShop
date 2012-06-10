using System;
namespace ShowShop.Model.Order
{
    [Serializable]
    public class InvoiceItem
    {
        public InvoiceItem()
        { }

        #region Model
        private int id;
        private string orderid;
        private string username;
        private DateTime? invoicedate;
        private string invoicecontent;
        private decimal? invoicemoney;
        private string invoicename;
        private string invoicetype;
        private string invoicenumber;
        private string invoicerise;
        private string bosomnote;
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
        /// 客户名
        /// </summary>
        public string UserName
        {
            set { username = value; }
            get { return username; }
        }
        /// <summary>
        /// 开票时间
        /// </summary>
        public DateTime? InvoiceDate
        {
            set { invoicedate = value; }
            get { return invoicedate; }
        }
        /// <summary>
        /// 发票内容
        /// </summary>
        public string InvoiceContent
        {
            set { invoicecontent = value; }
            get { return invoicecontent; }
        }
        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal? InvoiceMoney
        {
            set { invoicemoney = value; }
            get { return invoicemoney; }
        }
        /// <summary>
        /// 开票人
        /// </summary>
        public string InvoiceName
        {
            set { invoicename = value; }
            get { return invoicename; }
        }
        /// <summary>
        /// 发票类型
        /// </summary>
        public string InvoiceType
        {
            set { invoicetype = value; }
            get { return invoicetype; }
        }
        /// <summary>
        /// 票号
        /// </summary>
        public string InvoiceNumber
        {
            set { invoicenumber = value; }
            get { return invoicenumber; }
        }
        /// <summary>
        /// 发票抬头
        /// </summary>
        public string InvoiceRise
        {
            set { invoicerise = value; }
            get { return invoicerise; }
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
        /// 通知方法
        /// </summary>
        public string InformMode
        {
            set { informmode = value; }
            get { return informmode; }
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
