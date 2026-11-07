using System;
using System.Collections.Generic;
using System.Linq;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 1. Задание 14.</summary>
    public class Task14_Age : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 14. Возраст по дате рождения";
        /// <summary>Описание задания.</summary>
        public string Description => "Вычислить возраст в годах, месяцах и днях.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Использовать DateTime.TryParse.", "Учесть еще не наступивший день рождения.", "Ошибочный ввод не вызывает падение." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("Введите дату рождения:");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime birthday)
                || birthday.Date > DateTime.Today)
            {
                Console.WriteLine("Неверная дата.");
            }
            else
            {
                DateTime today = DateTime.Today;
                int years = today.Year - birthday.Year;
                if (birthday.AddYears(years) > today) years--;
                DateTime date = birthday.AddYears(years);
            
                int months = 0;
                while (date.AddMonths(1) <= today)
                {
                    date = date.AddMonths(1);
                    months++;
                }
                int days = (today - date).Days;
                Console.WriteLine(years + " лет, " + months + " месяцев, " + days + " дней");
            }
            ConsoleHelper.ShowReadyTask();
        }
    }
}
