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
            int intermediateOne = 0;
            int sum1 = 0;
            int sum2 = 0;
            int numberOne = 3;
            int numberTwo = 5;
            int intermediateTwo = 0;

            while (intermediateOne < number)
            {
                sum1 = sum1 + intermediateOne;
                intermediateOne = intermediateOne + numberOne;
            }

            Console.WriteLine(sum1);

            while (intermediateTwo < number)
            {
                sum2 = sum2 + intermediateTwo;
                intermediateTwo = intermediateTwo + numberTwo;
            }
            Console.WriteLine(sum2);

            Console.ReadLine();

        }
    }
}
