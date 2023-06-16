using System.Collections.Generic;
using System.Linq;

public class InvertBinaryTree
{
    //https://leetcode.com/problems/invert-binary-tree/
    public class Solution_Recursive
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;
            (root.right, root.left) = (root.left, root.right);
            InvertTree(root.left);
            InvertTree(root.right);
            return root;
        }
    }
    public class Solution_Queue
    {
        public TreeNode InvertTree(TreeNode root)
        {
            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
            if (root == null) 
                return null;
            nodeQueue.Enqueue(root);
            TreeNode current;
            while (nodeQueue.Count() != 0)
            {
                current = nodeQueue.Dequeue();
                if (current.right != null) nodeQueue.Enqueue(current.right);
                if (current.left != null) nodeQueue.Enqueue(current.left);
                (current.right, current.left) = (current.left, current.right);
            }
            return root;
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