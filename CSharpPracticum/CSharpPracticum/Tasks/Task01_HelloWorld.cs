using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticum.Tasks
{
    /// <summary>
    /// 1 Уровень 1 Задание.
    /// </summary>
    public class Task01_HelloWorld : ITask
    {
        public string Title => "Задание 1: Hello, World + текущая дата";
        public string Description => "Вывести приветствие и текущую дату.";
        public string[] Requirements => new string[] { "Использовать Console.WriteLine.", "Дату получить через DateTime.Now, отформатировать как dd.MM.yyyy.", "Вывести две строки: приветствие и дату." };

        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            DateTime now = DateTime.Now;
            Console.WriteLine($"Hello, World {now.Day}.{now.Month}.{now.Year}");
            ConsoleHelper.ShowReadyTask();
        }
    }
}
