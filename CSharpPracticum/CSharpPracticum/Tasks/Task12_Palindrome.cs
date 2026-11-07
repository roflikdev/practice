using System;
using System.Collections.Generic;
using System.Linq;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 1. Задание 12.</summary>
    public class Task12_Palindrome : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 12. Палиндром";
        /// <summary>Описание задания.</summary>
        public string Description => "Проверить строку без учета регистра и знаков.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Не учитывать пробелы, пунктуацию и регистр.", "Не использовать LINQ Reverse.", "Пустая строка считается палиндромом." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("Введите строку:");
            string text = (Console.ReadLine() ?? "").ToLowerInvariant();
            string clean = "";
            foreach (char c in text)
                if (char.IsLetterOrDigit(c)) clean += c;
            
            bool palindrome = true;
            for (int i = 0; i < clean.Length / 2; i++)
                if (clean[i] != clean[clean.Length - 1 - i]) palindrome = false;
            
            Console.WriteLine(palindrome ? "Палиндром" : "Не палиндром");
            ConsoleHelper.ShowReadyTask();
        }
    }
}
