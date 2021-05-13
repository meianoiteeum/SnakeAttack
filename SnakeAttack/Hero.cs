using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAttack
{
    class Hero
    {
        public Orientation orientation { get; set; }
        public int posHeroX { get; set; }
        public int posHeroY { get; set; }
        public int level { get; set; }
        public string elementBody { get; set; }

        public Hero()
        {
            this.orientation = Orientation.LESTE;

            Encoding cp437 = Encoding.GetEncoding(437);
            byte[] elementBodyHex = new byte[1];
            elementBodyHex[0] = 0xFE;
            this.elementBody = cp437.GetString(elementBodyHex);

            this.level = 0;

            this.posHeroX = 2;
            this.posHeroY = 2;
        }

        public void invertOrientation(char key)
        {
            switch (this.orientation)
            {
                case Orientation.NORTE:
                case Orientation.SUL:
                    if (key == 'A' || key == 'a')
                        this.orientation = Orientation.OESTE;
                    else
                        this.orientation = Orientation.LESTE;
                    break;
                case Orientation.LESTE:
                    if (key == 'A' || key == 'a')
                        this.orientation = Orientation.NORTE;
                    else
                        this.orientation = Orientation.SUL;
                    break;
                case Orientation.OESTE:
                    if (key == 'A' || key == 'a')
                        this.orientation = Orientation.SUL;
                    else
                        this.orientation = Orientation.NORTE;
                    break;
            }
        }
    }
}
