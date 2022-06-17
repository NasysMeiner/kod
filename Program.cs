using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2._9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int numberMin = 1;
            int numberMax = 28;
            int number = random.Next(numberMin, numberMax);
            int upperBound = 1000;
            int amountOfNumbers = 0;
            int referenceLimit = 100;

            for (int i = 0; i < upperBound; i += number)
            {
                if (i > referenceLimit)
                {
                    amountOfNumbers++;
                }
            }
            Console.WriteLine($"Кол-во чисел кратных: {number} равно: {amountOfNumbers}.");
            Console.ReadLine();
        }
    }
}
