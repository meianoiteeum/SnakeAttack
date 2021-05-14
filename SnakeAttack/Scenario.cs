using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeAttack
{
    class Scenario
    {
        public Map map;
        public Hero hero;        
        private ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        private int oldPosX;
        private int oldPosY;

        public Scenario()
        {
            Console.CursorVisible = false;
            this.map = new Map();
            this.hero = new Hero();
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
            }
        }

        public void repaint()
        {
            //Console.Clear();
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
                case Orientation.OESTE:
                    pos = this.hero.posHeroX - 1;
                    if (pos > 0)
                        this.hero.posHeroX = pos;
                    break;
                case Orientation.LESTE:
                    pos = this.hero.posHeroX + 1;
                    if (pos < map.lenghtX - 1)
                        this.hero.posHeroX = pos;
                    break;
                case Orientation.NORTE:
                    pos = this.hero.posHeroY - 1;
                    if (pos > 0)
                        this.hero.posHeroY = pos;
                    break;
                case Orientation.SUL:
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
