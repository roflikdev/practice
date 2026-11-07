using System;
using System.Collections.Generic;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 29.</summary>
    public class Task29_Factory : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 29. Фабрика уведомлений";
        /// <summary>Описание задания.</summary>
        public string Description => "Создать уведомления разных типов через фабрику.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "INotification с Send(string).", "Email, Sms, Push.", "NotificationFactory.Create по enum." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            foreach (NotificationType type in Enum.GetValues(typeof(NotificationType)))
            {
                INotification notification = NotificationFactory.Create(type);
                notification.Send("Проверка уведомления");
            }
            ConsoleHelper.ShowReadyTask();
        }

        /// <summary>Виды уведомлений.</summary>
        public enum NotificationType { Email, Sms, Push }
        
        /// <summary>Отправка уведомления.</summary>
        public interface INotification
        {
            /// <summary>Отправляет текст.</summary>
            void Send(string message);
        }
        
        /// <summary>Уведомление на почту.</summary>
        public class EmailNotification : INotification
        {
            /// <summary>Отправляет сообщение на экран.</summary>
            public void Send(string message) { Console.WriteLine("Email: " + message); }
        }
        
        /// <summary>Уведомление по SMS.</summary>
        public class SmsNotification : INotification
        {
            /// <summary>Отправляет сообщение на экран.</summary>
            public void Send(string message) { Console.WriteLine("SMS: " + message); }
        }
        
        /// <summary>Push-уведомление.</summary>
        public class PushNotification : INotification
        {
            /// <summary>Отправляет сообщение на экран.</summary>
            public void Send(string message) { Console.WriteLine("Push: " + message); }
        }
        
        /// <summary>Создает нужный вид уведомления.</summary>
        public static class NotificationFactory
        {
            /// <summary>Возвращает реализацию уведомления.</summary>
            public static INotification Create(NotificationType type)
            {
                switch (type)
                {
                    case NotificationType.Email: return new EmailNotification();
                    case NotificationType.Sms: return new SmsNotification();
                    case NotificationType.Push: return new PushNotification();
                    default: throw new ArgumentOutOfRangeException(nameof(type));
                }
            }
        }
    }
}
