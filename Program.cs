using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int limit = 101;
            int number = random.Next(0, limit);
            int sum1 = 0;
            int multiplicityFirst = 3;
            int multiplicityTwo = 5;

            for (int i = 1; i < number; i ++)
            {
                if (i % multiplicityFirst == 0)
                {
                    sum1 += i;
                }
                else if (i % multiplicityTwo == 0)
                {
                    sum1 += i;
                }
            }


            Console.WriteLine(sum1); 

            Console.ReadLine();
        }
    }
}
