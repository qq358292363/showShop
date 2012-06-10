using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Accessories
{
    public class Top_Searches
    {
         #region "member variant"
        private int id;
        private int sort;
        private string name;
        private int isshow;
        #endregion

        #region "Constructor"
        /// <summary>
        /// 构造一个空的新的数据访问对象
        /// </summary>
        /// <remarks></remarks>
        public Top_Searches()
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
        /// 与数据库基本列sort相对应的公共属性, Caption:排序
        /// </summary>
        public int Sort
        {
            get { return sort; }
            set { sort = value; }
        }
        /// <summary>
        /// 与数据库基本列name相对应的公共属性, Caption:名称
        /// </summary>
        /// <remarks></remarks>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 与数据库基本列Images相对应的公共属性, Caption:是否显示
        /// </summary>
        /// <remarks></remarks>
        public int IsShow
        {
            get { return isshow; }
            set {isshow = value; }
        }

        #endregion
    }
}
