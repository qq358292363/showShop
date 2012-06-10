using System;
namespace ShowShop.Model.Member
{
    /// <summary>
    /// 用户收货地址
    /// </summary>
    [Serializable]
    public class ReceAddress
    {
        public ReceAddress()
        { }
        #region Model
        private int id;
        private int uid;
        private string userid;
        private string username;
        private string mobile;
        private string phone;
        private string fax;
        private string province;
        private string city;
        private string borough;
        private string address;
        private string zip;
        private string email;
        private int stat;
        private string constructionSigns = string.Empty;
        private string consignesTime = string.Empty;
        /// <summary>
        /// 送货时间
        /// </summary>
        public string ConsignesTime
        {
            set { consignesTime = value; }
            get { return consignesTime; }
        }
        /// <summary>
        /// 建筑标志
        /// </summary>
        public string ConstructionSigns
        {
            set { constructionSigns = value; }
            get { return constructionSigns; }
        }
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        /// <summary>
        /// 用户自增ID
        /// </summary>
        public int UID
        {
            set { uid = value; }
            get { return uid; }
        }
        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserId
        {
            set { userid = value; }
            get { return userid; }
        }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string UserName
        {
            set { username = value; }
            get { return username; }
        }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string Mobile
        {
            set { mobile = value; }
            get { return mobile; }
        }
        /// <summary>
        /// 座机
        /// </summary>
        public string Phone
        {
            set { phone = value; }
            get { return phone; }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            set { fax = value; }
            get { return fax; }
        }
        /// <summary>
        /// 省
        /// </summary>
        public string Province
        {
            set { province = value; }
            get { return province; }
        }
        /// <summary>
        /// 市
        /// </summary>
        public string City
        {
            set { city = value; }
            get { return city; }
        }
        /// <summary>
        /// 区
        /// </summary>
        public string Borough
        {
            set { borough = value; }
            get { return borough; }
        }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address
        {
            set { address = value; }
            get { return address; }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        public string Zip
        {
            set { zip = value; }
            get { return zip; }
        }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email
        {
            set { email = value; }
            get { return email; }
        }
        /// <summary>
        /// 状态 0为非默认 1为默认收货地址
        /// </summary>
        public int Stat
        {
            set { stat = value; }
            get { return stat; }
        }
        #endregion Model

    }
}