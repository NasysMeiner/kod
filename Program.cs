using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7._7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers1 = new List<Soldier> { new Soldier("Андрей"), new Soldier("Kirill"), new Soldier("Олег")};
            List<Soldier> soldiers2 = new List<Soldier> { new Soldier("Борис1"), new Soldier("Антон"), new Soldier("Борис2"), new Soldier("Денис"), new Soldier("Борис3")};
            var sortSoldier = soldiers2.Where(soldier => soldier.Name.StartsWith("Б"));
            var newSoldeir2 = soldiers2.Except(sortSoldier);
            soldiers2 = newSoldeir2.ToList();
            sortSoldier = soldiers1.Union(sortSoldier);
            soldiers1 = sortSoldier.ToList();

            foreach (Soldier soldier in soldiers1)
            {
                Console.WriteLine(soldier.Name);
            }
            Console.ReadLine();
        }
    }

    class Soldier
    {
        public string Name { get; private set; }

        public Soldier(string name)
        {
            Name = name;
        }
    }    
}
