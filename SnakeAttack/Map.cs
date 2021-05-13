using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programação
{
    class Map
    {
        private string[,] graph;
        public int lenghtX { get; set; }
        public int lenghtY { get; set; }

        public Map()
        {
            Encoding cp437 = Encoding.GetEncoding(437);
            byte[] verticalHex = new byte[1];
            byte[] upRightHex = new byte[1];
            byte[] downLeftHex = new byte[1];
            byte[] horizontalHex = new byte[1];
            byte[] upLeftHex = new byte[1];
            byte[] downRightHex = new byte[1];

            verticalHex[0] = 0xB3;
            upRightHex[0] = 0xBF;
            downLeftHex[0] = 0xC0;
            horizontalHex[0] = 0xC4;
            upLeftHex[0] = 0xDA;
            downRightHex[0] = 0xD9;

            string vertical = cp437.GetString(verticalHex);
            string horizontal = cp437.GetString(horizontalHex);
            string upRight = cp437.GetString(upRightHex);
            string downRight = cp437.GetString(downRightHex);
            string upLeft = cp437.GetString(upLeftHex);
            string downLeft = cp437.GetString(downLeftHex);

            this.lenghtX = 20;
            this.lenghtY = 10;

            this.graph = new string[10, 20] {
                { upLeft,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,upRight },
                { vertical,".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",vertical },
                { vertical,".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",vertical },
                { vertical,".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",vertical },
                { vertical,".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",vertical },
                { vertical,".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",vertical },
                { vertical,".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",vertical },
                { vertical,".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",vertical },
                { vertical,".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",vertical },
                { downLeft,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,downRight }
            };
        }

        public void getMap()
        {
            for (int i = 0; i < this.lenghtY; i++)
            {
                for (int j = 0; j < this.lenghtX; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(this.graph[i, j]);
                }
            }
        }

        public void setMap(int newX, int newY, int oldX, int oldY, string element)
        {
            this.graph[newX, newY] = element;
            if (oldX != 0 && oldY != 0)
                this.graph[oldX, oldY] = ".";
        }
    }
}
