public class MinimumFlipsToMakeAOrBEqualToC
{
    //https://leetcode.com/problems/minimum-flips-to-make-a-or-b-equal-to-c/
    public class Solution
    {
        public int MinFlips(int a, int b, int c)
        {
            int count = 0;
            while (a != 0 || b != 0 || c != 0)
            {
                int aBit = a & 1;
                int bBit = b & 1;
                int cBit = c & 1;

                if (cBit == 0)
                    count += aBit + bBit;
                else if (aBit == 0 && bBit == 0)
                    count++;

                a >>= 1;
                b >>= 1;
                c >>= 1;
            }
            return count;
        }
    }
}