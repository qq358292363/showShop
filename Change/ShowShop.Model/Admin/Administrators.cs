using System;
namespace ShowShop.Model.Admin
{
    /// <summary>
    /// 实体类Administrators 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Administrators
    {
        public Administrators()
        { }
        #region Model
        private int _adminid;
        private string _name;
        private string _password;
        private int? _state;
        private DateTime? _managebegintime;
        private DateTime? _manageendtime;
        private int? _power;
        private int? _allowmodifypassword;
        private string _role;
        /// <summary>
        /// 
        /// </summary>
        public int AdminId
        {
            set { _adminid = value; }
            get { return _adminid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
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
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ManageBeginTime
        {
            set { _managebegintime = value; }
            get { return _managebegintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ManageEndTime
        {
            set { _manageendtime = value; }
            get { return _manageendtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Power
        {
            set { _power = value; }
            get { return _power; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? AllowModifyPassWord
        {
            set { _allowmodifypassword = value; }
            get { return _allowmodifypassword; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Role
        {
            set { _role = value; }
            get { return _role; }
        }
        #endregion Model

    }
}

