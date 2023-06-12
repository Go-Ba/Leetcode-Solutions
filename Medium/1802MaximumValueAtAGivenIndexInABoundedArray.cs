using System;

public class MaximumValueAtAGivenIndexInABoundedArray
{
    //https://leetcode.com/problems/maximum-value-at-a-given-index-in-a-bounded-array/
    public class Solution
    {
        public int MaxValue(int n, int index, int maxSum)
        {
            if (n == 1)
                return maxSum;

            long placesAbove = n - 1 - index;
            long placesBelow = index;

            long l = 1;
            long r = maxSum;
            long result = -1;

            while (l <= r)
            {
                long mid = (l + r) / 2;
                long aboveSum = ProgressionSum(mid - 1, placesAbove);
                long belowSum = ProgressionSum(mid - 1, placesBelow);
                if (aboveSum + belowSum <= maxSum - mid)
                {
                    result = Math.Max(result, mid);
                    l = mid + 1;
                }
                else
                    r = mid - 1;
            }
            return (int)result;
        }
        private long ProgressionSum(long num, long count)
        {
            if (num >= count)
                return (num + (num - count + 1)) * count / 2;
            else
                return ((1 + num) * num / 2) + (count - num);
        }
    }
}
