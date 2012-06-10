using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.OrderCard
{
    public class OrderCardInfo 
    {
        #region "member variant"
        private int id;
        private Nullable<Int32> productid;
        private int iswebsitersale;
        private string type;
        private string cardnumber;
        private string password;
        private Nullable<Decimal> facevalue;
        private string point;
        private string unit;
        private Nullable<DateTime> expirationdate;
        private string businessagent;
        private Nullable<DateTime> createdate;
        private Nullable<DateTime> updatedate;
        private int appearance;
        private Nullable<Decimal> price;
        private Nullable<Int32> whetherrelease;
        private string username;
        private Nullable<DateTime> fullmoneydate;
        #endregion

        #region "Constructor"
        /// <summary>
        /// 构造一个空的新的数据访问对象
        /// </summary>
        /// <remarks></remarks>
        public OrderCardInfo()
        {
        }

        #endregion

        #region "Property"
        /// <summary>
        /// 与数据库基本列ID相对应的公共属性, Caption:ID
        /// </summary>
        /// <remarks></remarks>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 与数据库基本列ProductID相对应的公共属性, Caption:商品ID
        /// </summary>
        public Nullable<Int32> ProductID
        {
            get { return productid; }
            set { productid = value; }
        }
        /// <summary>
        ///  与数据库基本列IsWhetherSale相对应的公共属性, Caption:是否本站充值卡
        /// </summary>
        public int IsWhetherSale
        {
            get { return iswebsitersale; }
            set { iswebsitersale = value; }
        }
        /// <summary>
        /// 与数据库基本列Type相对应的公共属性, Caption:充值卡类型
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        /// <summary>
        /// 与数据库基本列CardNumber相对应的公共属性, Caption:卡号
        /// </summary>
        public string CardNumber
        {
            get
            {
                return cardnumber;
            }
            set
            {
                cardnumber = value;
            }
        }
        /// <summary>
        /// 与数据库基本列Password相对应的公共属性, Caption:密码加密
        /// </summary>
        TryCode.SymmetricMethod pw = new TryCode.SymmetricMethod();
        public string Password
        {
            get
            {
                return pw.EnCode(password);
            }
            set
            {
                password = value;
            }
        }
        public string JOCW_Password
        {
            get
            {
                return pw.DeCode(password);
            }
            set
            {
                password = value;
            }
        }
        /// <summary>
        /// 与数据库基本列FaceValue相对应的公共属性, Caption:面值
        /// </summary>
        public Nullable<Decimal> FaceValue
        {
            get { return facevalue; }
            set { facevalue = value; }
        }
        /// <summary>
        /// 与数据库基本列Point相对应的公共属性, Caption:Point
        /// </summary>
        public string Point
        {
            get { return point; }
            set { point = value; }
        }
        /// <summary>
        /// 与数据库基本列Unit相对应的公共属性, Caption:Unit
        /// </summary>
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        /// <summary>
        /// 与数据库基本列ExpirationDate相对应的公共属性, Caption:截止日期
        /// </summary>
        public Nullable<DateTime> ExpirationDate
        {
            get
            {
                return expirationdate;
            }
            set
            {
                expirationdate = value;
            }
        }
        /// <summary>
        /// 与数据库基本列BusinessAgent相对应的公共属性, Caption:代理商家
        /// </summary>
        public string BusinessAgent
        {
            get
            {
                return businessagent;
            }
            set
            {
                businessagent = value;
            }
        }
        /// <summary>
        /// 与数据库基本列CreateDate相对应的公共属性, Caption:创建日期
        /// </summary>
        public Nullable<DateTime> CreateDate
        {
            get
            {
                return createdate;
            }
            set
            {
                createdate = value;
            }
        }
        /// <summary>
        /// 与数据库基本列Price相对应的公共属性, Caption:出售价格
        /// </summary>
        public Nullable<Decimal> Price
        {
            get { return price; }
            set { price = value; }
        }
        /// <summary>
        /// 与数据库基本列WhetherRelease相对应的公共属性, Caption:状态
        /// </summary>
        public Nullable<Int32> WhetherRelease
        {
            get { return whetherrelease; }
            set { whetherrelease = value; }
        }

        public int Appearance
        {
            get { return appearance; }
            set { appearance = value; }
        }

        public Nullable<DateTime> UpdateDate
        {
            get { return updatedate; }
            set { updatedate = value; }
        }
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public Nullable<DateTime> FullMoneyDate
        {
            get { return fullmoneydate; }
            set { fullmoneydate = value; }
        }
        #endregion
        
    }
}
