using System;
using System.Collections;

public class BalancedBinaryTree
{
    //https://leetcode.com/problems/balanced-binary-tree/
    public class Solution_WithEarlyEscape
    {
        bool isBalanced;
        public bool IsBalanced(TreeNode root)
        {
            isBalanced = true;
            return IsBalanced(root, out _);
        }
        public bool IsBalanced(TreeNode node, out int height)
        {
            height = 0;
            //if another subtree already found an imbalance,
            //just escape out of this function stack
            if (!isBalanced)
                return false;

            if (node == null)
                return true;
            if (!IsBalanced(node.left, out int heightL))
                return false;
            if (!IsBalanced(node.right, out int heightR))
                return false;
            height = Math.Max(heightL, heightR) + 1;

            //set a global balanced value so that other function calls can be aware
            isBalanced = Math.Abs(heightL - heightR) <= 1;
            return isBalanced;
        }
    }
    public class Solution_DepthFirst
    {
        public bool IsBalanced(TreeNode root)
        {
            return IsBalanced(root, out _);
        }
        public bool IsBalanced(TreeNode node, out int height)
        {
            height = 0;
            if (node == null)
                return true;
            if (!IsBalanced(node.left, out int heightL))
                return false;
            if (!IsBalanced(node.right, out int heightR))
                return false;
            height = Math.Max(heightL, heightR) + 1;
            return Math.Abs(heightL - heightR) <= 1;
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
