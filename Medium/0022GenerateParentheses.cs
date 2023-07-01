using System.Collections.Generic;

public class GenerateParentheses
{
    //https://leetcode.com/problems/generate-parentheses/
    public class Solution2
    {
        List<string> validStrings;
        int maxPairs;
        public IList<string> GenerateParenthesis(int n)
        {
            validStrings = new List<string>();
            maxPairs = n;
            GetStringList("(", 1, 0);
            return validStrings;
        }
        public void GetStringList(string currentString, int left, int right)
        {
            if (left + right == maxPairs * 2)
            {
                if (currentString[^1] == ')')
                    validStrings.Add(currentString);
                return;
            }

            if (left < maxPairs)
                GetStringList(currentString + "(", left + 1, right);
            if (right < maxPairs && left > right)
                GetStringList(currentString + ")", left, right + 1);
        }
    }
    public class Solution1
    {
        HashSet<string> validStrings;
        public IList<string> GenerateParenthesis(int n)
        {
            validStrings = new HashSet<string>();
            GetStringList("(", 1, 0, n);
            List<string> output = new List<string>();
            foreach (var item in validStrings)            
                output.Add(item);
            return output;
        }
        public void GetStringList(string currentString, int left, int right, int maxPairs)
        {
            if (left + right == maxPairs * 2)
            {
                if (currentString[^1] == ')')
                    validStrings.Add(currentString);
                return;
            }

            if (left < maxPairs)
                GetStringList(currentString + "(", left + 1, right, maxPairs);
            if (right < maxPairs && left > right)
                GetStringList(currentString + ")", left, right + 1, maxPairs);
        }
    }
}