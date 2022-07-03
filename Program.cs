using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6._12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Zoo zoo = new Zoo();
            zoo.Work();
        }
    }

    class Zoo
    {
        private static Random _random = new Random();


        private List<Aviary> _aviaris = new List<Aviary>();

        public Zoo()
        {
            _aviaris.Add(new Aviary("Львы", "Р", _random));
            _aviaris.Add(new Aviary("Кошки", "Мяу", _random));
            _aviaris.Add(new Aviary("Обезьяны", "У", _random));
            _aviaris.Add(new Aviary("Волки", "Ууу", _random));
        }

        public void Work()
        {
            bool isWork = true;
            string userInput;

            while (isWork)
            {
                ShowAllInfo();
                Console.Write("\nПодойти к клетке номер: ");
                userInput = Console.ReadLine();

                if(int.TryParse(userInput, out int result) && result <= _aviaris.Count && result > 0)
                {
                    ShowInfo(result - 1);
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                    Console.ReadKey();                   
                }

                Console.Clear();
            }
        }

        private void ShowAllInfo()
        {
            int numberAviary = 0;

            foreach(Aviary aviary in _aviaris)
            {
                Console.WriteLine($"Клетка - {numberAviary + 1}: {aviary.ShowBeast()}.");
                numberAviary++;
            }
        }

        private void ShowInfo(int number)
        {
            _aviaris[number].ShowAllBeasts();
        }


    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();
        private int _genderMale = 0;
        private int _genderWomen = 0;

        public Aviary(string name, string sound, Random random)
        {
            string gender;

            for (int i = 0; i < random.Next(1, 100); i++)
            {
                if(random.Next(0, 2) == 0)
                {
                    gender = "Мужской";
                    _genderMale++;
                }
                else
                {
                    gender = "Женский";
                    _genderWomen++;
                }

                _animals.Add(new Animal(name, sound, gender));
            }
        }

        public string ShowBeast()
        {
            return _animals[0].Name;
        }

        public void ShowAllBeasts()
        {
            Console.Clear();
            Console.WriteLine($"В клетке: {_animals[0].Name}.\nВнутри {_animals.Count} животных.\nОни издают звук {_animals[0].Sound}.\nМужских особей внутри: {_genderMale}, а женских: {_genderWomen}.\n");
            Console.WriteLine("\nНажмите, чтобы отойти от клетки.");
            Console.ReadKey();
        }
    }

    class Animal
    {
        public string Name { get; private set; }
        public string Sound { get; private set; }
        public string Gender { get; private set; }

        public Animal(string name, string sound, string gender)
        {
            Name = name;
            Sound = sound;
            Gender = gender;
        }
    }
}
