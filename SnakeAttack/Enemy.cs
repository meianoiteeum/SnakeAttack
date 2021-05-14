using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAttack
{
    class Enemy : BasePerson
    {
        public ConsoleColor consoleColor;

        public Enemy(int posX, int posY, int level)
        {
            base.posX = posX;
            base.posY = posY;
            base.level = level;
        }

        public ConsoleColor changeColor()
        {
            switch (base.level)
            {
                case 1:
                    return ConsoleColor.White;
                case 2:
                    return ConsoleColor.Blue;
                case 3:
                    return ConsoleColor.Green;
                case 4:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Gray;
            }
        }
    }
}
