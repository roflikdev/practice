using System;
using System.Collections.Generic;
using System.Linq;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 1. Задание 11.</summary>
    public class Task11_Matrix : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 11. Диагональ матрицы";
        /// <summary>Описание задания.</summary>
        public string Description => "Найти сумму главной диагонали матрицы NxN.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "N вводит пользователь, минимум 2.", "Случайные элементы.", "Сумма диагонали одним циклом for." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Console.WriteLine("Введите размер матрицы (2-50):");
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 2 || n > 50)
            {
                Console.WriteLine("Неверный размер.");
            }
            else
            {
                int[,] matrix = new int[n, n];
                Random random = new Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = random.Next(1, 10);
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            
                int sum = 0;
                for (int i = 0; i < n; i++)
                    sum += matrix[i, i];
                Console.WriteLine("Сумма диагонали: " + sum);
            }
            ConsoleHelper.ShowReadyTask();
        }
    }
}
