public class SortColors
{
    //https://leetcode.com/problems/sort-colors/
    public class Solution_MiddleSwap
    {
        //sorts each end of the array while moving towards the middle
        public void SortColors(int[] nums)
        {
            if (nums.Length <= 1)
                return;

            int l = 0, r = nums.Length - 1, mid = 0;

            while (mid <= r)
            {
                switch (nums[mid])
                {
                    case 0:
                        (nums[l], nums[mid]) = (nums[mid], nums[l]);
                        l++;
                        mid++;
                        break;
                    case 1:
                        mid++;
                        break;
                    case 2:
                        (nums[r], nums[mid]) = (nums[mid], nums[r]);
                        r--;
                        break;
                }
            }
        }
    }
    public class Solution_Counting
    {
        //one pass to count the amount of each
        //another pass to place them into the array in order
        public void SortColors(int[] nums)
        {
            int zeroes = 0;
            int ones = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    zeroes++;
                else if (nums[i] == 1)
                    ones++;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (i < zeroes)
                    nums[i] = 0;
                else if (i < ones + zeroes)
                    nums[i] = 1;
                else
                    nums[i] = 2;
            }
        }
    }
}