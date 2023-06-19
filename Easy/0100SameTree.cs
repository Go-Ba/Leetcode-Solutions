using System.Collections.Generic;

public class SameTree
{
    //https://leetcode.com/problems/same-tree/
    public class Solution_DumbOneLiner
    {
        public bool IsSameTree(TreeNode p, TreeNode q) => (p == null || q == null) ? (p == null && q == null) : (p.val == q.val && (IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right))); 
    }
    public class Solution_Recursive
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null || q == null) 
                return p == null && q == null;
            if (p.val != q.val) 
                return false;
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
    }
    public class Solution_Queues
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            Queue<TreeNode> pQueue = new();
            Queue<TreeNode> qQueue = new();
            pQueue.Enqueue(p);
            qQueue.Enqueue(q);

            while (pQueue.Count > 0)
            {
                int loops = pQueue.Count;
                for (int i = 0; i < loops; i++)
                {
                    TreeNode pNode = pQueue.Dequeue();
                    TreeNode qNode = qQueue.Dequeue();

                    if (pNode == null ^ qNode == null)
                        return false;
                    else if (pNode != null && pNode.val != qNode.val)
                        return false;

                    if (pNode == null) continue;
                    pQueue.Enqueue(pNode.left);
                    pQueue.Enqueue(pNode.right);
                    qQueue.Enqueue(qNode.left);
                    qQueue.Enqueue(qNode.right);
                }
            }
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