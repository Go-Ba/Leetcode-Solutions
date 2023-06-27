using System;
using System.Collections.Generic;

public class FindKPairsWithSmallestSums
{
    //https://leetcode.com/problems/find-k-pairs-with-smallest-sums/
    public class Solution_TooSlow
    {
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            List<IList<int>> output = new List<IList<int>>();

            int a = 0;
            bool searchA = true, searchB = true;
            int length = Math.Max(nums1.Length, nums2.Length);
            while (true)
            {
                searchA = true;
                searchB = true;
                for (int b = a; b < length; b++)
                {
                    if (searchA && a < nums1.Length && b < nums2.Length)
                    {
                        if (!TryAddToList(output, nums1[a], nums2[b], k))
                        {
                            searchA = false;
                        }
                    }
                    if (searchB && a != b && a < nums2.Length && b < nums1.Length)
                    {
                        if(!TryAddToList(output, nums1[b], nums2[a], k))
                        {
                            searchB = false;
                        }
                    }
                    if (!searchA && !searchB)
                        break;
                }
                a++;
                if (a > nums1.Length && a > nums2.Length)
                    break;
            }
            foreach (var item in output)           
                item.RemoveAt(2);
            
            return output;
        }
        public bool TryAddToList(List<IList<int>> list, int a, int b, int k)
        {
            var value = new List<int>() { a, b, a + b };
            bool success = false;
            int loops = Math.Min(k, list.Count);
            for (int i = 0; i < loops; i++)
            {
                if (value[2] < list[i][2])
                {
                    list.Insert(i, value);
                    success = true;
                    break;
                }
            }
            if (success == false && list.Count < k)
            {
                list.Add(value);
                success = true;
            }
            while (list.Count > k)
                list.RemoveAt(list.Count - 1);
            return success;
        }
    }
}