using System;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 3. Задание 49.</summary>
    public class Task49_GitReflog : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 49. Git reflog";
        /// <summary>Описание задания.</summary>
        public string Description => "Вернуть удалённый коммит через reflog.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Сделать учебный коммит.", "reset --hard HEAD~1.", "Найти SHA в reflog и восстановить." };

        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("Пример для отдельной учебной ветки:");
            Console.WriteLine("git reset --hard HEAD~1");
            Console.WriteLine("git reflog");
            Console.WriteLine("git reset --hard <хеш коммита>");
            Console.WriteLine("git log --oneline");
            Console.WriteLine("Результат записан в git-notes.md.");
            ConsoleHelper.ShowReadyTask();
        }
    }
}
