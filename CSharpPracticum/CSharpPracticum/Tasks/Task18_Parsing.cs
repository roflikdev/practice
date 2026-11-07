using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 18.</summary>
    public class Task18_Parsing : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 18. TryParse и try/catch";
        /// <summary>Описание задания.</summary>
        public string Description => "Сравнить два способа разбора числа.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "int.TryParse с out и bool.", "int.Parse в try/catch.", "Примеры 123 и abc." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            string[] values = { "123", "abc" };
            foreach (string text in values)
            {
                bool first = ParseWithTryParse(text, out int a);
                bool second = ParseWithCatch(text, out int b);
                Console.WriteLine(text + ": TryParse = " + first + " (" + a + "), try/catch = " + second + " (" + b + ")");
            }
            ConsoleHelper.ShowReadyTask();
        }

        private bool ParseWithTryParse(string text, out int number)
        {
            return int.TryParse(text, out number);
        }
        
        private bool ParseWithCatch(string text, out int number)
        {
            try
            {
                number = int.Parse(text);
                return true;
            }
            catch (FormatException)
            {
                number = 0;
                return false;
            }
            catch (OverflowException)
            {
                number = 0;
                return false;
            }
        }
    }
}
