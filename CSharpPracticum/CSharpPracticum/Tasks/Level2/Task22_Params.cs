using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 22.</summary>
    public class Task22_Params : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 22. params и перегрузка Sum";
        /// <summary>Описание задания.</summary>
        public string Description => "Посчитать сумму произвольных чисел.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Sum(params int[] numbers).", "Перегрузка для IEnumerable<int> вместо совпадающей сигнатуры int[].", "Sum(1,2,3), Sum(new[] {...}), Sum()." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("Список чисел: " + Sum(1, 2, 3));
            Console.WriteLine("Массив: " + Sum(new[] { 1, 2, 3 }));
            Console.WriteLine("Без аргументов: " + Sum());
            Console.WriteLine("Через IEnumerable: " + Sum((IEnumerable<int>)new[] { 1, 2, 3 }));
            ConsoleHelper.ShowReadyTask();
        }

        /// <summary>Сумма произвольного числа аргументов.</summary>
        public static int Sum(params int[] numbers)
        {
            int sum = 0;
            foreach (int n in numbers) sum += n;
            return sum;
        }
        
        // Обычный int[] нельзя перегрузить вместе с params int[].
            
        /// <summary>Сумма значений из коллекции.</summary>
        public static int Sum(IEnumerable<int> numbers)
        {
            int sum = 0;
            foreach (int n in numbers) sum += n;
            return sum;
        }
    }
}
