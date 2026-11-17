using System;
using System.Collections.Generic;
using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 3. Задание 38.</summary>
    public class Task38_ListCompare : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 38. List и LinkedList";
        /// <summary>Описание задания.</summary>
        public string Description => "Сравнить вставку элементов в середину двух коллекций.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "По 100000 элементов.", "1000 вставок в середину.", "Замерить время через Stopwatch." };

        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();
            for (int i = 0; i < 100000; i++)
            {
                list.Add(i);
                linkedList.AddLast(i);
            }

            // В LinkedList сначала находим середину, потом вставляем перед этим узлом.
            LinkedListNode<int> middle = linkedList.First;
            for (int i = 0; i < 50000; i++)
                middle = middle.Next;

            Stopwatch timer = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
                list.Insert(list.Count / 2, -1);
            timer.Stop();
            double listTime = timer.Elapsed.TotalMilliseconds;

            timer.Restart();
            for (int i = 0; i < 1000; i++)
                linkedList.AddBefore(middle, -1);
            timer.Stop();

            Console.WriteLine("List: " + listTime.ToString("F3") + " мс");
            Console.WriteLine("LinkedList: " + timer.Elapsed.TotalMilliseconds.ToString("F3") + " мс");
            Console.WriteLine("Элементов: " + list.Count + " и " + linkedList.Count);
            // LinkedList быстрее вставляет по готовому узлу, но искать узел в нём дольше.
            Console.WriteLine("В List при вставке сдвигаются элементы, а в LinkedList меняются ссылки.");
            Console.WriteLine("Зато в LinkedList нельзя быстро получить элемент по индексу.");
            ConsoleHelper.ShowReadyTask();
        }
    }
}
