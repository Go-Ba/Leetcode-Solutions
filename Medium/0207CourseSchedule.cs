using System.Collections.Generic;

public class CourseSchedule
{
    //https://leetcode.com/problems/course-schedule/
    public class Solution
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            List<int>[] graph = new List<int>[numCourses];
            foreach (var prerequisite in prerequisites)
            {
                if (graph[prerequisite[0]] == null)
                    graph[prerequisite[0]] = new();
                graph[prerequisite[0]].Add(prerequisite[1]);
            }

            //copied from problem 802
            HashSet<int> traversed = new();
            bool?[] isSafe = new bool?[graph.Length];

            for (int i = 0; i < graph.Length; i++)
                if (!IsSafeNode(i))
                    return false;
            return true;

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
            bool AreNeighboursSafe(List<int> neighbours)
            {
                if (neighbours == null)
                    return true;
                foreach (int neighbour in neighbours)
                    if (traversed.Contains(neighbour) || !IsSafeNode(neighbour))
                        return false;
                return true;
            }
        }
    }
}