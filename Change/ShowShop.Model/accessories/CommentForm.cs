using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Accessories
{
    public class CommentForm
    {
    #region "member variant"
        private int _id;
		private string _filed;
        private string _datavalue;
		private int? _type;
        private int? _isrequire;
		
        #endregion 
        /// <summary>
        /// 构造一个空的新的数据访问对象
        /// </summary>
        /// <remarks></remarks>
        public CommentForm()
        {
        }
     
        #region 实体信息
        public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 点评项名称
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
		#endregion Model
    }
}
