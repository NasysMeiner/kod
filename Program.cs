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
            string userInputName = "";
            string userInputPost = "";            
            string userInput = "";
            string[] nameSurName = new string[0];
            string[] post = new string[0];
            int number = 0;

            while (isWork)
            {
                Console.WriteLine("Выберите пункт.\n1 - добавить досье.\n2 - вывести все досье.\n3 - удалить досье.\n4 - поиск по фамилии.\n5 - выход");
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.Clear();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        AddFile(ref userInputName, ref userInputPost);
                        ArrayUp(ref nameSurName, userInputName);
                        ArrayUp(ref post, userInputPost);
                        break;
                    case ConsoleKey.D2:
                        SummonFile(nameSurName, post);                        
                        break;
                    case ConsoleKey.D3:
                        number = DeleteFile(ref nameSurName, ref post);
                        ArrayDown(ref nameSurName, number);
                        ArrayDown(ref post, number);
                        break;
                    case ConsoleKey.D4:
                        Search(nameSurName, post);
                        break;
                    case ConsoleKey.D5:
                        isWork = false;
                        break;
                }
            }
        }

        static void ArrayUp(ref string[] arrayUp, string variable)
        {
            string[] newArray = new string[arrayUp.Length + 1];

            for (int i = 0; i < arrayUp.Length; i++)
            {
                newArray[i] = arrayUp[i];
            }

            newArray[newArray.Length - 1] = variable;
            arrayUp = newArray;
        }

        static void ArrayDown(ref string[] arrayDown, int variable)
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

        static void AddFile(ref string userInputName, ref string UserInputPost)
        {
            Console.Write("Введите ФИО:");
            userInputName = Console.ReadLine();
            Console.Clear();

            Console.Write("Введите должность:");
            UserInputPost = Console.ReadLine();
            Console.Clear();

            Console.WriteLine($"Вы ввели.\nФио: {userInputName} и должность: {UserInputPost}.");
            Console.ReadKey();
            Console.Clear();
        }

        static void SummonFile(string[] nameSurName, string[] post)
        {
            for (int i = 0; i < nameSurName.Length; i++)
            {
                Console.WriteLine($"{nameSurName[i]} - {post[i]}");
            }

            Console.ReadKey();
            Console.Clear();
        }

        static int DeleteFile(ref string[] nameSurName, ref string[] post)
        {
            Console.WriteLine("Введите фамилию в досье, которое хотите удалить:");
            string userInput = Console.ReadLine();
            string[] newArray = new string[nameSurName.Length - 1];
            int number = 0;

            for(int i = 0; i < nameSurName.Length; i++)
            {
                string[] surName = nameSurName[i].Split(' ');

                for (int j = 0; j < surName.Length; j++)
                {
                    if (surName[j] == userInput)
                    {
                        number = i;
                    }
                }
            }

            Console.Clear();
            return(number);
        }

        static void Search(string[] nameSurName, string[] post)
        {
            Console.WriteLine("Введите фамилию в досье, которое хотите найти:");
            string userInput = Console.ReadLine();
            Console.Clear();
            int number = 0;

            for(int i = 0; i < nameSurName.Length; i++)
            {
                string[] surName = nameSurName[i].Split(' ');

                for (int j = 0; j < surName.Length; j++)
                {
                    if (surName[j] == userInput)
                    {
                        number = i;
                    }
                }
            }

            Console.WriteLine($"Досье которое вы искали:");
            Console.WriteLine($"{nameSurName[number]} - {post[number]}");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
