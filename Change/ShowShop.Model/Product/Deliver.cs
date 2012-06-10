using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Product
{
    /// <summary>
    /// 送货方式
    /// </summary>
    [Serializable]
    public class Deliver
    {
        public Deliver()
        {
        }

        #region Model
        private int id;
        private string name;
        private decimal? inceptprice;
        private decimal? inceptweight;
        private int? arrivepay;
        private string description;
        private decimal? addpriceladder;
        private decimal? addweightladder;
        private string boundprice;
        private int? isspecial;
        private int? isused;
        private int? putoutid;
        private int? putouttyid;
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
        /// 配送方式名称
        /// </summary>
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        /// <summary>
        /// 起点价格（单位：元/千克）
        /// </summary>
        public decimal? InceptPrice
        {
            set { inceptprice = value; }
            get { return inceptprice; }
        }
        /// <summary>
        /// 起点重量（单位：千克）
        /// </summary>
        public decimal? InceptWeight
        {
            set { inceptweight = value; }
            get { return inceptweight; }
        }
        /// <summary>
        /// 是否货到付款
        /// </summary>
        public int? ArrivePay
        {
            set { arrivepay = value; }
            get { return arrivepay; }
        }
        /// <summary>
        /// 配送方式描述
        /// </summary>
        public string Description
        {
            set { description = value; }
            get { return description; }
        }
        /// <summary>
        /// 送货加价幅度（例如每增加一千克需要增加的配送费用）
        /// </summary>
        public decimal? AddPriceLadder
        {
            set { addpriceladder = value; }
            get { return addpriceladder; }
        }
        /// <summary>
        /// 商品重量的加价幅度（例如是每增加一千克还是十千克才会增加一个价格等级）
        /// </summary>
        public decimal? AddWeightLadder
        {
            set { addweightladder = value; }
            get { return addweightladder; }
        }
        /// <summary>
        /// 范围价格（例如1到10千克，10到100千克会有不同的送货价格，加价幅度不统一的送货方式，采用数组方式存储，0.01，100|20；100.01，500|30；表示100千克以下20元，100到500千克30元）
        /// </summary>
        public string BoundPrice
        {
            set { boundprice = value; }
            get { return boundprice; }
        }
        /// <summary>
        /// 是否是范围价格 1是 0否
        /// </summary>
        public int? IsSpecial
        {
            set { isspecial = value; }
            get { return isspecial; }
        }
        /// <summary>
        /// 是否启用该配送方式 1 启用 0不启用
        /// </summary>
        public int? IsUsed
        {
            set { isused = value; }
            get { return isused; }
        }
        /// <summary>
        /// 管理员ID
        /// </summary>
        public int? PutoutId
        {
            set { putoutid = value; }
            get { return putoutid; }
        }
        /// <summary>
        /// 会员类型 0是管理员 1是会员
        /// </summary>
        public int? PutouttyId
        {
            set { putouttyid = value; }
            get { return putouttyid; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort
        {
            get { return sort; }
            set { sort = value; }
        }
        #endregion Model
    }
}
