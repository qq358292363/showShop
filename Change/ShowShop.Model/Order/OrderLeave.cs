using System;
namespace ShowShop.Model.Order
{
    [Serializable]
    public class OrderLeave
    {
        public OrderLeave()
        { }

        #region Model
        private int id;
        private int? memberid;
        private string orderid;
        private string content;
        private DateTime? createdate;
        private int? state;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        /// <summary>
        /// 会员ID
        /// </summary>
        public int? MemberId
        {
            set { memberid = value; }
            get { return memberid; }
        }
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderId
        {
            set { orderid = value; }
            get { return orderid; }
        }
        /// <summary>
        /// 留言内容
        /// </summary>
        public string Content
        {
            set { content = value; }
            get { return content; }
        }
        /// <summary>
        ///  时间(是回复则是回复时间,是发送则是发送时间)
        /// </summary>
        public DateTime? CreateDate
        {
            set { createdate = value; }
            get { return createdate; }
        }
        /// <summary>
        /// 状态是(0代表后台回复件 ,1代表会员发送件)
        /// </summary>
        public int? State
        {
            set { state = value; }
            get { return state; }
        }
        #endregion Model
    }
}
