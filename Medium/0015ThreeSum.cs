using System;
using System.Collections.Generic;

public class ThreeSum
{
    //https://leetcode.com/problems/3sum/
    public class Solution_FastEnough
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            List<IList<int>> output = new List<IList<int>>();
            //-2 because no triplet can be formed by the final 2 elements
            for (int i = 0; i < nums.Length - 2; i++)
            {
                //avoid duplicates for first value in triplet
                //works because array is sorted
                if (i != 0 && nums[i] == nums[i - 1])
                    continue;
                var pairs = GetValidPairs(nums, i + 1, -nums[i]);
                foreach (var pair in pairs)
                {
                    output.Add(new List<int> { nums[i], pair[0], pair[1] });
                }
            }
            return output;
        }

        public List<int[]> GetValidPairs(int[] nums, int startIndex, int desiredComplement)
        {
            int l = startIndex, r = nums.Length - 1;
            List<int[]> output = new List<int[]>();

            while(l < r)
            {
                //skip dupes
                if (r != nums.Length - 1 && nums[r] == nums[r + 1])
                {
                    r--;
                    continue;
                }
                if (l != startIndex && nums[l] == nums[l - 1])
                {
                    l++;
                    continue;
                }
                //analyze sum
                int sum = nums[l] + nums[r];
                if (sum == desiredComplement)
                {
                    output.Add(new int[2] { nums[l], nums[r] });
                    //once a sum with these values is found, any valid sum involving these digits would be a repeat
                    r--;
                    l++;
                }
                else if (sum > desiredComplement)
                    r--;
                else
                    l++;
            }
            return output;
        }
    }
    public class Solution_Slow
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {

            //index1, index2, sum
            Dictionary<Tuple<int, int>, int> pairs = new Dictionary<Tuple<int, int>, int>();
            //value, indexes
            Dictionary<int, List<int>> values = new Dictionary<int, List<int>>();


            for (int i = 0; i < nums.Length; i++)
            {
                values.TryAdd(nums[i], new List<int>());
                values[nums[i]].Add(i);
                for (int j = i + 1; j < nums.Length; j++)
                    pairs.Add(new Tuple<int, int>(i, j), nums[i] + nums[j]);
            }

            HashSet<Tuple<int, int, int>> tripletsSet = new HashSet<Tuple<int, int, int>>();
            foreach (var pair in pairs)
            {
                if (values.TryGetValue(-pair.Value, out List<int> indexes))
                {
                    int i = pair.Key.Item1;
                    int j = pair.Key.Item2;
                    foreach (var k in indexes)
                    {
                        if (k == i || k == j) 
                            continue;
                        var triplet = new List<int> { nums[i], nums[j], nums[k] };
                        triplet.Sort();
                        tripletsSet.Add(new Tuple<int, int, int>(triplet[0], triplet[1], triplet[2]));
                    }
                }
            }
            List<IList<int>> output = new List<IList<int>>();
            foreach (var triplet in tripletsSet)           
                output.Add(new List<int> { triplet.Item1, triplet.Item2, triplet.Item3 });
            
            return output;
        }
    }
}
