using CSharpPracticum.Common;
using CSharpPracticum.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticum.Menu
{
    public class LevelMenu
    {
        /// <summary>
        /// Выводит список доступных уровней.
        /// </summary>
        public static int ShowLevels()
        {
            ConsoleHelper.ShowHeader("Практикум C#", true);
            Console.WriteLine("1. Уровень 1 — Базовый (задания 1–15)");
            Console.WriteLine("2. Выход");
            Console.WriteLine("\nВыберите уровень:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int level))
            {
                return level;
            } else
            {
                return -1;
            }
        }
        /// <summary>
        /// Выводит задания первого уровня.
        /// </summary>
        public static void StartLevel1()
        {
            bool isWork = true;
            while (isWork)
            {
                ConsoleHelper.ShowHeader("Уровень 1: Базовый");
                Console.WriteLine("1. Задание 1. Hello, World + текущая дата");
                Console.WriteLine("2. Задание 2. Переменные примитивных типов");
                Console.WriteLine("3. Назад");
                Console.WriteLine("\nВыберите задание:");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int level))
                {
                    switch (level)
                    {
                        case 1:
                            new Task01_HelloWorld().Run();
                            break;
                        case 2:
                            new Task02_VariablesTypes().Run();
                            break;
                        case 3:
                            isWork = false;
                            break;
                    }
                }

            }
        }
    }
}
