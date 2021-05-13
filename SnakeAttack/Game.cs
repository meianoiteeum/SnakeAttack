using System;
using System.Threading;

namespace Programação
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
