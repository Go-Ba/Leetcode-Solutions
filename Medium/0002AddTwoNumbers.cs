public class AddTwoNumbers
{
    //https://leetcode.com/problems/add-two-numbers/

    //Definition for singly-linked list.
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
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode baseNode = new ListNode();
            ListNode currentNode = baseNode;
            while (true)
            {
                int val1 = l1 == null ? 0 : l1.val;
                int val2 = l2 == null ? 0 : l2.val;

                currentNode.val += val1 + val2;

                CarryExcess(currentNode);

                l1 = l1?.next;
                l2 = l2?.next;
                if (l1 == null && l2 == null)
                    break;

                if (currentNode.next == null)
                    currentNode.next = new ListNode();
                currentNode = currentNode.next;
            }
            return baseNode;
        }
        void CarryExcess(ListNode node)
        {
            if (node.val < 10)
                return;
            if (node.next == null)
                node.next = new ListNode();
            int remainder = node.val % 10;
            node.next.val += (node.val - remainder) / 10;
            node.val = remainder;
        }
    }
}
