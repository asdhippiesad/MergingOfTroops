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

            MoveSoldiersToAnotherDivision(_soldiers1,_soldiers2);

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

            if (_soldiers2.Any())
            {
                foreach (var soldier in soldiers)
                {
                    Console.WriteLine($"{soldiersNumber}: {soldier.Name}, {soldier.Title}");
                    soldiersNumber++;
                }
            }
        }

        private void MoveSoldiersToAnotherDivision(List<Soldier> soldiers1, List<Soldier> soldiers2)
        {
            string startWithB = "Б";

            var soldiers = soldiers1.Where(soldier => soldier.Name.StartsWith(startWithB)).ToList();
            soldiers1.RemoveAll(soldier => soldier.Name.Contains(startWithB));
            soldiers2.AddRange(soldiers);
        }
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
