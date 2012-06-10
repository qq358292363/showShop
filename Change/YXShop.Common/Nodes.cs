using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Common
{
    public class Nodes
    {
        private List<PowerNode> _PowerList;
        public int Count
        {
            get { return _PowerList.Count; }
        }
        public Nodes()
        {
            _PowerList = new List<PowerNode>();
        }
        public Nodes(int maxCount)
        {
            _PowerList = new List<PowerNode>(maxCount);
        }
        public void Add(PowerNode pNode)
        {
            _PowerList.Add(pNode);
        }
        public void AddAd(int index, PowerNode pNode)
        {
            if (index >= 0 && index < this.Count)
            {
                _PowerList.Insert(index, pNode);
            }
        }
        public void Remove(PowerNode pNode)
        {
            _PowerList.Remove(pNode);
        }
        public void RemoveAd(int index)
        {
            if (index >= 0 && index < this.Count)
            {
                _PowerList.RemoveAt(index);
            }
        }
        public void Clear()
        {
            _PowerList.Clear();
        }
        public PowerNode FindNode(Nodes nodes, PowerNode pNode, PowerPath pPath)
        {
            PowerNode reNode = null;
            foreach (PowerNode node in nodes._PowerList)
            {
                if (!string.IsNullOrEmpty(pPath.PathNode3) && node.NodeDepth == 3)
                {
                    if (node.NodeValue != pPath.PathNode3)
                    {
                        continue;
                    }
                }
                else if (!string.IsNullOrEmpty(pPath.PathNode2) && node.NodeDepth == 2)
                {
                    if (node.NodeValue != pPath.PathNode2)
                    {
                        continue;
                    }
                }
                if (node.NodeDepth == pNode.NodeDepth)
                {
                    if (node.NodeText == pNode.NodeText && node.NodeValue == pNode.NodeValue)
                    {
                        reNode = node;
                        break;
                    }
                }
                else if (node.ChildNodes.Count > 0)
                {
                    reNode = FindNode(node.ChildNodes, pNode, pPath);
                    if (reNode != null)
                        break;
                }
            }
            return reNode;
        }
        public PowerNode this[int index]
        {
            get
            {
                PowerNode[] pnArr = _PowerList.ToArray();
                if (index > 0 && index < this.Count)
                {
                    return pnArr[index];
                }
                else
                {
                    return null;
                }
            }
        }
    }
    public class PowerPath
    {
        private string _PathNode3;

        public string PathNode3
        {
            get { return _PathNode3; }
            set { _PathNode3 = _pNode.NodeValue.Substring(0, _pNode.NodeValue.Length - 6) + "000000"; }
        }
        private string _PathNode2;

        public string PathNode2
        {
            get { return _PathNode2; }
            set { _PathNode2 = _pNode.NodeValue.Substring(0, _pNode.NodeValue.Length - 3) + "000"; }
        }
        private string _PathNode1;

        public string PathNode1
        {
            get { return _PathNode1; }
            set { _PathNode1 = _pNode.NodeValue; }
        }
        private PowerNode _pNode;
        public PowerPath(PowerNode pNode)
        {
            _pNode = pNode;
        }
    }
}
