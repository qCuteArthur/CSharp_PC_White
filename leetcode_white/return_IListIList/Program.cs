using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//That is related to C# covariance and contravariance. 

namespace return_IListIList
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public IList<IList<T>> Foo<T>()
        {
            return new List<IList<T>>();
        }
        //函数签名不包括返回值
        public IList<T> Foo1<T>()
        {
            return new List<T>();
        }
        //因为List<T>实现了IList<T>
        //你将能够添加任何形式IList<T> 的结果
    }
    
}
