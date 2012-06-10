using System;
namespace ShowShop.Model.Member
{
    /// <summary>
    /// 实体类MemberAccount 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class MemberAccount
    {
        public MemberAccount()
        { }
        #region Model
        private int _uid;
        private int _usertype;
        private int? _usergroup;
        private string _userid;
        private string _password;
        private string _signed;
        private string _question;
        private string _answer;
        private string _email;
        private int? _state;
        private DateTime? _registerdate;
        private string _registerip;
        private DateTime? _lastlogindate;
        private string _lastloginip;
        private int? _logintimes;
        private decimal? _capital;
        private decimal? _coupons;
        private decimal? _points;
        private DateTime? _periodofvalidity;
        /// <summary>
        /// 
        /// </summary>
        public int UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UserGroup
        {
            set { _usergroup = value; }
            get { return _usergroup; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PassWord
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Signed
        {
            set { _signed = value; }
            get { return _signed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Question
        {
            set { _question = value; }
            get { return _question; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Answer
        {
            set { _answer = value; }
            get { return _answer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RegisterDate
        {
            set { _registerdate = value; }
            get { return _registerdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegisterIP
        {
            set { _registerip = value; }
            get { return _registerip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastLoginDate
        {
            set { _lastlogindate = value; }
            get { return _lastlogindate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastLoginIP
        {
            set { _lastloginip = value; }
            get { return _lastloginip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? LoginTimes
        {
            set { _logintimes = value; }
            get { return _logintimes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Capital
        {
            set { _capital = value; }
            get { return _capital; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Coupons
        {
            set { _coupons = value; }
            get { return _coupons; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Points
        {
            set { _points = value; }
            get { return _points; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PeriodOfValidity
        {
            set { _periodofvalidity = value; }
            get { return _periodofvalidity; }
        }
        #endregion Model

    }
}

