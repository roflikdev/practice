using System;
using System.Collections.Generic;
using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>
    /// Уровень 1. Задание 9.
    /// </summary>
    public class Task09_ArrayStats : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 9. Массив: минимум, максимум, сумма, среднее";
        /// <summary>Описание задания.</summary>
        public string Description => "Найти основные значения массива.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Без LINQ.", "Четыре отдельных метода.", "Пустой массив не вызывает ошибку." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            int[] numbers = new int[20];
            Random random = new Random();
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = random.Next(1, 101);
            
            Console.WriteLine("Массив: " + string.Join(", ", numbers));
            Console.WriteLine("Минимум: " + Min(numbers));
            Console.WriteLine("Максимум: " + Max(numbers));
            Console.WriteLine("Сумма: " + Sum(numbers));
            Console.WriteLine("Среднее: " + Average(numbers));
            ConsoleHelper.ShowReadyTask();
        }

        private int Min(int[] numbers)
        {
            if (numbers.Length == 0) return 0;
            int min = numbers[0];
            foreach (int n in numbers)
                if (n < min) min = n;
            return min;
        }
        
        private int Max(int[] numbers)
        {
            if (numbers.Length == 0) return 0;
            int max = numbers[0];
            foreach (int n in numbers)
                if (n > max) max = n;
            return max;
        }
        
        private int Sum(int[] numbers)
        {
            int sum = 0;
            foreach (int n in numbers) sum += n;
            return sum;
        }
        
        private double Average(int[] numbers)
        {
            if (numbers.Length == 0) return 0;
            return (double)Sum(numbers) / numbers.Length;
        }
    }
}
