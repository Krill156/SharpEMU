using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldServer.model
{
    /**
     * Holds data for a single animation request.
     */
    class Animation
    {
        private int id, delay;

        public Animation(int id)
        {
            this.id = id;
            delay = 0;
        }

        public Animation(int id, int delay)
        {
            this.id = id;
            this.delay = delay;
        }

        public int getId()
        {
            return id;
        }

        public int getDelay()
        {
            return delay;
        }
    }
}
