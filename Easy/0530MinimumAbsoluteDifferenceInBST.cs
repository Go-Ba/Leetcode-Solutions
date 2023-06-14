using System;

public class MinimumAbsoluteDifferenceInBST
{
    //https://leetcode.com/problems/minimum-absolute-difference-in-bst
    public class Solution_InOrderTraversal_Simplified
    {
        int previousNodeVal;
        int min;
        public int GetMinimumDifference(TreeNode root)
        {
            min = int.MaxValue;
            previousNodeVal = int.MaxValue;
            InOrderTraversal(root);
            return min;
        }
        public void InOrderTraversal(TreeNode node)
        {
            if (node.left != null)
                InOrderTraversal(node.left);

            int dif = Math.Abs(node.val - previousNodeVal);
            min = Math.Min(min, dif);
            previousNodeVal = node.val;

            if (node.right != null)
                InOrderTraversal(node.right);
        }
    }
    public class Solution_InOrderTraversal
    {
        TreeNode previousNode;
        int min;
        public int GetMinimumDifference(TreeNode root)
        {
            min = int.MaxValue;
            InOrderTraversal(root);
            return min;
        }
        public void InOrderTraversal(TreeNode node)
        {
            if (node.left != null)           
                InOrderTraversal(node.left);

            int dif = previousNode == null ? int.MaxValue : Math.Abs(node.val - previousNode.val);
            min = Math.Min(min, dif);
            previousNode = node;

            if (node.right != null)            
                InOrderTraversal(node.right);
        }
    }
    public class Solution_Depth
    {
        public int GetMinimumDifference(TreeNode root)
        {
            if (root.left == null && root.right == null)
                return int.MaxValue;

            int thisMin = GetSmallestDifferenceToThisNode(root);
            int leftMin = root.left == null ? int.MaxValue : GetMinimumDifference(root.left);
            int rightMin = root.right == null ? int.MaxValue : GetMinimumDifference(root.right);

            int result = Math.Min(leftMin, rightMin);
            result = Math.Min(result, thisMin);

            return result;
        }
        public int GetSmallestDifferenceToThisNode(TreeNode node)
        {
            int leftDif = int.MaxValue, rightDif = int.MaxValue;
            if (node.left != null)
            {
                TreeNode left = GetRightmostLeaf(node.left);
                leftDif = Math.Abs(node.val - left.val);
            }
            if (node.right != null)
            {
                TreeNode right = GetLeftmostLeaf(node.right);
                rightDif = Math.Abs(node.val - right.val);
            }
            return Math.Min(leftDif, rightDif);
        }
        public TreeNode GetRightmostLeaf(TreeNode node) => node.right == null ? node : GetRightmostLeaf(node.right);
        public TreeNode GetLeftmostLeaf(TreeNode node) => node.left == null ? node : GetLeftmostLeaf(node.left);
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