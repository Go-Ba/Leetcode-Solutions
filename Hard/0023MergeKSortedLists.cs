public class MergeKSortedLists
{
    //https://leetcode.com/problems/merge-k-sorted-lists/
    //Priority Queue doesn't exist in the version of .NET I'm using
    //but I tried
    public class Solution_PriorityQueue
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null)
                return null;
            
            var pq = new PriorityQueue<ListNode, int>();

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null)
                    pq.Enqueue(lists[i], lists[i].val);
            }

            ListNode dummyHead = new ListNode();
            ListNode current = dummyHead;

            while(pq.Count > 0)
            {
                var node = pq.Dequeue();
                if (node.next != null)
                    pq.Enqueue(node.next, node.next.val);
                current.next = node;
                current = current.next;
            }
            return dummyHead.next;
        }
    }
    public class Solution_Insertion
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null)
                return null;

            ListNode dummyHead = new ListNode();
            ListNode current = dummyHead;

            while (true)
            {
                ListNode smallest = null;
                int smallestIndex = -1;
                int nullCount = 0;
                for (int i = 0; i < lists.Length; i++)
                {
                    if (lists[i] == null)
                    {
                        nullCount++;
                        continue;
                    }
                    if (smallest == null || lists[i].val < smallest.val)
                    {
                        smallest = lists[i];
                        smallestIndex = i;
                    }
                }
                if (nullCount == lists.Length)
                    break;

                current.next = smallest;
                current = current.next;
                lists[smallestIndex] = lists[smallestIndex].next;

            }
            return dummyHead.next;
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