using System.Collections.Generic;
using System.Linq;
using System;

public class MedianOfTwoSortedArrays
{
    //https://leetcode.com/problems/median-of-two-sorted-arrays/
    public class Solution_LogN
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int size1 = nums1.Length;
            int size2 = nums2.Length;
            if (size1 > size2)
                return FindMedianSortedArrays(nums2, nums1);

            int low = 0;
            int high = size1;
            while (true)
            {
                int cut1 = (low + high) / 2;
                int cut2 = (size1 + size2 + 1) / 2 - cut1;
                int l1 = cut1 == 0 ? int.MinValue : nums1[cut1 - 1];
                int l2 = cut2 == 0 ? int.MinValue : nums2[cut2 - 1];
                int r1 = cut1 == size1 ? int.MaxValue : nums1[cut1];
                int r2 = cut2 == size2 ? int.MaxValue : nums2[cut2];

                Console.WriteLine($"low: {low}, high: {high}");
                Console.WriteLine($"cut1: {cut1}, cut2: {cut2}");
                Console.WriteLine($"l1: {l1}, r1: {r1}, l2: {l2}, r2: {r2} \n ");

                if (l1 > r2)
                    high = cut1 - 1;
                else if (l2 > r1)
                    low = cut1 + 1;
                else
                {
                    if ((size1 + size2) % 2 == 0)
                        return (double)(Math.Max(l1, l2) + Math.Min(r1, r2)) / 2;
                    else
                        return (double)Math.Max(l1, l2);
                }
            }
        }
    }
    public class Solution_Linear2
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var both = nums1.Concat(nums2).ToList();
            both.Sort();
            return GetMedian(both);
        }
        public double GetMedian(List<int> nums)
        {
            int half = nums.Count / 2;
            if (nums.Count % 2 == 0)
                return ((double)nums[half] + nums[half - 1]) / 2;
            else
                return nums[half];
        }
    }
    public class Solution_Linear
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            List<int> output = new();
            int i = 0, j = 0;
            while (i < nums1.Length || j < nums2.Length)
            {
                if (i < nums1.Length && (j >= nums2.Length || nums1[i] < nums2[j]))
                {
                    output.Add(nums1[i]);
                    i++;
                }
                else
                {
                    output.Add(nums2[j]);
                    j++;
                }
            }
            return GetMedian(output);
        }
        public double GetMedian(List<int> nums)
        {
            int half = nums.Count / 2;
            if (nums.Count % 2 == 0)
                return ((double)nums[half] + nums[half - 1]) / 2;
            else
                return nums[half];           
        }
    }
}
