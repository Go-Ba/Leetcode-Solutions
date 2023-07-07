using System;

public class MinimumSizeSubarraySum
{
    //https://leetcode.com/problems/minimum-size-subarray-sum/
    public class Solution
    {
        public int MinSubArrayLen(int target, int[] nums)
        {
            int currSum = 0, minSpan = 0, l = 0;

            for (int r = 0; r < nums.Length; r++)
            {
                currSum += nums[r];
                while (currSum >= target)
                {
                    int span = r - l + 1;
                    minSpan = minSpan == 0 ? span : Math.Min(minSpan, span);
                    currSum -= nums[l++];
                }
            }
            return minSpan;
        }
    }
}