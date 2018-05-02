using System;
using System.Collections.Generic;

namespace 创建二叉查找树
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree binarySearchTree = new BinarySearchTree();
            int[] nodes = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Array.Sort(nodes);
            int middle = (0 + nodes.Length -1 ) / 2;
            TreeNode root = new TreeNode(nodes[middle]);
            binarySearchTree.CreateTree(ref root , nodes, 0, nodes.Length-1);



            Console.ReadLine();
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
        public void CreateTree(ref TreeNode root,int[] nodes,int begin,int end)
        {
            //beigin就是ret的第一个元素，end就是ret的最后一个元素
            if (begin > end) return;
            int middle = (begin + end) / 2;
            if (root == null)
            {
                root = new TreeNode(nodes[middle]);
                root.Left = null;
                root.Right = null;
            }
            CreateTree(ref root.Left, nodes, begin, middle-1);
            CreateTree(ref root.Right, nodes, middle + 1, end);
        }
        //非递归的层序遍历
        public void LayerTraverse(TreeNode root,List<int> ret)
        {
            Queue<TreeNode> myTree = new Queue<TreeNode>();
            myTree.Enqueue(root);
            while (myTree.Count != 0)
            {
                TreeNode myNode =myTree.Dequeue();
                ret.Add(myNode.val);
                myTree.Enqueue(root.Left);
                myTree.Enqueue(root.Left);
            }
        }
        //递归先序遍历
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
        public void MidOrderTraverse(TreeNode root,List<int> ret)
        {
            if(root!=null)
            {
                MidOrderTraverse(root.Left,ret);
                ret.Add(root.val);
                MidOrderTraverse(root.Right, ret);
            }
        }
        //非递归中序遍历
        public void MidOrderTraverse(TreeNode root,List<int> ret,Stack<TreeNode> temp)
        {
            if (root != null)
            {
                temp.Push(root);
            }
            if (root== null)
            {
                root = temp.Pop();
                ret.Add(root.val);
                MidOrderTraverse(root.Right, ret, temp);
            }
            if (root.Left != null)
            {
                MidOrderTraverse(root.Left,ret,temp);
            }
        }
    }
    public class Tree
    {
        //层序遍历创建树
        public TreeNode CreateTree2(int[] nodes)
        {
            TreeNode root = null;
            if (nodes[0] == null) return root;
            ////////////////////////////////////////////////////////////////
            root = new TreeNode(nodes[0]);
            Queue<TreeNode> treeNodes = new Queue<TreeNode>();
            treeNodes.Enqueue(root);
            int cts = 1;
            //如果说队列中还有节点
            while ((treeNodes.Count != 0) &&(cts < nodes.Length-1))
            {
                TreeNode treeNode = treeNodes.Dequeue();
                if (treeNode.val != null)
                {
                    if (nodes[cts + 1] != null)
                    {
                        treeNode.Left = new TreeNode(nodes[cts++]);
                        treeNodes.Enqueue(treeNode.Left);
                    }
                    else if (nodes[cts + 1] == null)
                    {
                        treeNode.Left = null;
                        cts++;
                    }
                    if (cts == nodes.Length) return root;
                    ///////////////////////////////////
                    if (nodes[cts + 1] != null)
                    {
                        treeNode.Right = new TreeNode(nodes[cts++]);
                        treeNodes.Enqueue(treeNode.Right);
                    }
                    else if (nodes[cts + 1] == null)
                    {
                        treeNode.Right = null;
                        cts++;
                    }
                    if (cts == nodes.Length) return root;
                    ///////////////////////////////
                    //对于0号节点来说，把cts=1和cts=2的节点作为自己的左右孩子可以
                }
            }
            return root;
        }
    }
}
