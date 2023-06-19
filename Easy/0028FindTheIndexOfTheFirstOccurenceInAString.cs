using System.Collections.Generic;

public class FindTheIndexOfTheFirstOccurenceInAString
{
    //https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/
    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            Queue<int> returnPoints = new();
            int j = 0;
            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] != needle[j])
                {
                    j = 0;
                    if (returnPoints.Count > 0)
                        i = returnPoints.Dequeue();
                }
                if (haystack[i] == needle[j])
                {
                    if (j != 0 && haystack[i] == needle[0])
                        returnPoints.Enqueue(i);
                    j++;
                    if (j >= needle.Length)
                        return i - j + 1;
                }
            }
            return -1;
        }
    }
}