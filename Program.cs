using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6._7
{
    internal class Program
    {
        private static List<City> _routes = new List<City>();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            _routes.Add(new City("Гатчина", 0, 0));
            bool isWork = true;
            string userInput;
            
            while(isWork)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 20);
                ShowInfoRoats();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Меню:");
                Console.WriteLine("\n1 - построить маршрут.\n2 - выход");
                userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                        SerchRoute();
                        break;
                    case "2":
                        isWork = false;
                        break;
                }
            }

        }

        private static void SerchRoute()
        {
            string userInput;
            Random random = new Random();

            Train train = new Train();
            City Moskow = new City("Москва", 1000, random.Next(35, 500));
            City Petersburg = new City("Петербург", 500, random.Next(35, 500));
            City Shanghai = new City("Шанхай", 10000, random.Next(35, 500));

            Console.Clear();
            Console.WriteLine("\nВы находитесь: Гатчина. Построить маршрут до:\n1 - Москвa.\n2 - Петербург.\n3 - Шанхай.\n");
            userInput= Console.ReadLine();

            switch(userInput)
            {
                case"1":
                    _routes.Add(Moskow);
                    break;
                case"2":
                    _routes.Add(Petersburg);
                    break;
                case"3":
                    _routes.Add(Shanghai);
                    break;
            }
        }

        public static void ShowInfoRoats()
        {   
            Train train = new Train();     
            int numberRailwayCarriage = 0;

            if (_routes.Count > 1)
            {
                foreach (City city in _routes)
                {
                    if (city.Name == _routes[0].Name)
                    {
                        continue;
                    }
                    numberRailwayCarriage = train.CreateComposition(city.Passengers);
                    Console.WriteLine($"Маршрут {_routes[0].Name} - {city.Name} дальностью в {city.Distance}км. Пассажирова купило билетов: {city.Passengers} и заняло вагонов: {numberRailwayCarriage}.");
                }
            }
            else
            {
                Console.WriteLine("Маршруты не созданы.");
            }

        }
    }

    class RailwayCarriage
    {
        public int Place { get; private set; }

        public RailwayCarriage(int place)
        {
            Place = place;
        }
    }

    class Train
    {
        private RailwayCarriage _railwayCarriage = new RailwayCarriage(35);
        private int _numberRailwayCarriage = 0;

        public int CreateComposition(int numberOfPassengers)
        {
            return DefineLengthTrain(numberOfPassengers);          
        }

        private int DefineLengthTrain(int numberOfPassengers)
        {
            if (numberOfPassengers % _railwayCarriage.Place == 0)
            {
                return _numberRailwayCarriage = numberOfPassengers / _railwayCarriage.Place;
            }
            else
            {
                return _numberRailwayCarriage = numberOfPassengers / _railwayCarriage.Place + 1;
            }
        }
    }

    class City
    {
        public string Name { get; private set; }
        public int Distance { get; private set; }
        public int Passengers { get; private set; }

        public City(string name, int distance, int passengers)
        {
            Name = name;
            Distance = distance;
            Passengers = passengers;
        }
    }
}
