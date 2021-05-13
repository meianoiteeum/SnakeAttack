using System;
using System.Threading;

namespace SnakeAttack
{
    class Game
    {
        public static void Main(string[] args)
        {
            Scenario scenario = new Scenario();
            scenario.start();
            Console.ReadKey();
        }
    }
}
