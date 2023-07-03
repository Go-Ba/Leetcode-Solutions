using System.Collections.Generic;

public class BuddyStrings
{
    //https://leetcode.com/problems/buddy-strings/
    public class Solution_TwoFunc
    {
        public bool BuddyStrings(string s, string goal)
        {
            if (s.Length != goal.Length)
                return false;
            if (s == goal)
                return HasDupe(s, goal);
            return CanSwitch(s, goal);
        }
        bool HasDupe(string s, string goal)
        {
            HashSet<char> letters = new();
            for (int i = 0; i < s.Length; i++)
            {
                if (letters.Contains(s[i]))
                    return true;
                letters.Add(s[i]);
            }
            return false;
        }
        bool CanSwitch(string s, string goal)
        {
            (char, char) charPair = new('_', '_');
            int errors = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == goal[i])
                    continue;
                switch (errors++)
                {
                    case 0:
                        charPair = (s[i], goal[i]);
                        break;
                    case 1:
                        if ((goal[i], s[i]) != charPair)
                            return false;
                        break;
                    default: return false;
                }
            }
            return errors == 2;
        }
    }
    public class Solution_TwoChecks
    {
        public bool BuddyStrings(string s, string goal)
        {
            if (s.Length != goal.Length)
                return false;

            if (s == goal)
            {
                HashSet<char> letters = new();
                for (int i = 0; i < s.Length; i++)
                {
                    if (letters.Contains(s[i]))
                        return true;
                    letters.Add(s[i]);
                }
                return false;
            }

            (char, char) difference = new('_', '_');
            int errors = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != goal[i])
                {
                    if (errors == 0)
                    {
                        errors++;
                        difference = (s[i], goal[i]);
                    }
                    else if (errors == 1)
                    {
                        errors++;
                        if ((goal[i], s[i]) != difference)
                            return false;
                    }
                    else
                        return false;
                }
            }
            return errors == 2;
        }
    }
    public class Solution_Dict
    {
        public bool BuddyStrings(string s, string goal)
        {
            if (s.Length != goal.Length)
                return false;

            Dictionary<char, int> sDict = new Dictionary<char, int>();
            Dictionary<char, int> goalDict = new Dictionary<char, int>();
            int errors = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (!sDict.TryAdd(s[i], 1))
                    sDict[s[i]]++;
                if (!goalDict.TryAdd(goal[i], 1))
                    goalDict[goal[i]]++;
                if (s[i] != goal[i])
                    errors++;
                if (errors > 2)
                    return false;
            }
            if (sDict.Count != goalDict.Count)
                return false;

            bool isDupe = false;
            foreach (var item in sDict)
            {
                if (!goalDict.ContainsKey(item.Key))
                    return false;
                if (goalDict[item.Key] != item.Value)
                    return false;
                if (item.Value > 1)                
                    isDupe = true;         
            }

            return errors > 0 || isDupe;
        }
    }
}