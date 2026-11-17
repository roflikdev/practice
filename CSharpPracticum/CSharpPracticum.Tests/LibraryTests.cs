using System;
using System.Collections.Generic;
using Xunit;

using Book = CSharpPracticum.Tasks.Task45_Library.Book;
using Reader = CSharpPracticum.Tasks.Task45_Library.Reader;
using Library = CSharpPracticum.Tasks.Task45_Library.Library;

namespace CSharpPracticum.Tests
{
    /// <summary>Проверки задания 45.</summary>
    public class LibraryTests
    {
        /// <summary>Книга становится недоступной после выдачи.</summary>
        [Fact]
        public void Borrow_MakesBookUnavailable()
        {
            Book book = new Book("Книга 1", "Автор");
            Reader reader = new Reader("Иван");
            Library library = new Library(new List<Book> { book });

            library.Borrow(book, reader);

            Assert.False(book.IsAvailable);
            Assert.Single(reader.BorrowedBooks);
        }

        /// <summary>После возврата книгу снова можно взять.</summary>
        [Fact]
        public void Return_MakesBookAvailable()
        {
            Book book = new Book("Книга 1", "Автор");
            Reader reader = new Reader("Иван");
            Library library = new Library(new List<Book> { book });

            library.Borrow(book, reader);
            library.Return(book, reader);

            Assert.True(book.IsAvailable);
            Assert.Empty(reader.BorrowedBooks);
        }

        /// <summary>Нельзя выдать одну книгу дважды.</summary>
        [Fact]
        public void Borrow_Twice_Throws()
        {
            Book book = new Book("Книга 1", "Автор");
            Library library = new Library(new List<Book> { book });
            library.Borrow(book, new Reader("Иван"));

            Assert.Throws<InvalidOperationException>(() => library.Borrow(book, new Reader("Оля")));
        }

        /// <summary>Четвёртую книгу выдавать нельзя.</summary>
        [Fact]
        public void Borrow_FourthBook_Throws()
        {
            Book first = new Book("Книга 1", "Автор");
            Book second = new Book("Книга 2", "Автор");
            Book third = new Book("Книга 3", "Автор");
            Book fourth = new Book("Книга 4", "Автор");
            Library library = new Library(new List<Book> { first, second, third, fourth });
            Reader reader = new Reader("Иван");
            library.Borrow(first, reader);
            library.Borrow(second, reader);
            library.Borrow(third, reader);

            Assert.Throws<InvalidOperationException>(() => library.Borrow(fourth, reader));
            Assert.True(fourth.IsAvailable);
        }

        /// <summary>Нельзя вернуть чужую книгу.</summary>
        [Fact]
        public void Return_NotBorrowed_Throws()
        {
            Book book = new Book("Книга 1", "Автор");
            Library library = new Library(new List<Book> { book });

            Assert.Throws<InvalidOperationException>(() => library.Return(book, new Reader("Иван")));
        }

        /// <summary>После возврата книгу может взять другой читатель.</summary>
        [Fact]
        public void Borrow_AfterReturn_Works()
        {
            Book book = new Book("Книга 1", "Автор");
            Reader first = new Reader("Иван");
            Reader second = new Reader("Оля");
            Library library = new Library(new List<Book> { book });
            library.Borrow(book, first);
            library.Return(book, first);

            library.Borrow(book, second);

            Assert.Contains(book, second.BorrowedBooks);
        }

        /// <summary>Нельзя выдать книгу, которой нет в библиотеке.</summary>
        [Fact]
        public void Borrow_UnknownBook_Throws()
        {
            Library library = new Library(new List<Book>());
            Book book = new Book("Чужая книга", "Автор");

            Assert.Throws<InvalidOperationException>(() => library.Borrow(book, new Reader("Иван")));
        }
    }
}
