using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 16.</summary>
    public class Task16_Extensions : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 16. Методы расширения string";
        /// <summary>Описание задания.</summary>
        public string Description => "Создать три метода расширения строк.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "StringExtensions.", "IsPalindrome, WordCount, ReverseString.", "Показать на 2-3 строках." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            string[] texts = { "А роза упала на лапу Азора", "Привет, мир!", "abc" };
            foreach (string text in texts)
            {
                Console.WriteLine("Строка: " + text);
                Console.WriteLine("Палиндром: " + text.IsPalindrome());
                Console.WriteLine("Слов: " + text.WordCount());
                Console.WriteLine("Наоборот: " + text.ReverseString());
            }
            ConsoleHelper.ShowReadyTask();
        }
    }
}
