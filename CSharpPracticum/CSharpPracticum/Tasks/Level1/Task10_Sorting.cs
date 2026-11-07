using System;
using System.Collections.Generic;
using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>
    /// Уровень 1. Задание 10.
    /// </summary>
    public class Task10_Sorting : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 10. Сортировка пузырьком и вставками";
        /// <summary>Описание задания.</summary>
        public string Description => "Сравнить две сортировки массива.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "BubbleSort и InsertionSort без Array.Sort и LINQ.", "Массив из 10000 элементов.", "Время каждого алгоритма через Stopwatch." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            int[] first = new int[10000];
            Random random = new Random();
            for (int i = 0; i < first.Length; i++)
                first[i] = random.Next(0, 100000);
            int[] second = (int[])first.Clone();
            
            Stopwatch watch = Stopwatch.StartNew();
            BubbleSort(first);
            watch.Stop();
            Console.WriteLine("Пузырьком: " + watch.ElapsedMilliseconds + " мс");
            
            watch.Restart();
            InsertionSort(second);
            watch.Stop();
            Console.WriteLine("Вставками: " + watch.ElapsedMilliseconds + " мс");
            
            bool equal = true;
            for (int i = 0; i < first.Length; i++)
                if (first[i] != second[i]) equal = false;
            Console.WriteLine("Массивы совпадают: " + equal);
            ConsoleHelper.ShowReadyTask();
        }

        private void BubbleSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                bool changed = false;
                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                        changed = true;
                    }
                }
                if (!changed) break;
            }
        }
        
        private void InsertionSort(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                int value = numbers[i];
                int j = i - 1;
                while (j >= 0 && numbers[j] > value)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }
                numbers[j + 1] = value;
            }
        }
    }
}
