using System;
using System.Threading;

namespace SnakeAttack
{
    class Scenario
    {
        public Map map;
        public Hero hero;
        public Header header;
        private ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        private int oldPosX;
        private int oldPosY;

        public Scenario()
        {
            this.map = new Map();
            this.hero = new Hero();
            this.header = new Header(this.hero);
            this.hero.posHeroX = 1;
            this.hero.posHeroY = 1;
        }

        public void start() {
            this.map.setMap(this.hero.posHeroY,this.hero.posHeroX,0,0, this.hero.elementBody);
            this.map.getMap();
            while (true)
            {
                move();
                input();
                Thread.Sleep(150);
                repaint();
                this.header.reprintPhrase(this.hero.level, this.hero.xp);
            }
        }

        public void repaint()
        {
            if((this.hero.posHeroX != this.oldPosX) || (this.hero.posHeroY != this.oldPosY))
                this.map.setMap(this.hero.posHeroY, this.hero.posHeroX, this.oldPosY, this.oldPosX, this.hero.elementBody);            
            this.map.getMap();
        }

        public void move() {
            this.oldPosX = this.hero.posHeroX;
            this.oldPosY = this.hero.posHeroY;
            int pos;

            switch (this.hero.orientation)
            {
                case Orientation.WEST:
                    pos = this.hero.posHeroX - 1;
                    if (pos > 0)
                        this.hero.posHeroX = pos;
                    break;
                case Orientation.EAST:
                    pos = this.hero.posHeroX + 1;
                    if (pos < map.lenghtX - 1)
                        this.hero.posHeroX = pos;
                    break;
                case Orientation.NORTH:
                    pos = this.hero.posHeroY - 1;
                    if (pos > 0)
                        this.hero.posHeroY = pos;
                    break;
                case Orientation.SOUTH:
                    pos = this.hero.posHeroY + 1;
                    if (pos + 1 < this.map.lenghtY)
                        this.hero.posHeroY = pos;
                    break;
            }
        }

        public void input()
        {
            if (Console.KeyAvailable)
            {
                this.keyInfo = Console.ReadKey(true);
                char key = this.keyInfo.KeyChar;
                if (key == 'A' || key == 'D' || key == 'a' || key == 'd')
                    this.hero.invertOrientation(key);
            }
        }

    }
}
