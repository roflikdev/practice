using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticum.Tasks
{
    public class Task04_Even : ITask
    {
        public string Title => "Задание 4. Чётность числа (два способа).";
        public string Description => "определить, чётное ли введённое число.";
        public string[] Requirements => new string[] { "Способ 1: через % 2 == 0.", "Способ 2: через тернарный оператор ? :.", "Оба способа реализовать отдельными методами.", "Вывести результат обоих способов." };

        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("Введите число: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Способ 1: число " + (Method1(a) ? "четное" : "нечетное"));
            Console.WriteLine("Способ 2: число " + (Method2(a) ? "четное" : "нечетное"));
            ConsoleHelper.ShowReadyTask();

        }

        private bool Method1(int nubmer)
        {
            if (nubmer % 2 == 0)
            {
                return true;
            }

            return false;
        }

        private bool Method2(int nubmer)
        {
            return nubmer % 2 == 0 ? true : false;
        }
    }
}
