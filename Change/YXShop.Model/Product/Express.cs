using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Product
{
    /// <summary>
    /// 快递公司
    /// </summary>
    [Serializable]
    public class Express
    {
        public Express()
        {
        }
        #region Model
        private int id;
        private string name;
        private string fullname;
        private string address;
        private string phone;
        private string person;
        private string numstr;
        private int? sort;
        /// <summary>
        /// 主键自增
        /// </summary>
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        /// <summary>
        /// 快递公司名称
        /// </summary>
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        /// <summary>
        /// 公司全称
        /// </summary>
        public string FullName
        {
            set { fullname = value; }
            get { return fullname; }
        }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string Address
        {
            set { address = value; }
            get { return address; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone
        {
            set { phone = value; }
            get { return phone; }
        }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string Person
        {
            set { person = value; }
            get { return person; }
        }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string Numstr
        {
            set { numstr = value; }
            get { return numstr; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort
        {
            set { sort = value; }
            get { return sort; }
        }
        #endregion Model
    }
}
