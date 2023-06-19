public class LowestCommonAncestoryOfABinarySearchTree
{
    //https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
    public class Solution_BinarySearch
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;
            if (root == p || root == q) return root;

            TreeNode current = root;
            
            //uses the specific quality of a BST
            //if the values are both more than current, they must be to the right. Vice versa for left
            //if the values are on either side of current, the road splits
            //and thus this must be the lowest common ancestor          
            while (current != null)
            {
                if (p.val > current.val && q.val > current.val)
                    current = current.right;
                else if (p.val < current.val && q.val < current.val)
                    current = current.left;
                else
                    return current;
            }
            return root;
        }
    }
    public class Solution_Depth
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
            => FindLCA(root, p, q, out _, out _);

        //Navigates the tree through DFS searching for p and q
        //if one is found, sends the message "found p" and/or "found q" back up the stack once its subtree has been explored
        //when one of the functions receives both messages of "found p" and "found q" it returns itself as the main return value.
        //then every other function in the stack sees that the answer has been found already and returns it
        public TreeNode FindLCA(TreeNode node, TreeNode p, TreeNode q, out bool foundP, out bool foundQ)
        {
            foundP = false;
            foundQ = false;
            if (node == null)
                return null;

            TreeNode left = FindLCA(node.left, p, q, out bool foundPLeft, out bool foundQLeft);
            if (left != null) return left;
            TreeNode right = FindLCA(node.right, p, q, out bool foundPRight, out bool foundQRight);
            if (right != null) return right;

            foundP = node == p || foundPLeft || foundPRight;
            foundQ = node == q || foundQLeft || foundQRight;
            if (foundP && foundQ)
                return node;
            return null;
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}