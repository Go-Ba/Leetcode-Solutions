public class FindTheDuplicateNumber
{
    //https://leetcode.com/problems/find-the-duplicate-number/
    public class Solution_FloydsTortoiseAndHare
    {
        public int FindDuplicate(int[] nums)
        {
            int tort = 0, hare = 0;
            tort = nums[tort];
            hare = nums[nums[hare]];
            while (tort != hare)
            {
                tort = nums[tort];
                hare = nums[nums[hare]]; 
            }
            tort = 0;
            while (tort != hare)
            {
                tort = nums[tort];
                hare = nums[hare];
            }
            return nums[tort];
        }
    }
    public class Solution_Slow
    {
        public int FindDuplicate(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)            
                for (int j = i+1; j < nums.Length; j++)               
                    if (nums[i] == nums[j])
                        return nums[i];               
            
            return -1;
        }
    }
}
