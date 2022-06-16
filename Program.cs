using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double rub;
            double usd;
            double eur;

            string userInput = "0";
            double userNumber;

            int rubToUsd = 65;
            int rubToEur = 75;
            double usdToRub = 0.015;
            double usdToEur = 1.15;
            double eurToRub = 0.014;
            double eurToUsd = 0.87;

            Console.WriteLine("Сколько у вас рублей?");
            rub = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Сколько у вас долларов?");
            usd = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Сколько у вас евро?");
            eur = Convert.ToSingle(Console.ReadLine());

            while (Convert.ToInt32(userInput) < 7)
            {

                Console.WriteLine("Как именно вы хотите обменять валюту?");

                Console.WriteLine("1 - рубли в доллары");
                Console.WriteLine("2 - рубли в евро");
                Console.WriteLine("3 - доллары в рубли");
                Console.WriteLine("4 - доллары в евро");
                Console.WriteLine("5 - евро в рубли");
                Console.WriteLine("6 - евро в доллары");
                Console.WriteLine("7 - выход");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Рубли в доллары");
                        Console.WriteLine("Сколько вы хотите обменять?");
                        userNumber = Convert.ToSingle(Console.ReadLine());
                        rub -= userNumber;
                        usd += userNumber / rubToUsd;
                        break;
                    case "2":
                        Console.WriteLine("Рубли в евро");
                        Console.WriteLine("Сколько вы хотите обменять?");
                        userNumber = Convert.ToSingle(Console.ReadLine());
                        rub -= userNumber;
                        eur += userNumber / rubToEur;
                        break;
                    case "3":
                        Console.WriteLine("Доллары в рубли");
                        Console.WriteLine("Сколько вы хотите обменять?");
                        userNumber = Convert.ToSingle(Console.ReadLine());
                        usd -= userNumber;
                        rub += userNumber / usdToRub;
                        break;
                    case "4":
                        Console.WriteLine("Доллары в евро");
                        Console.WriteLine("Сколько вы хотите обменять?");
                        userNumber = Convert.ToSingle(Console.ReadLine());
                        usd -= userNumber;
                        eur += userNumber / usdToEur;
                        break;
                    case "5":
                        Console.WriteLine("Евро в рубли");
                        Console.WriteLine("Сколько вы хотите обменять?");
                        userNumber = Convert.ToSingle(Console.ReadLine());
                        eur -= userNumber;
                        rub += userNumber / eurToRub;
                        break;
                    case "6":
                        Console.WriteLine("Евро в доллары");
                        Console.WriteLine("Сколько вы хотите обменять?");
                        userNumber = Convert.ToSingle(Console.ReadLine());
                        eur -= userNumber;
                        usd += userNumber / eurToUsd;
                        break;
                }
                Console.WriteLine($"У вас рублей: {rub}. долларов: {usd}. евро: {eur}.");
            }
            Console.WriteLine("Вы вышли из конвертора валюты.");
            Console.ReadLine();
        }
    }
}
