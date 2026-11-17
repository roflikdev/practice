using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 3. Задание 44.</summary>
    public class Task44_TodoList : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 44. Список дел";
        /// <summary>Описание задания.</summary>
        public string Description => "Добавлять, просматривать, выполнять и удалять дела с сохранением в JSON.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "TaskItem, TaskRepository, TaskService.", "Добавление, просмотр, выполнение, удаление.", "Сохранение и загрузка tasks.json." };

        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            TaskService service = new TaskService(new TaskRepository());
            bool isWork = true;
            while (isWork)
            {
                Console.WriteLine("\n1. Добавить дело");
                Console.WriteLine("2. Показать все дела");
                Console.WriteLine("3. Отметить выполненным");
                Console.WriteLine("4. Удалить дело");
                Console.WriteLine("0. Назад");
                Console.Write("Выберите действие: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Название: ");
                        string title = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(title))
                            Console.WriteLine("Название не может быть пустым.");
                        else
                        {
                            service.Add(title.Trim());
                            Console.WriteLine("Дело добавлено.");
                        }
                        break;
                    case "2":
                        List<TaskItem> items = service.GetAll();
                        if (items.Count == 0)
                            Console.WriteLine("Список пока пуст.");
                        foreach (TaskItem item in items)
                            Console.WriteLine(item.Id + ". " + item.Title + " - " + (item.IsDone ? "готово" : "не готово"));
                        break;
                    case "3":
                        Console.Write("Номер дела: ");
                        if (int.TryParse(Console.ReadLine(), out int doneId))
                            Console.WriteLine(service.MarkDone(doneId) ? "Готово." : "Дело не найдено.");
                        else
                            Console.WriteLine("Введите число.");
                        break;
                    case "4":
                        Console.Write("Номер дела: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                            Console.WriteLine(service.Delete(deleteId) ? "Удалено." : "Дело не найдено.");
                        else
                            Console.WriteLine("Введите число.");
                        break;
                    case "0":
                    case "q":
                    case null:
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Нет такого действия.");
                        break;
                }
            }
            ConsoleHelper.ShowReadyTask();
        }

        /// <summary>Одно дело из списка.</summary>
        public class TaskItem
        {
            /// <summary>Номер.</summary>
            public int Id { get; set; }
            /// <summary>Название.</summary>
            public string Title { get; set; }
            /// <summary>Выполнено или нет.</summary>
            public bool IsDone { get; set; }
        }

        /// <summary>Хранение списка и работа с файлом.</summary>
        public class TaskRepository
        {
            private List<TaskItem> items = new List<TaskItem>();
            private string path = "tasks.json";

            /// <summary>Загружает список из файла, если он есть.</summary>
            public TaskRepository()
            {
                if (File.Exists(path))
                {
                    try
                    {
                        items = JsonSerializer.Deserialize<List<TaskItem>>(File.ReadAllText(path)) ?? new List<TaskItem>();
                    }
                    catch (JsonException)
                    {
                        Console.WriteLine("Не получилось прочитать tasks.json.");
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Не получилось открыть tasks.json.");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("Нет доступа к tasks.json.");
                    }
                }
            }

            /// <summary>Возвращает все дела.</summary>
            public List<TaskItem> GetAll() { return items; }

            /// <summary>Добавляет новое дело.</summary>
            public void Add(TaskItem item)
            {
                items.Add(item);
                Save();
            }

            /// <summary>Отмечает дело выполненным.</summary>
            public bool MarkDone(int id)
            {
                TaskItem item = items.FirstOrDefault(x => x.Id == id);
                if (item == null) return false;
                item.IsDone = true;
                Save();
                return true;
            }

            /// <summary>Удаляет дело.</summary>
            public bool Delete(int id)
            {
                TaskItem item = items.FirstOrDefault(x => x.Id == id);
                if (item == null) return false;
                items.Remove(item);
                Save();
                return true;
            }

            private void Save()
            {
                try
                {
                    File.WriteAllText(path, JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true }));
                }
                catch (IOException)
                {
                    Console.WriteLine("Не получилось сохранить tasks.json.");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Нет доступа к tasks.json для сохранения.");
                }
            }
        }

        /// <summary>Действия со списком дел.</summary>
        public class TaskService
        {
            private TaskRepository repository;

            /// <summary>Получает хранилище дел.</summary>
            public TaskService(TaskRepository repository) { this.repository = repository; }

            /// <summary>Показывает все дела.</summary>
            public List<TaskItem> GetAll() { return repository.GetAll(); }

            /// <summary>Добавляет дело с новым номером.</summary>
            public void Add(string title)
            {
                List<TaskItem> items = repository.GetAll();
                int id = items.Count == 0 ? 1 : items.Max(x => x.Id) + 1;
                repository.Add(new TaskItem { Id = id, Title = title, IsDone = false });
            }

            /// <summary>Отмечает дело выполненным.</summary>
            public bool MarkDone(int id) { return repository.MarkDone(id); }

            /// <summary>Удаляет дело.</summary>
            public bool Delete(int id) { return repository.Delete(id); }
        }
    }
}
