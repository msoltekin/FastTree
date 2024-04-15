using System.Collections.Generic;

namespace FastTree
{
    public class TreeManager
    {
        private readonly TreeNode rootNode;
        private readonly List<TreeLevel> levelList;
        
        public int FoundItemCount { get; set; }

        public TreeManager()
        {
            FoundItemCount = 0;
            rootNode = new TreeNode();
            levelList = new List<TreeLevel>();
        }
            
        public void AddItem(string item)
        {
            if (string.IsNullOrEmpty(item))
                return;

            var activeNode = rootNode;
            var charArr = item.ToCharArray();
            for (int i = 0; i < charArr.Length; i++)
            {
                var activeItem = (byte)charArr[i];
                //level process
                if (levelList.Count < i + 1)  //extend list 
                {
                    for (int y = levelList.Count; y < i + 1; y++)
                    {
                        levelList.Add(new TreeLevel());
                    }
                }

                var activeLevel = levelList[i];
                var nodeIndex = activeLevel.InsertItemToMap(activeItem);

                //node process
                if (activeNode.ChildNodes.Count < nodeIndex + 1) //extend node list to node index
                {
                    for (int y = activeNode.ChildNodes.Count; y < nodeIndex + 1; y++)
                    {
                        activeNode.ChildNodes.Add(new TreeNode());
                    }
                }

                activeNode = activeNode[nodeIndex];
                activeNode.NodeValue = activeItem;
                activeNode.IsDataNode = i == charArr.Length - 1;
            }
        }

        public void SearchItem(string item)
        {
            if (string.IsNullOrEmpty(item))
                return;

            TreeNode currentNode = rootNode;
            for (int i = 0; i < item.Length; i++)
            {
                var currentByte = (byte)item[i];
                var currentLevel = levelList[i];
                var currentIndexAtLevel = currentLevel[currentByte];
                if (currentIndexAtLevel == -1 || currentNode.ChildNodes.Count <= currentIndexAtLevel)
                    return;

                currentNode = currentNode[currentIndexAtLevel];

                if (i == item.Length - 1 && currentNode.IsDataNode && !currentNode.Found && currentNode.NodeValue == currentByte)
                {
                    currentNode.Found = true;
                    FoundItemCount++;
                    return;
                }
            }
        }
    }
}
