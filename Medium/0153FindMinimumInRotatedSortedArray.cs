using System;
using System.Linq;

public class FindMinimumInRotatedSortedArray
{
    //https://leetcode.com/problems/find-minimum-in-rotated-sorted-array
    public class Solution_TrackMin
    {
        public int FindMin(int[] nums)
        {
            if (nums[0] < nums[nums.Length - 1])
                return nums[0];
            if (nums.Length <= 2)
                return nums.Min();

            int root = nums[0];
            int l = 1, r = nums.Length - 1, mid;
            int min = int.MaxValue;
            while (l <= r)
            {
                mid = (l + r) / 2;
                if (nums[mid] >= root)
                    l = mid + 1;
                else
                    r = mid - 1;
                min = Math.Min(min, nums[mid]);
            }
            return min;
        }
    }
    public class Solution_CheckLeft
    {
        public int FindMin(int[] nums)
        {
            if (nums[0] < nums[nums.Length - 1])
                return nums[0];

            int root = nums[0];
            int l = 1;
            int r = nums.Length - 1;
            int mid = 0;
            while (l <= r)
            {
                mid = (l + r) / 2;
                if (mid > 0 && nums[mid] - nums[mid - 1] < -1)
                    return nums[mid];
                if (nums[mid] >= root)
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            return nums[mid];
        }
    }
}