using System;
using System.Collections.Generic;

namespace reGroupList
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nodes = { 1, 2, 3, 4, 5 };
            ListNode wpt = new ListNode(nodes[0]);
            ListNode root = wpt;
            for(int i = 1; i < nodes.Length; i++)
            {
                ListNode temp = new ListNode(nodes[i]);
                wpt.next = temp;
                wpt = wpt.next;
            }

            ////////////////////初始化完毕，开始reverse
            Solution2 solution2 = new Solution2();
            root =solution2.Reverse(root);
            //////////////破坏性输出
            while (root != null)
            {
                Console.WriteLine(root.val);
                root = root.next;
            }
            Console.ReadLine();
        }
    }

    
 //* Definition for singly-linked list.
  public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
 }

    public class Solution
    {
        public void ReorderList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return;
            }
            ////////////////////分割链表
            ListNode fast = head;
            ListNode slow = head;
            //快指针每次移动两个
            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            //退出循环的条件就是，快指针的next和nextnext已经没了
            //slow-fast-null-null
            fast = slow.next;
            slow.next = null;
            //完成两个链表的分割。一个是原始的head，一个是新的fast
            ///////////////////////////逆转第二个链表
            Stack<ListNode> myStack = new Stack<ListNode>();
            while (head != null)
            {
                myStack.Push(head);
                head = head.next;
            }
            ListNode myNode = myStack.Peek();
            ListNode SecondList = myStack.Peek();
            myStack.Pop();
            while (myStack.Count != 0)
            {
                myNode.next = myStack.Peek();
                myNode = myNode.next;
            }
            ////////////////逻辑上说，这里的SecondList已经是一个倒转之后的List了。
            ListNode temp = head;
            head = head.next;
            ListNode ret = temp;
            while (head != null && SecondList != null)
            {
                temp.next = SecondList;
                SecondList = SecondList.next;
                temp = temp.next;
                temp.next = head;
                head = head.next;
                temp = temp.next;
            }
            if (SecondList != null)
            {
                temp.next = SecondList;
            }
            if (head != null)
            {
                temp.next = head;
            }
            //return ret;
        }
    }
    public class Solution2
    {
        public ListNode Reverse(ListNode root)
        {
            if (root == null) return root;
            ListNode temp = root;
            Stack<ListNode> listNodes = new Stack<ListNode>();
            while (temp != null)
            {
                listNodes.Push(temp);
                temp = temp.next;
            }
            temp = listNodes.Pop();
            root = temp;
            //temp = temp.next;
            while(listNodes.Count != 0)
            {
                ListNode wpt= listNodes.Pop();
                wpt.next = null;
                temp.next = wpt;
                temp = temp.next;
            }
            return root;
        }
    }
}
