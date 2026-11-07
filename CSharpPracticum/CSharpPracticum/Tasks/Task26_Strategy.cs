using System;
using System.Collections.Generic;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 26.</summary>
    public class Task26_Strategy : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 26. Стратегии скидок";
        /// <summary>Описание задания.</summary>
        public string Description => "Рассчитать цену с разными скидками.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "IDiscountStrategy и метод Apply(decimal).", "NoDiscount, VipDiscount (10%), PromoDiscount (20%).", "PriceCalculator со стратегией в конструкторе." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            decimal price = 1000m;
            IDiscountStrategy[] strategies =
            {
                new NoDiscount(),
                new VipDiscount(),
                new PromoDiscount()
            };
            foreach (IDiscountStrategy strategy in strategies)
            {
                PriceCalculator calculator = new PriceCalculator(strategy);
                Console.WriteLine(strategy.GetType().Name + ": " + calculator.Calculate(price));
            }
            ConsoleHelper.ShowReadyTask();
        }

        /// <summary>Правило скидки.</summary>
        public interface IDiscountStrategy
        {
            /// <summary>Возвращает цену со скидкой.</summary>
            decimal Apply(decimal price);
        }
        
        /// <summary>Без скидки.</summary>
        public class NoDiscount : IDiscountStrategy
        {
            /// <summary>Оставляет цену.</summary>
            public decimal Apply(decimal price) { return price; }
        }
        
        /// <summary>Скидка 10%.</summary>
        public class VipDiscount : IDiscountStrategy
        {
            /// <summary>Применяет 10%.</summary>
            public decimal Apply(decimal price) { return price * 0.9m; }
        }
        
        /// <summary>Скидка 20%.</summary>
        public class PromoDiscount : IDiscountStrategy
        {
            /// <summary>Применяет 20%.</summary>
            public decimal Apply(decimal price) { return price * 0.8m; }
        }
        
        /// <summary>Считает цену по выбранному правилу.</summary>
        public class PriceCalculator
        {
            private IDiscountStrategy strategy;
            /// <summary>Принимает правило скидки.</summary>
            public PriceCalculator(IDiscountStrategy strategy) { this.strategy = strategy; }
            /// <summary>Возвращает новую цену.</summary>
            public decimal Calculate(decimal price) { return strategy.Apply(price); }
        }
    }
}
