using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_XX
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public interface Flyable
    {
        void fly();
    }
    public interface Runable
    {
        void run();
    }
    public class Bird : Flyable, Runable
    {
        public void fly()
        {
            Console.WriteLine("could fly!");
        }
        public void run()
        {
            Console.WriteLine("could run!");
        }
    }
}

//接口相当于没有实现的抽象类
//常用的系统接口：
//using，实现了IDisposable接口的对象可以使用using进行资源声明，出了using的作用域以后自动调用Dispose方法。 Dispose和Close的区别：实现了IDisposable接口必须定义Dispose方法，但不一定有Close方法，很多Dispose的实现都是调用Close方法。SqlConnection Close以后还能重新Open，但是Dispose以后就不能再用。

//     用using最多的就是再与非托管代码的交道中，例如using(SqlConnection con = new SqlConnection()) { XXXXXXXX }，省去了释放资源的代码，简洁了开发工作。

//foreach：实现了IEnumerable接口的对象都可以使用foreach进行遍历。申明一个对象，并查看IEnumerable的定义，发现其有一个属性接口和两个方法接口，Current，MoveNext等。

//这个事情应该这么想，你自己声明的东西其实都是从系统的接口出发的。foreach其实是在IEnumerable接口中已经定义好的方法，你声明的对象如果类型上继承了这个接口，那么你这个object就可以调用foreach接口。

//ArrayList可以看做是动态的数组。Add、Clear、Contains、Count、Remove、RemoveAt、ToArray（转换，再没关系）、索引器。C#中所有的数组类型int[]、string[]等都是继承自Array类。

//当然，ArrayList还有许多美中不足的地方：数据放进去就不知道是什么类型的了；不能防止非法类型数据的放入；将ArrayList返回给其他函数，会令调用者很困惑。要区分变量、返回值类型和实际对象类型的区别。IntArrayList,StringArrayList又没完没了。因此，就出现了泛型List列表。
//跟随老大了解了集合，ArrayList、HashSet、Hashtable、Dictionary等都可以叫做集合类。实现了IEnumerable(getEnumerator())、IEnumerable<T> 的接口都可以使用foreach进行遍历。
//List其实就是规定好了返回值和输入值的类型，也就是不用你额外的声明类型。

// Dictionary找东西特别快。

//泛型的非泛型类型是什么？例如Dictionary<K, V> 的非泛型对应的是Hashtable；List<T>→ArrayList
//至于说为什么Dictionary计算的特别快，因为使用key结合算法计算得到value的位置，最后用数组寻址的方式很快就找到了最后的结果。

//HashSet<T>：不能盛放重复的数据，重复的数据只保留一份。Add(T value)添加元素；Contains(T value)判断是否存在元素，HashSet使用了和Dictionary类似的算法，因此Contains方法效率非常高，时间复杂度为O(1)。

