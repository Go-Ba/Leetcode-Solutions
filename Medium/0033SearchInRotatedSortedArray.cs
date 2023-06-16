public class SearchInRotatedSortedArray
{
    //https://leetcode.com/problems/search-in-rotated-sorted-array/

    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 1)
                return nums[0] == target ? 0 : -1;
            if (target == nums[0])
                return 0;

            int l = 0, r = nums.Length - 1, mid, current;
            int root = nums[0];
            bool targetLessThanRoot = target < root;

            while (l <= r)
            {
                mid = (l + r) / 2;
                current = nums[mid];
                //find target
                if (current == target)
                    return mid;
                //move to appropriate section
                if (targetLessThanRoot && current >= root)
                    l = mid + 1;
                else if (!targetLessThanRoot && current < root)
                    r = mid - 1;
                //binary search the sorted section
                else if (current > target)
                    r = mid - 1;
                else if (current < target)
                    l = mid + 1;
            }
            return -1;
        }
    }
}