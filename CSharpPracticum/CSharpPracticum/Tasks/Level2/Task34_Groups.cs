using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 34.</summary>
    public class Task34_Groups : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 34. LINQ: группы слов";
        /// <summary>Описание задания.</summary>
        public string Description => "Сгруппировать слова по первой букве.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "10+ слов.", "GroupBy по первому символу.", "Сортировка групп и слов внутри." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            List<string> words = new List<string>
            {
                "арбуз", "апельсин", "ананас",
                "банан", "береза", "бабочка",
                "вишня", "волк", "ворона",
                "груша", "гриб", "город"
            };
            var groups = words.GroupBy(w => w[0]).OrderBy(g => g.Key);
            foreach (var group in groups)
                Console.WriteLine(group.Key + ": " + string.Join(", ", group.OrderBy(w => w)));
            ConsoleHelper.ShowReadyTask();
        }
    }
}
