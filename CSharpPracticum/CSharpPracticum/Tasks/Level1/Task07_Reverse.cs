using System;
using System.Collections.Generic;
using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>
    /// Уровень 1. Задание 7.
    /// </summary>
    public class Task07_Reverse : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 7. Реверс строки";
        /// <summary>Описание задания.</summary>
        public string Description => "Перевернуть строку циклом.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Без LINQ и Array.Reverse.", "Цикл for с конца строки.", "Учитывать пустую строку." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("Введите строку:");
            string text = Console.ReadLine() ?? "";
            string reversed = "";
            for (int i = text.Length - 1; i >= 0; i--)
            {
                reversed += text[i];
            }
            Console.WriteLine("Результат: " + reversed);
            ConsoleHelper.ShowReadyTask();
        }
    }
}
