using System;
using System.Collections.Generic;
using System.Linq;

public class GroupAnagrams
{
    //https://leetcode.com/problems/group-anagrams/
    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            //sort each string and then stores a list of all strings with the same sort result
            //in a list with the sorted string as the key
            Dictionary<string, List<string>> charSortedDict = new Dictionary<string, List<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                string sortedString = String.Concat(strs[i].OrderBy(c => c));
                if (!charSortedDict.TryAdd(sortedString, new List<string>() { strs[i] }))
                {
                    charSortedDict[sortedString].Add(strs[i]);
                }
            }

            //put all the lists into the output list
            List<IList<string>> output = new List<IList<string>>();
            foreach (var item in charSortedDict)           
                output.Add(item.Value);
            
            return output;
        }
    }
}
public class PathWithMaximumProbability
{
    //https://leetcode.com/problems/path-with-maximum-probability/
    public class Solution
    {
        public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
        {
            if (start >= n || end >= n) return 0;

            Dictionary<int, Dictionary<int, double>> nodes = new Dictionary<int, Dictionary<int, double>>();
            HashSet<int> visited = new HashSet<int>();
            Dictionary<int, double> maxProb = new Dictionary<int, double>();
            HashSet<int> currentNodes = new HashSet<int>() { start };

            for (int i = 0; i < edges.Length; i++)
            {
                AddEdge(nodes, edges[i], succProb[i]);
                maxProb.TryAdd(edges[i][0], 0);
                maxProb.TryAdd(edges[i][1], 0);
            }

            if (!nodes.ContainsKey(start) || !nodes.ContainsKey(end))
                return 0;

            maxProb[start] = 1;

            while (currentNodes.Count > 0)
            {
                int bestNode = -1;
                foreach (var node in currentNodes)
                    if (bestNode == -1 || maxProb[node] > maxProb[bestNode])
                        bestNode = node;

                if (bestNode == end)
                    return maxProb[end];

                visited.Add(bestNode);
                currentNodes.Remove(bestNode);

                foreach (var edge in nodes[bestNode])
                {
                    if (visited.Contains(edge.Key))
                        continue;
                    double newProb = edge.Value * maxProb[bestNode];
                    maxProb[edge.Key] = Math.Max(maxProb[edge.Key], newProb);
                    currentNodes.Add(edge.Key);
                }
            }
            return 0;
        }
        public void AddEdge(Dictionary<int, Dictionary<int, double>> nodes, int[] edge, double succProb)
        {
            if (!nodes.TryAdd(edge[0], new Dictionary<int, double>() { { edge[1], succProb } }))
                nodes[edge[0]].Add(edge[1], succProb);
            if (!nodes.TryAdd(edge[1], new Dictionary<int, double>() { { edge[0], succProb } }))
                nodes[edge[1]].Add(edge[0], succProb);
        }
    }
    public class Solution2
    {
        public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
        {
            if (start >= n || end >= n) return 0;

            Dictionary<int, Dictionary<int, double>> nodes = new Dictionary<int, Dictionary<int, double>>();

            for (int i = 0; i < edges.Length; i++)           
                AddEdge(nodes, edges[i], succProb[i]);

            HashSet<int> visited = new HashSet<int>();
            PriorityQueue<int, double> nodePQ = new PriorityQueue<int, double>();
            nodePQ.Enqueue(start, -1);
            while (true)
            {
                nodePQ.TryDequeue(out int current, out double probability);
                probability *= -1;
                if (current == end)
                    return probability;
                foreach (var edge in nodes[current])
                    nodePQ.Enqueue(edge.Key, -1 * edge.Value * probability);
            }
        }
        public void AddEdge(Dictionary<int, Dictionary<int, double>> nodes, int[] edge, double succProb)
        {
            if (!nodes.TryAdd(edge[0], new Dictionary<int, double>() { { edge[1], succProb } }))
                nodes[edge[0]].Add(edge[1], succProb);
            if (!nodes.TryAdd(edge[1], new Dictionary<int, double>() { { edge[0], succProb } }))
                nodes[edge[1]].Add(edge[0], succProb);
        }
    }
    public class Solution1
    {
        public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
        {
            if (start >= n || end >= n) return 0;

            Node[] nodes = new Node[n];
            for (int i = 0; i < n; i++)           
                nodes[i] = new Node(i);
            
            for (int i = 0; i < edges.Length; i++)
                AddEdge(nodes, edges[i], succProb[i]);

            Node startNode = nodes[start];
            Node endNode = nodes[end];

            PriorityQueue<Node, double> nodePQ = new PriorityQueue<Node, double>();
            nodePQ.Enqueue(startNode, -1);
            while (true)
            {
                nodePQ.TryDequeue(out Node current, out double probability);
                probability *= -1;
                if (current == endNode)
                    return probability;
                foreach (var edge in current.edges)
                    nodePQ.Enqueue(nodes[edge.Item1], -1 * edge.Item2 * probability);
            }
        }
        public void AddEdge(Node[] nodes, int[] edge, double succProb)
        {
            int nodeA = edge[0], nodeB = edge[1];
            nodes[nodeA].edges.Add(new(nodeB, succProb));
            nodes[nodeB].edges.Add(new(nodeA, succProb));
        }
        public class Node
        {
            public int index;
            public List<(int, double)> edges;
            public Node(int index)
            {
                this.index = index;
                edges = new List<(int, double)>();
            }
        }
    }
    public class Solution_Slow
    {
        public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
        {
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < edges.Length; i++)            
                AddEdge(nodes, edges[i], succProb[i]);

            if (start >= nodes.Count) return 0;
            Node startNode = nodes[start];
            if (end >= nodes.Count) return 0;
            Node endNode = nodes[end];

            PriorityQueue<Node, double> nodePQ = new PriorityQueue<Node, double>();
            nodePQ.Enqueue(startNode, -1);
            while (true)
            {
                nodePQ.TryDequeue(out Node current, out double probability);
                probability *= -1;
                if (current == endNode)
                    return probability;
                foreach (var edge in current.edges)                
                    nodePQ.Enqueue(edge.Item1, -1 * edge.Item2 * probability);               
            }
        }
        public void AddEdge(List<Node> nodes, int[] edge, double succProb)
        {
            int nodeA = edge[0], nodeB = edge[1];
            while (nodes.Count <= nodeA || nodes.Count <= nodeB)
                nodes.Add(new Node(nodes.Count));
            nodes[nodeA].edges.Add(new(nodes[nodeB], succProb));
            nodes[nodeB].edges.Add(new(nodes[nodeA], succProb));
        }
        public class Node
        {
            public int index;
            public List<(Node, double)> edges;
            public Node(int index)
            {
                this.index = index;
                edges = new List<(Node, double)>();
            }
        }
    }
}