using System.Collections.Generic;

public class SummaryRanges
{
    //https://leetcode.com/problems/summary-ranges/
    public class Solution
    {
        public IList<string> SummaryRanges(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return new List<string>();
            if (nums.Length == 1)
                return new List<string> { nums[0].ToString() };
            var output = new List<string>();
            int headNum = nums[0];
            int previousNum = headNum;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] - previousNum != 1)
                {
                    output.Add(GetString(headNum, previousNum));
                    headNum = nums[i];
                }
                previousNum = nums[i];
            }
            output.Add(GetString(headNum, previousNum));
            return output;
        }
        public string GetString(int headNum, int tailNum)
        {
            if (headNum == tailNum)
                return headNum.ToString();
            else
                return $"{headNum}->{tailNum}";
        }
    }
}