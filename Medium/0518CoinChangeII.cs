using System.Collections.Generic;
public class CoinChangeII
{
    public class Solution1
    {
        Dictionary<(int, int), int> cache;
        public int Change(int amount, int[] coins)
        {
            if (amount == 0) return 1;
            cache = new();
            int solutions = 0;
            foreach (var coin in coins)
                solutions += GetCombinationCount(coin, 0, coins, amount);
            return solutions;
        }
        public int GetCombinationCount(int nextCoin, int currentTotal, int[] coins, int goalTotal)
        {
            if (cache.TryGetValue((nextCoin, currentTotal), out int result))
                return result;
            int newTotal = currentTotal + nextCoin;

            if (newTotal > goalTotal)
            {
                cache.Add((nextCoin, currentTotal), 0);
                return 0;
            }
            if (newTotal == goalTotal)
            {
                cache.Add((nextCoin, currentTotal), 1);
                return 1;
            }

            int solutions = 0;
            foreach (var coin in coins)
            {
                if (coin > nextCoin) continue;
                solutions += GetCombinationCount(coin, newTotal, coins, goalTotal);
            }
            cache.Add((nextCoin, currentTotal), solutions);
            return solutions;
        }
    }
}
