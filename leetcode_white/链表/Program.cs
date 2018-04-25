using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//给定一个排序链表，删除所有重复的元素使得每个元素只留下一个。
//案例：
//给定 1->1->2，返回 1->2
//给定 1->1->2->3->3，返回 1->2->3

//    {}
//{1,1,1,1,1}
//复习一下基于C#的链表实现方式
namespace 链表
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[] {};
            //这个东西就是一个工作指针
            ListNode nodeA = new ListNode(data[0]);
            //创建一个不改变引用对象的引用
            ListNode root = nodeA;
            
            //使用数据构造链表
            for (int i=1;i<data.Length;i++)
            {
                ListNode nodeX = new ListNode(data[i]);
                nodeA.next=nodeX;
                nodeA = nodeX;
            }
            //while (root != null)
            //{
            //    Console.WriteLine(root.val);
            //    root = root.next;
            //}


            //Solution2 solution2 = new Solution2();
            //ListNode ret = solution2.DeleteDuplicates(root);
            Solution3 solution3 = new Solution3();
            ListNode ret = solution3.DeleteDuplicates(root);


            //这种遍历方式必须主动创建副本。
            while (ret != null)
            {
                Console.WriteLine(ret.val);
                ret = ret.next;
            }
            Console.ReadLine();
        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
        public class Solution
        {
            public ListNode DeleteDuplicates(ListNode head)
            {
            //如果可以对链表先做个排序，就在好不过了。
            //所以我把东西放在stack里面。
            //Stack<int> myStack = new Stack<int>();
                HashSet<int> myHashSet = new HashSet<int>();
                while (head!= null && head.next == null)
                {
                    myHashSet.Add(head.val);
                    head = head.next;
                 }
                for(int i = 0; i < myHashSet.Count; i++)
                {
                //从保证不重复的hashSet中不断输出元素。
               //待完成！！！
                }
                return head;
            }
        }
    public class Solution2
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
            {
                return head;
            }
            ListNode WorkingNode = head;
            ListNode PreviousNode = head;
            //分两种情况，一个是前后两个节点的值相等，一个是前后两个点的值不相等。
            while(WorkingNode != null)
            {
                //注意工作指针的删除和你head节点指向的内存没有关系
                //我们不用考虑多重循环，只需要考虑每一重循环的时候，是不是做到了，相等删除，不相等同时移动一个位置。
                if(WorkingNode.val == PreviousNode.val)
                {
                    PreviousNode.next = WorkingNode.next;
                    WorkingNode = WorkingNode.next;
                }
                else
                {
                    PreviousNode = WorkingNode;
                    WorkingNode = WorkingNode.next;
                }
            }
            return head;
        }
    }
    public class Solution3
    {
        //仅仅使用一个指针进行删除
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode curr = head;
            while (curr != null && curr.next!=null)
            {
                if(curr.val == curr.next.val)
                {
                    curr.next = curr.next.next;
                }
                else
                {
                    curr = curr.next;
                }
            }
            return head;
        }

    }
}
