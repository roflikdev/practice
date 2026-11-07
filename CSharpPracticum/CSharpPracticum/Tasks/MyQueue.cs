using System;
namespace CSharpPracticum.Tasks
{
    /// <summary>Простая очередь на массиве.</summary>
    public class MyQueue<T>
    {
        private T[] items = new T[2];
        /// <summary>Количество элементов.</summary>
        public int Count { get; private set; }
        /// <summary>Пуста ли очередь.</summary>
        public bool IsEmpty => Count == 0;
        /// <summary>Добавляет элемент в конец.</summary>
        public void Enqueue(T value)
        {
            if (Count == items.Length) Array.Resize(ref items, items.Length * 2);
            items[Count++] = value;
        }
        /// <summary>Забирает первый элемент.</summary>
        public T Dequeue()
        {
            if (IsEmpty) throw new InvalidOperationException("Очередь пуста.");
            T value = items[0];
            for (int i = 1; i < Count; i++)
                items[i - 1] = items[i];
            items[--Count] = default(T);
            return value;
        }
        /// <summary>Показывает первый элемент.</summary>
        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Очередь пуста.");
            return items[0];
        }
    }
}
