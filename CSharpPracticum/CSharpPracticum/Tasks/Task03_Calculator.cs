using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticum.Tasks
{
    public class Task03_Calculator: ITask
    {
        public string Title => "Задание 3. Калькулятор с обработкой деления на ноль";
        public string Description => "принимать два числа и оператор (+ - * /), выводить результат.";
        public string[] Requirements => new string[] { "Оператор обрабатывать через switch.", "При делении на ноль — вывести сообщение об ошибке, не ронять приложение.", "Некорректный оператор — вывести «Неизвестная операция».", "Ввод чисел — через double.Parse или TryParse." };

        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("Введите первое число:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            double b = double.Parse(Console.ReadLine());
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
                    {
                        Console.WriteLine("Результат: " + (a / b));
                    } else
                    {
                        Console.WriteLine("Ошибка: нельзя делить на 0.");
                    }
                    break;
                default:
                    Console.WriteLine("Неккоректный оператор");
                    break;
            }
            ConsoleHelper.ShowReadyTask();
        }
    }
}
