using System.Collections.Generic;

public class BinaryTreeRightSideView
{
    //https://leetcode.com/problems/binary-tree-right-side-view/
    public class Solution_Queue
    {
        List<int> output;
        public IList<int> RightSideView(TreeNode root)
        {
            output = new List<int>();
            if (root == null)
                return output;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                int loops = queue.Count;
                for (int i = 0; i < loops; i++)
                {
                    var current = queue.Dequeue();
                    if (i == 0)
                        output.Add(current.val); //put the rightmost value of this layer into the output list
                    if (current.right != null) queue.Enqueue(current.right);
                    if (current.left != null) queue.Enqueue(current.left);
                }
            }

            return output;
        }
    }
    public class Solution_Recursion
    {
        List<int> output;
        public IList<int> RightSideView(TreeNode root)
        {
            output = new List<int>();
            Helper(root, 0);
            return output;
        }
        void Helper(TreeNode node, int level)
        {
            if (node == null)
                return;
            if (level >= output.Count)
                output.Add(node.val);
            Helper(node.right, level + 1);
            Helper(node.left, level + 1);
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
