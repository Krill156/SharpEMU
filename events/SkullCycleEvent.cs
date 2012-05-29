using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;

namespace WorldServer.events
{
    class SkullCycleEvent : Event
    {
        public SkullCycleEvent()
            : base(60000) {}

        public override void runAction() {
            foreach(Player p in Server.getPlayerList()) {
                if (p != null) {
                    if (p.isSkulled() && !p.isDead())
                        p.setSkullCycles(p.getSkullCycles() - 1);
                }
		    }
        }
    }
}
