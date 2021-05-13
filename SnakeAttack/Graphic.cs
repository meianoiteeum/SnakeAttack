using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string[,] graph;
        public int positionX { get; set; }
        public int positionY { get; set; }
        public int lenghtX { get; set; }
        public int lenghtY { get; set; }

        public Graphic()
        {
            
        }

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

        public void getMap()
        {
            int x;
            int y = 0;
            int lenghtY = this.positionY + this.lenghtY;
            int lenghtX = this.positionX + this.lenghtX;

            for (int i = this.positionY; i < lenghtY; i++)
            {
                x = 0;
                for (int j = this.positionX; j < lenghtX; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(this.graph[y, x]);
                    x++;
                }
                y++;
            }
        }
    }
}
