using System;
using System.Collections.Generic;

//217.Contains Duplicate
public class ContainsDuplicate
{
    //https://leetcode.com/problems/contains-duplicate/
    public class Solution
    {
        public bool ContainsDuplicate(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == nums[i])
                        return true;
                }
            }
            return false;
        }
        public bool ContainsDuplicate1(int[] nums)
        {
            if (nums.Length <= 1)
                return false;
            HashSet<int> exists = new HashSet<int>() { nums[0] };
            for (int i = 1; i < nums.Length; i++)
            {
                if (exists.Contains(nums[i]))
                    return true;
                exists.Add(nums[i]);
            }
            return false;
        }
    }
}
