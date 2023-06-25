using System;
using System.Collections.Generic;

public class LongestSubstringWithoutRepeatingCharaters
{
    //https://leetcode.com/problems/longest-substring-without-repeating-characters/
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length <= 1)
                return s.Length;

            int l = 0, r = 0, longest = 1;
            HashSet<char> existingChars = new();
            while (r < s.Length)
            {
                if (l != r && existingChars.Contains(s[r]))
                {
                    existingChars.Remove(s[l]);
                    l++;
                }
                else
                {
                    existingChars.Add(s[r]);
                    longest = Math.Max(longest, r - l + 1);
                    r++;
                }
            }
            return longest;
        }
    }
}