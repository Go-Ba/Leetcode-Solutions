public class ConvertSortedArrayToBinarySearchTree
{
    //https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
    public class Solution_StupidOneLiner
    {
        public TreeNode SortedArrayToBST(int[] nums) => (nums == null || nums.Length == 0) ? null : new (nums[nums.Length / 2], SortedArrayToBST(nums[..(nums.Length / 2)]), SortedArrayToBST(nums[(nums.Length / 2 + 1)..]));
    }
    public class Solution
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            int mid = nums.Length / 2;
            TreeNode node = new TreeNode(nums[mid]);

            node.left = SortedArrayToBST(nums[..mid]);
            node.right = SortedArrayToBST(nums[(mid + 1)..]);

            return node;
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
