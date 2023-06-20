using System;

public class BestTimeToBuyAndSellStock
{
    //https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int minimumSoFar = int.MaxValue, maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                minimumSoFar = Math.Min(minimumSoFar, prices[i]);
                maxProfit = Math.Max(maxProfit, prices[i] - minimumSoFar);
            }
            return maxProfit;
        }
    }
    //This might be a bit overengineered...
    public class Solution_Preprocess
    {
        public int MaxProfit(int[] prices)
        {
            int length = prices.Length;
            int[] minPriceSoFar = new int[length];
            int[] maxPriceInFuture = new int[length];
            minPriceSoFar[0] = prices[0];
            maxPriceInFuture[length - 1] = prices[length - 1];

            //get the minimum and maximum from every point
            for (int i = 1; i < length; i++)
            {
                minPriceSoFar[i] = Math.Min(prices[i], minPriceSoFar[i - 1]);
                maxPriceInFuture[length - 1 - i] = Math.Max(prices[length - 1 - i], maxPriceInFuture[length - 1 - i]);
            }

            //get the max profit of each point and return the best
            int bestProfit = 0;
            for (int i = 0; i < length; i++)
            {
                int todayProfit = maxPriceInFuture[i] - minPriceSoFar[i];
                bestProfit = Math.Max(todayProfit, bestProfit);
            }

            return bestProfit;
        }
    }
}