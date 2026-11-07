using System;
using CSharpPracticum.Common;
namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 1. Задание 2.</summary>
    public class Task02_VariablesTypes : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 2. Переменные примитивных типов";
        /// <summary>Описание задания.</summary>
        public string Description => "Объявить переменные разных типов и вывести их значения и типы.";
        /// <summary>Требования.</summary>
        public string[] Requirements => new string[] { "int, long, double, float, decimal, bool, char, string.", "Для каждого GetType().Name.", "Суффиксы f и m." };
        /// <summary>Запуск.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            int a = 67;
            long b = 148867524213L;
            double c = 3.14;
            float d = 12f;
            decimal v = 8m;
            bool isD = false;
            char k = 'a';
            string g = "hello";
            Console.WriteLine($"a = {a} ({a.GetType().Name})");
            Console.WriteLine($"b = {b} ({b.GetType().Name})");
            Console.WriteLine($"c = {c} ({c.GetType().Name})");
            Console.WriteLine($"d = {d} ({d.GetType().Name})");
            Console.WriteLine($"v = {v} ({v.GetType().Name})");
            Console.WriteLine($"isD = {isD} ({isD.GetType().Name})");
            Console.WriteLine($"k = {k} ({k.GetType().Name})");
            Console.WriteLine($"g = {g} ({g.GetType().Name})");
            ConsoleHelper.ShowReadyTask();
        }
    }
}
