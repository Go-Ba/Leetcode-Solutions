using System;

public class MinStack
{
    //https://leetcode.com/problems/min-stack/
    public class MinStack
    {
        public class Node
        {
            public int Value;
            public Node Child;
            public int MinValueOfStack;
            public Node (int value, Node child)
            {
                Value = value;
                Child = child;
            }
        }
        private Node head;
        private Node tail;
        private int currentMin;
        public MinStack()
        {
            currentMin = int.MaxValue;
        }

        public void Push(int val)
        {
            var newHead = new Node(val, head);
            head = newHead;
            if (tail == null)
                tail = newHead;
            currentMin = Math.Min(currentMin, val);
            newHead.MinValueOfStack = currentMin;
        }

        public void Pop()
        {
            if (head == null)
                return;
            head = head.Child;
            currentMin = head == null ? int.MaxValue : head.MinValueOfStack;
        }

        public int Top()
        {
            if (head == null)
                return 0;
            return head.Value;
        }

        public int GetMin()
        {
            return currentMin;
        }
    }

    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(val);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
}