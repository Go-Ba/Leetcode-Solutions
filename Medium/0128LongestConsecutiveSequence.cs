using System;
using System.Collections.Generic;

public class LongestConsecutiveSequence
{
    //https://leetcode.com/problems/longest-consecutive-sequence/
    //must run in O(n)

    //According to leetcode this hashset performs worse than radix sort despite being the recommended method
    //maybe I just implemented this badly?
    public class Solution_Hashset
    {
        public int LongestConsecutive(int[] nums)
        {
            if (nums == null)
                return 0;
            if (nums.Length <= 1)
                return nums.Length;

            HashSet<int> numExists = new HashSet<int>();
            foreach (var num in nums)
                numExists.Add(num);

            int longestSequence = 0;

            foreach (var num in nums)
            {
                //if there is a number previous, this can't be the start of a sequence
                if (numExists.Contains(num - 1))
                    continue;

                int currentNum = num;
                int currentSequence = 1;
                while (numExists.Contains(currentNum + 1))
                {
                    currentSequence++;
                    currentNum++;
                }
                if (currentSequence > longestSequence)
                    longestSequence = currentSequence;
            }
            return longestSequence;
        }
    }
    public class Solution_RadixSort
    {
        public int LongestConsecutive(int[] nums)
        {
            if (nums == null) 
                return 0;
            if (nums.Length <= 1) 
                return nums.Length;

            int size = nums.Length;
            var longNums = IntToLong(nums, size); //array copy is O(n)
            var sorted = RadixSort(longNums, size); //radix sort is O(n)
            Console.WriteLine($"Sorted: {ArrayToString(sorted)}");
            return GetLongestConsecutive(sorted); //iterate through array is O(n)
        }
        string ArrayToString(long[] nums)
        {
            string output = "";
            foreach (var digit in nums)            
                output += $"{digit}, ";            
            return output;
        }
        long[] IntToLong(int[] nums, int size)
        {
            long[] output = new long[size];
            for (int i = 0; i < size; i++)            
                output[i] = (long)nums[i] + int.MaxValue;
            return output;
        }
        public int GetLongestConsecutive(long[] nums)
        {
            int longestSequence = 0;
            int currentSequence = 1;
            long currentValue = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                long dif = nums[i] - currentValue;
                if (dif == 0)
                    continue;
                else if (dif == 1)
                    currentSequence++;
                else
                {
                    if (currentSequence > longestSequence)
                        longestSequence = currentSequence;
                    currentSequence = 1;
                }
                currentValue = nums[i];
            }
            return Math.Max(currentSequence, longestSequence);
        }
        public long[] RadixSort(long[] array, int size)
        {
            var maxVal = GetMaxVal(array, size);
            for (int exponent = 1; maxVal / exponent > 0; exponent *= 10)
                CountingSort(array, size, exponent);
            return array;
        }
        public static void CountingSort(long[] array, int size, int exponent)
        {
            var output = new long[size];
            var occurences = new long[10];
            for (int i = 0; i < 10; i++)
                occurences[i] = 0;
            for (int i = 0; i < size; i++)
                occurences[(array[i] / exponent) % 10]++;
            for (int i = 1; i < 10; i++)
                occurences[i] += occurences[i - 1];
            for (int i = size - 1; i >= 0; i--)
            {
                output[occurences[(array[i] / exponent) % 10] - 1] = array[i];
                occurences[(array[i] / exponent) % 10]--;
            }
            for (int i = 0; i < size; i++)
                array[i] = output[i];
        }
        public static long GetMaxVal(long[] array, int size)
        {
            var maxVal = array[0];
            for (int i = 1; i < size; i++)
                if (array[i] > maxVal)
                    maxVal = array[i];
            return maxVal;
        }
    }
}