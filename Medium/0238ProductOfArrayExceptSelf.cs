public class ProductOfArrayExceptSelf
{
    //https://leetcode.com/problems/product-of-array-except-self/

    //needs to be O(n) with no division
    public class Solution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] prefix = new int[nums.Length];
            int[] postfix = new int[nums.Length];
            int[] output = new int[nums.Length];

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i == nums.Length - 1)
                    postfix[i] = 1;
                else
                    postfix[i] = nums[i + 1] * postfix[i + 1];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                    prefix[i] = 1;
                else
                    prefix[i] = nums[i - 1] * prefix[i - 1];

                output[i] = prefix[i] * postfix[i];
            }
            return output;

        }
    }
    public class Solution_NSquared
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] output = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                int product = 1;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j) continue;
                    product *= nums[j];
                }
                output[i] = product;
            }
            return output;
        }
    }
}