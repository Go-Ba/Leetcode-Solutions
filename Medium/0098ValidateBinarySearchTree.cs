using System;

public class ValidateBinarySearchTree
{
    //https://leetcode.com/problems/validate-binary-search-tree/
    public class Solution
    {
        public bool IsValidBST(TreeNode root)
        {
            if (root == null)
                return false;
            if (root.left == null && root.right == null)
                return true;
            return IsValid(root, long.MinValue, long.MaxValue);
        }
        public bool IsValid(TreeNode node, long minParent, long maxParent)
        {
            if (node.val <= minParent || node.val >= maxParent)
                return false;

            if (node.left != null && !IsValid(node.left, minParent, Math.Min(maxParent, node.val)))
                return false;
            if (node.right != null && !IsValid(node.right, Math.Max(minParent, node.val), maxParent))
                return false;

            return true;
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