using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 31.</summary>
    public class Task31_FileWriter : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 31. IDisposable и using";
        /// <summary>Описание задания.</summary>
        public string Description => "Записать файл и правильно закрыть поток.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "FileWriter с StreamWriter.", "Dispose закрывает файл.", "Использовать using и using var." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            string path = Path.Combine(Path.GetTempPath(), "task31.txt");
            using (FileWriter writer = new FileWriter(path))
            {
                writer.WriteLine("Первая строка");
            }
            using var secondWriter = new FileWriter(path);
            secondWriter.WriteLine("Вторая строка");
            Console.WriteLine("Файл записан: " + path);
            ConsoleHelper.ShowReadyTask();
        }

        /// <summary>Простая запись текста в файл.</summary>
        public class FileWriter : IDisposable
        {
            private StreamWriter writer;
            /// <summary>Открывает файл.</summary>
            public FileWriter(string path)
            {
                writer = new StreamWriter(path, true);
            }
            /// <summary>Записывает строку.</summary>
            public void WriteLine(string text)
            {
                writer.WriteLine(text);
            }
            /// <summary>Закрывает файл.</summary>
            public void Dispose()
            {
                writer.Dispose();
            }
        }
    }
}
