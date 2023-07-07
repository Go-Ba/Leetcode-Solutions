using System;
using System.Collections.Generic;
using System.Linq;

public class GroupAnagrams
{
    //https://leetcode.com/problems/group-anagrams/
    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            //sort each string and then stores a list of all strings with the same sort result
            //in a list with the sorted string as the key
            Dictionary<string, List<string>> charSortedDict = new Dictionary<string, List<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                string sortedString = String.Concat(strs[i].OrderBy(c => c));
                if (!charSortedDict.TryAdd(sortedString, new List<string>() { strs[i] }))
                {
                    charSortedDict[sortedString].Add(strs[i]);
                }
            }

            //put all the lists into the output list
            List<IList<string>> output = new List<IList<string>>();
            foreach (var item in charSortedDict)           
                output.Add(item.Value);
            
            return output;
        }
    }
}
public class MaximizeTheConfusionOfAnExame
{
    //https://leetcode.com/problems/maximize-the-confusion-of-an-exam/
    public class Solution
    {
        public int MaxConsecutiveAnswers(string answerKey, int k)
        {
            int left = 0, T = 0, F = 0, maxSpan = 0;

            for (int right = 0; right < answerKey.Length; right++)
            {
                //count the number of F and T chars so far
                if (answerKey[right] == 'F')
                    F++;
                else
                    T++;

                //if both T and F are over k, then we have an invalid window
                while (T > k && F > k)
                {
                    //move the left pointer until we return to a valid window
                    if (answerKey[left] == 'F')
                        F--;
                    else
                        T--;
                    left++;
                }
                //compare the current window to the maximum we have found
                maxSpan = Math.Max(maxSpan, right - left + 1);
            }
            return maxSpan;
        }
    }
}