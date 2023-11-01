using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingOfTroops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Armies armies = new Armies();

            armies.Work();

            Console.ReadKey();
        }
    }

    class Armies
    {
        private List<Soldier> _soldiers1;
        private List<Soldier> _soldiers2;

        public Armies()
        {
            _soldiers1 = new List<Soldier>
            {
                new Soldier("Быков", "Рядовой"),
                new Soldier("Абрамов", "Рядовой"),
                new Soldier("Блинов", "Рядовой"),
                new Soldier("Бобров", "Сержант"),
                new Soldier("Лавров", "Сержант"),
                new Soldier("Устинов", "Капитан"),
                new Soldier("Балашов", "Капитан")
            };

            _soldiers2 = new List<Soldier>
            {
                new Soldier("Андрианов", "Рядовой"),
                new Soldier("Терехов", "Капитан"),
                new Soldier("Бочкарёв", "Рядовой"),
                new Soldier("Родин", "Рядовой"),
                new Soldier("Беликов", "Сержант")
            };
        }

        public void Work()
        {
            Console.WriteLine("Отряд первый: ");
            ShowSoldiers(_soldiers1);

            Console.WriteLine("Отряд второй: ");
            ShowSoldiers(_soldiers2);

            MoveSoldiersToAnotherDivision();

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Отряд первый, после перемещения: ");
            ShowSoldiers(_soldiers1);

            Console.WriteLine("Отряд второй, после перемещения: ");
            ShowSoldiers(_soldiers2);
        }

        private void ShowSoldiers(List<Soldier> soldiers)
        {
            int soldiersNumber = 1;

            if (soldiers.Any())
            {
                foreach (var soldier in soldiers)
                {
                    Console.WriteLine($"{soldiersNumber}: {soldier.Name}, {soldier.Title}");
                    soldiersNumber++;
                }
            }
        }

        private void MoveSoldiersToAnotherDivision()
        {
            string filterByPrefix = "Б";

            var soldiers = _soldiers1.Where(soldier => soldier.Name.StartsWith(filterByPrefix));
            _soldiers1 = _soldiers1.Except(soldiers).ToList();
            _soldiers2 = _soldiers2.Union(soldiers).ToList();
        }

        class Soldier
        {
            public Soldier(string name, string title)
            {
                Name = name;
                Title = title;
            }

            public string Name { get; private set; }
            public string Title { get; private set; }
        }
    }
}
