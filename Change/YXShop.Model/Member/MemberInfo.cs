using System;
namespace ShowShop.Model.Member
{
    /// <summary>
    /// 实体类MemberInfo 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class MemberInfo
    {
        public MemberInfo()
        { }
        #region Model
        private int _uid;
        private int? _privacysettings;
        private string _truename;
        private string _title;
        private string _photo;
        private DateTime? _birthday;
        private string _paperstype;
        private string _papersnumber;
        private string _origin;
        private string _nation;
        private int? _sex;
        private int? _marriage;
        private string _education;
        private string _graduateschool;
        private string _province;
        private string _city;
        private string _borough;
        private string _address;
        private string _zip;
        private string _officephone;
        private string _homephone;
        private string _mobilephone;
        private string _handphone;
        private string _fax;
        private string _personwebsite;
        private string _qq;
        private string _msn;
        private string _icq;
        private string _uc;
        private string _lifehobbies;
        private string _culturehobbies;
        private string _entertainment;
        private string _sportshobbies;
        private string _otherhobbies;
        private string _incname;
        private string _department;
        private string _positions;
        private string _workrange;
        private string _incaddress;
        private string _monthlyincome;
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
        public int? PrivacySettings
        {
            set { _privacysettings = value; }
            get { return _privacysettings; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TrueName
        {
            set { _truename = value; }
            get { return _truename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Photo
        {
            set { _photo = value; }
            get { return _photo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Birthday
        {
            set { _birthday = value; }
            get {return _birthday;   }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PapersType
        {
            set { _paperstype = value; }
            get { return _paperstype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PapersNumber
        {
            set { _papersnumber = value; }
            get { return _papersnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Origin
        {
            set { _origin = value; }
            get { return _origin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Nation
        {
            set { _nation = value; }
            get { return _nation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Marriage
        {
            set { _marriage = value; }
            get { return _marriage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Education
        {
            set { _education = value; }
            get { return _education; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GraduateSchool
        {
            set { _graduateschool = value; }
            get { return _graduateschool; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Borough
        {
            set { _borough = value; }
            get { return _borough; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Zip
        {
            set { _zip = value; }
            get { return _zip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OfficePhone
        {
            set { _officephone = value; }
            get { return _officephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HomePhone
        {
            set { _homephone = value; }
            get { return _homephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MobilePhone
        {
            set { _mobilephone = value; }
            get { return _mobilephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HandPhone
        {
            set { _handphone = value; }
            get { return _handphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PersonWebSite
        {
            set { _personwebsite = value; }
            get { return _personwebsite; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MSN
        {
            set { _msn = value; }
            get { return _msn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ICQ
        {
            set { _icq = value; }
            get { return _icq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UC
        {
            set { _uc = value; }
            get { return _uc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LifeHobbies
        {
            set { _lifehobbies = value; }
            get { return _lifehobbies; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CultureHobbies
        {
            set { _culturehobbies = value; }
            get { return _culturehobbies; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Entertainment
        {
            set { _entertainment = value; }
            get { return _entertainment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SportsHobbies
        {
            set { _sportshobbies = value; }
            get { return _sportshobbies; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OtherHobbies
        {
            set { _otherhobbies = value; }
            get { return _otherhobbies; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IncName
        {
            set { _incname = value; }
            get { return _incname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Department
        {
            set { _department = value; }
            get { return _department; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Positions
        {
            set { _positions = value; }
            get { return _positions; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkRange
        {
            set { _workrange = value; }
            get { return _workrange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IncAddress
        {
            set { _incaddress = value; }
            get { return _incaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MonthlyInCome
        {
            set { _monthlyincome = value; }
            get { return _monthlyincome; }
        }
        #endregion Model

    }
}

