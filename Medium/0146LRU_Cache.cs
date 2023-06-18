using System;
using System.Collections.Generic;

public class LRU_Cache
{
    //https://leetcode.com/problems/lru-cache/

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
    public class ListNode
    {
        public int val;
        public int key;
        public ListNode next;
        public ListNode prev;
        public ListNode(int key, int val)
        {
            this.val = val;
            this.key = key;
            next = null;
            prev = null;
        }
    }
    public class LRUCache
    {
        readonly Dictionary<int, ListNode> cache;
        readonly int capacity;

        ListNode head;
        ListNode tail;
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            this.cache = new Dictionary<int, ListNode>();
        }
        public int Get(int key)
        {
            if (cache == null)
                return -1;
            if (cache.TryGetValue(key, out ListNode node))
            {
                MakeMostRecent(node);
                return node.val;
            }
            else
                return -1;
        }

        public void Put(int key, int value)
        {
            if (cache == null)
                return;
            //update value
            if (cache.TryGetValue(key, out ListNode node))
            {
                node.val = value;
                MakeMostRecent(node);
            }
            else //add new
            {
                var newNode = new ListNode(key, value);
                cache.Add(key, newNode);
                MakeMostRecent(newNode);
                if (cache.Count > capacity)
                    Eject();
            }
        }
        public void MakeMostRecent(ListNode node)
        {
            if (head == null)
            {
                head = node;
                tail = node;
                return;
            }
            if (node == head)
                return;

            //link ends together
            if (node.prev != null)
            {
                //at end
                if (node == tail) 
                    SetAsTail(node.prev);
                //in middle
                else
                    node.prev.next = node.next;
            }
            if (node.next != null)
                node.next.prev = node.prev;
            
            //set to head
            node.prev = null;
            node.next = head;
            head.prev = node;
            head = node;
        }
        public void Eject()
        {
            cache.Remove(tail.key);
            SetAsTail(tail.prev);
        }
        public void SetAsTail(ListNode node)
        {
            tail = node;
            node.next = null;
        }
    }








    /// <summary>
    /// DEBUG PRINTOUTS 
    /// BECAUSE I WAS DUMB AND PUT A
    /// NULL BEFORE ASSIGNMENT INSTEAD OF AFTER
    /// AND IT TOOK ME TOO LONG TO FIND IT
    /// </summary>
    public class LRUCache_DEBUG
    {
        Dictionary<int, ListNode> cache;
        int capacity;

        ListNode head;
        ListNode tail;
        public LRUCache(int capacity)
        {
            Console.WriteLine($"capacity {capacity}");
            this.capacity = capacity;
            this.cache = new Dictionary<int, ListNode>();
        }

        public int Get(int key)
        {
            PrintCache();
            Console.WriteLine($"Get {key}");
            if (cache == null)
                return -1;
            if (cache.TryGetValue(key, out ListNode node))
            {
                MakeMostRecent(node);
                return node.val;
            }
            else
                return -1;
        }

        public void Put(int key, int value)
        {
            Console.WriteLine($"Put {key}, {value}");
            if (cache == null)
                return;
            if (cache.TryGetValue(key, out ListNode node))
            {
                node.val = value;
                MakeMostRecent(node);
            }
            else
            {
                var newNode = new ListNode(key, value);
                cache.Add(key, newNode);
                MakeMostRecent(newNode);
                if (cache.Count > capacity)
                    Eject();
            }
            PrintCache();
        }
        public void MakeMostRecent(ListNode node)
        {
            Console.WriteLine($"        Recent: {node.val}");
            if (head == null)
            {
                head = node;
                tail = node;
                return;
            }
            if (node == head)
                return;

            if (node.prev != null)
            {
                Console.WriteLine($"        Node: {node.val}, Tail: {tail.val}, is tail? {node == tail}");
                if (node == tail)
                    SetAsTail(node.prev);
                else
                    node.prev.next = node.next;
            }
            if (node.next != null)
            {
                node.next.prev = node.prev;
            }
            node.prev = null;
            node.next = head;
            head.prev = node;
            head = node;
        }
        public void Eject()
        {
            Console.WriteLine($"Eject: {tail.val}");
            cache.Remove(tail.key);
            SetAsTail(tail.prev);
        }
        public void SetAsTail(ListNode node)
        {
            Console.WriteLine($"        Set Tail: {node.val}");
            tail = node;
            node.next = null;
        }
        public void PrintCache()
        {
            Console.Write("    CACHE: ");
            ListNode current = head;
            while (current != null)
            {
                Console.Write($"{current.val}, ");
                current = current.next;
            }
            Console.Write("\n");
            Console.Write("    BACK CACHE: ");
            current = tail;
            while (current != null)
            {
                Console.Write($"{current.val}, ");
                current = current.prev;
            }
            Console.Write("\n");
            Console.WriteLine($"    head: {head.val}, tail: {tail.val}");
        }
    }

}