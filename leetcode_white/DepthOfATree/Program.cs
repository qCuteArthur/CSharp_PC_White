using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthOfATree
{
    class Program
    {
        static void Main(string[] args)
        {
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
        public int Rob(TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return root.val;
            if (root.left == null && root.right != null) return Math.Max(root.left.val, root.val);
            if (root.left != null && root.right == null) return Math.Max(root.right.val, root.val);

            //基于二叉树的一个DP
        }
}
