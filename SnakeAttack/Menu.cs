using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeAttack
{
    class Menu : Graphic
    {

        public Menu()
        {
            Console.CursorVisible = false;
            List<byte[]> hexCodes = new List<byte[]>();
            byte[] verticalHex = new byte[1] { 0xBA };
            byte[] upRightHex = new byte[1] { 0xBB };
            byte[] downLeftHex = new byte[1] { 0xC8 };
            byte[] horizontalHex = new byte[1] { 0xCD };
            byte[] upLeftHex = new byte[1] { 0xC9 };
            byte[] downRightHex = new byte[1] {0xBC };

            hexCodes.Add(verticalHex);
            hexCodes.Add(horizontalHex);
            hexCodes.Add(upRightHex);
            hexCodes.Add(downRightHex);
            hexCodes.Add(upLeftHex);
            hexCodes.Add(downLeftHex);

            base.setHexCodes(hexCodes);

            base.lenghtX = 60;
            base.lenghtY = 20;

            base.positionX = 30;
            base.positionY = 5;

            this.graph = new string[20, 60] {
                { upLeft,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",upRight },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","S","N","A","K","E"," "," ","A","T","T","A","C","K","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { vertical,"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",vertical },
                { downLeft,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,horizontal,downRight }
            };

            start();
        }

        private void start()
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();            
            while (!keyInfo.Key.Equals(ConsoleKey.Enter))
            {
                drawAnimation();
                if(Console.KeyAvailable)
                    keyInfo = Console.ReadKey(true);
            }
            input(keyInfo);
        }
        private void drawAnimation()
        {
            paintPressStart();
        }
        private void paintPressStart()
        {
            string[] pressStart = new string[11] { "p", "r", "e", "s", "s", " ", "E", "N", "T", "E", "R" };
            int[] y = new int[] { 17};
            int[] positionX = new int[11] {25,26,27,28,29,30,31,32,33,34,35};

            for(int i = 0; i < pressStart.Length; i++)
            {
                string s = pressStart[i];
                int x = positionX[i];
                base.setMap(y[0],x,0,0,s);
            }
            
            ConsoleColor consoleColor = ConsoleColor.Yellow;
            base.getMap(positionX, y, consoleColor);
            Thread.Sleep(500);

            for (int i = 0; i < pressStart.Length; i++)
            {
                int x = positionX[i];
                base.setMap(y[0], x, 0, 0, " ");
            }
            base.getMap();
            Thread.Sleep(500);
        }
        private void input(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Scenario scenario = new Scenario();
                scenario.start();
            }
        }
    }
}