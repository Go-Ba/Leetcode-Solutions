using System;

public class MaximizeTheConfusionOfAnExame
{
    //https://leetcode.com/problems/maximize-the-confusion-of-an-exam/
    public class Solution
    {
        public int MaxConsecutiveAnswers(string answerKey, int k)
        {
            int left = 0, T = 0, F = 0, maxSpan = 0;

            for (int right = 0; right < answerKey.Length; right++)
            {
                if (answerKey[right] == 'F')
                    F++;
                else
                    T++;

                while (T > k && F > k)
                {
                    if (answerKey[left++] == 'F')
                        F--;
                    else
                        T--;
                }
                maxSpan = Math.Max(maxSpan, right - left + 1);
            }
            return maxSpan;
        }
    }
}