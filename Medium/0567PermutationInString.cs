using System.Collections.Generic;

public class PermutationInString
{
    //https://leetcode.com/problems/permutation-in-string/
    public class Solution
    {
        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length)
                return false;

            GenerateDictionaries(s1, s2, out Dictionary<char, int> s1Dict, out Dictionary<char, int> windowDict);
            if (DictionaryEquals(s1Dict, windowDict))
                return true;

            int l = 1;
            while (l <= s2.Length - s1.Length)
            {
                Add(windowDict, s2[l + s1.Length - 1]);
                Remove(windowDict, s2[l - 1]);
                if (DictionaryEquals(s1Dict, windowDict))
                    return true;
                l++;
            }
            return false;
        }
        public void GenerateDictionaries(string s1, string s2, out Dictionary<char, int> a, out Dictionary<char, int> b)
        {
            a = new Dictionary<char, int>();
            b = new Dictionary<char, int>();
            for (int i = 0; i < s1.Length; i++)
            {
                if (!a.TryAdd(s1[i], 1))
                    a[s1[i]]++;
                if (!b.TryAdd(s2[i], 1))
                    b[s2[i]]++;
            }
        }
        public void Add(Dictionary<char, int> dict, char c)
        {
            if (!dict.TryAdd(c, 1))
                dict[c]++;
        }
        public void Remove(Dictionary<char, int> dict, char c)
        {
            if (!dict.ContainsKey(c))
                return;
            if (dict[c] <= 1)
                dict.Remove(c);
            else
                dict[c]--;
        }
        public bool DictionaryEquals(Dictionary<char, int> a, Dictionary<char, int> b)
        {
            foreach (var item in a)
            {
                if (b.TryGetValue(item.Key, out int count))
                    if (count == item.Value)
                        continue;
                return false;
            }
            return true;
        }
    }
}