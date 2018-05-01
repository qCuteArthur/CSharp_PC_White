using System;
using System.Collections.Generic;

namespace SameTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] TreeA = {1, 2, 3 };
            int[] TreeB = { 1, 2, 3};
            

        }
        //先序遍历的方式创建Tree
        public TreeNode CreateTree(int[] Tree)
        {
            if (Tree.Length == 0) return null;
            TreeNode root = new TreeNode(Tree[0]);
            root.left = null;
            root.right = null;


            return root;
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public class Solution
    {
        public bool IsSameTreeI(TreeNode p,TreeNode q)
        {
            if ((p == null) && (q == null)) return true;
            if (p!=null || q!=null) return false;
            if (p.val == q.val) return IsSameTreeI(p.left, q.left) && IsSameTreeI(p.right, q.right);
            return false;
        }
        //非递归的实现
        public bool IsSameTreeII(TreeNode p, TreeNode q)
        {

            if ((p == null) && (q == null)) return true;
            if (p == null || q == null) return false;

            //下面保证了根节点至少都是有东西的。
            Stack<TreeNode> a = new Stack<TreeNode>();
            Stack<TreeNode> b = new Stack<TreeNode>();
            a.Push(p);
            b.Push(q);

            while (a != null && b != null)
            {
                TreeNode TopA = a.Peek();
                TreeNode TopB = b.Peek();
                a.Pop();
                b.Pop();
                /////////////////////
                if (TopA.val != TopB.val)
                {
                    return false;
                }
                /////////////////////
                if (TopA.right != null && TopB.right != null)
                {
                    a.Push(TopA.right);
                    b.Push(TopB.right);
                }
                //其中一个是空的，另外一个不是空的
                else if (TopA.right == null || TopB.right == null)
                {
                    return false;
                }
                //如果可以过了上面那关，剩下的就是都空的情况了，那么此时也不用push了，直接看右边的情况
                /////////////////////
                if (TopA.left != null && TopB.left != null)
                {
                    a.Push(TopA.left);
                    b.Push(TopB.left);
                }
                else if (TopA.left == null || TopB.left == null)
                {
                    return false;
                }
                ////////////////////
            }
            return true;
        }
    }
}
