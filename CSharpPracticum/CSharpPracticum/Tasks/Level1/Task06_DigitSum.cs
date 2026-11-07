using System;
using System.Collections.Generic;
using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>
    /// Уровень 1. Задание 6.
    /// </summary>
    public class Task06_DigitSum : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 6. Сумма цифр числа";
        /// <summary>Описание задания.</summary>
        public string Description => "Найти сумму цифр строкой и арифметикой.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Два отдельных метода: через строку и через while.", "Отрицательные числа брать по модулю.", "Проверить минимум 3 числа." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("Введите целое число:");
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Неверное число.");
            }
            else
            {
                int[] numbers = { number, -123, 405, 0 };
                foreach (int n in numbers)
                {
                    Console.WriteLine(n + ": строкой = " + SumString(n) + ", арифметикой = " + SumMath(n));
                }
            }
            ConsoleHelper.ShowReadyTask();
        }

        private int SumString(int number)
        {
            string text = Math.Abs((long)number).ToString();
            int sum = 0;
            foreach (char digit in text)
            {
                sum += int.Parse(digit.ToString());
            }
            return sum;
        }
        
        private int SumMath(int number)
        {
            long n = Math.Abs((long)number);
            int sum = 0;
            while (n > 0)
            {
                sum += (int)(n % 10);
                n /= 10;
            }
            return sum;
        }
    }
}
