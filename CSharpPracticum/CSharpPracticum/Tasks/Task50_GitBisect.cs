using System;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 3. Задание 50.</summary>
    public class Task50_GitBisect : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 50. Git bisect";
        /// <summary>Описание задания.</summary>
        public string Description => "Найти коммит, который сломал функцию.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "10+ учебных коммитов.", "git bisect good и bad.", "Найти ошибку и сделать bisect reset." };

        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("git bisect start");
            Console.WriteLine("git bisect bad");
            Console.WriteLine("git bisect good <хеш первого рабочего коммита>");
            Console.WriteLine("Дальше проверять каждый коммит и вводить git bisect good или bad.");
            Console.WriteLine("git bisect reset");
            Console.WriteLine("Найденный коммит записан в git-notes.md.");
            ConsoleHelper.ShowReadyTask();
        }
    }
}
