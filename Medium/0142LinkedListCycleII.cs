using System.Collections.Generic;

public class LinkedListCycleII
{
    //https://leetcode.com/problems/linked-list-cycle-ii/description/
    public class Solution_HashSet
    {
        HashSet<ListNode> existingNodes;
        public ListNode DetectCycle(ListNode head)
        {
            existingNodes = new HashSet<ListNode>();
            ListNode current = head;
            while (current != null)
            {
                if (existingNodes.Contains(current))
                    return current;
                existingNodes.Add(current);
                current = current.next;
            }
            return null;
        }
    }
    public class Solution_MaxInt
    {
        public ListNode DetectCycle(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                if (current.val == int.MaxValue)
                    return current;
                current.val = int.MaxValue;
                current = current.next;
            }
            return null;
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
}