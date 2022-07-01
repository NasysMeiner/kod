using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6._8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Area area = new Area();
            area.Fight();
        }
    }

    class Area
    {
        private Warrior[] _warriors = { new Knight(500, 100, 75, 2, 3), new Barbarian(1100, 140, 40, 3), new Assassin(400, 70, 200, 2), new Mag(350, 100, 3, 200), new Archer(400, 90, 2) };


        public void Fight()
        {
            Warrior warrior1 = new Warrior();
            Warrior warrior2 = new Warrior();

            ChoiceFighters(ref warrior1, ref warrior2);

            while(warrior1.Health > 0 && warrior2.Health > 0)
            {
                warrior1.TakeDamage(warrior2);
                warrior2.TakeDamage(warrior1);
                warrior1.ShowStats();
                warrior2.ShowStats();
                Warrior.Plus();
                Console.ReadLine();
                Console.Clear();
            }

            if (warrior1.Health > 0)
            {
                Console.WriteLine($"Победил: {warrior1.Name}");
            }
            else if (warrior2.Health >= 0)
            {
                Console.WriteLine($"Победил: {warrior2.Name}");
            }
            else
            {
                Console.WriteLine("Ничья");
            }

            Console.ReadLine();
        }

        public void ChoiceFighters(ref Warrior warrior1, ref Warrior warrior2)
        {
            string userInput1 = "";
            string userInput2 = "";
            
            CheckInput(ref userInput1, ref userInput2);

            warrior1 = _warriors[Convert.ToInt32(userInput1) - 1];
            warrior2 = _warriors[Convert.ToInt32(userInput2) - 1];
            warrior1.ShowStats();
            warrior2.ShowStats();
            Console.WriteLine("\nНажмите чтобы начать бой.");
            Console.ReadKey();
            Console.Clear();
        }

        public void CheckInput(ref string userInput1, ref string userInput2)
        {
            bool isWork = true;

            while(isWork)
            {
                Console.WriteLine("Выберите 1 бойца:");
                ShowInfo();
                userInput1 = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Выберите 2 бойца:");
                ShowInfo();
                userInput2 = Console.ReadLine();
                Console.Clear(); 

                if(int.TryParse(userInput1, out int result1) && int.TryParse(userInput2, out int result2))
                {
                    if(userInput1 == userInput2)
                    {
                        Console.WriteLine("Этот боец уже выбран.");
                    }
                    else if(result1 <= _warriors.Length && result2 <= _warriors.Length && result1 >= 0 && result2 >= 0)
                    {                                            
                        isWork = false;                        
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        
        public void ShowInfo()
        {
            int variable = 1;

            foreach(var warrior in _warriors)
            {
                Console.WriteLine($"{variable} - {warrior.Name} имеет: {warrior.Health}Hp, {warrior.Damage} урона и {warrior.Armor} брони.");
                variable++;
            }
        }
    }

    class Warrior
    {

        public string Name { get; protected set;}
        public static int MovesToAbility { get; protected set;}
        public double Health { get; protected set;}
        public double BaseDamage { get; protected set;}
        public double Damage { get; protected set;}
        public int Armor { get; protected set;}

        public Warrior(double health = 0, double damage = 0, string name = "", int armor = 1)
        {
            Name = name;
            Health = health;
            BaseDamage = damage;
            Damage = BaseDamage;
            Armor = armor;
            MovesToAbility = 1;
        }

        public static void Plus()
        {
            MovesToAbility++;
        }

        public virtual void TakeDamage(Warrior warrior)
        {
            Health -= warrior.RecalculationDamage() * ((Convert.ToDouble(100) - Armor) / Convert.ToDouble(100));
        }

        public virtual double RecalculationDamage()
        {
            return Damage;
        }

        public virtual void ShowStats()
        {
            Console.WriteLine($"{Name}: {Health}Hp, урона: {Damage} и брони:{Armor}.");
        }
    }

    class Knight : Warrior
    {
        private int _damageBaff;
        public double CooldownAbility { get; private set;}

        public Knight(double health, int damage, int armor, int damageBaff, int cooldownAbility) : base(health, damage, "Рыцарь", armor)
        {
            _damageBaff = damageBaff;
            CooldownAbility = cooldownAbility;
        }

        public override double RecalculationDamage()
        {
            if(MovesToAbility % CooldownAbility == 0 && MovesToAbility > 0)
            {
                Console.WriteLine("Рыцарь наносит двойной урон.");
                Damage = _damageBaff * BaseDamage;
                return Damage;
            }
            else
            {
                Damage = BaseDamage;
                return base.RecalculationDamage();
            }          
        }
    }

    class Barbarian : Warrior
    {
        private double _maxHealth;
        private int _stateOfRage;
        private int _coefficientDamage;

        public Barbarian(double health, int damage, int stateOfRage, int coefficientDamage) : base(health, damage, "Варвар")
        {
            _stateOfRage = stateOfRage;
            _coefficientDamage = coefficientDamage;
            _maxHealth = health;
        }

        public override double RecalculationDamage()
        {
            double percentageHealth = Health / (_maxHealth / 100);

            if(percentageHealth <= _stateOfRage)
            {
                Console.WriteLine("Варвар в состоянии ярости.");
                Damage = _coefficientDamage * BaseDamage;
                return Damage;
            }
            else
            {
                Damage = BaseDamage;
                return base.RecalculationDamage();
            }           
        }
    }

    class Assassin : Warrior
    {
        private int _critDamage;
        public double CooldownAbility { get; private set;}

        public Assassin(double health, int damage, int critDamage, int cooldownAbility) : base(health, damage, "Ассасин")
        {
            _critDamage = critDamage;
            BaseDamage = damage;
            CooldownAbility = cooldownAbility;
            Damage = BaseDamage;
        }

        public override double RecalculationDamage()
        {
            if(MovesToAbility % CooldownAbility == 0 && MovesToAbility > 1)
            {
                Console.WriteLine("Ассасин наносит критический удар.");
                Damage *= (_critDamage / 100);
                return Damage;
            }
            else
            {
                Damage = BaseDamage;
                return base.RecalculationDamage();
            }
        }
    }

    class Mag : Warrior
    {
        public double CooldownAbility { get; private set;}
        public double ShieldLife { get; private set;}
        public double Shield { get; private set;}

        public Mag(double health, int damage, int cooldownAbility, double shildLife) : base(health , damage, "Маг")
        {
            CooldownAbility = cooldownAbility;
            ShieldLife = shildLife;
            Shield = 0;
        }

        public override void TakeDamage(Warrior warrior)
        {
            if(MovesToAbility % CooldownAbility == 0 && MovesToAbility > 1)
            {
                if(Shield <= 0)
                {
                    Shield = 0;
                    Console.WriteLine("Маг использовал барьер.");
                    Shield += ShieldLife;
                }
                else
                {
                    Console.WriteLine("Маг использовал барьер.");
                    Shield += ShieldLife;
                }
            }
            if(Shield > 0)
            {
                Shield -= warrior.RecalculationDamage() * ((Convert.ToDouble(100) - Armor) / Convert.ToDouble(100));
            }
            else
            {
                base.TakeDamage(warrior);
            }
        }

        public override void ShowStats()
        {
            Console.WriteLine($"{Name}: {Health}Hp, урона: {Damage} и барьер:{Shield}.");
        }
    }

    class Archer : Warrior
    {
        public int CooldownDodge { get; private set; }

        public Archer(double health, int damage, int cooldownDodge) : base(health, damage, "Лучник")
        {
            CooldownDodge = cooldownDodge;
        }

        public override void TakeDamage(Warrior warrior)
        {
            if(MovesToAbility % CooldownDodge == 0 && MovesToAbility > 1)
            {
                Console.WriteLine("Лучник уклонился.");
                Health -= warrior.RecalculationDamage() * 0;
            }
            else
            {
                base.TakeDamage(warrior);
            }           
        }
    }

}
