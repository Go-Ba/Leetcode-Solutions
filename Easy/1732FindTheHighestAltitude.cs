using System;

public class FindTheHighestAltitude
{
    //https://leetcode.com/problems/find-the-highest-altitude/
    public class Solution
    {
        public int LargestAltitude(int[] gain)
        {
            int currentAltitude = 0;
            int maxAltitude = 0;

            for (int i = 0; i < gain.Length; i++)
            {
                currentAltitude += gain[i];
                maxAltitude = Math.Max(maxAltitude, currentAltitude);
            }
            return maxAltitude;
        }
    }
}