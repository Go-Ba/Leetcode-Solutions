public class SingleNumberII
{
    //https://leetcode.com/problems/single-number-ii/
    public class Solution_BitManipulation
    {
        //This solution is unintuitive, it just works because *bit magic*
        public int SingleNumber(int[] nums)
        {
            //when an element first shows up, the bits will be put into ones
            //when it shows up a second time, the bits will be moved into twos
            //when it shows up a third time, the bits will be removed from twos
            //at the end, there will only be the bits of the single non-repeating number in ones
            int ones = 0, twos = 0;
            foreach (var num in nums)
            {
                ones ^= num & ~twos;
                twos ^= num & ~ones;
            }
            return ones;
        }
    }
    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            //create a 32 int array to store the count of each of the 32 bits of the ints
            int[] bitCount = new int[32];

            //go through each int and count its bits
            foreach (int num in nums)
                for (int i = 0; i < 32; i++)
                    //we shift the number by i places to the right
                    //then bitwise-and with 1 to find the bit at that position
                    //add that bit to the i'th place of the array to count it
                    bitCount[i] += num >> i & 1;


            int result = 0;
            //we go backwards through the array because we
            //are sending the bits from the right back to the left
            //so we want the final bits to be processed first
            for (int i = 31; i >= 0; i--)
            {
                //we shift the result to the left by one place so the current
                //bits get sent towards the end and we have a new place at the start
                result <<= 1;
                //all numbers repeat three times except one, therefore if we do mod 3
                //of the bit count, we will get either 0 if the bit isn't in our
                //non-repeating number or a 1 if the bit *is* in our non-repeating number.
                bitCount[i] %= 3;
                //we bitwise-or the result with the new bitcount (0 or 1)
                //this sets the current starting bit to 1 if the bit is in our non-repeating number
                result |= bitCount[i];
            }

            //after setting all the bits to our result, we have the non-repeating number
            return result;
        }
    }
}