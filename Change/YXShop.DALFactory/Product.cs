using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Product;

namespace ShowShop.DALFactory
{
    public sealed partial class DataAccess
    {
        /// <summary>
        /// 商品分类
        /// </summary>
        /// <returns></returns>
        public static IProductclass CreateProductcalss()
        {
            return (IProductclass)CreateObject("Product.Productclass");
        }
        /// <summary>
        /// 商品品牌
        /// </summary>
        /// <returns></returns>
        public static IProductBrand CreateProductBrand()
        {
            return (IProductBrand)CreateObject("Product.ProductBrand");
        }
        /// <summary>
        /// 商品属性
        /// </summary>
        /// <returns></returns>
        public static IProductPropery CreateProductPropery()
        {
            return (IProductPropery)CreateObject("Product.ProductProperty");
        }
        /// <summary>
        /// 商品单位
        /// </summary>
        /// <returns></returns>
        public static IProductUnit CreateProductUnit()
        {
            return (IProductUnit)CreateObject("Product.ProductUnit");
        }

        /// <summary>
        /// 商品信息
        /// </summary>
        /// <returns></returns>
        public static IProductInfo CreateProductInfo()
        {
            return (IProductInfo)CreateObject("Product.ProductInfo");
        }
        /// <summary>
        /// 商品相册
        /// </summary>
        /// <returns></returns>
        public static IProductAlbum CreateProductAlbum()
        {
            return (IProductAlbum)CreateObject("Product.ProductAlbum");
        }
 
   
        /// <summary>
        /// 拍卖商品
        /// </summary>
        /// <returns></returns>
        public static IProductAuction CreateProductAuction()
        {
            return (IProductAuction)CreateObject("Product.ProductAuction");
        }
        /// <summary>
        /// 拍卖出价
        /// </summary>
        /// <returns></returns>
        public static IProduct_Auction_Bid CreateProduct_Auction_Bid()
        {
            return (IProduct_Auction_Bid)CreateObject("Product.Product_Auction_Bid");
        }
      
        /// <summary>
        /// 送货方式
        /// </summary>
        /// <returns></returns>
        public static IDeliver CreateDeliver()
        {
            return (IDeliver)CreateObject("Product.Deliver");
        }
        /// <summary>
        /// 快递公司
        /// </summary>
        /// <returns></returns>
        public static IExpress CreateExpress()
        {
            return (IExpress)CreateObject("Product.Express");
        }
        /// <summary>
        /// 浏览
        /// </summary>
        /// <returns></returns>
        public static IScanInfo CreateScanInfo()
        {
            return (IScanInfo)CreateObject("Product.ScanInfo");
        }

        ///// <summary>
        ///// 商品类型
        ///// </summary>
        ///// <returns></returns>
        //public static IProductType CreateProductType()
        //{
        //    return (IProductType)CreateObject("Product.ProductType");
        //}
       
        ///// <summary>
        ///// 商品规格
        ///// </summary>
        ///// <returns></returns>
        //public static IProductSpecification CreateProductSpecification()
        //{
        //    return (IProductSpecification)CreateObject("Product.ProductSpecification");
        //}

        /// <summary>
        /// 商品配件
        /// </summary>
        /// <returns></returns>
        public static IProductSparepart CreateProductSparepart()
        {
            return (IProductSparepart)CreateObject("Product.ProductSparepart");
        }
    }
}
