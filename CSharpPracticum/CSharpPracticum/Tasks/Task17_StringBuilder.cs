using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 17.</summary>
    public class Task17_StringBuilder : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 17. StringBuilder и сложение строк";
        /// <summary>Описание задания.</summary>
        public string Description => "Сравнить время построения одной строки двумя способами.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "10000 чисел.", "Stopwatch для обоих способов.", "Одинаковый результат и разница во времени." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Stopwatch watch = Stopwatch.StartNew();
            string text = "";
            for (int i = 0; i < 10000; i++)
                text += i.ToString();
            watch.Stop();
            long firstTime = watch.ElapsedMilliseconds;
            
            watch.Restart();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 10000; i++)
                builder.Append(i);
            string secondText = builder.ToString();
            watch.Stop();
            long secondTime = watch.ElapsedMilliseconds;
            
            // StringBuilder меняет один буфер, а при + создаются новые строки.
            Console.WriteLine("Через +: " + firstTime + " мс");
            Console.WriteLine("StringBuilder: " + secondTime + " мс");
            Console.WriteLine("Разница: " + (firstTime - secondTime) + " мс");
            Console.WriteLine("Строки равны: " + (text == secondText));
            ConsoleHelper.ShowReadyTask();
        }
    }
}
