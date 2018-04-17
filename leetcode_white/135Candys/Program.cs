using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _135Candys
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ratings = { 1, 2 };
            Solution2 solution2 = new Solution2();
            int ret = solution2.Candy(ratings);
            Console.WriteLine(ret);
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int Candy(int[] ratings)
        {
            int[] candys = new int[ratings.Length];
            int total = 0;
            const int LOW = -1;
            const int HIGH = 1;
            const int EQUAL = 0;
            const int BEGIN = -2;
            int STATE = BEGIN;
            for (int i = 0; i < ratings.Length - 1; i++)
            {
                switch (STATE)
                {
                    case BEGIN:
                        candys[0] = ratings[0];
                        if (ratings[i] < ratings[i + 1])
                        {
                            STATE = HIGH;
                        }
                        else if (ratings[i] == ratings[i + 1])
                        {
                            STATE = EQUAL;
                        }
                        else if (ratings[i] > ratings[i + 1])
                        {
                            STATE = LOW;
                        }
                        break;
                    //也就是ratings在降低
                    case LOW:
                        candys[i] = ratings[i];
                        if (ratings[i] < ratings[i + 1])
                        {
                            STATE = HIGH;
                        }
                        else if (ratings[i] == ratings[i + 1])
                        {
                            STATE = EQUAL;
                        }
                        break;
                    case HIGH:
                        candys[i] = candys[i - 1] + 1;
                        if (ratings[i] > ratings[i + 1])
                        {
                            STATE = LOW;
                        }
                        else if (ratings[i] == ratings[i + 1])
                        {
                            STATE = EQUAL;
                        }
                        break;
                    case EQUAL:
                        candys[i] = candys[i - 1];
                        if (ratings[i] > ratings[i + 1])
                        {
                            STATE = LOW;
                        }
                        else if (ratings[i] < ratings[i + 1])
                        {
                            STATE = HIGH;
                        }
                        break;
                }
            }
            foreach (var item in candys)
            {
                total += item;
            }
            return total;
        }
    }

    public class Solution2
    {
        public int Candy(int[] ratings)
        {
            int[] candys = new int[ratings.Length];
            int total = 0;
            for (int i = 0; i < ratings.Length; i++)
            {
                candys[i] = 1;
            }
            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1] && candys[i] <= candys[i - 1])
                {
                    candys[i] = candys[i - 1] + 1;
                }
            }
            for (int j = ratings.Length - 2; j >= 0; j--)
            {
                if (ratings[j] > ratings[j + 1] && candys[j] <= candys[j + 1])
                {
                    candys[j] = candys[j + 1] + 1;
                }
            }
            foreach (var item in candys)
            {
                total += item;
            }
            return total;
        }
    }
}
