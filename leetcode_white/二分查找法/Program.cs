using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//折半查找法的优点是比较次数少,查找速度快,平均性能好; 其缺点是要求待查表为有序表,且插入删除困难。因此,折半查找方法适用于不经常变动而查找频繁的有序列表。

//难点：终止条件的确定以及查找截止条件的确定困难。

//算法步骤描述
//① 首先确定整个查找区间的中间位置 mid = （ left + right ）/ 2
//② 用待查关键字值与中间位置的关键字值进行比较；
//　 若相等,则查找成功
// 若大于,则在后（右）半个区域继续进行折半查找
// 若小于,则在前（左）半个区域继续进行折半查找
//③ 对确定的缩小区域再按折半公式,重复上述步骤。
//最后,得到结果：要么查找成功, 要么查找失败。折半查找的存储结构采用一维数组存放。
namespace 二分查找法
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] srcArray =new int[]{ 3, 5, 11, 17,19, 21, 23, 28, 30, 32, 50, 64, 78,81,
                95,101 };
            //Console.WriteLine(BinarySearch1(srcArray, 21));
            Console.WriteLine(BinarySearch2(srcArray, 21,0,srcArray.Length-1));
            Console.ReadLine();
        }
        //基于有序表的一个查找
        //二分查找的递归实现。
        //奇数与偶数真的重要吗？？？？
        static int BinarySearch1(int[] array,int key)
        {
            //默认输入的是一个非空数组。
            int Length = array.Length;
            int start=0;
            int end=Length-1;
            //所以，非递归的二分查找根本就不难。
            while (start <= end)
            {
                //如果start = end，会出现end start mid都一样的情况，这个时候，肯定是会返回一个值。
                //如果这个时候还没有找到。

                //这里也可用——————   (end-start)/2+start 
                int mid = (start + end) / 2;
                if (array[mid] == key)
                {
                    return mid;
                    break;
                }
                else
                {
                        if (array[mid] > key)
                        {
                            end = mid - 1;
                        }
                        else
                        {
                            start = mid + 1;
                        }
                    }
            }
            return -1;
        }
        //二分查找的非递归、普通循环方法的实现。
        static int BinarySearch2(int [] array,int key,int start,int end)
        {
            //为了解决end = start = mid的情况。或者用(end+start)/2 
            int mid = (end - start) / 2+start;
            //是不是要增加一个等于号
            if (array[mid] == key)
            {
                return mid;
            }

            if (start >= end)
            {
                return -1;
            }

            else if(array[mid]>key)
             {
                return BinarySearch2(array, key, start, mid - 1);
            }
            else if (array[mid] < key)
            {
                return BinarySearch2(array, key, mid + 1, end);
            }
            return -1;
        }

    }

}

 //3.1 不像顺序查找那样，我们取得数组中间的数字，如果正好是我们要查找的元素，则搜索过程结束；

 //        3.2 中间的元素不是我们想要的元素，我们比较中间元素和我们想要元素的大小

 //        如果中间元素大于/小于中间元素，则我们在大于/小于的那一半查找，而且和开始一样从中间的元素开始比较（也就是把剩下的一半当做新的开始）。

 //        3.3 直到某一步比较，找到我们的key，返回该key所在的数组下标。

 //        3.4 如果都没有找到，存放数组低地址的变量大于高地址变量时，则查找结束，说明该有序序列中没有我们想找到的。

      //1）取数组中间位置，第一次可以是数组元素长度/2，第二次我们如何从数组剩下的一半中取中间位置？以及第三次呢？也就是每次我们都要知道”新数组”的开始和结尾，以及中间位置；所以我们可以定义两个数组下标变量，low 和high（内存中的地址大小），以及mid（每次的中间下标），这样通过移动他们来做到轮询，有些类似c语言中的指针变量。

      //   2）怎么结束比较？每次都找不到，直到数组的一半已经没有元素了，也就是low指向的数组地址已经大于high指向的数组地址，说明不存在。java代码如下，之后再逐步分析代码

    //我觉得leetocde里面涉及到数组的，要不就是要shell排序——快排——桶排序——基数排序——选择/插入排序——冒泡排序，要不然就是让你进行查找。我觉得查找——二分查找——也不是什么难事——要不然就是hashTable检索。（最牛逼了）