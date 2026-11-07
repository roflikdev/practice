using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 21.</summary>
    public class Task21_Days : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 21. Перечисление дней недели";
        /// <summary>Описание задания.</summary>
        public string Description => "Определить название и тип каждого дня.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "enum DayOfWeek с семью днями.", "IsWeekend и GetRussianName.", "Показать все дни." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
                Console.WriteLine(GetRussianName(day) + " - " + (IsWeekend(day) ? "выходной" : "будний"));
            ConsoleHelper.ShowReadyTask();
        }

        /// <summary>Дни недели.</summary>
        public enum DayOfWeek { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
        
        /// <summary>Проверяет выходной день.</summary>
        public static bool IsWeekend(DayOfWeek day)
        {
            return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
        }
        
        /// <summary>Возвращает название дня.</summary>
        public static string GetRussianName(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday: return "Понедельник";
                case DayOfWeek.Tuesday: return "Вторник";
                case DayOfWeek.Wednesday: return "Среда";
                case DayOfWeek.Thursday: return "Четверг";
                case DayOfWeek.Friday: return "Пятница";
                case DayOfWeek.Saturday: return "Суббота";
                case DayOfWeek.Sunday: return "Воскресенье";
                default: return "Неизвестный день";
            }
        }
    }
}
