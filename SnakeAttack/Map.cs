using System;
using System.Collections.Generic;

namespace SnakeAttack
{
    class Map : Graphic
    {
        public Map()
        {
            Console.CursorVisible = false;
            List<byte[]> hexCodes = new List<byte[]>();

            byte[] verticalHex = new byte[1] { 0xB3 };
            byte[] upRightHex = new byte[1] { 0xBF };
            byte[] downLeftHex = new byte[1] { 0xC0 };
            byte[] horizontalHex = new byte[1] { 0xC4 };
            byte[] upLeftHex = new byte[1] { 0xDA };
            byte[] downRightHex = new byte[1] { 0xD9 };

            hexCodes.Add(verticalHex);
            hexCodes.Add(horizontalHex);
            hexCodes.Add(upRightHex);
            hexCodes.Add(downRightHex);
            hexCodes.Add(upLeftHex);
            hexCodes.Add(downLeftHex);

            base.setHexCodes(hexCodes);

            base.lenghtX = 40;
            base.lenghtY = 20;

            base.positionX = 40;
            base.positionY = 5;

            base.graph = new string[20, 40] {
                { upLeft,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,upRight },
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
