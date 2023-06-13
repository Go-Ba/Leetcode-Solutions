using System;
using System.Collections.Generic;
using System.Text;

public class TrappingRainWater
{
    //https://leetcode.com/problems/trapping-rain-water/

    //uses a stack to keep track of when the terrain goes downhill
    //then pops off the stack when terrain goes uphill and
    //calculates the area between
    public class Solution_Stack_FastEnough
    {
        public int Trap(int[] height)
        {
            //index, depth
            Stack<Tuple<int, int>> downslopeEvents = new Stack<Tuple<int, int>>();
            int totalWaterArea = 0;
            for (int i = 1; i < height.Length; i++)
            {
                int heightDif = (height[i] - height[i - 1]);
                if (heightDif < 0)
                    downslopeEvents.Push(new Tuple<int, int>(i, Math.Abs(heightDif)));
                while (downslopeEvents.Count > 0 && heightDif > 0)
                {
                    var downslopeEvent = downslopeEvents.Pop();
                    int distance = i - downslopeEvent.Item1;
                    int downslopeHeight = downslopeEvent.Item2;

                    //if remaining upslope height is less than the height of the most recent downslope amount
                    //we remove the upslope height from the downslope amount and add the event back with the reduced amount
                    //this will then break out of the loop
                    if (heightDif < downslopeHeight)
                    {
                        totalWaterArea += distance * heightDif;
                        var revisedEvent = new Tuple<int, int>(downslopeEvent.Item1, downslopeHeight - heightDif);
                        downslopeEvents.Push(revisedEvent);
                        heightDif -= downslopeHeight;
                    }
                    //if the remaining upslope height is MORE than the most recent downslope amount
                    //we remove the downslope amount from the upslope height
                    //loop will continue until we hit the condition above this where we've
                    //used up enough height to reach the current altitude
                    else
                    {
                        totalWaterArea += distance * downslopeHeight;
                        heightDif -= downslopeHeight;
                    }
                }
            }
            return totalWaterArea;
        }
        public string StackString(Stack<Tuple<int, int>> downslopeEvents)
        {
            StringBuilder output = new StringBuilder();
            foreach (var item in downslopeEvents)
                output.Append($"<{item.Item1}, {item.Item2}> ");
            output.Append("\n ");
            return output.ToString();
        }
    }
    /*
    public class Solution
    {
        public int Trap(int[] height)
        {
            int maxLeft = 0, maxRight = 0, maxArea = 0;
            for (int i = 1; i < height.Length; i++)
            {
                maxLeft = Math.Max(height[i - 1], maxLeft);
                maxRight = Math.Max(height[height.Length - i], maxRight);
                maxArea += Math.Clamp(Math.Min(maxLeft, maxRight) - height[i], 0, int.MaxValue);
            }
            return maxArea;
        }
    }
    */
    public class Solution_MinMax
    {
        public int Trap(int[] height)
        {
            int length = height.Length;
            int[] maxLeft = new int[length];
            int[] maxRight = new int[length];

            for (int i = 1; i < length; i++)            
                maxLeft[i] = Math.Max(height[i - 1], maxLeft[i - 1]);            
            for (int i = length - 2; i >- 0; i--)            
                maxRight[i] = Math.Max(height[i + 1], maxRight[i + 1]);

            int maxArea = 0;
            for (int i = 0; i < length; i++)           
                maxArea += Math.Clamp(Math.Min(maxLeft[i], maxRight[i]) - height[i], 0, int.MaxValue);

            return maxArea;
        }
    }
    public class Solution_Stack_TooSlow
    {
        public int Trap(int[] height)
        {
            Stack<int> DownslopeIndex = new Stack<int>();
            int totalWaterArea = 0;
            for (int i = 1; i < height.Length; i++)
            {
                int heightDif = (height[i] - height[i - 1]);
                while (heightDif < 0)
                {
                    DownslopeIndex.Push(i);
                    heightDif++;
                }
                while (DownslopeIndex.Count > 0 && heightDif > 0)
                {
                    int index = DownslopeIndex.Pop();
                    totalWaterArea += i - index;
                    heightDif--;
                }
            }
            return totalWaterArea;
        }
    }
}
