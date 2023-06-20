public class KRadiusSubarrayAverages
{
    //https://leetcode.com/problems/k-radius-subarray-averages/
    public class Solution_WindowSum_2
    {
        public int[] GetAverages(int[] nums, int k)
        {
            long sum = 0;
            int[] averages = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                //null out the edges
                if (i < k || i >= nums.Length - k)
                {
                    averages[i] = -1;
                    continue;
                }
                //if previous is empty, calculate full sum
                else if (i - k == 0 || nums[i - 1] == -1)
                    for (int j = i - k; j <= i + k; j++)
                        sum += nums[j];
                //else, just modify the two ends of the previous sum to make it your own
                else sum = sum - nums[i - k - 1] + nums[i + k];
                //calculate average
                averages[i] = (int)(sum / (k * 2 + 1));
            }
            return averages;
        }
    }
    public class Solution_WindowSum
    {
        public int[] GetAverages(int[] nums, int k)
        {
            long[] sums = new long[nums.Length];
            int[] averages = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                //null out the edges
                if (i < k || i >= nums.Length - k)
                    sums[i] = -1;
                //if previous is empty, get full sum
                else if (i - k == 0 || nums[i - 1] == -1)
                    for (int j = i - k; j <= i + k; j++)
                        sums[i] += nums[j];
                //else, just modify the two ends of the previous sum to make it your own
                else
                    sums[i] = sums[i - 1] - nums[i - k - 1] + nums[i + k];
            }
            //turn sum into average
            for (int i = 0; i < nums.Length; i++)
            {
                if (sums[i] != -1)
                    averages[i] = (int)(sums[i] / (k * 2 + 1));
                else
                    averages[i] = -1;
            }
            
            return averages;
        }
    }
}