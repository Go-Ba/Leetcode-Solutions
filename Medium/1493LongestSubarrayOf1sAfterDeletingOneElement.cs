using System;

public class LongestSubarrayOf1sAfterDeletingOneElement
{
    //https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element/
    public class Solution_StoreZeroPosition
    {
        public int LongestSubarray(int[] nums)
        {
            int longestSpan = 0, lastZero = -1, l = 0;

            for (int r = 0; r < nums.Length; r++)
            {
                if (nums[r] == 0)
                {
                    l = lastZero + 1;
                    lastZero = r;
                }
                longestSpan = Math.Max(longestSpan, r - l);
            }
            return longestSpan;
        }
    }
    public class Solution_IterateLeftPointer
    {
        const int allowedZeroes = 1;
        public int LongestSubarray(int[] nums)
        {
            int longestSpan = 0, zeroCount = 0, l = 0;

            for (int r = 0; r < nums.Length; r++)
            {
                if (nums[r] == 0)
                    zeroCount++;

                while (zeroCount > allowedZeroes)                
                    if (nums[l++] == 0)
                        zeroCount--;   
                
                longestSpan = Math.Max(longestSpan, r - l);
            }
            return longestSpan;
        }
    }
}