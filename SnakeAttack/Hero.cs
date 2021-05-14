using System.Text;

namespace SnakeAttack
{
    class Hero
    {
        public Orientation orientation { get; set; }
        public int posHeroX { get; set; }
        public int posHeroY { get; set; }
        public int level { get; set; }
        public string elementBody { get; set; }
        public int xp { get; set; }

        public Hero()
        {
            this.orientation = Orientation.EAST;

            Encoding cp437 = Encoding.GetEncoding(437);
            byte[] elementBodyHex = new byte[1];
            elementBodyHex[0] = 0xFE;
            this.elementBody = cp437.GetString(elementBodyHex);

            this.level = 1;

            this.posHeroX = 2;
            this.posHeroY = 2;

            this.xp = 0;
        }

        public void invertOrientation(char key)
        {
            switch (this.orientation)
            {
                case Orientation.NORTH:
                case Orientation.SOUTH:
                    if (key == 'A' || key == 'a')
                        this.orientation = Orientation.WEST;
                    else
                        this.orientation = Orientation.EAST;
                    break;
                case Orientation.EAST:
                    if (key == 'A' || key == 'a')
                        this.orientation = Orientation.NORTH;
                    else
                        this.orientation = Orientation.SOUTH;
                    break;
                case Orientation.WEST:
                    if (key == 'A' || key == 'a')
                        this.orientation = Orientation.SOUTH;
                    else
                        this.orientation = Orientation.NORTH;
                    break;
            }
        }

        public int getXpForLevel(int level)
        {
            switch (level)
            {
                case 1:
                    return 4;
                    break;
                case 2:
                    return 6;
                    break;
                case 3:
                    return 8;
                    break;
                default:
                    return 0;
            }
        }
    }
}
