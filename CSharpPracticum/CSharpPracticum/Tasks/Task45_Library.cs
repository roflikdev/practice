using System;
using System.Collections.Generic;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 3. Задание 45.</summary>
    public class Task45_Library : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 45. Библиотека";
        /// <summary>Описание задания.</summary>
        public string Description => "Выдавать и возвращать книги, проверять ограничения.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Book, Reader и Library.", "Не больше 3 книг на человека.", "Исключения и 5+ тестов xUnit." };

        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            Book first = new Book("Капитанская дочка", "А. Пушкин");
            Book second = new Book("Ревизор", "Н. Гоголь");
            Reader reader = new Reader("Даниил");
            Library library = new Library(new List<Book> { first, second });

            library.Borrow(first, reader);
            Console.WriteLine(reader.Name + " взял книгу: " + first.Title);
            Console.WriteLine("Книга доступна: " + first.IsAvailable);
            library.Return(first, reader);
            Console.WriteLine(reader.Name + " вернул книгу: " + first.Title);
            Console.WriteLine("Книга доступна: " + first.IsAvailable);
            Console.WriteLine("Проверки есть в проекте CSharpPracticum.Tests.");
            ConsoleHelper.ShowReadyTask();
        }

        /// <summary>Книга в библиотеке.</summary>
        public class Book
        {
            /// <summary>Название.</summary>
            public string Title { get; set; }
            /// <summary>Автор.</summary>
            public string Author { get; set; }
            /// <summary>Можно ли выдать книгу.</summary>
            public bool IsAvailable { get; set; }

            /// <summary>Создаёт книгу.</summary>
            public Book(string title, string author)
            {
                Title = title;
                Author = author;
                IsAvailable = true;
            }
        }

        /// <summary>Читатель.</summary>
        public class Reader
        {
            /// <summary>Имя читателя.</summary>
            public string Name { get; set; }
            /// <summary>Взятые книги.</summary>
            public List<Book> BorrowedBooks { get; set; }

            /// <summary>Создаёт читателя.</summary>
            public Reader(string name)
            {
                Name = name;
                BorrowedBooks = new List<Book>();
            }
        }

        /// <summary>Выдача и возврат книг.</summary>
        public class Library
        {
            private List<Book> books;

            /// <summary>Создаёт библиотеку.</summary>
            public Library(List<Book> books) { this.books = books; }

            /// <summary>Выдаёт книгу читателю.</summary>
            public void Borrow(Book book, Reader reader)
            {
                if (!books.Contains(book))
                    throw new InvalidOperationException("Такой книги нет в библиотеке.");
                if (!book.IsAvailable)
                    throw new InvalidOperationException("Книгу уже выдали.");
                if (reader.BorrowedBooks.Count >= 3)
                    throw new InvalidOperationException("Можно взять не больше трёх книг.");

                book.IsAvailable = false;
                reader.BorrowedBooks.Add(book);
            }

            /// <summary>Принимает книгу обратно.</summary>
            public void Return(Book book, Reader reader)
            {
                if (!reader.BorrowedBooks.Contains(book))
                    throw new InvalidOperationException("Читатель не брал эту книгу.");

                reader.BorrowedBooks.Remove(book);
                book.IsAvailable = true;
            }
        }
    }
}
