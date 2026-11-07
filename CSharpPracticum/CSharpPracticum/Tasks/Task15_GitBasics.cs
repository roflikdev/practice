using System;
using System.Collections.Generic;
using System.Linq;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 1. Задание 15.</summary>
    public class Task15_GitBasics : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 15. Git: ветка и merge";
        /// <summary>Описание задания.</summary>
        public string Description => "Создать ветку, объединить изменения и разобрать конфликт.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "git init и несколько коммитов.", "feature/git-basics и merge.", "Разрешение конфликта README.md.", "Запись истории в git-notes.md." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("Практика Git выполняется в репозитории.");
            Console.WriteLine("git init");
            Console.WriteLine("git switch -c feature/git-basics");
            Console.WriteLine("git add .");
            Console.WriteLine("git commit -m \"feat: task 15 - git basics\"");
            Console.WriteLine("git switch main");
            Console.WriteLine("git merge feature/git-basics");
            Console.WriteLine("git log --graph --oneline --all");
            Console.WriteLine("История записывается в git-notes.md.");
            ConsoleHelper.ShowReadyTask();
        }
    }
}
