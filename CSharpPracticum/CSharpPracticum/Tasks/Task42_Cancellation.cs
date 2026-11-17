using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 3. Задание 42.</summary>
    public class Task42_Cancellation : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 42. Отмена операции";
        /// <summary>Описание задания.</summary>
        public string Description => "Отменить долгую задачу через 2 секунды.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "CancellationTokenSource.", "10 задержек по 500 мс.", "OperationCanceledException в try/catch." };

        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            RunAsync().GetAwaiter().GetResult();
            ConsoleHelper.ShowReadyTask();
        }

        private async Task RunAsync()
        {
            using (CancellationTokenSource source = new CancellationTokenSource())
            {
                source.CancelAfter(2000);
                try
                {
                    await LongOperationAsync(source.Token);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Операция отменена.");
                }
            }
        }

        private async Task LongOperationAsync(CancellationToken token)
        {
            for (int i = 1; i <= 10; i++)
            {
                await Task.Delay(500, token);
                Console.WriteLine("Шаг " + i + " из 10");
            }
        }
    }
}
