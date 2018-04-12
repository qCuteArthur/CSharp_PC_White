using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell排序CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //另外一种方式是随机产生要排序的数字，可以随机种子或者是随机函数。注意，随机数的生成需要使用时间。

            int [] array = new int []{1,4,7,2,8,3,9,6};
            SelectSort(ref array);
            Disp(array);
            Console.ReadLine();
        }
        static void SelectSort(ref int[] array)
        {
            int length = array.Length;
            int index=0;
            int temp=0;

            for(int i = 0; i < length; i++)
            {
                //首先找最小，需要索引号和具体的数值
                int min_position = i;
                int currentMin = array[i];
               
                //j从i开始还是从i+1开始是无所谓的
                for (int j = i+1; j < length; j++)
                {
                    if (currentMin > array[j])
                    {
                        currentMin = array[j];
                        min_position = j;
                    }
                }
                //找到最小元素之后，和i位置的元素进行比较，如果小，就交换。
                if (array[i] > array[min_position])
                {
                    Swap(ref array[i], ref array[min_position]);
                }
            }
        }
        static void Swap(ref int a,ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static void Disp(int[] array)
        {
            foreach(var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}

//排序
//冒泡
//选择   
//插入
//哈希
//快速排序（分组排序的一种）

//shell排序
//桶排序
//归并排序
//二分查找

//红黑树—用来做查找树——红黑更稳定，每次都说是一个速度。7
//但是最快的查找树是哈希——查找效率变化大。1~10
//如果查找次数少，用红黑树更好。

//衡量算法好坏——时间复杂 空间复杂 稳定程度

//一个文件中保存了2个G的电话号码和姓名，写一个算法找到电话号码。
//——涉及到很多知识，学完win32才能做？？？？不是简单的把2G排序，因为还要操作文件。

//shell排序不稳定，桶排序稳定。（时间复杂度不稳定）

//选择排序（比插入排序慢）
//假设一个数组中存在10个数据，选择排序首先把最小的选出来，把这个数据放在第一个位置，然后交换位置。（交换相对来说耗费时间比较少），然后对于剩下的部分，选择最小的，继续交换。