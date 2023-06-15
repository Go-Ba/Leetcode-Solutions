public class BinarySearch
{
    //https://leetcode.com/problems/binary-search/
    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            int l = 0, r = nums.Length - 1, mid;
            while (l <= r)
            {
                mid = (l + r) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            return -1;
        }
    }
}