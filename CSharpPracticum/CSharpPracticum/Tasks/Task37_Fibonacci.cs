using System;
using System.Collections.Generic;
using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 3. Задание 37.</summary>
    public class Task37_Fibonacci : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 37. Фибоначчи и Dictionary";
        /// <summary>Описание задания.</summary>
        public string Description => "Сравнить обычную рекурсию и рекурсию с запоминанием результатов.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Обычная рекурсия.", "Dictionary<int, long> для запоминания.", "Stopwatch для N = 35." };

        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            int n = 35;
            Stopwatch timer = Stopwatch.StartNew();
            long first = Fibonacci(n);
            timer.Stop();
            double firstTime = timer.Elapsed.TotalMilliseconds;

            Dictionary<int, long> memory = new Dictionary<int, long>();
            timer.Restart();
            long second = FibonacciWithMemory(n, memory);
            timer.Stop();
            double secondTime = timer.Elapsed.TotalMilliseconds;

            Console.WriteLine("Фибоначчи(" + n + "): " + first);
            Console.WriteLine("С запоминанием: " + second);
            Console.WriteLine("Обычная рекурсия: " + firstTime.ToString("F3") + " мс");
            Console.WriteLine("С Dictionary: " + secondTime.ToString("F3") + " мс");
            Console.WriteLine("Разница: " + (firstTime - secondTime).ToString("F3") + " мс");
            Console.WriteLine("Результаты совпадают: " + (first == second));
            ConsoleHelper.ShowReadyTask();
        }

        private long Fibonacci(int n)
        {
            if (n <= 1) return n;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        private long FibonacciWithMemory(int n, Dictionary<int, long> memory)
        {
            if (n <= 1) return n;
            if (memory.ContainsKey(n)) return memory[n];

            long result = FibonacciWithMemory(n - 1, memory) + FibonacciWithMemory(n - 2, memory);
            memory[n] = result;
            return result;
        }
    }
}
