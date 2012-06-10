using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Member
{   
    [Serializable]
    public class Integral
    {
        public Integral()
        {
        }
        /// <summary>
        /// 会员积分记录
        /// </summary>
        #region model
        private int _id;
        /// <summary>
        /// ID
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _userid;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }

        private string _orderid;
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderId
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        private int _integralClass;
        /// <summary>
        /// 积分来源(1商品订单,2评论,3登陆)
        /// </summary>
        public int IntegralClass
        {
            get { return _integralClass; }
            set { _integralClass = value; }
        }
        private string _origin = string.Empty;
        /// <summary>
        /// 积分来源内容
        /// </summary>
        public string Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }
        private Nullable<Decimal> _integral;
        /// <summary>
        /// 积分
        /// </summary>
        public Nullable<Decimal> IntegralNum
        {
            get { return _integral; }
            set { _integral = value; }
        }
    
  
        private Nullable<DateTime> _gainDate;
        /// <summary>
        /// 积分获得时间
        /// </summary>
        public Nullable<DateTime> GainDate
        {
            get { return _gainDate; }
            set { _gainDate = value; }
        }
        private Nullable<DateTime> _noteDate;
        /// <summary>
        /// 记录时间
        /// </summary>
        public Nullable<DateTime> NoteDate
        {
            get { return _noteDate; }
            set { _noteDate = value; }
        }
        private string _noteName = string.Empty;
        /// <summary>
        /// 记录人
        /// </summary>
        public string NoteName
        {
            get { return _noteName; }
            set { _noteName = value; }
        }
        private string _remark;     
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        private int _integralStatus;
        /// <summary>
        /// 积分状态(0为增,1为减)
        /// </summary>
        public int IntegralStatus
        {
            get { return _integralStatus; }
            set { _integralStatus = value; }
        }
        #endregion
    }
}
