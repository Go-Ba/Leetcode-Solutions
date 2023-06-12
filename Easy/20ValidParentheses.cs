using System.Collections.Generic;

public class ValidParentheses
{
    //https://leetcode.com/problems/valid-parentheses/
    public class Solution
    {
        public bool IsValid(string s)
        {
            Stack<char> openStack = new Stack<char>();
            foreach (char c in s)
            {
                if (IsOpen(c))
                    openStack.Push(c);
                else if (openStack.Count == 0 || !IsValidPair(openStack.Pop(), c))
                    return false;
            }
            return openStack.Count == 0;
        }
        bool IsValidPair(char open, char close)
        {
            switch (open)
            {
                case '(': return close == ')';
                case '{': return close == '}';
                case '[': return close == ']';
                default: return false;
            }
        }
        bool IsOpen(char b) => b == '(' || b == '{' || b == '[';
    }
}