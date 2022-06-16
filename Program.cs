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
            int number = random.Next(0, 101);
            int sum1 = 0;
            int sum2 = 0;
            int multiplicityFirst = 3;
            int multiplicityTwo = 5;

            for (int i = 0; i < number; i += multiplicityFirst)
            {
                sum1 += i;
            }

            for (int i = 0; i < number; i += multiplicityTwo)
            {
                sum2 += i;
            }

            Console.WriteLine(sum1 + sum2);

            Console.ReadLine();
        }
    }
}
