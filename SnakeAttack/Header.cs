using System;

namespace SnakeAttack
{
    class Header
    {
        private int positionX;
        private int positionY;
        private string phrase;
        private int actualXPHero;
        private Hero hero;
        private string barXP;

        public Header(Hero hero)
        {
            this.phrase = "Snake Level: {level}           XP: {xp}";
            this.hero = hero;
            this.barXP = getBarXP(hero.level, hero.xp);
            this.positionX = 40;
            this.positionY = 2;
            
        }

        public void reprintPhrase(int levelHero, int xpHero) {

            if (actualXPHero < xpHero)
            {
                this.barXP = getBarXP(levelHero, xpHero);
            }
                
            this.actualXPHero = xpHero;
            string phrase = this.phrase.Replace("{level}", levelHero.ToString())
                                        .Replace("{xp}", this.barXP);

            Console.SetCursorPosition(this.positionX, this.positionY);
            Console.Write(phrase);
        }

        private string getBarXP(int levelHero, int xpHero) {
            return bar(this.hero.getXpForLevel(levelHero), xpHero);
        }

        private string bar(int lenght,int xpHero)
        {
            string bar = "";
            int newLenght = lenght + 2;
            for(int i = 0; i<newLenght; i++)
            {
                if(i == 0)
                {
                    bar+="[";
                }else if (i == newLenght-1)
                {
                    bar+="]";
                }
                else if(i <= xpHero )
                {
                    bar+="x";
                }
                else
                {
                    bar+=" ";
                }
            }
            return bar;
        }
    }
}
