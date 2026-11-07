using System;
using CSharpPracticum.Common;
namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 1. Задание 1.</summary>
    public class Task01_HelloWorld : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 1. Hello, World + текущая дата";
        /// <summary>Описание задания.</summary>
        public string Description => "Вывести приветствие и текущую дату.";
        /// <summary>Требования.</summary>
        public string[] Requirements => new string[] { "Console.WriteLine", "Дата через DateTime.Now в формате dd.MM.yyyy.", "Две строки вывода." };
        /// <summary>Запуск.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("Hello, World!");
            Console.WriteLine(DateTime.Now.ToString("dd.MM.yyyy"));
            ConsoleHelper.ShowReadyTask();
        }
    }
}
