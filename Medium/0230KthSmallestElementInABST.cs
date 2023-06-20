using System.Collections.Generic;

public class KthSmallestElementInABST
{
    //https://leetcode.com/problems/kth-smallest-element-in-a-bst/
    public class Solution_InOrderTraversal
    {
        int count;
        public int KthSmallest(TreeNode root, int k)
        {
            count = 0;
            return InOrderTraversal(root, k);
        }
        public int InOrderTraversal(TreeNode node, int k)
        {
            if (node == null)
                return -1;
            int left = InOrderTraversal(node.left, k);
            if (left != -1) return left;

            count++;
            if (count == k)
                return node.val;

            return InOrderTraversal(node.right, k);
        }
    }
    public class Solution_Sorting
    {
        List<int> nodeValues;
        public int KthSmallest(TreeNode root, int k)
        {
            nodeValues = new List<int>();
            Navigate(root);
            nodeValues.Sort();
            return nodeValues[k - 1];
        }
        public void Navigate(TreeNode node)
        {
            if (node == null) return;
            nodeValues.Add(node.val);
            Navigate(node.left);
            Navigate(node.right);
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