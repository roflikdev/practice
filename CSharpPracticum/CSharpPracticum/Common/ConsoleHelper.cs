using System;

namespace CSharpPracticum.Common
{
    /// <summary>Работа с консолью.</summary>
    public class ConsoleHelper
    {
        /// <summary>Выводит заголовок меню.</summary>
        /// <param name="title">Заголовок.</param>
        /// <param name="isMain">Главное меню.</param>
        public static void ShowHeader(string title, bool isMain = false)
        {
            if (!Console.IsOutputRedirected) Console.Clear();
            Console.WriteLine(isMain ? "=== " + title + " ===" : "--- " + title + " ---");
        }

        /// <summary>Показывает описание и требования задания.</summary>
        /// <param name="title">Название.</param>
        /// <param name="description">Описание.</param>
        /// <param name="requirements">Требования.</param>
        public static void ShowTaskInfo(string title, string description, string[] requirements)
        {
            if (!Console.IsOutputRedirected) Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine(title);
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Описание: " + description);
            Console.WriteLine("Требования:");
            foreach (string requirement in requirements)
                Console.WriteLine(" - " + requirement);
            Console.WriteLine("Подсказка: используйте стандартные классы .NET и методы C#.");
            Console.WriteLine("--------------------------------------------------");
        }

        /// <summary>Возвращает в меню после задания.</summary>
        public static void ShowReadyTask()
        {
            Console.WriteLine();
            Console.WriteLine("Нажмите Enter для возврата в меню...");
            Console.ReadLine();
        }
    }
}
