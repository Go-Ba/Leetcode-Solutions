using System.Collections.Generic;

public class LinkedListCycle
{
    //https://leetcode.com/problems/linked-list-cycle/
    public class Solution_HashSet
    {
        HashSet<ListNode> existingNodes;
        public bool HasCycle(ListNode head)
        {
            existingNodes = new HashSet<ListNode>();
            ListNode current = head;
            while (current != null)
            {
                if (existingNodes.Contains(current))
                    return true;
                existingNodes.Add(current);
                current = current.next;
            }
            return false;
        }
    }
    public class Solution_FastSlow
    {
        public bool HasCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    return true;
            }
            return false;
        }
    }
    public class Solution_ValueChange
    {
        public bool HasCycle(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                if (current.val == int.MaxValue)
                    return true;
                current.val = int.MaxValue;
                current = current.next;
            }
            return false;
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