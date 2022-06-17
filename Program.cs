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
            int min = 1;
            int max = 28;
            int number = random.Next(min, max);
            int upperBound = 1000;
            int amountOfNumbers = 0;

            for (int i = 0; i < upperBound; i += number)
            {
                if (i > 100)
                {
                    amountOfNumbers++;
                }
            }
            Console.WriteLine($"Кол-во чисел кратных: {number} равно: {amountOfNumbers}.");
            Console.ReadLine();
        }
    }
}
