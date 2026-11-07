using System;
namespace CSharpPracticum.Tasks
{
    /// <summary>Простой стек на массиве.</summary>
    public class MyStack<T>
    {
        private T[] items = new T[2];
        /// <summary>Количество элементов.</summary>
        public int Count { get; private set; }
        /// <summary>Пуст ли стек.</summary>
        public bool IsEmpty => Count == 0;
        /// <summary>Добавляет элемент.</summary>
        public void Push(T value)
        {
            if (Count == items.Length) Array.Resize(ref items, items.Length * 2);
            items[Count++] = value;
        }
        /// <summary>Забирает верхний элемент.</summary>
        public T Pop()
        {
            if (IsEmpty) throw new InvalidOperationException("Стек пуст.");
            T value = items[--Count];
            items[Count] = default(T);
            return value;
        }
        /// <summary>Показывает верхний элемент.</summary>
        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Стек пуст.");
            return items[Count - 1];
        }
    }
}
