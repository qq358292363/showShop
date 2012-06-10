using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Product
{
    public class productproperty
    {
        #region "member variant"
        private int _id;
		private string _cid;
		private string _filed;
        private string _datavalue;
		private int? _type;
        private int? _isrequire;
		private int? _sort;
		
        #endregion 
        /// <summary>
        /// 构造一个空的新的数据访问对象
        /// </summary>
        /// <remarks></remarks>
        public productproperty()
        {
        }
     
        #region 实体信息
        public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 商品分类ID
		/// </summary>
		public string CID
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 属性名称
		/// </summary>
		public string Filed
		{
			set{ _filed=value;}
			get{return _filed;}
		}
		/// <summary>
		/// 属性值
		/// </summary>
        public string Datavalue
		{
            set { _datavalue = value; }
            get { return _datavalue; }
		}
		/// <summary>
		/// 属性类型（1、下拉列表；2、单选；3、多选；4、手动填写）
		/// </summary>
		public int? Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 是否必填
		/// </summary>
        public int? IsRequire
		{
            set { _isrequire = value; }
            get { return _isrequire; }
		}
		/// <summary>
		/// 显示顺序
		/// </summary>
		public int? Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		#endregion Model
    }
}
