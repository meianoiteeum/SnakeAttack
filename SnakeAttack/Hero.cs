using System.Text;

namespace SnakeAttack
{
    class Hero : BasePerson
    {
        public Orientation orientation { get; set; }
        public int xp { get; set; }

        public Hero()
        {
            this.orientation = Orientation.EAST;            

            base.level = 1;

            base.posX = 2;
            base.posY = 2;

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
