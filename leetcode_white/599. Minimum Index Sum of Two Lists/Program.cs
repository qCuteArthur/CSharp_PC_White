using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _599.Minimum_Index_Sum_of_Two_Lists
{
    class Program
    {
        static void Main(string[] args)
        {


            string[] list1 = { "Shogun", "Tapioca Express", "Burger King", "KFC" };
            string[] list2 ={"Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse", "Shogun"};
            Solution solution = new Solution();
            string[] ret = solution.FindRestaurant(list1, list2);
            Console.ReadLine();
        }
    }
    public class Solution
    {
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            //HashSet或者是Dictionary
            Dictionary<string, int> First = new Dictionary<string, int>();
            Dictionary<string, int> Second = new Dictionary<string, int>();
            HashSet<string> FirstHash = new HashSet<string>();
            HashSet<string> SecondHash = new HashSet<string>();
            //Dictionary是用来快速查找的，而HashSet是用来寻找公共集合的，为什么我感觉使用Linq会更加的方便。
            for (int i = 0; i < list1.Length; i++)
            {
                First.Add(list1[i],i);
                FirstHash.Add(list1[i]);
            }
            for(int j = 0; j < list2.Length; j++)
            {
                Second.Add(list2[j], j);
                SecondHash.Add(list2[j]);
            }
            //完成初始化
            FirstHash.IntersectWith(SecondHash);
            //现在FirstHash里面就是二者的公共了，寻找二者的并集
            Dictionary<string, int> result = new Dictionary<string, int>();
            //结果的键值对
            foreach(string item in FirstHash)
            {
                int value =First[item]+Second[item];
                result.Add(item,value);
            }
            //更新结果result字典 ，我们已经有了一个待返回的字典，里面的元素都是string-int类型的。
            if (result == null) return null;
            //然后字典里面的东西就是二者的公共，以及二者的和，按照一个值的顺序对于键进行排序
            var dicSort = from objDic in result orderby objDic.Value select objDic;
            //descending 是按照降序，去掉是按照升序 
            
            //循环决定返回的元素的个数
            KeyValuePair<string, int> FirstElem = dicSort.ElementAt(0);
            List<string> myList = new List<string>();
            myList.Add(FirstElem.Key);
            //只有出现了超过一个元素才会进入这个循环。
            for (int i = 1; i < dicSort.Count(); i++)
            {
                if (dicSort.ElementAt(i).Value == FirstElem.Value)
                {
                    myList.Add(dicSort.ElementAt(i).Key);
                }
                else
                {
                    break;
                }
            }
            return myList.ToArray();
            //根据上面的ret_cts判断应该输出的string[]的元素的元素
        }
    }
}
