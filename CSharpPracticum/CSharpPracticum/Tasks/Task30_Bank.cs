using System;
using System.Collections.Generic;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 30.</summary>
    public class Task30_Bank : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 30. Банковский счет и исключение";
        /// <summary>Описание задания.</summary>
        public string Description => "Пополнить счет и попробовать снять больше баланса.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "BankAccount с приватным балансом.", "Deposit и Withdraw.", "InsufficientFundsException и try/catch." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            BankAccount account = new BankAccount();
            account.Deposit(1000m);
            Console.WriteLine("Баланс: " + account.Balance);
            account.Withdraw(300m);
            Console.WriteLine("После снятия: " + account.Balance);
            try
            {
                account.Withdraw(2000m);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Итоговый баланс: " + account.Balance);
            ConsoleHelper.ShowReadyTask();
        }

        /// <summary>Исключение при нехватке денег.</summary>
        public class InsufficientFundsException : Exception
        {
            /// <summary>Создает исключение.</summary>
            public InsufficientFundsException(string message) : base(message) { }
        }
        
        /// <summary>Банковский счет.</summary>
        public class BankAccount
        {
            private decimal balance;
            /// <summary>Текущий баланс.</summary>
            public decimal Balance => balance;
            /// <summary>Пополняет счет.</summary>
            public void Deposit(decimal amount)
            {
                if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
                balance += amount;
            }
            /// <summary>Снимает деньги.</summary>
            public void Withdraw(decimal amount)
            {
                if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
                if (amount > balance) throw new InsufficientFundsException("Недостаточно средств.");
                balance -= amount;
            }
        }
    }
}
