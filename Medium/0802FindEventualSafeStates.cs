using System.Collections.Generic;

public class FindEventualSafeStates
{
    //https://leetcode.com/problems/find-eventual-safe-states/
    public class Solution2
    {
        public IList<int> EventualSafeNodes(int[][] graph)
        {
            List<int> safeNodes = new();
            HashSet<int> traversed = new();
            bool?[] isSafe = new bool?[graph.Length];

            for (int i = 0; i < graph.Length; i++)
                if (IsSafeNode(i))
                    safeNodes.Add(i);

            return safeNodes;

            bool IsSafeNode(int current)
            {
                if (isSafe[current] != null)
                    return isSafe[current] == true;

                traversed.Add(current);
                bool safeNeighbours = AreNeighboursSafe(graph[current]);
                traversed.Remove(current);

                isSafe[current] = safeNeighbours;
                return safeNeighbours;
            }
            bool AreNeighboursSafe(int[] neighbours)
            {
                foreach (int neighbour in neighbours)
                    if (traversed.Contains(neighbour) || !IsSafeNode(neighbour))
                        return false;
                return true;
            }
        }
    }
    public class Solution1
    {
        bool?[] isSafe;
        int[][] graph;
        HashSet<int> traversed;
        public IList<int> EventualSafeNodes(int[][] graph)
        {
            isSafe = new bool?[graph.Length];
            this.graph = graph;
            List<int> safeNodes = new List<int>();
            traversed = new HashSet<int>();

            for (int i = 0; i < graph.Length; i++)
            {
                if (IsSafeNode(i))
                {
                    safeNodes.Add(i);
                }
            }

            return safeNodes;
        }
        bool IsSafeNode(int current)
        {
            if (isSafe[current] != null)
                return isSafe[current] == true;

            traversed.Add(current);
            var neighbours = graph[current];

            for (int i = 0; i < neighbours.Length; i++)
            {            
                if (traversed.Contains(neighbours[i]) || !IsSafeNode(neighbours[i]))
                {
                    traversed.Remove(current);
                    isSafe[current] = false;
                    return false;
                }
            }
            traversed.Remove(current);
            isSafe[current] = true;
            return true;
        }
    }
}