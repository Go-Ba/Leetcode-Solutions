using System;
using System.Collections.Generic;
using System.Linq;

public class TotalCostToHireKWorkers
{
    //https://leetcode.com/problems/total-cost-to-hire-k-workers/

    //my version of .NET doesn't have priority queues lol
    public class Solution
    {
        public long TotalCost(int[] costs, int k, int candidates)
        {
            var pqLeft = new PriorityQueue<int, int>();
            var pqRight = new PriorityQueue<int, int>();
            int i = 0, j = costs.Length - 1;
            long totalCost = 0;

            while (k > 0)
            {
                //add items to the priority queue until it has enough candidates
                //or until it hits the other priority queue's end
                while (pqLeft.Count < candidates && i <= j)
                {
                    pqLeft.Enqueue(costs[i], costs[i]);
                    i++;
                }
                while (pqRight.Count < candidates && j >= i)
                {
                    pqRight.Enqueue(costs[j], costs[j]);
                    j--;
                }

                //get the lowest value from left and right
                int left = pqLeft.Count > 0 ? pqLeft.Peek() : int.MaxValue;
                int right = pqRight.Count > 0 ? pqRight.Peek() : int.MaxValue;

                //prefer the left one because it will have the smallest index if equal
                if (left <= right)
                    pqLeft.TryDequeue(out int _, out int _);               
                else
                    pqRight.TryDequeue(out int _, out int _);                

                //add to total cost
                totalCost += Math.Min(left, right);

                k--;
            }
            return totalCost;
        }
    }
    public class Solution_TooSlow
    {
        public long TotalCost(int[] costs, int k, int candidates)
        {
            List<int> costList = costs.ToList();
            long totalCost = 0;

            for (int i = 0; i < k; i++)
            {
                int lowestCost = int.MaxValue, lowestIndex = int.MaxValue;
                int loops = Math.Min(candidates, (int)Math.Ceiling((double)costList.Count / 2));
                for (int j = 0; j < loops; j++)
                {
                    CheckIndex(costList, j, ref lowestCost, ref lowestIndex);
                    CheckIndex(costList, costList.Count - j - 1, ref lowestCost, ref lowestIndex);
                }
                totalCost += lowestCost;
                costList.RemoveAt(lowestIndex);
            }
            return totalCost;
        }
        public void CheckIndex(List<int> costList, int i, ref int lowestCost, ref int lowestIndex)
        {
            if (costList[i] > lowestCost)
                return;

            if (costList[i] < lowestCost)
                lowestIndex = i;
            else
                lowestIndex = Math.Min(i, lowestIndex);
            lowestCost = costList[i];
        }
    }
}