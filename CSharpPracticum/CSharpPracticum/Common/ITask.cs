namespace CSharpPracticum.Common
{
    /// <summary>Общие свойства и метод каждого задания.</summary>
    public interface ITask
    {
        /// <summary>Название задания.</summary>
        string Title { get; }
        /// <summary>Описание задания.</summary>
        string Description { get; }
        /// <summary>Требования к заданию.</summary>
        string[] Requirements { get; }
        /// <summary>Запуск решения.</summary>
        void Run();
    }
}
