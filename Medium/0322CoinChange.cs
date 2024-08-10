using System;
using System.Collections.Generic;

public class CoinChange
{
    public class Solution1
    {
        int minCount;
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;
            minCount = -1;
            GetCombinationCount(0, 0, 0, coins, amount);
            return minCount;
        }
        public void GetCombinationCount(int nextCoin, int currentTotal, int currentCount, int[] coins, int goalTotal)
        {
            if (currentCount >= minCount && minCount > 0)
                return;
            currentTotal += nextCoin;
            if (currentTotal > goalTotal)
                return;
            if (currentTotal == goalTotal)
            {
                minCount = currentCount;
                return;
            }
            foreach (var coin in coins)
            {
                if (coin < nextCoin) continue;
                GetCombinationCount(coin, currentTotal, currentCount + 1, coins, goalTotal);
            }
        }
    }
    public class Solution2
    {
        Dictionary<(int, long), int> CoinAndTotalToDistance;
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;
            CoinAndTotalToDistance = new();
            return GetDistanceToGoal(0, 0, coins, amount);
        }
        public int GetDistanceToGoal(int nextCoin, long currentTotal, int[] coins, int goalTotal)
        {
            if (CoinAndTotalToDistance.TryGetValue((nextCoin, currentTotal), out int result))
                return result;

            var newTotal = currentTotal + nextCoin;
            if (newTotal > goalTotal)
                return -1;
            if (newTotal == goalTotal)
            {
                CoinAndTotalToDistance.Add((nextCoin, currentTotal), 0);
                return 0;
            }
            var minDis = -1;
            foreach (var coin in coins)
            {
                var dis = GetDistanceToGoal(coin, newTotal, coins, goalTotal);
                if (minDis < 0) minDis = dis;
                if (dis < minDis && dis >= 0) minDis = dis;
            }
            if (minDis >= 0)
                minDis++;
            CoinAndTotalToDistance.Add((nextCoin, currentTotal), minDis);
            return minDis;
        }
    }
    public class Solution
    {
        int[] cache;
        public int CoinChange(int[] coins, int amount)
        {
            cache = new int[amount + 1];
            for (int i = 0; i < amount + 1; i++)           
                cache[i] = amount + 1;
            cache[0] = 0;

            foreach (int coin in coins)            
                for (int i = coin; i <= amount; i++)               
                    cache[i] = Math.Min(cache[i], cache[i - coin] + 1);

            return cache[amount] <= amount ? cache[amount] : -1;
        }
    }

    /*

    1,2,5
    6
    0,1,1,2,2,1,2
    
    */

}