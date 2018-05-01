using System;
using System.Collections.Generic;

namespace 创建二叉查找树
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode Left;
        public TreeNode Right;
        public TreeNode(int x) { val = x; }
    }
    public class BinarySearchTree
    {
        //递归
        public void PreOrderTraverse(TreeNode root, List<int> ret)
        {
            if(root!=null){ ret.Add(root.val); }
            if(root.Left!=null)
            {
                PreOrderTraverse(root.Left, ret);
            }
            if (root.Right != null)
            {
                PreOrderTraverse(root.Right, ret);
            }
            //我总觉得应该引用传递参数，或者更直接的声明全局静态变量Static级别的。
            return;
        }
        //递归中序遍历
        public void MidOrderTraverse(TreeNode root,List<int> ret,Stack<TreeNode> temp)
        {
            if (root != null)
            {
                temp.Push(root);
            }
            if (root.Left == null)
            {
                TreeNode myNode = temp.Pop();
                ret.Add(myNode.val);
                MidOrderTraverse(root.Right, ret, temp);
            }
            if (root.Left != null)
            {
                MidOrderTraverse(root.Left,ret,temp);
            }
        }
        public void PostOrderTraverse(TreeNode root ,List<int > ret,Stack<TreeNode> temp)
        {

        }
    }
}
