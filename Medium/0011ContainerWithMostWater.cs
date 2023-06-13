using System;

public class ContainerWithMostWater
{
    //https://leetcode.com/problems/container-with-most-water/
    public class Solution_MoveSmallerPointer_Cleaner //beats 98% in runtime
    {
        public int MaxArea(int[] height)
        {
            int l = 0, r = height.Length - 1, bestArea = 0;
            while (l < r)
            {
                bestArea = Math.Max(bestArea, GetArea(height, l, r));
                //move the smallest of the two pointers because it is the only way to increase area
                if (height[l] < height[r]) 
                    l++;
                else if (height[l] == height[r]) //check == after < because < is much more likely to occur
                {
                    l++; r--;
                }
                else 
                    r--;
            }
            return bestArea;
        }
        public int GetArea(int[] height, int a, int b) => Math.Min(height[a], height[b]) * (b - a);
    }
    public class Solution_MoveSmallerPointer
    {
        public int MaxArea(int[] height)
        {
            int l = 0, r = height.Length - 1, bestL = l, bestR = r, bestArea = GetArea(height, l, r);
            l++;
            r--;
            while (l < r)
            {
                int newRArea = GetArea(height, bestL, r);
                int newLArea = GetArea(height, l, bestR);
                int newBothArea = GetArea(height, l, r);
                int maxArea = Math.Max(newRArea, newLArea);
                maxArea = Math.Max(maxArea, newBothArea);
                if (newBothArea == maxArea && newBothArea > bestArea)
                {
                    bestR = r;
                    bestL = l;
                    bestArea = maxArea;
                }
                else if (newRArea == maxArea && newRArea > bestArea)
                {
                    bestR = r;
                    bestArea = maxArea;
                }
                else if (newLArea == maxArea && newLArea > bestArea)
                {
                    bestL = l;
                    bestArea = maxArea;
                }
                //move the smallest of the two pointers because it is the only way to increase area
                if (height[l] < height[r])
                    l++;
                else
                    r--;
            }
            return bestArea;
        }
        public int GetArea(int[] height, int a, int b) => Math.Min(height[a], height[b]) * (b - a);
    }
    public class Solution_Slow
    {
        public int MaxArea(int[] height)
        {
            int maxArea = 0;
            for (int i = 0; i < height.Length; i++)
            {
                for (int j = i+1; j < height.Length; j++)
                {
                    int area = GetArea(height, i, j);
                    Console.WriteLine($"{i}, {j}: area: {area} min: {Math.Min(height[i], height[j])}");
                    if (area > maxArea)
                        maxArea = area;
                }
            }
            return maxArea;
        }
        public int GetArea(int[] heights, int a, int b) => Math.Min(heights[a], heights[b]) * (b - a);
    }
}