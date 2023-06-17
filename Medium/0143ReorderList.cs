using System;

public class ReorderList
{
    //https://leetcode.com/problems/reorder-list/
    public class Solution
    {
        public void ReorderList(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head.next;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            ListNode first = head;
            ListNode second = slow.next;
            slow.next = null;
            second = ReverseList(second);

            PrintList(first);
            PrintList(second);

            while (second != null)
            {
                var firstNext = first.next;
                var secondNext = second.next;
                first.next = second;
                second.next = firstNext;
                first = firstNext;
                second = secondNext;
            }
        }
        public void PrintList(ListNode head)
        {
            var current = head;
            while (current != null)
            {
                Console.Write($"{current.val},");
                current = current.next;
            }
            Console.Write($"\n");
        }
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;

            ListNode current = head;
            ListNode child = null;
            while (current != null)
            {
                var next = current.next;
                current.next = child;
                child = current;
                current = next;
            }
            return child;
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
