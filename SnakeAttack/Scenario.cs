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
        private List<Enemy> enemies;
        List<int> enemiesPosX;
        List<int> enemiesPosY;
        private int enemiesQtde;

        public Scenario()
        {
            this.hero = new Hero();
            this.map = new Map();            
            this.header = new Header(this.hero);
            this.levelArea = 1;
            this.hero.posX = 1;
            this.hero.posY = 1;
            this.enemies = new List<Enemy>();
            this.enemiesPosX = new List<int>();
            this.enemiesPosY = new List<int>();
        }

        public void start() {
            this.map.setMap(this.hero.posY,this.hero.posX,0,0, this.hero.elementBody);
            this.map.getMap();
            spawnEnemys();
            while (this.hero.isLive && this.levelArea < 6)
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

            if (this.enemiesQtde == 0)
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
            foreach(Enemy enemy in enemies) {
                if (enemy.posX.Equals(posX) && enemy.posY.Equals(posY)) {
                    if(enemy.level > this.hero.level)
                    {
                        this.hero.isLive = false;
                        break;
                    }
                    this.enemiesPosX.Remove(enemy.posX);
                    this.enemiesPosY.Remove(enemy.posY);
                    this.enemiesQtde--;
                    this.enemies.Remove(enemy);
                    this.map.setMap(posY, posX, 0, 0, " ");
                    this.hero.xp++;
                    this.hero.verifyLevelUp();
                    break;
                }
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
                    this.enemiesQtde = 2;
                    generateEnemy(2, 1);
                    break;
                case 2:
                    this.enemiesQtde = 4;
                    generateEnemy(4, 1);
                    generateEnemy(2, 2);
                    break;
                case 3:
                    this.enemiesQtde = 4;
                    generateEnemy(5, 2);
                    generateEnemy(2, 3);
                    generateEnemy(3, 4);
                    break;
                case 4:
                    this.enemiesQtde = 3;
                    generateEnemy(5, 3);
                    generateEnemy(14, 4);
                    break;
                case 5:
                    this.enemiesQtde = 3;
                    generateEnemy(6, 3);
                    generateEnemy(11, 4);
                    break;
            }
        }

        private void generateEnemy(int qtdeEnemy, int enemyLvl)
        {
            for (int i = 0; i < qtdeEnemy ; i++)
            {
                int x = generatePosition(enemiesPosX, this.map.lenghtX - 1);

                int y = generatePosition(enemiesPosY, this.map.lenghtY - 1);

                Enemy enemy = new Enemy(x,y, enemyLvl);
                this.enemies.Add(enemy);
                this.map.setEnemyMap(y, x, enemy.elementBody, enemy.changeColor());
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
