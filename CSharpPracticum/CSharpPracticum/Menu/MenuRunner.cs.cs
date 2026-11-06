using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticum.Menu
{
    public class MenuRunner
    {
        /// <summary>
        /// Запускает главное меню практики.
        /// </summary>
        public static void Start()
        {
            bool isWork = true;
            while (isWork)
            {
                int level = LevelMenu.ShowLevels();
                Console.WriteLine(level);
                switch (level)
                {
                    case 1:
                        LevelMenu.StartLevel1();
                        break;
                    case 2:
                        isWork = false;
                        break;

                }
            }

        }
    }
}
