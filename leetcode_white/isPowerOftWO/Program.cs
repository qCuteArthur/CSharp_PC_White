using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isPowerOftWO
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public bool isPowerOfTwo(int n)
        {
            double number = Math.Sqrt(n);
            if(Math.Sqrt(n) != (double)Math.Floor(Math.Sqrt(n)))
            {
                return false;
            }
            return true;
        }
    }
}
