using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二维坐标作为字典的key
{
    class Program
    {
        static void Main(string[] args)
        {
            //研究List<List<int>>使用
            List<List<int>> vsA = new List<List<int>>();
            int ret = vsA[1][1];


            //二维矩阵的一个长和宽
            int[,] matrix = new int[10, 11];
            int ansY = matrix.GetLength(0);
            int ansX = matrix.GetLength(1);
            int[,] memory = new int[ansX, ansY];
            memory[1, 1] = 10;
            //动态数组
            List<int> vs = new List<int>();
            int ret = vs[1];
            //尝试使用List创建二维矩阵，也支持索引形式的访问
            List<List<int>> myList = new List<List<int>>();
            List<int> retA = myList[1];
            int retB =myList[1][2];
            ///////////二维坐标作为字典的key
             //Solution:1
            Dictionary<KeyValuePair<int,int>, int> myDic = new Dictionary<KeyValuePair<int,int>, int>();
            //其中的KeyValuePair就是一个键值对
            //solution:2 
            Hashtable hashtable = new Hashtable();
            hashtable.Add("key1","value1");
            hashtable.Add("key2","value2");
            var value = hashtable["key1"];
            Type type = value.GetType();
            Console.WriteLine(type);
            Console.ReadLine();
        }
    }
}
