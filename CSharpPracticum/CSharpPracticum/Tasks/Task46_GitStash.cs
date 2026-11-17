using System;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 3. Задание 46.</summary>
    public class Task46_GitStash : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 46. Git stash";
        /// <summary>Описание задания.</summary>
        public string Description => "Спрятать изменения и вернуть их обратно.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "git stash и stash list.", "Смена ветки.", "git stash pop и вывод в git-notes.md." };

        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("git stash");
            Console.WriteLine("git stash list");
            Console.WriteLine("git switch main");
            Console.WriteLine("git switch level-3");
            Console.WriteLine("git stash pop");
            Console.WriteLine("git stash list");
            Console.WriteLine("Вывод команд записан в git-notes.md.");
            ConsoleHelper.ShowReadyTask();
        }
    }
}
