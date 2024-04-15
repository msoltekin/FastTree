using System.Collections.Generic;

namespace FastTree
{
    public class TreeNode
    {
        public TreeNode()
        {
            Initialize();
        }

        public TreeNode(byte nodeValue)
        {
            NodeValue = nodeValue;
            Initialize();
        }

        private void Initialize()
        {
            ChildNodes = new List<TreeNode>();
            IsDataNode = false;
            Found = false;
        }

        public TreeNode this[short key]
        {
            get => ChildNodes[key];
            set => ChildNodes[key] = value;
        }

        public bool Found { get; set; }
        public bool IsDataNode { get; set; }
        public byte NodeValue { get; set; }
        public List<TreeNode> ChildNodes { get; private set; }
    }
}
