using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;          
            string[] fullNames = new string[0];
            string[] works = new string[0];

            while (isWork)
            {
                Console.WriteLine("Выберите пункт.\n1 - добавить досье.\n2 - вывести все досье.\n3 - удалить досье.\n4 - поиск по фамилии.\n5 - выход");
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.Clear();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        AddFile(ref fullNames, ref works);
                        break;
                    case ConsoleKey.D2:
                        SummonFile(fullNames, works);                        
                        break;
                    case ConsoleKey.D3:
                        DeleteFile(ref fullNames, ref works);
                        break;
                    case ConsoleKey.D4:
                        Search(fullNames, works);
                        break;
                    case ConsoleKey.D5:
                        isWork = false;
                        break;
                }
            }
        }

        static void ArrayExpand(ref string[] arrayUp, string variable)
        {
            string[] newArray = new string[arrayUp.Length + 1];

            for (int i = 0; i < arrayUp.Length; i++)
            {
                newArray[i] = arrayUp[i];
            }

            newArray[newArray.Length - 1] = variable;
            arrayUp = newArray;
        }

        static void ArrayDereace(ref string[] arrayDown, int variable)
        {
            string[] newArray = new string[arrayDown.Length - 1];

            int delete = 0;

            for (int i = 0; i < arrayDown.Length; i++)
            {
                if (i == variable)
                {
                    continue;
                }                            
                newArray[delete] = arrayDown[i];
                delete++;
            }

            arrayDown = newArray;
        }

        static void AddFile(ref string[] fullNames, ref string[] works)
        {
            Console.Write("Введите ФИО:");
            string userInputName = Console.ReadLine();
            Console.Clear();

            Console.Write("Введите должность:");
            string userInputPost = Console.ReadLine();
            Console.Clear();

            ArrayExpand(ref fullNames, userInputName);
            ArrayExpand(ref works, userInputPost);

            Console.WriteLine($"Вы ввели.\nФио: {userInputName} и должность: {userInputPost}.");
            Console.ReadKey();
            Console.Clear();
        }

        static void SummonFile(string[] fullNames, string[] works)
        {
            for (int i = 0; i < fullNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}:{fullNames[i]} - {works[i]}");
            }

            Console.ReadKey();
            Console.Clear();
        }

        static void DeleteFile(ref string[] fullNames, ref string[] works)
        {
            Console.WriteLine("Введите индекс в досье, которое хотите удалить:");
            int userInput = Convert.ToInt32(Console.ReadLine());
            int number = 0;

            if (fullNames.Length > 0) 
            {
                
                for(int i = 0; i < fullNames.Length; i++)
                {
                    string[] surName = fullNames[i].Split(' ');

                    if (i == (userInput - 1))
                    {
                            number = i;
                    }                   
                }

                ArrayDereace(ref fullNames, number);
                ArrayDereace(ref works, number);

                Console.Clear();
            }
            else
            {
                Console.WriteLine("Архив пустой.");
            }
        }

        static void Search(string[] nameSurName, string[] post)
        {
            Console.WriteLine("Введите фамилию в досье, которое хотите найти:");
            string userInput = Console.ReadLine();
            Console.Clear();

            int number = 0;
            Console.WriteLine($"Досье которое вы искали:");

            for(int i = 0; i < nameSurName.Length; i++)
            {
                string[] surName = nameSurName[i].Split(' ');

                for (int j = 0; j < surName.Length; j++)
                {
                    if (surName[j] == userInput)
                    {
                        number = i;
                        Console.WriteLine($"{nameSurName[number]} - {post[number]}");
                    }
                }
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
