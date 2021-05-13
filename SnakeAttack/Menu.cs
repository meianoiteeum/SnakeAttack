using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAttack
{
    class Menu : Graphic
    {
        private string[,] graph;

        public Menu()
        {
            List<byte[]> hexCodes = new List<byte[]>();
            byte[] verticalHex = new byte[1] { 0xCD };
            byte[] upRightHex = new byte[1] { 0xBB };
            byte[] downLeftHex = new byte[1] { 0xC8 };
            byte[] horizontalHex = new byte[1] { 0xCF };
            byte[] upLeftHex = new byte[1] { 0xC9 };
            byte[] downRightHex = new byte[1] {0xBC };

            hexCodes.Add(verticalHex);
            hexCodes.Add(upRightHex);
            hexCodes.Add(downLeftHex);
            hexCodes.Add(horizontalHex);
            hexCodes.Add(upLeftHex);
            hexCodes.Add(downRightHex);

            this.graph = new string[20, 40] {
                { upLeft,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",upRight },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { downLeft,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,downRight }
            };

            
        }
    }
}


