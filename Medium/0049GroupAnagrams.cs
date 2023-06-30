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
