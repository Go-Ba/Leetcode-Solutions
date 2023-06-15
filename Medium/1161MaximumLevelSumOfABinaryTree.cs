using System.Collections.Generic;
using System.Linq;

public class MaximumLevelSumOfABinaryTree
{
    //https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree/
    public class Solution_Queue
    {
        public int MaxLevelSum(TreeNode root)
        {
            Queue<TreeNode> layerQueue = new Queue<TreeNode>();
            int bestSum = int.MinValue, bestLayer = 0, currentLayer = 0;
            int currentSum, loopCount;
            layerQueue.Enqueue(root);
            while (layerQueue.Count > 0)
            {
                currentLayer++;
                currentSum = 0;
                loopCount = layerQueue.Count;
                for (int i = 0; i < loopCount; i++)
                {
                    var node = layerQueue.Dequeue();
                    currentSum += node.val;
                    if (node.left != null) layerQueue.Enqueue(node.left);
                    if (node.right != null) layerQueue.Enqueue(node.right);
                }
                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                    bestLayer = currentLayer;
                }
            }
            return bestLayer;
        }
    }
    public class Solution_Traversal
    {
        List<int> layerSums;
        public int MaxLevelSum(TreeNode root)
        {
            layerSums = new List<int>() { int.MinValue };
            NavigateTree(root, 1);
            return layerSums.IndexOf(layerSums.Max());
        }
        public void NavigateTree(TreeNode node, int layer)
        {
            if (node == null) 
                return;
            if (layerSums.Count <= layer)
                layerSums.Add(node.val);
            else
                layerSums[layer] += node.val;
            NavigateTree(node.left, layer + 1);
            NavigateTree(node.right, layer + 1);
        }
    }
    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

}