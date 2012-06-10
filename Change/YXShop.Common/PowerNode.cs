using System;
using System.Collections.Generic;
using System.Text;

namespace ShowShop.Common
{
    public class PowerNode
    {
        public PowerNode(string nodeValue, string nodeText, int nodeDepth)
        {
            this._NodeValue = nodeValue;
            this._NodeText = nodeText;
            this._NodeDepth = nodeDepth;
        }
        private Nodes _ChildNodes;

        public Nodes ChildNodes
        {
            get
            {
                if (_ChildNodes == null)
                {
                    _ChildNodes = new Nodes();
                }
                return _ChildNodes;
            }
        }
        private PowerNode _ParNode;

        public PowerNode ParNode
        {
            get { return _ParNode; }
            set { _ParNode = value; }
        }
        private int _NodeDepth;

        public int NodeDepth
        {
            get { return _NodeDepth; }
        }

        private string _NodeValue;

        public string NodeValue
        {
            get { return _NodeValue; }
        }
        private string _NodeText;

        public string NodeText
        {
            get { return _NodeText; }
        }
    }
}
