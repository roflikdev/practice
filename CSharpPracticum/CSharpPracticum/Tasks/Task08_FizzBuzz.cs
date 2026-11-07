using System;
using System.Collections.Generic;
using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>
    /// Уровень 1. Задание 8.
    /// </summary>
    public class Task08_FizzBuzz : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 8. FizzBuzz 1-100";
        /// <summary>Описание задания.</summary>
        public string Description => "Вывести числа от 1 до 100 с заменами.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "15 - FizzBuzz.", "3 - Fizz, 5 - Buzz.", "Сначала проверять делимость на 15." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            for (int i = 1; i <= 100; i++)
            {
                if (i % 15 == 0)
                    Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0)
                    Console.WriteLine("Fizz");
                else if (i % 5 == 0)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(i);
            }
            ConsoleHelper.ShowReadyTask();
        }
    }
}
