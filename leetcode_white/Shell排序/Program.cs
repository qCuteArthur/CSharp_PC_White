using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//shell排序就是选择排序、插入排序和分组排序（快排）的合并。
//先进行快速排序的分组 调换顺序，然后进行插入排序的思想。
//停止条件，步长为1
namespace Shell排序
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vs = new int[10000];
            Random random = new Random();
            for(int i = 0; i < 10000; i++)
            {
                vs[i] = random.Next(0, 99999);
            }
            //int[] elements = new int[] { 1, 4, 6, 9, 2, 5, 8, 3,7 };
            //ShellSort(elements);
            ShellSort2(vs);
            Disp(vs);
            Console.ReadLine();
        }
        //这个不是完全的shell，而是每次都比较两个差距为步长的元素。并对于步长进行循环。

        //真正的shell排序，是根据步长的不同，逻辑上分成步长个小组，步长越短，小组中的元素个数越多。然后每次是对小组中的元素组排序。
        static void ShellSort(int[] array)
        {
            int step = array.Length / 2;
            while (step >= 1)
            {
                for(int i = step; i < array.Length; i++)
                {
                    //temp是要被插入进去的变量
                    int temp = array[i];
                    if (array[i] < array[i - step])
                    {
                        //直接和前面的步长跨度的元素交换位置
                        array[i] = array[i - step];
                        array[i - step] = temp;

                        //移动位置 在这里比不上交换好
                        //for(int k = i; k > i - step; k--)
                        //{
                        //    array[k] = array[k - 1];
                        //}
                    }
                }   
                step = step / 2;
            }
        }
        static void ShellSort2(int[] array)
        {
            //假如你有50个数，一开始用25作为步长，然后分为25个小组进行排序。着25个小组，彼此之间比大小。
            //然后按照12作为步长，这个时候，是12个小组，每个小组4个元素，小组内进行一个排序。
            //和ShellSort1最大的不同就是逻辑上的小组概念。上面的那个，逻辑小组的元素个数就是两个，只不过距离不同。下面这个，小组中的元素个数一直在增加。

            //推荐使用下面这种。
            int step = array.Length / 2;
            while (step >= 1)
            {
                for(int i = step; i < array.Length; i++)
                {
                    int temp = array[i];
                    if (array[i] < array[i - step])
                    {
                        int j = 0;
                        for (j = i-step; j > 0; j -= step)
                        {
                            if (array[j] > array[j + step])
                            {
                                array[j + step] = array[j];
                            }
                            else
                            {
                                break;
                            }
                        }
                        array[j+step] = temp;
                    }
                }
                step = step / 2;
            }
        }
        static void Disp(int[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }

    //这个是从网上看到的shell排序
    class ShellSortTest
    {
        private static ShellSortTest _instance = new ShellSortTest();
        public static ShellSortTest Instance
        {
            get { return _instance; }
        }

        //希尔排序 是对直接插入排序的改进
        //主要思想：首先确定一个增量(增量一般为2^（t-k+1）-1（0≤k≤t≤log2(n+1)）)，
        //将相距某个“增量”的记录组成一个子序列，
        //这样才能保证在子序列内分别进行直接插入排序后得到的结果是基本有序而不是局部有序的。
        //特点：1.不稳定排序 2.时间复杂度O（n^3/2）3.增量序列的最后一个增量值必须等于1才行
        public void ShellSort(int[] nums)
        {
            int increment = nums.Length;
            int temp, j;//临时变量，用于交换数值
            do
            {
                //每次循环增量步长
                increment = increment / 3 + 1;
                //从当前增量位置开始，选择待插入元素
                for (int i = increment; i < nums.Length; i++)
                {
                    //待插入元素小于之前近邻 增量元素
                    if (nums[i] < nums[i - increment])
                    {
                        temp = nums[i];
                        //循环 以增量递减方式倒查找待插入位置j
                        for (j = i - increment; j > 0 && nums[j] > temp; j -= increment)
                        {
                            //间隔增量后移(跳跃式后移)
                            nums[j + increment] = nums[j];
                        }
                        nums[j + increment] = temp;
                    }
                }
            } while (increment > 1);//当增量为1时就停止循环
        }
    }
}
