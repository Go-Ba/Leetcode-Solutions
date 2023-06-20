using System.Collections.Generic;

public class BinaryTreeLevelOrderTraversal
{
    //https://leetcode.com/problems/binary-tree-level-order-traversal/

    public class Solution_Recursion
    {
        List<IList<int>> output;
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            output = new();
            if (root == null)
                return output;
            Traverse(root, 0);
            return output;
        }
        void Traverse(TreeNode node, int depth)
        {
            if (node == null)
                return;
            while (output.Count <= depth)
                output.Add(new List<int>());
            output[depth].Add(node.val);
            Traverse(node.left, depth + 1);
            Traverse(node.right, depth + 1);
        }
    }
    public class Solution_Queue
    {       
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> output = new();
            if (root == null)
                return output;
            Queue<TreeNode> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                List<int> level = new();
                int loops = queue.Count;
                for (int i = 0; i < loops; i++)
                {
                    var current = queue.Dequeue();
                    level.Add(current.val);
                    if (current.left != null) queue.Enqueue(current.left);
                    if (current.right != null) queue.Enqueue(current.right);
                }
                output.Add(level);
            }
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
