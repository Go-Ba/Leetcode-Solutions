using System;
using System.Collections.Generic;

public class LongestRepeatingCharacterReplacement
{
    //https://leetcode.com/problems/longest-repeating-character-replacement/
    public class Solution
    {
        public int CharacterReplacement(string s, int k)
        {
            Dictionary<int, int> map = new();
            int left = 0;
            int longest = 0;
            int highestFrequency = 0;
            for (int right = 0; right < s.Length; right++)
            {
                //add current right to dictionary
                if (!map.ContainsKey(s[right]))               
                    map.Add(s[right], 1);                
                else               
                    map[s[right]]++;
                
                //check if the frequency of rightmost char is more than current highest
                highestFrequency = Math.Max(map[s[right]], highestFrequency);

                //after removing the count of the highest frequency char
                //check if the remainder is less than max replacements
                //if not, move left pointer forward until it is
                while ((right - left + 1) - highestFrequency > k)
                {
                    map[s[left]]--;
                    left++;
                }

                //keep track of longest string
                longest = Math.Max(right - left + 1, longest);
            }
            return longest;
        }
    }
}
