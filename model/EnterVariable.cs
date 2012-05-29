using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldServer.model
{
    class EnterVariable
    {
        private int interfaceId;
        private int slot;

        public EnterVariable(int interfaceId, int slot)
        {
            this.interfaceId = interfaceId;
            this.slot = slot;
        }

        public int getInterfaceId()
        {
            return interfaceId;
        }

        public int getSlot()
        {
            return slot;
        }
    }
}
