using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeAttack
{
    public abstract class Graphic
    {
        public string vertical { get; set; }
        public string horizontal { get; set; }
        public string upRight { get; set; }
        public string downRight { get; set; }
        public string upLeft { get; set; }
        public string downLeft { get; set; }
        public string[,] graph { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
        public int lenghtX { get; set; }
        public int lenghtY { get; set; }

        public Graphic() {}

        public void setHexCodes(List<byte[]> hexCodes)
        {
            Encoding cp437 = Encoding.GetEncoding(437);
            this.vertical = cp437.GetString(hexCodes[0]);
            this.horizontal = cp437.GetString(hexCodes[1]);
            this.upRight = cp437.GetString(hexCodes[2]);
            this.downRight = cp437.GetString(hexCodes[3]);
            this.upLeft = cp437.GetString(hexCodes[4]);
            this.downLeft = cp437.GetString(hexCodes[5]);
        }

        public void setMap(int newX, int newY, int oldX, int oldY, string element)
        {
            this.graph[newX, newY] = element;
            if (oldX != 0 && oldY != 0)
                this.graph[oldX, oldY] = " ";
        }

        public void getMap()
        {
            getMap(new int[] {-1}, new int[] { -1 }, 0);
        }

        public void setEnemyMap(int posX, int posY, string body, ConsoleColor consoleColor)
        {
            int y = this.positionY + posX;
            int x = this.positionX + posY;

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = consoleColor;
            Console.Write(body);
            resetColorConsole();
        }

        public void getMap(int[] colorX, int[] colorY, ConsoleColor consoleColor)
        {
            int x;
            int y = 0;
            int getColorX = 0;
            int lenghtY = this.positionY + this.lenghtY;
            int lenghtX = this.positionX + this.lenghtX;
            Boolean waitColor = false;            

            for (int i = this.positionY; i < lenghtY; i++)
            {
                x = 0;
                for (int j = this.positionX; j < lenghtX; j++)
                {
                    Console.SetCursorPosition(j, i);
                    if(verifyExistsDifferentColor(getColorX, colorX, y, colorY[0], x))
                    {
                        Console.ForegroundColor = consoleColor;
                        waitColor = true;
                        getColorX++;
                    }
                    Console.Write(this.graph[y, x]);
                    if (waitColor)
                    {
                        resetColorConsole();
                        waitColor = false;
                    }                        
                    x++;
                }
                y++;
            }
        }

        private void resetColorConsole()
        {
            ConsoleColor consoleColorGray = ConsoleColor.Gray;
            Console.ForegroundColor = consoleColorGray;
        }

        private Boolean verifyExistsDifferentColor(int getColorX, int[] colorX, int y, int colorY, int x)
        {
            return getColorX < colorX.Length && y == colorY && colorX[getColorX] == x;
        }
    }
}
