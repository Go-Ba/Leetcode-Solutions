using System;
public class RemoveNthNodeFromEndOfList
{
    //https://leetcode.com/problems/remove-nth-node-from-end-of-list/
    public class Solution_Recursion
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //remove only item
            if (head.next == null)
                return null;

            ListNode dummy = new(0, head);
            int length = GetTotalLength(dummy, -1, n);
            if (length == n)
                return head.next;
            return head;
        }
        public int GetTotalLength(ListNode node, int currentDepth, int n)
        {
            if (node.next == null)
                return currentDepth + 1;
            int totalLength = GetTotalLength(node.next, currentDepth + 1, n);
            if (currentDepth == totalLength - n - 1)
                node.next = node.next.next;
            return totalLength;
        }
    }
    public class Solution_N_Distance
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //remove only item
            if (head.next == null)
                return null;

            ListNode dummy = new(0, head);
            ListNode slow = dummy, fast = dummy;

            //move fast to be n distance from start
            for (int i = 0; i < n; i++)           
                fast = fast.next;
           
            //move both until fast hits the end
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next;
            }

            //slow is n distance from fast, so it is n distance from the end
            slow.next = slow.next.next;

            return dummy.next;
        }
    }
    public class Solution_GetLength
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //remove only item
            if (head.next == null)
                return null;

            int length = GetLength(head);
            //remove first item in list
            if (length == n)
                return head.next;

            //remove nth item
            ListNode current = head;
            for (int i = 0; i < length; i++)
            {
                if (i == length - n - 1)
                {
                    current.next = current.next.next;
                    break;
                }
                current = current.next;
            }
            return head;
        }
        public int GetLength(ListNode head)
        {
            ListNode current = head;
            int count = 0;
            while (current != null)
            {
                count++;
                current = current.next;
            }
            return count;
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
