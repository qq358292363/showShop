using System;
namespace ShowShop.Model.Product
{
    /// <summary>
    /// 实体类ProductInfo 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ProductInfo
    {
        public ProductInfo()
        { }
        /// <summary>
        /// pro_ID
        /// </summary>
        public int ProductID { set; get; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProductNo { set; get; }
        /// <summary>
        ///商品名称
        /// </summary>
        public string ProductName { set; get; }
        /// <summary>
        /// 商品附加名称
        /// </summary>
        public string ProductAttachName { set; get; }
        /// <summary>
        /// 商品分类ID
        /// </summary>
        public int ClassID { set; get; }
        /// <summary>
        /// 商品品牌ID
        /// </summary>
        public int BrandID{  set; get; }
        /// <summary>
        /// 商城价
        /// </summary>
        public decimal ShopPrice{set;get;}
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal MarketPrice{set;get;}
        /// <summary>
        /// 缩略图
        /// </summary>
        public string Thumbnail{set;get;}
        /// <summary>
        /// 商品单位
        /// </summary>
        public string Unit {set; get; }
        /// <summary>
        /// 商品简介
        /// </summary>
        public string Synopsis{set;get;}
        /// <summary>
        /// 商品详细内容
        /// </summary>
        public string ProductContent { set; get; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime{set;get;}
        /// <summary>
        ///修改时间
        /// </summary>
        public DateTime UpdateTime{set;get;}
        /// <summary>
        /// 上架时间
        /// </summary>
        public DateTime AutoUp{set;get;}
        /// <summary>
        /// 下架时间
        /// </summary>
        public DateTime AutoDown{set;get;}
         /// <summary>
        /// 是否上下架
        /// </summary>
           public int IsAuto{set;get;}
    }
}

