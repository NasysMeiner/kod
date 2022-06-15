using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wh_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hour;
            int minute;
            int human;

            Console.Write("Сколько старушек в очереди? ");
            human = Convert.ToInt32(Console.ReadLine());

            minute = human * 10;
            hour = minute / 60;
            minute -= hour * 60;

            Console.Write($"Вы должны отстоять в очереди {hour} часов и {minute} минут.");
            Console.ReadLine();
        }
    }
}
