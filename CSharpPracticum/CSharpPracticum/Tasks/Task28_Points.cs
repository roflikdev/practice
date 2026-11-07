using System;
using System.Collections.Generic;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 28.</summary>
    public class Task28_Points : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 28. Equals и GetHashCode";
        /// <summary>Описание задания.</summary>
        public string Description => "Проверить равенство точек и HashSet.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Point с X, Y.", "Equals(object), GetHashCode, IEquatable<Point>.", "HashSet не добавляет дубликат." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Point a = new Point(1, 2);
            Point b = new Point(1, 2);
            Point c = new Point(2, 3);
            Console.WriteLine("Точки равны: " + a.Equals(b));
            HashSet<Point> points = new HashSet<Point> { a, b, c };
            Console.WriteLine("Точек в HashSet: " + points.Count);
            ConsoleHelper.ShowReadyTask();
        }

        /// <summary>Точка с двумя координатами.</summary>
        public class Point : IEquatable<Point>
        {
            /// <summary>Координата X.</summary>
            public int X { get; }
            /// <summary>Координата Y.</summary>
            public int Y { get; }
            /// <summary>Создает точку.</summary>
            public Point(int x, int y) { X = x; Y = y; }
            /// <summary>Сравнение с другой точкой.</summary>
            public bool Equals(Point other)
            {
                return other != null && X == other.X && Y == other.Y;
            }
            /// <summary>Сравнение с объектом.</summary>
            public override bool Equals(object obj)
            {
                return Equals(obj as Point);
            }
            /// <summary>Хеш координат.</summary>
            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }
        }
    }
}
