using System;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 3. Задание 48.</summary>
    public class Task48_GitTags : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 48. Git теги";
        /// <summary>Описание задания.</summary>
        public string Description => "Поставить аннотированный тег v1.0.0.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Тег на main.", "git push origin v1.0.0.", "git tag и git show в git-notes.md." };

        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("git switch main");
            Console.WriteLine("git tag -a v1.0.0 -m \"Release v1.0.0\"");
            Console.WriteLine("git push origin v1.0.0");
            Console.WriteLine("git tag");
            Console.WriteLine("git show v1.0.0");
            Console.WriteLine("Вывод команд записан в git-notes.md.");
            ConsoleHelper.ShowReadyTask();
        }
    }
}
