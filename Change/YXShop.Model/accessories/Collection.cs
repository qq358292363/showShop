using System;
namespace ShowShop.Model.Accessories
{
    /// <summary>
    /// 收藏管理实体类
    /// </summary>
    [Serializable]
    public class Collection
    {
        public Collection()
		{}
		#region Model
		private int id;
		private int? collectiontype;
		private int collectionid;
		private string collectionname;
		private DateTime? collectiondate;
		private int? collectionuid;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int ID
		{
			set{ id=value;}
			get{return id;}
		}
		/// <summary>
		/// 收藏类型
		/// </summary>
		public int? CollectionType
		{
			set{ collectiontype=value;}
			get{return collectiontype;}
		}
		/// <summary>
		/// 收藏的商品ID
		/// </summary>
		public int CollectionId
		{
			set{ collectionid=value;}
			get{return collectionid;}
		}
		/// <summary>
		/// 收藏人登陆账号
		/// </summary>
		public string CollectionName
		{
			set{ collectionname=value;}
			get{return collectionname;}
		}
		/// <summary>
		/// 收藏时间
		/// </summary>
		public DateTime? CollectionDate
		{
			set{ collectiondate=value;}
			get{return collectiondate;}
		}
		/// <summary>
		/// 收藏人ID
		/// </summary>
		public int? CollectionUid
		{
			set{ collectionuid=value;}
			get{return collectionuid;}
		}
		#endregion Model
    }
}
