using System;
using System.Collections.Generic;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks
{
    /// <summary>Уровень 2. Задание 24.</summary>
    public class Task24_Animals : ITask
    {
        /// <summary>Название задания.</summary>
        public string Title => "Задание 24. Наследование: животные";
        /// <summary>Описание задания.</summary>
        public string Description => "Создать животных с разными звуками.";
        /// <summary>Требования к заданию.</summary>
        public string[] Requirements => new string[] { "Абстрактный Animal с Name, MakeSound, ToString.", "Dog, Cat и Bird, у Bird есть Fly.", "List<Animal> и полиморфизм." };
        /// <summary>Запуск задания.</summary>
        public void Run()
        {
            ConsoleHelper.ShowTaskInfo(Title, Description, Requirements);
            List<Animal> animals = new List<Animal>
            {
                new Dog("Шарик"),
                new Cat("Мурка"),
                new Bird("Кеша")
            };
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
                animal.MakeSound();
            }
            Bird bird = new Bird("Чиж");
            bird.Fly();
            ConsoleHelper.ShowReadyTask();
        }

        /// <summary>Общее описание животного.</summary>
        public abstract class Animal
        {
            /// <summary>Имя животного.</summary>
            public string Name { get; set; }
            /// <summary>Создает животное.</summary>
            public Animal(string name) { Name = name; }
            /// <summary>Издает звук.</summary>
            public abstract void MakeSound();
            /// <summary>Имя и тип животного.</summary>
            public override string ToString() { return GetType().Name + ": " + Name; }
        }
        
        /// <summary>Собака.</summary>
        public class Dog : Animal
        {
            /// <summary>Создает собаку.</summary>
            public Dog(string name) : base(name) { }
            /// <summary>Гавкает.</summary>
            public override void MakeSound() { Console.WriteLine("Гав!"); }
        }
        
        /// <summary>Кошка.</summary>
        public class Cat : Animal
        {
            /// <summary>Создает кошку.</summary>
            public Cat(string name) : base(name) { }
            /// <summary>Мяукает.</summary>
            public override void MakeSound() { Console.WriteLine("Мяу!"); }
        }
        
        /// <summary>Птица.</summary>
        public class Bird : Animal
        {
            /// <summary>Создает птицу.</summary>
            public Bird(string name) : base(name) { }
            /// <summary>Чирикает.</summary>
            public override void MakeSound() { Console.WriteLine("Чирик!"); }
            /// <summary>Летает.</summary>
            public void Fly() { Console.WriteLine(Name + " летает!"); }
        }
    }
}
