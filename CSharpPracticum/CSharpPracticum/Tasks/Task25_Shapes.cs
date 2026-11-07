using System;
using System.Collections.Generic;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 25.</summary>
    public class Task25_Shapes : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 25. Фигуры и сортировка";
        /// <summary>Описание задания.</summary>
        public string Description => "Найти площади и периметры фигур, отсортировать по площади.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "IShape с Area и Perimeter.", "Circle, Rectangle, Triangle.", "5+ фигур в List<IShape>.", "Сортировка по площади." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            List<IShape> shapes = new List<IShape>
            {
                new Circle(2),
                new Rectangle(2, 3),
                new Triangle(3, 4, 5),
                new Circle(1),
                new Rectangle(5, 4)
            };
            Console.WriteLine("До сортировки:");
            PrintShapes(shapes);
            shapes.Sort((a, b) => a.Area().CompareTo(b.Area()));
            Console.WriteLine("После сортировки:");
            PrintShapes(shapes);
            ConsoleHelper.ShowReadyTask();
        }

        /// <summary>Общие методы фигур.</summary>
        public interface IShape
        {
            /// <summary>Площадь.</summary>
            double Area();
            /// <summary>Периметр.</summary>
            double Perimeter();
        }
        
        /// <summary>Круг.</summary>
        public class Circle : IShape
        {
            private double radius;
            /// <summary>Создает круг.</summary>
            public Circle(double radius) { this.radius = radius; }
            /// <summary>Площадь круга.</summary>
            public double Area() { return Math.PI * radius * radius; }
            /// <summary>Периметр круга.</summary>
            public double Perimeter() { return 2 * Math.PI * radius; }
        }
        
        /// <summary>Прямоугольник.</summary>
        public class Rectangle : IShape
        {
            private double width, height;
            /// <summary>Создает прямоугольник.</summary>
            public Rectangle(double width, double height) { this.width = width; this.height = height; }
            /// <summary>Площадь прямоугольника.</summary>
            public double Area() { return width * height; }
            /// <summary>Периметр прямоугольника.</summary>
            public double Perimeter() { return 2 * (width + height); }
        }
        
        /// <summary>Треугольник.</summary>
        public class Triangle : IShape
        {
            private double a, b, c;
            /// <summary>Создает треугольник.</summary>
            public Triangle(double a, double b, double c) { this.a = a; this.b = b; this.c = c; }
            /// <summary>Площадь по формуле Герона.</summary>
            public double Area()
            {
                double p = Perimeter() / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            /// <summary>Периметр.</summary>
            public double Perimeter() { return a + b + c; }
        }
        
        private void PrintShapes(List<IShape> shapes)
        {
            foreach (IShape shape in shapes)
                Console.WriteLine(shape.GetType().Name + ": площадь " + Math.Round(shape.Area(), 2)
                    + ", периметр " + Math.Round(shape.Perimeter(), 2));
        }
    }
}
