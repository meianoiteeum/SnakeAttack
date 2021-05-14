using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeAttack
{
    class Scenario
    {
        private Map map;
        private Hero hero;
        private Header header;
        private ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        private int oldPosX;
        private int oldPosY;
        private int levelArea;
        private List<int> enemyPosX;
        private List<int> enemyPosY;
        private int enemyQtde;

        public Scenario()
        {
            this.hero = new Hero();
            this.map = new Map();            
            this.header = new Header(this.hero);
            this.levelArea = 1;
            this.hero.posX = 1;
            this.hero.posY = 1;
            this.enemyPosX = new List<int>();
            this.enemyPosY = new List<int>();
        }

        public void start() {
            this.map.setMap(this.hero.posY,this.hero.posX,0,0, this.hero.elementBody);
            spawnEnemys();
            this.map.getMap();            
            while (this.levelArea < 6)
            {
                move();
                input();
                Thread.Sleep(150);
                this.header.reprintPhrase(this.hero.level, this.hero.xp);
                repaint();
            }
        }

        private void repaint()
        {
            if((this.hero.posX != this.oldPosX) || (this.hero.posY != this.oldPosY))
                this.map.setMap(this.hero.posY, this.hero.posX, this.oldPosY, this.oldPosX, this.hero.elementBody);

            if(this.enemyQtde == 0)
            {
                this.levelArea++;
                spawnEnemys();
            }
                
            this.map.getMap();
        }

        private void move() {
            this.oldPosX = this.hero.posX;
            this.oldPosY = this.hero.posY;
            int pos;

            switch (this.hero.orientation)
            {
                case Orientation.WEST:
                    pos = this.hero.posX - 1;
                    if (pos > 0)
                        this.hero.posX = pos;
                    break;
                case Orientation.EAST:
                    pos = this.hero.posX + 1;
                    if (pos < map.lenghtX - 1)
                        this.hero.posX = pos;
                    break;
                case Orientation.NORTH:
                    pos = this.hero.posY - 1;
                    if (pos > 0)
                        this.hero.posY = pos;
                    break;
                case Orientation.SOUTH:
                    pos = this.hero.posY + 1;
                    if (pos+1 < this.map.lenghtY)
                        this.hero.posY = pos;
                    break;
            }
            verifyEnemyPosition(this.hero.posX, this.hero.posY);
        }

        public void verifyEnemyPosition(int posX, int posY)
        {
            if(this.enemyPosX.Contains(posX) && this.enemyPosY.Contains(posY)){
                this.enemyQtde--;
                this.enemyPosX.Remove(posX);
                this.enemyPosY.Remove(posY);
                this.map.setMap(posY, posX, 0, 0," ");
                this.hero.xp++;
            }
        }

        private void input()
        {
            if (Console.KeyAvailable)
            {
                this.keyInfo = Console.ReadKey(true);
                char key = this.keyInfo.KeyChar;
                if (key == 'A' || key == 'D' || key == 'a' || key == 'd')
                    this.hero.invertOrientation(key);
            }
        }

        private void spawnEnemys()
        {
            switch (this.levelArea)
            {
                case 1:
                    this.enemyQtde = 2;
                    generateEnemy(this.enemyQtde);
                    break;
                case 2:
                    this.enemyQtde = 4;
                    generateEnemy(this.enemyQtde);
                    break;
                case 3:
                    this.enemyQtde = 8;
                    generateEnemy(this.enemyQtde);
                    break;
                case 4:
                    this.enemyQtde = 16;
                    generateEnemy(this.enemyQtde);
                    break;
                case 5:
                    this.enemyQtde = 16;
                    generateEnemy(this.enemyQtde);
                    break;
            }
        }

        private void generateEnemy(int qtdeEnemy)
        {
            for (int i = 0; i < qtdeEnemy ; i++)
            {
                int x = generatePosition(this.enemyPosX, this.map.lenghtX - 1);

                int y = generatePosition(this.enemyPosY, this.map.lenghtY - 1);

                Enemy enemy = new Enemy(x,y, this.levelArea);

                this.map.setMap(y, x, 0, 0, enemy.elementBody);
            }
        }

        private int generatePosition(List<int> pos, int lenght)
        {            
            while (true)
            {
                Random random = new Random();
                int x = random.Next(1, lenght);
                if (!pos.Contains(x))
                {
                    pos.Add(x);
                    return x;
                }
            }
        }
    }
}
