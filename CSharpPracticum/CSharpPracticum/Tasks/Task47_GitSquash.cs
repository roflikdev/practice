using System;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 3. Задание 47.</summary>
    public class Task47_GitSquash : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 47. Git rebase -i";
        /// <summary>Описание задания.</summary>
        public string Description => "Объединить четыре коммита в один.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Ветка feature/squash-demo.", "4 маленьких коммита.", "rebase -i HEAD~4, вывод до и после." };

        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("git switch -c feature/squash-demo");
            Console.WriteLine("После четырёх коммитов:");
            Console.WriteLine("git log --oneline -4");
            Console.WriteLine("git rebase -i HEAD~4");
            Console.WriteLine("В редакторе оставить pick у первого, остальные заменить на squash.");
            Console.WriteLine("git log --oneline -4");
            Console.WriteLine("Вывод команд записан в git-notes.md.");
            ConsoleHelper.ShowReadyTask();
        }
    }
}
