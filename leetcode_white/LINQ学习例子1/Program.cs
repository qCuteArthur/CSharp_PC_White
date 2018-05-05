using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ学习例子1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Query #1.
            List<int> numbers = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // The query variable can also be implicitly typed by using var
            IEnumerable<int> filteringQuery =
                from num in numbers
                where num < 3 || num > 7
                select num;
            
            // Query #2.
            IEnumerable<int> orderingQuery =
                from num in numbers
                where num < 3 || num > 7
                orderby num ascending
                select num;

            var  concatResult =filteringQuery.Concat(orderingQuery);
            if (concatResult.Contains(1))
            {
                Console.WriteLine("All Right!");
            }
            Console.WriteLine(orderingQuery.Count());

            var DefaultResult = concatResult.DefaultIfEmpty();
            
            Console.WriteLine(DefaultResult.GetType());
    
            // Query #3.
            string[] groupingQuery = { "carrots", "cabbage", "broccoli", "beans", "barley" };
            IEnumerable<IGrouping<char, string>> queryFoodGroups =
                from item in groupingQuery
                group item by item[0];

            double ret = Math.Pow(2,3);
            Console.WriteLine(ret);


            Console.ReadLine();
        }
    }
}
