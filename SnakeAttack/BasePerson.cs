using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAttack
{
    public abstract class BasePerson
    {
        public int posX { get; set; }
        public int posY { get; set; }
        public int level { get; set; }
        public string elementBody { get; set; }

        public BasePerson()
        {
            body();
        }

        private void body()
        {
            Encoding cp437 = Encoding.GetEncoding(437);
            byte[] elementBodyHex = new byte[1];
            elementBodyHex[0] = 0xFE;
            this.elementBody = cp437.GetString(elementBodyHex);
        }
    }
}
