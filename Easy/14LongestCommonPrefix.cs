public class LongestCommonPrefix
{
    //https://leetcode.com/problems/longest-common-prefix/
    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            string longestPrefix = strs[0];
            foreach (var word in strs)
                longestPrefix = GetLongestCommonPrefix(longestPrefix, word);

            return longestPrefix;
        }
        public string GetLongestCommonPrefix(string a, string b)
        {
            if (a == null || b == null || a == "" || b == "" || a[0] != b[0])
                return "";
            for (int i = 0; i < a.Length; i++)
            {
                if (i >= b.Length)
                    return b;
                if (a[i] != b[i])
                    return a.Substring(0, i);
            }
            return a;
        }
    }
}