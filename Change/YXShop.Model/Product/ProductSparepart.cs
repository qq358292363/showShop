using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Product
{
    public class ProductSparepart
    {
        #region "member variant"
        private int _id;
        private int _productid;
        private string _sparepartname;
        private int _buymincount;
        private int _buymaxcount;
        private int _favourabletype;
        private decimal _favourablelimit;
        private string _sparepartproduct;
        #endregion

        #region "Constructor"
        /// <summary>
        /// 构造一个空的新的数据访问对象
        /// </summary>
        /// <remarks></remarks>
        public ProductSparepart()
        {
        }
        #endregion

        #region "Property"
        /// <summary>
        /// 与数据库基本列Id相对应的公共属性, Caption:Id
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 与数据库基本列ProductId相对应的公共属性, Caption:商品ID
        /// </summary>
        public int ProductId
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 与数据库基本列SparepartName相对应的公共属性, Caption:配件组名称
        /// </summary>
        public string SparepartName
        {
            set { _sparepartname = value; }
            get { return _sparepartname; }
        }
        /// <summary>
        /// 与数据库基本列BuyMinCount相对应的公共属性, Caption:购买最小数量
        /// </summary>
        public int BuyMinCount
        {
            set { _buymincount = value; }
            get { return _buymincount; }
        }
        /// <summary>
        /// 与数据库基本列BuyMaxCount相对应的公共属性, Caption:购买最大数量
        /// </summary>
        public int BuyMaxCount
        {
            set { _buymaxcount = value; }
            get { return _buymaxcount; }
        }
        /// <summary>
        /// 与数据库基本列FavourableType相对应的公共属性, Caption:配件优惠
        /// </summary>
        public int FavourableType
        {
            set { _favourabletype = value; }
            get { return _favourabletype; }
        }
        /// <summary>
        /// 与数据库基本列FavourableLimit相对应的公共属性, Caption:优惠额度
        /// </summary>
        public decimal FavourableLimit
        {
            set { _favourablelimit = value; }
            get { return _favourablelimit; }
        }
        /// <summary>
        /// 与数据库基本列FavourableLimit相对应的公共属性, Caption:配件商品
        /// </summary>
        public string SparepartProduct
        {
            set { _sparepartproduct = value; }
            get { return _sparepartproduct; }
        }
        #endregion

    }
}
