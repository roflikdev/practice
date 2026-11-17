using System;
using System.Threading.Tasks;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 3. Задание 40.</summary>
    public class Task40_Download : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 40. async/await и ошибки";
        /// <summary>Описание задания.</summary>
        public string Description => "Имитировать скачивание и обработать ошибку.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "DownloadAsync с Task.Delay(1000).", "ArgumentException для пустой строки.", "try/catch для обоих вызовов." };

        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            RunAsync().GetAwaiter().GetResult();
            ConsoleHelper.ShowReadyTask();
        }

        private async Task RunAsync()
        {
            string[] urls = new string[] { "https://example.com/file", "" };
            foreach (string url in urls)
            {
                try
                {
                    string result = await DownloadAsync(url);
                    Console.WriteLine(result);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }

        private async Task<string> DownloadAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Адрес не должен быть пустым.");

            await Task.Delay(1000);
            return "Скачивание с " + url + " завершено.";
        }
    }
}
