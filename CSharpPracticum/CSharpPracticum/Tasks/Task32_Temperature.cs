using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 32.</summary>
    public class Task32_Temperature : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 32. Свойства с проверкой";
        /// <summary>Описание задания.</summary>
        public string Description => "Проверить температуру и перевод в Фаренгейты.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Celsius не ниже -273.15.", "При ошибке ArgumentOutOfRangeException.", "Fahrenheit только для чтения." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Temperature temperature = new Temperature();
            temperature.Celsius = 25;
            Console.WriteLine("Цельсий: " + temperature.Celsius);
            Console.WriteLine("Фаренгейт: " + temperature.Fahrenheit);
            try
            {
                temperature.Celsius = -300;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Температура ниже абсолютного нуля!");
            }
            ConsoleHelper.ShowReadyTask();
        }

        /// <summary>Температура в градусах.</summary>
        public class Temperature
        {
            private double celsius;
            /// <summary>Температура по Цельсию.</summary>
            public double Celsius
            {
                get { return celsius; }
                set
                {
                    if (value < -273.15 || double.IsNaN(value))
                        throw new ArgumentOutOfRangeException(nameof(value));
                    celsius = value;
                }
            }
            /// <summary>Температура по Фаренгейту.</summary>
            public double Fahrenheit => Celsius * 9 / 5 + 32;
        }
    }
}
