using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            int sum = 0;
            string userInput = "";

            List<int> numbers = new List<int>();

            while (isWork)
            {
                userInput = Console.ReadLine();

                if (userInput == "exit")
                {
                    isWork = false;
                }
                else if (userInput == "sum")
                {
                    Console.Clear();

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        sum += numbers[i];
                    }

                    Console.WriteLine(sum);
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    numbers.Add(Convert.ToInt32(userInput));                   
                }
            }
        }
    }
}
