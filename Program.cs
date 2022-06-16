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
            int number = random.Next(0, 30);
            int sum1 = 0;
            int sum2 = 0;
            int numberOne = 3;
            int numberTwo = 5;

            for (int i = 0; i <= number; i += numberOne)
            {
                sum1 += i;
            }

            for (int i = 0; i <= number; i += numberTwo)
            {
                sum2 += i;
            }

            Console.WriteLine(sum1);
            Console.WriteLine(sum2);

            Console.ReadLine();
        }
    }
}
