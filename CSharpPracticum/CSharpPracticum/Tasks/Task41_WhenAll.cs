using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 3. Задание 41.</summary>
    public class Task41_WhenAll : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 41. Task.WhenAll";
        /// <summary>Описание задания.</summary>
        public string Description => "Сравнить последовательное и одновременное выполнение 10 задач.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "WorkAsync с задержкой 500 мс.", "10 задач по очереди.", "10 задач через Task.WhenAll и сравнение времени." };

        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            RunAsync().GetAwaiter().GetResult();
            ConsoleHelper.ShowReadyTask();
        }

        private async Task RunAsync()
        {
            Stopwatch timer = Stopwatch.StartNew();
            List<int> first = new List<int>();
            for (int i = 1; i <= 10; i++)
                first.Add(await WorkAsync(i));
            timer.Stop();
            double firstTime = timer.Elapsed.TotalMilliseconds;

            List<Task<int>> tasks = new List<Task<int>>();
            timer.Restart();
            for (int i = 1; i <= 10; i++)
                tasks.Add(WorkAsync(i));
            int[] second = await Task.WhenAll(tasks);
            timer.Stop();

            Console.WriteLine("По очереди: " + firstTime.ToString("F0") + " мс");
            Console.WriteLine("Одновременно: " + timer.Elapsed.TotalMilliseconds.ToString("F0") + " мс");
            Console.WriteLine("Результаты совпадают: " + first.SequenceEqual(second));
            Console.WriteLine("Одновременно быстрее, потому что задачи ждут вместе, а не друг за другом.");
        }

        private async Task<int> WorkAsync(int id)
        {
            await Task.Delay(500);
            return id;
        }
    }
}
