using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wh1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            string zodiacSign;
            string work;
            int age;

            Console.Write("Ваше имя: ");
            name = Console.ReadLine();

            Console.Write("Ваш возраст: ");
            age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ваш знак зодиака: ");
            zodiacSign = Console.ReadLine();

            Console.Write("Где вы работаете? ");
            work = Console.ReadLine();

            Console.WriteLine($"Вас зовут {name}, возраст {age}, знак зодиака {zodiacSign}, и работаете {work}.");
            Console.ReadLine();
        }
    }
}
