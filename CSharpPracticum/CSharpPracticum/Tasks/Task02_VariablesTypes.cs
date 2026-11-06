using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticum.Tasks
{
    internal class Task02_VariablesTypes : ITask
    {
        public string Title => "Задание 2. Переменные примитивных типов";
        public string Description => "Объявить переменные всех примитивных типов и вывести их значения и типы.";
        public string[] Requirements => new string[] { "Объявить минимум: int, long, double, float, decimal, bool, char, string.", "Для каждой переменной вывести значение и GetType().Name.", "decimal — с суффиксом m, float — с f." };

        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            int a = 67;
            long b = 148867524213;
            double c = 3.14;
            float d = 12f;
            decimal v = 8m;
            bool isD = false;
            char k = 'a';
            string g = "hello";

            Console.WriteLine($"{a} - {a.GetType().Name}");
            Console.WriteLine($"{b} - {b.GetType().Name}");
            Console.WriteLine($"{c} - {c.GetType().Name}");
            Console.WriteLine($"{d}f - {d.GetType().Name}");
            Console.WriteLine($"{v}m - {v.GetType().Name}");
            Console.WriteLine($"{isD} - {isD.GetType().Name}");
            Console.WriteLine($"{k} - {k.GetType().Name}");
            Console.WriteLine($"{g} - {g.GetType().Name}");
            ConsoleHelper.ShowReadyTask();
        }
    }
}
