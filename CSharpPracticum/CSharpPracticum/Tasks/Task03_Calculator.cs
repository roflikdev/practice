using System;
using CSharpPracticum.Common;
namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 1. Задание 3.</summary>
    public class Task03_Calculator : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 3. Калькулятор с обработкой деления на ноль";
        /// <summary>Описание задания.</summary>
        public string Description => "Принять два числа и оператор, вывести результат.";
        /// <summary>Требования.</summary>
        public string[] Requirements => new string[] { "Операции через switch.", "Проверить деление на ноль.", "Неизвестная операция.", "Ввод чисел через TryParse." };
        /// <summary>Запуск.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("Введите первое число:");
            bool first = double.TryParse(Console.ReadLine(), out double a);
            Console.WriteLine("Введите второе число:");
            bool second = double.TryParse(Console.ReadLine(), out double b);
            if (!first || !second)
            {
                Console.WriteLine("Неверное число.");
                ConsoleHelper.ShowReadyTask();
                return;
            }
            Console.WriteLine("Введите оператор (+, -, *, /):");
            string o = Console.ReadLine();
            switch (o)
            {
                case "+":
                    Console.WriteLine("Результат: " + (a + b));
                    break;
                case "-":
                    Console.WriteLine("Результат: " + (a - b));
                    break;
                case "*":
                    Console.WriteLine("Результат: " + (a * b));
                    break;
                case "/":
                    if (b != 0)
                        Console.WriteLine("Результат: " + (a / b));
                    else
                        Console.WriteLine("Ошибка: нельзя делить на 0.");
                    break;
                default:
                    Console.WriteLine("Неизвестная операция");
                    break;
            }
            ConsoleHelper.ShowReadyTask();
        }
    }
}
