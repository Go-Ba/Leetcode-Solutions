using System.Collections.Generic;
using System;

public class DiameterOfBinaryTree
{
    public class Solution_DepthFirst_Cleaner
    {
        int maxDiameter;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            maxDiameter = 0;
            FindDiameter(root, out _);
            return maxDiameter;
        }
        public void FindDiameter(TreeNode node, out int height)
        {
            height = 0;
            if (node == null)
                return;
            FindDiameter(node.left, out int heightL);
            FindDiameter(node.right, out int heightR);
            maxDiameter = Math.Max(maxDiameter, heightL + heightR);
            height = 1 + Math.Max(heightL, heightR);
        }
    }
    public class Solution_DynamicProgramming
    {
        readonly Dictionary<TreeNode, int> maxDepthMap = new();
        public int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null)
                return 0;
            int diameterFromHere = MaxDepth(root.left) + MaxDepth(root.right);
            int diameterLeft = DiameterOfBinaryTree(root.left);
            int diameterRight = DiameterOfBinaryTree(root.right);
            return Math.Max(diameterFromHere, Math.Max(diameterRight, diameterLeft));
        }
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            if (maxDepthMap.TryGetValue(root, out int depth))
                return depth;
            depth = 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
            maxDepthMap.Add(root, depth);
            return depth;
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