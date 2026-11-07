using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 20.</summary>
    public class Task20_Generics : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 20. Обобщенные Swap и Max";
        /// <summary>Описание задания.</summary>
        public string Description => "Написать методы для разных типов.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Swap<T>(ref a, ref b) без ограничений.", "Max<T> с IComparable<T>.", "Проверить int, string, double." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            int a = 3, b = 8;
            Swap(ref a, ref b);
            Console.WriteLine("int: " + a + ", " + b + "; max = " + Max(a, b));
            
            string c = "кот", d = "пёс";
            Swap(ref c, ref d);
            Console.WriteLine("string: " + c + ", " + d + "; max = " + Max(c, d));
            
            double x = 1.5, y = 7.2;
            Swap(ref x, ref y);
            Console.WriteLine("double: " + x + ", " + y + "; max = " + Max(x, y));
            ConsoleHelper.ShowReadyTask();
        }

        /// <summary>Меняет два значения местами.</summary>
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        
        /// <summary>Возвращает большее значение.</summary>
        public static T Max<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) >= 0 ? a : b;
        }
    }
}
