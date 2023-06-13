using System.Collections.Generic;

public class ValidPalindrome
{
    //https://leetcode.com/problems/valid-palindrome
    public class Solution
    {
        public bool IsPalindrome(string s)
        {
            List<char> sanitizedString = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetterOrDigit(s[i]))
                    sanitizedString.Add(char.ToLower(s[i]));
            }
            int count = sanitizedString.Count;
            for (int i = 0; i < count / 2; i++)
            {
                if (sanitizedString[i] != sanitizedString[count - 1 - i])
                    return false;
            }
            return true;
        }
    }
}
