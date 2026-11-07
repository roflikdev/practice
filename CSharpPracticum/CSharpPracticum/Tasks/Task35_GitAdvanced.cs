using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 35.</summary>
    public class Task35_GitAdvanced : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 35. Git: PR и rebase";
        /// <summary>Описание задания.</summary>
        public string Description => "Выполнить Git-сценарий второго уровня.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { ".gitignore и .editorconfig отдельным коммитом.", "Ветка feature/task-35 и PR в main.", "Ветка feature/rebase-demo и squash трех коммитов.", "Сохранить вывод команд в git-notes.md." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("Git-действия выполняются в репозитории.");
            Console.WriteLine("git switch -c feature/task-35");
            Console.WriteLine("git add .");
            Console.WriteLine("git commit -m \"feat: task 35 - git workflow\"");
            Console.WriteLine("git push -u origin feature/task-35");
            Console.WriteLine("После PR: git switch -c feature/rebase-demo");
            Console.WriteLine("git rebase -i HEAD~3");
            Console.WriteLine("git log --oneline");
            Console.WriteLine("Результаты сохранены в git-notes.md.");
            ConsoleHelper.ShowReadyTask();
        }
    }
}
