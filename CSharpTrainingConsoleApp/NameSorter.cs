using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTrainingConsoleApp
{
    public class NameSorter
    {
        public List<string> Names { get; set; }

        // Событие — вызывает сортировку
        public event Action<int> OnSort;

        public NameSorter()
        {
            Names = new List<string>()
            {
                "Кузнецов",
                "Иванов",
                "Петров",
                "Сидоров",
                "Алексеев"
            };
        }

        public void StartSort(int option)
        {
            OnSort?.Invoke(option);
        }

        public void SortAscending(int option)
        {
            if (option == 1)
            {
                Names = Names.OrderBy(x => x).ToList();
                Console.WriteLine("Отсортировано А–Я:");
                PrintNames();
            }
        }

        public void SortDescending(int option)
        {
            if (option == 2)
            {
                Names = Names.OrderByDescending(x => x).ToList();
                Console.WriteLine("Отсортировано Я–А:");
                PrintNames();
            }
        }

        private void PrintNames()
        {
            foreach (var n in Names)
                Console.WriteLine(n);
        }
    }
}

