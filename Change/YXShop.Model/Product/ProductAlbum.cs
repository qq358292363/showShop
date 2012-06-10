using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Product
{
    public class ProductAlbum
    {
        #region "member variant"
        private int id;
        private int productid;
        private string thumbnailaddress;
        private string originaladdress;
        private string description;
        private int specificaticationSignId=-1;
        private int isSpecialspecificationsSign=0;
        #endregion

        #region "Constructor"
        /// <summary>
        /// 构造一个空的新的数据访问对象
        /// </summary>
        /// <remarks></remarks>
        public ProductAlbum()
        {
        }
        #endregion

        #region "Property"
        /// <summary>
        /// 与数据库基本列id相对应的公共属性, Caption:id
        /// </summary>
        /// <remarks></remarks>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 与数据库基本列Productid相对应的公共属性, Caption:商品ID
        /// </summary>
        public int Productid
        {
            get { return productid; }
            set { productid = value; }
        }
        /// <summary>
        /// 与数据库基本列ThumbnailAddress相对应的公共属性, Caption:缩略图
        /// </summary>
        /// <remarks></remarks>
        public string ThumbnailAddress
        {
            get { return thumbnailaddress; }
            set { thumbnailaddress = value; }
        }

        /// <summary>
        /// 与数据库基本列OriginalAddress相对应的公共属性, Caption:原图
        /// </summary>
        /// <remarks></remarks>
        public string OriginalAddress
        {
            get { return originaladdress; }
            set { originaladdress = value; }
        }

        /// <summary>
        /// 与数据库基本列Description相对应的公共属性, Caption:描述
        /// </summary>
        /// <remarks></remarks>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// 与数据库基本列SpecificaticationSignId相对应的公共属性, Caption:规格标示
        /// </summary>
        /// <remarks></remarks>
        public int SpecificaticationSignId
        {
            get { return specificaticationSignId; }
            set { specificaticationSignId = value; }
        }

        /// <summary>
        /// 与数据库基本列IsSpecialspecificationsSign相对应的公共属性, Caption:是否是特殊规格
        /// </summary>
        /// <remarks></remarks>
        public int IsSpecialspecificationsSign
        {
            get { return isSpecialspecificationsSign; }
            set { isSpecialspecificationsSign = value; }
        }
        #endregion
    }
}
