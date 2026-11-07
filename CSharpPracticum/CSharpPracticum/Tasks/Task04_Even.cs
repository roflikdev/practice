using System;
using CSharpPracticum.Common;
namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 1. Задание 4.</summary>
    public class Task04_Even : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 4. Чётность числа (два способа)";
        /// <summary>Описание задания.</summary>
        public string Description => "Определить четность введенного числа.";
        /// <summary>Требования.</summary>
        public string[] Requirements => new string[] { "Способ 1 через % 2 == 0.", "Способ 2 через ? :.", "Отдельные методы и оба результата." };
        /// <summary>Запуск.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("Введите число:");
            if (int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Способ 1: число " + (Method1(a) ? "четное" : "нечетное"));
                Console.WriteLine("Способ 2: число " + (Method2(a) ? "четное" : "нечетное"));
            }
            else
                Console.WriteLine("Неверное число.");
            ConsoleHelper.ShowReadyTask();
        }
        private bool Method1(int number)
        {
            if (number % 2 == 0) return true;
            return false;
        }
        private bool Method2(int number)
        {
            return number % 2 == 0 ? true : false;
        }
    }
}
