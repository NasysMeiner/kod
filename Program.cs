using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3._7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Дана строка с текстом, используя метод строки String.Split() получить массив слов, которые разделены пробелом в тексте и вывести массив, каждое слово с новой строки.";

            string[] texts = text.Split(' ');

            foreach (string s in texts)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
}
