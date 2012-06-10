using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.SystemInfo
{
    /// <summary>
    /// 送货方式
    /// </summary>
    public class Deliver
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 配送名称
        /// </summary>
        private string _distributionname;

        public string Distributionname
        {
            get { return _distributionname; }
            set { _distributionname = value; }
        }
        /// <summary>
        /// 配送描述
        /// </summary>
        private string _distributiondescription;

        public string Distributiondescription
        {
            get { return _distributiondescription; }
            set { _distributiondescription = value; }
        }
        /// <summary>
        /// 保价费用
        /// </summary>
        private float _insuredcosts;

        public float Insuredcosts
        {
            get { return _insuredcosts; }
            set { _insuredcosts = value; }
        }
        /// <summary>
        /// 是否货到付款
        /// </summary>
        private int _isCOD;

        public int IsCOD
        {
            get { return _isCOD; }
            set { _isCOD = value; }
        }
        /// <summary>
        /// 作者
        /// </summary>
        private string _author;

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        /// <summary>
        /// 版本
        /// </summary>
        private string _Version;

        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        /// <summary>
        /// 是否已安装
        /// </summary>
        private int _isinstallation;

        public int Isinstallation
        {
            get { return _isinstallation; }
            set { _isinstallation = value; }
        }
    }
}
