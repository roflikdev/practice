using System;
using CSharpPracticum.Common;
using CSharpPracticum.Tasks;

namespace CSharpPracticum.Menu
{
    /// <summary>Меню выбора задания.</summary>
    public class LevelMenu
    {
        /// <summary>Показывает главное меню.</summary>
        public static int ShowLevels()
        {
            ConsoleHelper.ShowHeader("Практикум по C#", true);
            Console.WriteLine("1. Уровень 1 — Базовый (задания 1–15)");
            Console.WriteLine("2. Уровень 2 — Средний (задания 16–35)");
            Console.WriteLine("3. Уровень 3 — Продвинутый (задания 36–50)");
            Console.WriteLine("4. Выход");
            Console.WriteLine("\nВыберите уровень:");
            string input = Console.ReadLine();
            if (input == "q" || input == "0") return 4;
            return int.TryParse(input, out int number) ? number : -1;
        }

        /// <summary>Открывает первый уровень.</summary>
        public static void StartLevel1()
        {
            ITask[] tasks = new ITask[]
            {
                new Task01_HelloWorld(),
                new Task02_VariablesTypes(),
                new Task03_Calculator(),
                new Task04_Even(),
                new Task05_Table(),
                new Task06_DigitSum(),
                new Task07_Reverse(),
                new Task08_FizzBuzz(),
                new Task09_ArrayStats(),
                new Task10_Sorting(),
                new Task11_Matrix(),
                new Task12_Palindrome(),
                new Task13_Words(),
                new Task14_Age(),
                new Task15_GitBasics()
            };
            ShowTasks("Уровень 1: Базовый", tasks, 1);
        }

        /// <summary>Открывает второй уровень.</summary>
        public static void StartLevel2()
        {
            ConsoleHelper.ShowHeader("Уровень 2: Средний");
            Console.WriteLine("Задания добавляются.");
            Console.WriteLine("Нажмите Enter для возврата.");
            Console.ReadLine();
        }

        /// <summary>Открывает третий уровень.</summary>
        public static void StartLevel3()
        {
            ConsoleHelper.ShowHeader("Уровень 3: Продвинутый");
            Console.WriteLine("Задания 36–50 пока не сделаны.");
            Console.WriteLine("Нажмите Enter для возврата.");
            Console.ReadLine();
        }

        private static void ShowTasks(string title, ITask[] tasks, int firstNumber)
        {
            bool isWork = true;
            while (isWork)
            {
                ConsoleHelper.ShowHeader(title);
                for (int i = 0; i < tasks.Length; i++)
                    Console.WriteLine((firstNumber + i) + ". " + tasks[i].Title);
                Console.WriteLine("0. Назад");
                Console.WriteLine("\nВыберите задание:");
                string input = Console.ReadLine();
                if (input == "0" || input == "q")
                {
                    isWork = false;
                }
                else if (int.TryParse(input, out int number))
                {
                    int index = number - firstNumber;
                    if (index >= 0 && index < tasks.Length)
                        tasks[index].Run();
                    else
                    {
                        Console.WriteLine("Нет такого задания.");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
