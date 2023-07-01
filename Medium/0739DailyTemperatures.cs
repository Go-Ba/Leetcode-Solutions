using System.Collections.Generic;

public class DailyTemperatures
{
    //https://leetcode.com/problems/daily-temperatures/
    public class Solution_Stack
    {
        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] output = new int[temperatures.Length];
            Stack<int> indexStack = new();
            indexStack.Push(0);
            for (int i = 1; i < temperatures.Length; i++)
            {
                while (indexStack.Count > 0 && temperatures[indexStack.Peek()] < temperatures[i])
                {
                    int index = indexStack.Pop();
                    output[index] = i - index;
                }
                indexStack.Push(i);
            }
            return output;
        }
    }
    public class Solution_Naive
    {
        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] output = new int[temperatures.Length];
            for (int i = 0; i < temperatures.Length; i++)
                for (int j = i + 1; j < temperatures.Length; j++)
                    if (temperatures[j] > temperatures[i])
                    {
                        output[i] = j - i;
                        break;
                    }
             return output;       
        }
    }
}