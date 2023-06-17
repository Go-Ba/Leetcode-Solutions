public class ReverseLinkedList
{
    //https://leetcode.com/problems/reverse-linked-list/
    public class Solution
    {
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