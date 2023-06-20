using System;

public class CountGoodNodesInBinaryTree
{
    //https://leetcode.com/problems/count-good-nodes-in-binary-tree/
    public class Solution
    {
        int goodCount;
        public int GoodNodes(TreeNode root)
        {
            goodCount = 0;
            Traverse(root, int.MinValue);
            return goodCount;
        }
        public void Traverse(TreeNode node, int maxValue)
        {
            if (node == null)
                return;
            maxValue = Math.Max(node.val, maxValue);
            if (maxValue <= node.val)
                goodCount++;
            Traverse(node.left, maxValue);
            Traverse(node.right, maxValue);
        }
    }
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