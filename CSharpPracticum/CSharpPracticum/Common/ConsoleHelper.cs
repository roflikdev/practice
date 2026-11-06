using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticum.Common
{
    /// <summary>
    /// Вспомогательные функции для работы с консолью.
    /// </summary>
    public class ConsoleHelper
    {
        /// <summary>
        /// Очищает консоль и выводит заголовок.
        /// </summary>
        /// <param name="title">Заголовок.</param>
        /// <param name="isMain">Включает оформление главного меню.</param>
        public static void ShowHeader(string title, bool isMain = false)
        {
            Console.Clear();
            if (isMain)
            {
                Console.WriteLine($"=== {title} ===");
            } else
            {
                Console.WriteLine($"--- {title} ---");
            }
        }
        /// <summary>
        /// Вывести информацию задания.
        /// </summary>
        /// <param name="title">Заголовок.</param>
        /// <param name="description">Описание.</param>
        /// <param name="requirements">Требования.</param>
        public static void ShowTaskInfo(string title, string description, string[] requirements)
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine(title);
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Описание: {description}");
            Console.WriteLine("Требования:");
            Console.WriteLine("- " + string.Join("\n - ", requirements));
            Console.WriteLine();
        }

        /// <summary>
        /// Вывести информацию о конце исполнения задания.
        /// </summary>
        public static void ShowReadyTask()
        {
            Console.WriteLine();
            Console.WriteLine("Нажмите Enter для возврата в меню...");
            Console.ReadLine();
        }
    }
}
