using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Product
{
    [Serializable]
    public class ScanInfo
    {
        public ScanInfo()
        {
        }

        #region model
        private int _id;
        /// <summary>
        /// 主键
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _uid;
        /// <summary>
        /// 浏览用户ID
        /// </summary>
        public int Uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        private int _productId;
        /// <summary>
        /// 浏览商品ID
        /// </summary>
        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }
        private DateTime? _scanTime;
        /// <summary>
        /// 浏览时间
        /// </summary>
        public DateTime? ScanTime
        {
            get { return _scanTime; }
            set { _scanTime = value; }
        }
        #endregion
    }
}
