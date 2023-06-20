using System;
using System.Collections.Generic;
using System.Linq;

public class ConstructBinaryTreeFromPreorderAndInorderTraversal
{
    //https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
    public class Solution_ArrayRanges
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || preorder.Length == 0)
                return null;

            TreeNode node = new TreeNode(preorder[0]);
            int rootIndex = Array.IndexOf(inorder, node.val);

            int[] leftInorder = inorder[..rootIndex];
            int[] rightInorder = inorder[(rootIndex + 1)..];
            int[] leftPreorder = preorder[1..(rootIndex + 1)];
            int[] rightPreorder = preorder[(rootIndex + 1)..];

            node.left = BuildTree(leftPreorder, leftInorder);
            node.right = BuildTree(rightPreorder, rightInorder);
            return node;
        }
    }
    public class Solution_Slow
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder) => BuildTree(preorder.ToList(), inorder.ToList());
        public TreeNode BuildTree(List<int> preorder, List<int> inorder)
        {
            int nodeVal = preorder[0];
            TreeNode node = new TreeNode(nodeVal);
            if (preorder.Count == 1)
                return node;

            GetLeftRightInorder(inorder, nodeVal, out List<int> leftInorder, out List<int> rightInorder);

            if (leftInorder.Count > 0)
                node.left = BuildTree(MaskPreorder(preorder, leftInorder), leftInorder);
            if (rightInorder.Count > 0)
                node.right = BuildTree(MaskPreorder(preorder, rightInorder), rightInorder);

            return node;
        }
        public void GetLeftRightInorder(List<int> inorder, int root, out List<int> leftInorder, out List<int> rightInorder)
        {
            leftInorder = new();
            rightInorder = new();
            bool doRight = false;
            for (int i = 0; i < inorder.Count; i++)
            {
                if (!doRight && inorder[i] == root)
                    doRight = true;
                else if (doRight)
                    rightInorder.Add(inorder[i]);
                else
                    leftInorder.Add(inorder[i]);
            }
        }
        public List<int> MaskPreorder(List<int> preorder, List<int> mask)
        {
            List<int> output = new List<int>();
            for (int i = 0; i < preorder.Count; i++)
                if (mask.Contains(preorder[i]))
                    output.Add(preorder[i]);
            return output;
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