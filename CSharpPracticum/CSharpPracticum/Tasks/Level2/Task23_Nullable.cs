using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 23.</summary>
    public class Task23_Nullable : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 23. Nullable, ?? и ?.";
        /// <summary>Описание задания.</summary>
        public string Description => "Безопасно работать с отсутствующими значениями.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "FindValue возвращает int?.", "Использовать ?? и ?..", "HasValue и Value с проверкой." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            string[] keys = { "apple", "unknown" };
            foreach (string key in keys)
            {
                int? result = FindValue(key);
                Console.WriteLine(key + ": " + (result ?? 0));
                if (result.HasValue)
                    Console.WriteLine("Найдено: " + result.Value);
                else
                    Console.WriteLine("Ключ не найден.");
            }
            
            string text = null;
            Console.WriteLine("Длина пустой ссылки: " + (text?.Length ?? 0));
            ConsoleHelper.ShowReadyTask();
        }

        private int? FindValue(string key)
        {
            Dictionary<string, int> values = new Dictionary<string, int>();
            values["apple"] = 10;
            values["orange"] = 20;
            if (values.TryGetValue(key, out int number)) return number;
            return null;
        }
    }
}
