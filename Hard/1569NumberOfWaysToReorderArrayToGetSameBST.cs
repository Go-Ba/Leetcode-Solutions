using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

public class NumberOfWaysToReorderArrayToGetSameBST
{
    //https://leetcode.com/problems/number-of-ways-to-reorder-array-to-get-same-bst
    public class Solution_SomewhatCleaner
    {
        readonly int mod = 1000000007; //% 10^9 + 7 is requirement of problem
        long[,] coefficientTable;
        public int NumOfWays(int[] nums)
        {
            GenerateBinomialCoefficientTable(nums.Length);
            return (NumOfWays(nums.ToList()) - 1) % mod;
        }
        public int NumOfWays(List<int> nums)
        {
            if (nums.Count <= 2)
                return 1;

            List<int> left = new List<int>();
            List<int> right = new List<int>();
            int root = nums[0];

            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] < root)
                    left.Add(nums[i]);
                else
                    right.Add(nums[i]);
            }

            long waysLeft = NumOfWays(left);
            long waysRight = NumOfWays(right);
            long subtrees = (waysLeft * waysRight) % mod;
            long binomialCoefficient = coefficientTable[nums.Count - 1, left.Count];
            return (int)((binomialCoefficient * subtrees) % mod);            
        }
        public void GenerateBinomialCoefficientTable(int size)
        {
            coefficientTable = new long[size, size];
            for (int i = 0; i < size; ++i)
            {
                coefficientTable[i, 0] = 1;
                coefficientTable[i, i] = 1;
            }
            for (int i = 2; i < size; i++)           
                for (int j = 1; j < i; j++)                
                    coefficientTable[i, j] = (coefficientTable[i - 1, j - 1] + coefficientTable[i - 1, j]) % mod;                            
        }
    }
    public class Solution_Messy
    {
        readonly int mod = 1000000007; //% 10^9 + 7 is requirement of problem
        public int NumOfWays(int[] nums)
        {
            GenerateBinomialCoefficients(nums.Length);
            return (NumOfWays(nums.ToList()) - 1) % mod;
        }
        public int NumOfWays(List<int> nums)
        {
            if (nums.Count <= 2)
                return 1;

            List<int> left = new List<int>();
            List<int> right = new List<int>();
            int root = nums[0];

            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] < root)
                    left.Add(nums[i]);
                else
                    right.Add(nums[i]);
            }
            BigInteger waysLeft = NumOfWays(left);
            BigInteger waysRight = NumOfWays(right);
            BigInteger subtrees = (waysLeft * waysRight) % mod;
            Console.WriteLine($"waysLeft: {waysLeft}, waysRight: {waysRight}, subtrees: {subtrees}");

            BigInteger binomialCoefficient = table[nums.Count - 1, left.Count];
            BigInteger result = (binomialCoefficient * subtrees) % mod;
            Console.WriteLine($"nums: {nums.Count}, left: {left.Count}, right: {right.Count}, C: {binomialCoefficient}, subtrees: {subtrees}, result: {result}, {(int)result}");
            return (int)(result%mod);
        }
        long[,] table;
        public void GenerateBinomialCoefficients(int size)
        {
            table = new long[size, size];
            for (int i = 0; i < size; ++i)
            {
                table[i, 0] = 1;
                table[i, i] = 1;
            }
            for (int i = 2; i < size; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    table[i,j] = (table[i - 1, j - 1] + table[i - 1, j]) % mod;
                }
            }
        }
    }
}

