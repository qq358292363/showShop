using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.SystemInfo
{
    public class PostArea
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _deliverymode;

        public int Deliverymode
        {
            get { return _deliverymode; }
            set { _deliverymode = value; }
        }

        private string _areaname;

        public string Areaname
        {
            get { return _areaname; }
            set { _areaname = value; }
        }

        private string _areaid;

        public string Areaid
        {
            get { return _areaid; }
            set { _areaid = value; }
        }

        private float _basicfees;

        public float Basicfees
        {
            get { return _basicfees; }
            set { _basicfees = value; }
        }

        private float _freeamount;

        public float Freeamount
        {
            get { return _freeamount; }
            set { _freeamount = value; }
        }

        private float _CODpayfees;

        public float CODpayfees
        {
            get { return _CODpayfees; }
            set { _CODpayfees = value; }
        }

        private int _feescalculationway;

        public int Feescalculationway
        {
            get { return _feescalculationway; }
            set { _feescalculationway = value; }
        }

        private float _initialfees;
        /// <summary>
        /// 单件商品费用
        /// </summary>
        public float Initialfees
        {
            get { return _initialfees; }
            set { _initialfees = value; }
        }

        private float _overweight;

        public float Overweight
        {
            get { return _overweight; }
            set { _overweight = value; }
        }

        private float _overweight2;

        public float Overweight2
        {
            get { return _overweight2; }
            set { _overweight2 = value; }
        }

        private float _packagingcosts;

        public float Packagingcosts
        {
            get { return _packagingcosts; }
            set { _packagingcosts = value; }
        }

        private int _putouttyid;

        public int Putouttyid
        {
            get { return _putouttyid; }
            set { _putouttyid = value; }
        }

        private int _putoutid;

        public int Putoutid
        {
            get { return _putoutid; }
            set { _putoutid = value; }
        }
    }
}
