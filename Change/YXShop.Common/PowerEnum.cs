using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Common
{
    public class PowerEnum
    {
         //查看,增加,修改,删除,增加和删除,增加和修改,修改和删除,所有,其它
        public enum PowerType { add, update, look, del, deladd, delupdate, updateadd, all, other }
        public PowerEnum() 
        {
            
        }
        private Nodes _PNodes;

        public Nodes PNodes
        {
            get {
                if (_PNodes == null) 
                {
                    _PNodes = new Nodes();
                }
                return _PNodes;
            }
            set { _PNodes = value; }
        }
        public PowerNode FindNode(PowerNode pNode)
        {
            return _PNodes.FindNode(this.PNodes, pNode, new PowerPath(pNode));
        }
        ~PowerEnum() 
        {
            _PNodes = null;
        }
    }
}
