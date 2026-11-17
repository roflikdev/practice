using System;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 3. Задание 43.</summary>
    public class Task43_Exceptions : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 43. Виды исключений";
        /// <summary>Описание задания.</summary>
        public string Description => "Поймать разные ошибки и выполнить finally.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "FormatException.", "DivideByZeroException.", "Свой CustomException и finally." };

        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine("Случай " + i + ":");
                try
                {
                    CheckError(i);
                }
                // Сначала ловим конкретные ошибки, а общий Exception ставим в конце.
                catch (FormatException ex)
                {
                    Console.WriteLine("Ошибка формата: " + ex.Message);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Деление на ноль: " + ex.Message);
                }
                catch (CustomException ex)
                {
                    Console.WriteLine("Своя ошибка: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Другая ошибка: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Завершено");
                }
            }
            ConsoleHelper.ShowReadyTask();
        }

        private void CheckError(int number)
        {
            if (number == 1)
                int.Parse("не число");
            else if (number == 2)
            {
                int zero = 0;
                Console.WriteLine(10 / zero);
            }
            else
                throw new CustomException("Пример своего исключения.");
        }

        /// <summary>Своё исключение.</summary>
        public class CustomException : Exception
        {
            /// <summary>Создаёт исключение с сообщением.</summary>
            public CustomException(string message) : base(message) { }
        }
    }
}
