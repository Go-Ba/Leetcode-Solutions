public class RomanToInteger
{
    //https://leetcode.com/problems/roman-to-integer/
    public class Solution
    {
        public int RomanToInt(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                bool notLast = i != s.Length - 1;
                switch (s[i])
                {
                    case 'I':
                        count++;
                        if (notLast)
                        {
                            i++;
                            if (s[i] == 'V')
                                count += 3;
                            else if (s[i] == 'X')
                                count += 8;
                            else
                                i--;
                        }
                        break;
                    case 'V':
                        count += 5;
                        break;
                    case 'X':
                        count += 10;
                        if (notLast)
                        {
                            i++;
                            if (s[i] == 'L')
                                count += 30;
                            else if (s[i] == 'C')
                                count += 80;
                            else
                                i--;
                        }
                        break;
                    case 'L':
                        count += 50;
                        break;
                    case 'C':
                        count += 100;
                        if (notLast)
                        {
                            i++;
                            if (s[i] == 'D')
                                count += 300;
                            else if (s[i] == 'M')
                                count += 800;
                            else
                                i--;
                        }
                        break;
                    case 'D':
                        count += 500;
                        break;
                    case 'M':
                        count += 1000;
                        break;
                    default:
                        break;
                }
            }
            return count;
        }
    }
}