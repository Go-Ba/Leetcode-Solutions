using System;

public class MaximumDepthOfBinaryTree
{
    //https://leetcode.com/problems/maximum-depth-of-binary-tree/
    public class Solution_LessLines
    {
        public int MaxDepth(TreeNode root)
        {
            //could be one line, but I think it looks ugly
            if (root == null)
                return 0;
            return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }
    }
    public class Solution_SimpleToUnderstand
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null) 
                return 0;
            return GetDepth(root, 1);
        }
        public int GetDepth(TreeNode node, int currentDepth)
        {
            int lDepth = node.left == null ? currentDepth : GetDepth(node.left, currentDepth + 1);
            int rDepth = node.right == null ? currentDepth : GetDepth(node.right, currentDepth + 1);
            return Math.Max(lDepth, rDepth);
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