using System;
using System.Collections.Generic;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 27.</summary>
    public class Task27_Students : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 27. Сортировка студентов";
        /// <summary>Описание задания.</summary>
        public string Description => "Сортировать студентов по оценке и имени.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Student с Name и AverageGrade.", "IComparable<Student> по оценке по убыванию.", "ByNameComparer по имени." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            List<Student> students = new List<Student>
            {
                new Student("Иван", 4.5),
                new Student("Анна", 5.0),
                new Student("Борис", 3.8),
                new Student("Олег", 4.2)
            };
            students.Sort();
            Console.WriteLine("По баллу:");
            Print(students);
            students.Sort(new ByNameComparer());
            Console.WriteLine("По имени:");
            Print(students);
            ConsoleHelper.ShowReadyTask();
        }

        /// <summary>Студент и средняя оценка.</summary>
        public class Student : IComparable<Student>
        {
            /// <summary>Имя.</summary>
            public string Name { get; set; }
            /// <summary>Средний балл.</summary>
            public double AverageGrade { get; set; }
            /// <summary>Создает студента.</summary>
            public Student(string name, double grade) { Name = name; AverageGrade = grade; }
            /// <summary>Сравнивает по оценке по убыванию.</summary>
            public int CompareTo(Student other)
            {
                if (other == null) return -1;
                return other.AverageGrade.CompareTo(AverageGrade);
            }
        }
        
        /// <summary>Сортирует студентов по имени.</summary>
        public class ByNameComparer : IComparer<Student>
        {
            /// <summary>Сравнивает имена.</summary>
            public int Compare(Student a, Student b)
            {
                return string.Compare(a.Name, b.Name, StringComparison.CurrentCulture);
            }
        }
        
        private void Print(List<Student> students)
        {
            foreach (Student student in students)
                Console.WriteLine(student.Name + " - " + student.AverageGrade);
        }
    }
}
