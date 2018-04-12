using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//选择排序（交换）
//插入排序（移动）
//希尔排序 快速排序的方法设置步长，按照步长的距离做插入排序（移动）。对于里面的奇偶情况，由于我们并不涉及到实际的分组，所以无所谓。====快排+插入排序
//视频里面是shell的一种简化版，每个组的元素都是两个，但是易于劣迹


//基数排序
//桶排序 （盒排序）
namespace 桶排序
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[1000];

            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                array[i] = random.Next(1, 999);
            }
            //排序
            BucketSortSimplified(array);
            //输出
            foreach(var item in array)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
        static void BucketSortSimplified(int [] array)
        {
            int length = array.Length;
            //创建空桶并把桶里面的东西赋值为0;
            int[] buckets = new int[length];
            for(int i = 0; i < length; i++)
            {
                buckets[i] = 0;
            }

            for(int i = 0; i < length; i++)
            {
                //增加array[i]这个元素
                buckets[array[i]]++; 
            }
            //将桶中的元素输出。
            for (int i = 0; i < length; i++)
            {
                for(int j = buckets[i]; j > 0; j--)
                {
                    //桶里有几个元素，就输出几次。
                    Console.WriteLine("{0}",i);
                }
            }
        }
    }
}

//核心是减少交换的次数，增加比较的次数？？？
//基于比较的排序——快排是最快的，还有归并查找也很快
//shell排序不是稳定的排序
//hashTree是用来做查找的，而不是用来做排序的。

//不基于比较的——桶哥——排序——并且是稳定的排序
//这里面的稳定——可以理解为新增加数组的元素，会不会改变原来已经排好的东西的顺序，也就是是不是要涉及到插入到原来的东西里面

//桶排序，以增加内存所换取的快速，内存的增加速度一定是10倍。首先用个位数分桶。。。。把个位数相同的数据放在一个桶里面。然后再把这些数据放回原来的那个桶里面。
//三位数就进行三次，4位数就进行4次。分桶的方式，按照十进制还是8进制，10进制要增加10个桶。
//不基于比较 但是占用很大空间 特性决定桶的个数（比如说你的个位数都是从0~9，那就要分成9个桶， 每个桶的大小都是数据的个数。

//按照特性来分桶，然后对每个桶用不同的排序方式进行排序

//现在分别有 5 个人的名字和分数：huhu 5 分、haha 3 分、xixi 5 分、hengheng 2 分和 gaoshou 8 分。请按照分数从高到低，输出他们的名字。即应该输出 gaoshou、huhu、xixi、haha、hengheng。发现问题了没有？如果使用我们刚才简化版的桶排序算法仅仅是把分数进行了排序。最终输出的也仅仅是分数，但没有对人本身进行排序。也就是说，我们现在并不知道排序后的分数原本对应着哪一个人！这该怎么办呢？不要着急请听下回——冒泡排序。