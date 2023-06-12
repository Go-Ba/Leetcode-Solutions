public class FindSmallestLetterGreaterThanTarget
{
    //https://leetcode.com/problems/find-smallest-letter-greater-than-target/
    public class Solution
    {
        public char NextGreatestLetter(char[] letters, char target)
        {
            int min = 0, max = letters.Length - 1, mid;
            while (min <= max)
            {
                mid = (min + max) / 2;
                if (letters[mid] > target)
                    max = mid - 1;
                else
                    min = mid + 1;
            }
            if (min == letters.Length)
                return letters[0];
            return letters[min];
        }
    }
}