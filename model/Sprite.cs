using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldServer.model
{
    class Sprite
    {
        private int dir1 = -1, dir2 = -1;

        public int getPrimarySprite()
        {
            return dir1;
        }

        public int getSecondarySprite()
        {
            return dir2;
        }

        public void setSprites(int dir1, int dir2)
        {
            this.dir1 = dir1;
            this.dir2 = dir2;
        }
    }
}
