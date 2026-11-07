using System;

namespace CSharpPracticum.Menu
{
    /// <summary>Главное меню практикума.</summary>
    public class MenuRunner
    {
        /// <summary>Запускает главное меню.</summary>
        public static void Start()
        {
            bool isWork = true;
            while (isWork)
            {
                switch (LevelMenu.ShowLevels())
                {
                    case 1:
                        LevelMenu.StartLevel1();
                        break;
                    case 2:
                        LevelMenu.StartLevel2();
                        break;
                    case 3:
                        LevelMenu.StartLevel3();
                        break;
                    case 4:
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
