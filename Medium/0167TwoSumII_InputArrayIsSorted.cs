public class TwoSumII_InputArrayIsSorted
{
    //https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
    public class Solution_BinarySearch
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length <= 1)
                return new int[2];

            int l, r, mid, complement;
            for (int i = 0; i < numbers.Length; i++)
            {
                complement = target - numbers[i];
                l = i + 1;
                r = numbers.Length - 1;
                while (r >= l)
                {
                    mid = l + (r - l) / 2;
                    if (numbers[mid] == complement)
                        return new int[] { i + 1, mid + 1 };
                    else if (numbers[mid] > complement)
                        r = mid - 1;
                    else
                        l = mid + 1;
                }
            }
            return new int[2];
        }
    }
    public class Solution_TwoPointers
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length <= 1)
                return new int[2];

            int l = 0, r = numbers.Length - 1;
            while (l < r)
            {
                int sum = numbers[l] + numbers[r];
                if (sum == target)
                    return new int[] { l + 1, r + 1 };
                else if (sum > target)
                    r--;
                else
                    l++;
            }
            return new int[2];
        }
    }
    public class Solution_Naive
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length <= 1)
                return new int[2];

            int complement;
            for (int i = 0; i < numbers.Length; i++)
            {
                complement = target - numbers[i];
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] > complement)
                        break;
                    if (numbers[j] == complement)
                        return new int[2] { i + 1, j + 1 };
                }
            }
            return new int[2];
        }
    }
}

