using System;
using System.Collections.Generic;
using System.Linq;
public class KokoEatingBananas
{
    //https://leetcode.com/problems/koko-eating-bananas/
    public class Solution
    {
        public int MinEatingSpeed(int[] piles, int h)
        {
            if (piles.Length == 1)
                return (int)Math.Ceiling((double)piles[0] / h);
            if (h <= piles.Length)
                return piles.Max();

            int l = 0, r = piles.Max(), mid = 0;
            int minRate = int.MaxValue;
            while (l <= r)
            {
                mid = (l + r) / 2;
                long duration = AssessDuration(piles, mid);
                if (duration > h)
                    l = mid + 1;
                else
                {
                    minRate = Math.Min(minRate, mid);
                    r = mid - 1;
                }
            }
            return minRate;
        }
        public long AssessDuration(int[] piles, int speed)
        {
            if (speed == 0)
                return int.MaxValue;
            long hours = 0;
            for (int i = 0; i < piles.Length; i++)
            {
                hours += (int)Math.Ceiling((double)piles[i] / speed);
            }
            return hours;
        }
    }
}