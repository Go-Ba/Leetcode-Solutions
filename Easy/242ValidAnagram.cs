using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ValidAnagram
{
    //https://leetcode.com/problems/valid-anagram/
    public class Solution
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            var charCount = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                charCount.TryAdd(s[i], 0);
                charCount.TryAdd(t[i], 0);

                charCount[s[i]]++;
                charCount[t[i]]--;
            }

            foreach (var item in charCount)
                if (item.Value != 0)
                    return false;

            return true;
        }
    }
    public class Solution1
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            List<char> a = s.ToList();
            List<char> b = t.ToList();

            while (a.Count > 0 && b.Count > 0)
            {
                for (int i = 0; i < b.Count; i++)
                {
                    if (b[i] == a[0])
                    {
                        a.RemoveAt(0);
                        b.RemoveAt(i);
                        break;
                    }
                    if (i == b.Count - 1)
                        return false;
                }
            }
            return true;
        }
    }
}
