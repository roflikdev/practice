using System;
using System.Collections.Generic;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 3. Задание 39.</summary>
    public class Task39_EvenGenerator : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 39. Генератор чётных чисел";
        /// <summary>Описание задания.</summary>
        public string Description => "Получать чётные числа с помощью yield return.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Метод IEnumerable<int>.", "Использовать yield return.", "Показать выполнение в foreach." };

        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            IEnumerable<int> numbers = GetEvenNumbers(10);
            Console.WriteLine("Генератор создан, но ещё ничего не вывел.");
            foreach (int number in numbers)
                Console.WriteLine("Получено число: " + number);
            ConsoleHelper.ShowReadyTask();
        }

        private IEnumerable<int> GetEvenNumbers(int max)
        {
            for (int i = 0; i <= max; i += 2)
            {
                Console.WriteLine("Генератор выдаёт: " + i);
                yield return i;
            }
        }
    }
}
