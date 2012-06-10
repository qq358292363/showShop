using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.SystemInfo
{
    public class Navigation
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _type;//导航类别

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _filed;//名称

        public string Filed
        {
            get { return _filed; }
            set { _filed = value; }
        }
        private string _contentregion;//系统内容

        public string Contentregion
        {
            get { return _contentregion; }
            set { _contentregion = value; }
        }
        private string _link;//链接

        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }
        private int _sort;//排序

        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
        private int _isshow;//是否显示

        public int Isshow
        {
            get { return _isshow; }
            set { _isshow = value; }
        }
        private int _isnewwindow;//是否新窗口

        public int Isnewwindow
        {
            get { return _isnewwindow; }
            set { _isnewwindow = value; }
        }
        private int _part;//位置 1代表页眉顶部、2代表页眉处、3代表页脚

        public int Part
        {
            get { return _part; }
            set { _part = value; }
        }

    }
}
