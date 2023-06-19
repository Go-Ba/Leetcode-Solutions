public class SubtreeOfAnotherTree
{
    //https://leetcode.com/problems/subtree-of-another-tree/
    public class Solution_Depth_DumbOneLiner
    {
        public bool IsSubtree(TreeNode root, TreeNode subRoot) => root == null ? false : IsSameTree(root, subRoot) || IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
        public bool IsSameTree(TreeNode p, TreeNode q) => (p == null || q == null) ? (p == null && q == null) : (p.val == q.val && (IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right)));
    }
    public class Solution_Depth
    {
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (root == null)
                return false;

            if (IsSameTree(root, subRoot))
                return true; 

            return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
        }
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null || q == null)
                return p == null && q == null;
            if (p.val != q.val)
                return false;
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
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