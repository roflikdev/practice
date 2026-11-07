using System;
using System.Collections.Generic;
using System.Linq;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 1. Задание 13.</summary>
    public class Task13_Words : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 13. Счетчик слов";
        /// <summary>Описание задания.</summary>
        public string Description => "Посчитать количество повторений каждого слова.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Dictionary<string, int>.", "Разбивать по знакам и пробелам.", "Вывести по убыванию количества." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("Введите текст:");
            string text = (Console.ReadLine() ?? "").ToLowerInvariant();
            Dictionary<string, int> counts = new Dictionary<string, int>();
            string word = "";
            foreach (char c in text + " ")
            {
                if (char.IsLetterOrDigit(c))
                    word += c;
                else if (word.Length > 0)
                {
                    if (counts.ContainsKey(word))
                        counts[word]++;
                    else
                        counts[word] = 1;
                    word = "";
                }
            }
            List<KeyValuePair<string, int>> sorted = new List<KeyValuePair<string, int>>(counts);
            sorted.Sort((a, b) => b.Value.CompareTo(a.Value));
            foreach (var item in sorted)
                Console.WriteLine(item.Key + " - " + item.Value);
            ConsoleHelper.ShowReadyTask();
        }
    }
}
