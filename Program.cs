using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6._13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            CarService carService = new CarService();
            carService.Work();
        }
    }

    class CarService
    {
        private static Random _random = new Random();
        private List<Detail> _details = new List<Detail>();
        private Queue<Car> _cars = new Queue<Car>();        
        private Car _nowСar;
        public int Money { get; private set; }
        public int PriceMoney { get; private set; }
        public int Fine { get; private set; }
        public int DamageMoney { get; private set; }

        public CarService()
        {
            PriceMoney = 1000;
            Fine = 700;
            DamageMoney = 1500;

            _details.Add(new Detail("Колесо", true, 1000));
            _details.Add(new Detail("Колесо", true, 1000));
            _details.Add(new Detail("Подъёмник окна", true, 2000));
            _details.Add(new Detail("Дверная ручка", true, 500));
            _details.Add(new Detail("Лобовое стекло", true, 5000));
            _details.Add(new Detail("Лобовое стекло", true, 5000));
            _details.Add(new Detail("Торпеда", true, 2500));
            _details.Add(new Detail("Фары", true, 1500));
            _details.Add(new Detail("Руль", true, 700));

            _cars.Enqueue(new Car(wheel: false, doorhandle: false, torpedo: false));
            _cars.Enqueue(new Car(windowRaiser: false));
            _cars.Enqueue(new Car(wheel: false, torpedo: false));
            _cars.Enqueue(new Car(steeringWheel: false));
            _cars.Enqueue(new Car(doorhandle: false));
            _cars.Enqueue(new Car(windshild: false));
            _cars.Enqueue(new Car(wheel: false));
        }

        public void Work()
        {
            Random random = new Random();

            ShowAllDetails();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Клиентов в очереди:{_cars.Count}.");
            Console.ReadLine();
            Console.Clear();

            while (_cars.Count > 0)
            {
                Console.Clear();
                ShowAllDetails();
                RepairCar();
                Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine($"Клиенты закончились.");
            ShowAllDetails();
            Console.ReadLine();
        }

        private void ShowAllDetails()
        {
            int positionY = 3;

            Console.SetCursorPosition(80, 0);
            Console.WriteLine($"Итого денег: {Money}");

            foreach(Detail detail in _details)
            {
                Console.SetCursorPosition(80, positionY);
                Console.WriteLine(detail.Name);
                positionY++;
            }
        }

        private void WatchCar()
        {
            _nowСar = _cars.Dequeue();
        }

        private bool SerachNewDetail(Detail damageDetail)
        {
            foreach(Detail detail in _details)
            {
                if(detail.Name == damageDetail.Name)
                {
                    return true;
                }
            }

            return false;
        }

        private void RepairCar()
        {
            string userInput;
            int numberDamageDetails; 
            int priceDetail;
            WatchCar();
            Stack<Detail> damageDetails = _nowСar.ShowAllDetails();

            Console.WriteLine("\n1 - заменить деталь.\n2 - прогнать клиента.");
            userInput = Console.ReadLine();

            if(userInput == "1")
            {
                numberDamageDetails = damageDetails.Count;

                for (int i = numberDamageDetails; i > 0; i--)
                {
                    Detail damageDetail = damageDetails.Pop();

                    if (_nowСar.ReplaceDetail(damageDetail, SerachNewDetail(damageDetail)))
                    {
                        priceDetail = RemoveNewDetail(damageDetail);
                        Console.WriteLine($"Замена прошла успешно. Вы заработали {PriceMoney} за работу и {priceDetail} за деталь");      
                        Money += priceDetail + PriceMoney;
                    }
                    else
                    {
                        priceDetail = RemoveNewDetail(damageDetail);
                        Console.WriteLine($"Заменить деталь не удалось. Возмещённый ущерб {priceDetail}.");
                        Money -= priceDetail;
                    }
                }
            }
            else
            {
                Console.WriteLine($"Вы прогнали клиента и получили штраф в размере:{Fine}");
                Money -= Fine;
            }
        }

        private int RemoveNewDetail(Detail damageDetail)
        {
            int detailPrice = 0;
            int number = _random.Next(0, _details.Count + 1);

            foreach (Detail detail in _details)
            {
                if (detail.Name == damageDetail.Name)
                {
                    detailPrice = detail.PriceDetail;
                    _details.Remove(detail);
                    return detailPrice;
                }
            }

            detailPrice = _details[number].PriceDetail;
            _details.RemoveAt(number);
            return detailPrice;
            
            return 0;
        }
    }

    class Car
    {     
        private List<Detail> _detailsCar = new List<Detail>();

        public Car(bool wheel = true, bool windshild = true, bool doorhandle = true, bool windowRaiser = true, bool torpedo = true, bool lights = true, bool steeringWheel = true)
        {
            _detailsCar.Add(new Detail("Колесо", wheel));
            _detailsCar.Add(new Detail("Подъёмник окна", windshild));
            _detailsCar.Add(new Detail("Дверная ручка", doorhandle));
            _detailsCar.Add(new Detail("Лобовое стекло", windowRaiser));
            _detailsCar.Add(new Detail("Торпеда", torpedo));
            _detailsCar.Add(new Detail("Фары", lights));
            _detailsCar.Add(new Detail("Руль", steeringWheel));
        }

        public bool ReplaceDetail(Detail detail1, bool inStock)
        {
            foreach(Detail detail2 in _detailsCar)
            {
                if(detail2.Condition == false && detail2.Name == detail1.Name && inStock)
                {
                    detail2.RepairDetail();

                    return true;
                }
            }

            return false;
        }

        public Stack<Detail> ShowAllDetails()
        {
            Stack<Detail> damageDetails = new Stack<Detail>();

            Console.SetCursorPosition(0, 0);

            foreach (Detail detail in _detailsCar)
            {
                if(detail.Condition == false)
                {
                    damageDetails.Push(detail);
                    Console.WriteLine($"{detail.Name} - требует замены.");
                }
            }

            return damageDetails;
        }
    }

    class Detail
    {
        public string Name { get; private set; }
        public bool Condition { get; private set; }
        public int PriceDetail { get; private set; }

        public Detail(string name = "", bool condition = true, int priceDetail = 0)
        {
            Name = name;
            Condition = condition;
            PriceDetail = priceDetail;
        }

        public void RepairDetail()
        {
            Condition = true;
        }
    }
}
