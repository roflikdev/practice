using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 33.</summary>
    public class Task33_Employees : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 33. LINQ: сотрудники";
        /// <summary>Описание задания.</summary>
        public string Description => "Найти сотрудников с помощью LINQ.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "10+ сотрудников.", "Топ-3 по зарплате.", "GroupBy и Average по отделу.", "Where для возраста старше 30." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            List<Employee> people = new List<Employee>
            {
                new Employee("Анна", 26, 70000m, "IT"),
                new Employee("Иван", 33, 90000m, "IT"),
                new Employee("Олег", 40, 110000m, "IT"),
                new Employee("Мария", 31, 65000m, "HR"),
                new Employee("Павел", 25, 50000m, "HR"),
                new Employee("Елена", 36, 75000m, "HR"),
                new Employee("Юра", 45, 120000m, "Sales"),
                new Employee("Катя", 29, 80000m, "Sales"),
                new Employee("Дима", 32, 85000m, "Sales"),
                new Employee("Саша", 27, 60000m, "IT")
            };
            Console.WriteLine("Топ-3 по зарплате:");
            foreach (Employee p in people.OrderByDescending(p => p.Salary).Take(3))
                Console.WriteLine(p.Name + " - " + p.Salary);
            Console.WriteLine("Средняя зарплата по отделам:");
            foreach (var group in people.GroupBy(p => p.Department))
                Console.WriteLine(group.Key + " - " + group.Average(p => p.Salary));
            Console.WriteLine("Старше 30 лет:");
            foreach (Employee p in people.Where(p => p.Age > 30))
                Console.WriteLine(p.Name + " - " + p.Age);
            ConsoleHelper.ShowReadyTask();
        }

        /// <summary>Сотрудник.</summary>
        public class Employee
        {
            /// <summary>Имя.</summary>
            public string Name { get; set; }
            /// <summary>Возраст.</summary>
            public int Age { get; set; }
            /// <summary>Зарплата.</summary>
            public decimal Salary { get; set; }
            /// <summary>Отдел.</summary>
            public string Department { get; set; }
            /// <summary>Создает сотрудника.</summary>
            public Employee(string name, int age, decimal salary, string department)
            {
                Name = name;
                Age = age;
                Salary = salary;
                Department = department;
            }
        }
    }
}
