using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 19.</summary>
    public class Task19_StackQueue : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 19. Свой стек и очередь";
        /// <summary>Описание задания.</summary>
        public string Description => "Реализовать MyStack и MyQueue на массиве.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Push, Pop, Peek, Count, IsEmpty.", "Enqueue, Dequeue, Peek, Count, IsEmpty.", "Автоматическое увеличение массива и ошибка пустой коллекции." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            MyStack<int> stack = new MyStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            Console.WriteLine("Стек Peek: " + stack.Peek());
            Console.WriteLine("Стек Pop: " + stack.Pop());
            Console.WriteLine("Стек Pop: " + stack.Pop());
            Console.WriteLine("Стек Pop: " + stack.Pop());
            try { stack.Pop(); }
            catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }
            
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine("Очередь Peek: " + queue.Peek());
            Console.WriteLine("Очередь Dequeue: " + queue.Dequeue());
            Console.WriteLine("Очередь Dequeue: " + queue.Dequeue());
            Console.WriteLine("Очередь Dequeue: " + queue.Dequeue());
            try { queue.Dequeue(); }
            catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }
            ConsoleHelper.ShowReadyTask();
        }
    }
}
