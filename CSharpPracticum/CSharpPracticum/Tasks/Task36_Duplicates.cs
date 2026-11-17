using System;
using System.Collections.Generic;
using System.Linq;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 3. Задание 36.</summary>
    public class Task36_Duplicates : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 36. Дубликаты в списке";
        /// <summary>Описание задания.</summary>
        public string Description => "Найти повторяющиеся числа двумя способами.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "HashSet с Contains.", "LINQ GroupBy и Where.", "Два отдельных метода." };

        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            List<int> numbers = new List<int> { 1, 2, 3, 2, 4, 5, 3, 6, 2, 7, 5 };
            List<int> first = FindWithHashSet(numbers);
            List<int> second = FindWithGroupBy(numbers);

            Console.WriteLine("Список: " + string.Join(", ", numbers));
            Console.WriteLine("HashSet: " + string.Join(", ", first));
            Console.WriteLine("GroupBy: " + string.Join(", ", second));
            Console.WriteLine("Результаты совпадают: " + first.SequenceEqual(second));
            ConsoleHelper.ShowReadyTask();
        }

        private List<int> FindWithHashSet(List<int> numbers)
        {
            HashSet<int> used = new HashSet<int>();
            HashSet<int> duplicates = new HashSet<int>();
            foreach (int number in numbers)
            {
                if (used.Contains(number))
                    duplicates.Add(number);
                else
                    used.Add(number);
            }
            return duplicates.OrderBy(x => x).ToList();
        }

        private List<int> FindWithGroupBy(List<int> numbers)
        {
            return numbers.GroupBy(x => x)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key)
                .OrderBy(x => x).ToList();
        }
    }
}
