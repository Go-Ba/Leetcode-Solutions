public class ReverseNodesInK_Group
{
    //https://leetcode.com/problems/reverse-nodes-in-k-group/
    public class Solution
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode dummyHead = new(-1, head);
            ListNode previousListEnd = dummyHead;
            ListNode nextListStart;

            while(true)
            {
                var kth = GetK(previousListEnd, k);
                if (kth == null)
                    break;

                nextListStart = kth.next;
                ListNode current = previousListEnd.next;
                ListNode previous = nextListStart;

                while (current != nextListStart)
                {
                    var next = current.next;
                    current.next = previous;
                    previous = current;
                    current = next;
                }
                var listStart = previousListEnd.next;
                previousListEnd.next = kth;
                previousListEnd = listStart;
            }
            return dummyHead.next;
        }
        ListNode GetK(ListNode node, int k)
        {
            ListNode current = node;
            while(current != null && k > 0)
            {
                current = current.next;
                k--;
            }
            return current;
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
