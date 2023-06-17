using System.Collections.Generic;

public class CopyListWithRandomPointer
{
    //https://leetcode.com/problems/copy-list-with-random-pointer/
    public class Solution_Dictionary
    {
        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return null;

            Dictionary<Node, Node> oldToNewMap = new();
            Node oldCurrent = head;
            Node newCurrent, newPrev = null;
            while (oldCurrent != null)
            {
                newCurrent = new Node(oldCurrent.val);
                if (newPrev != null)
                    newPrev.next = newCurrent;

                oldToNewMap.Add(oldCurrent, newCurrent);

                newPrev = newCurrent;
                oldCurrent = oldCurrent.next;
            }

            oldCurrent = head;
            newCurrent = oldToNewMap[head];
            while (oldCurrent != null)
            {
                if (oldCurrent.random != null)
                    newCurrent.random = oldToNewMap[oldCurrent.random];
                newCurrent = newCurrent.next;
                oldCurrent = oldCurrent.next;
            }
            return oldToNewMap[head];
        }
    }

    public class Solution_ParallelLists
    {
        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return null;

            //set old and new nodes to parallel lists
            List<Node> oldNodes = new();
            List<Node> newNodes = new();
            Node oldCurrent = head;
            Node newCurrent, newPrev = null;
            while (oldCurrent != null)
            {
                newCurrent = new Node(oldCurrent.val);
                if (newPrev != null)                
                    newPrev.next = newCurrent;

                oldNodes.Add(oldCurrent);
                newNodes.Add(newCurrent);

                newPrev = newCurrent;
                oldCurrent = oldCurrent.next;
            }

            //find the index of the random pointer in the old list
            //then set up the random pointer in the new list from that same index
            for (int i = 0; i < oldNodes.Count; i++)
            {
                if (oldNodes[i].random == oldNodes[i])
                    newNodes[i].random = newNodes[i];
                else if (oldNodes[i].random != null)
                {
                    int index = GetIndex(oldNodes, oldNodes[i].random);
                    newNodes[i].random = newNodes[index];
                }
            }
            return newNodes[0];
        }
        public int GetIndex(List<Node> list, Node node)
        {
            for (int i = 0; i < list.Count; i++)            
                if (list[i] == node)
                    return i;           
            return -1;
        }
    }
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}