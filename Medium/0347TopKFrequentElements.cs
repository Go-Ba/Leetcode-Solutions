using System.Collections.Generic;
using System.Linq;

public class TopKFrequenElements
{
    //https://leetcode.com/problems/top-k-frequent-elements/
    public class Solution
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return new int[0];
            if (nums.Length == 1) return nums;

            //int1 is num, int2 is frequency
            Dictionary<int, int> frequencies = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)            
                if (!frequencies.TryAdd(nums[i], 1))
                    frequencies[nums[i]]++;

            var sortedDict = frequencies.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return sortedDict.Keys.ToList().Take(k).ToArray();
        }
    }
    public class Solution1
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return new int[0];

            //int1 is num, int2 is frequency
            Dictionary<int, int> frequencies = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)           
                if (!frequencies.TryAdd(nums[i], 1))               
                    frequencies[nums[i]]++;                           

            var sortedDict = from entry 
                             in frequencies 
                             orderby entry.Value descending 
                             select entry;
            int[] output = new int[k];
            int j = 0;
            foreach (var item in sortedDict)
            {
                output[j] = item.Key;
                j++;
                if (j >= k)
                    break;
            }
            return output;
        }
    }
}