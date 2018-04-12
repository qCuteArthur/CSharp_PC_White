using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//插入排序，假设数组被分成两个数组，前面的数组是有序的，不断从后面数组中选择元素，插入前面的有序数组中，而插入的过程，遵循元素的移动和最后的一次赋值。
//选择排序，选择后数组最小的，放在前数组的最后一个位置（后数组的第一个位置）。
//shell排序，首先进行快排，然后进行插入排序。
//奇数情况——首先是length/2 = stepLength ，然后让arr[i] 和 arr[i-stepLength]进行比较 ，如果小，就插入。和对应步长的位置进行比较。如果后面的元素更小，就进行位置的移动（这里就是插入排序了）。
//然后步长减半，进行上述的比较，直到步长为1
namespace 插入排序DoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 4, 7, 2, 8, 3, 9, 6 };
            InsertSort(ref array);
            Disp(array);
            Console.ReadLine();
        }
        static void InsertSort(ref int[] arr)
        {
            //其实插入排序的本质就是，就是一个元素不断和一个有序数组中的最后的元素作比较。
            int length = arr.Length;
            //1得到要插入的数据
            //2 把要插入数据之前的数组中需要移动的部分后移一个下标？？？
            //3 赋值？？
            for (int i = 1; i < length; i++)
            {
                int temp = arr[i];
                //i指向后数组的第一个元素。
                //j-1是前数组的最后一个元素。
                int j = 0;
                for(j = i-1; j >=0&& arr[j] > temp; j--)
                {
                    //一定要注意里面的逻辑啊！！！！
                    //前一个元素比后一个元素大，就要交换位置
                    //注意区分开这个移动和交换
                    arr[j+1] = arr[j];
                }
                //退出循环的时候，要不就是j=-1了，这个时候temp要赋值给j+1=0,；要不就是arr[j]<=temp,这个时候temp的值要赋给arr[j+1]
                //赋值
                arr[j+1] = temp;
            }
        }
        //注意：真正影响数组有没有被交换的是这个函数
        //static void Swap(ref int a,ref int b)
        //{
        //    int temp = a;
        //    a = b;
        //    b = temp;
        //}
        static void Disp(int[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }

}
//选择排序每次都是选择最小的东西，与第一个元素的位置进行交换。当然不是严格的第一个元素的位置，而是待处理的子数组的第一个元素的位置进行交换。
//插入排序——首先假设这个数组分为两个子数组，第一个数组位于前面，已经有序，（当然第一次只有一个元素），在后面的数组中选择最小的元素，移动前面数组中比当前最小元素大的。【感觉真的麻烦啊】

    //插入比较快——因为不存在元素的交换情况