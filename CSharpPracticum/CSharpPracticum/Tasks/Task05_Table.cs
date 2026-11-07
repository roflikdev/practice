using System;
using System.Collections.Generic;
using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>
    /// Уровень 1. Задание 5.
    /// </summary>
    public class Task05_Table : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 5. Таблица умножения 10x10";
        /// <summary>Описание задания.</summary>
        public string Description => "Вывести таблицу умножения 10 на 10.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Вложенные циклы for.", "Ровные столбцы и все 100 результатов." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write($"{i * j,5}");
                }
                Console.WriteLine();
            }
            ConsoleHelper.ShowReadyTask();
        }
    }
}
