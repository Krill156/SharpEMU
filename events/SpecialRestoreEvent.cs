﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;

namespace WorldServer.events
{
    class SpecialRestoreEvent : Event
    {
        public SpecialRestoreEvent()
            : base(50000) {}

        public override void runAction()
        {
            foreach(Player p in Server.getPlayerList()) {
			    if (p == null) {
				    continue;
			    }
			    if (p.getSpecialAttack().getSpecialAmount() < 100) {
				    p.getSpecialAttack().setSpecialAmount(p.getSpecialAttack().getSpecialAmount() + 20);
				    if (p.getSpecialAttack().getSpecialAmount() > 100) {
					    p.getSpecialAttack().setSpecialAmount(100);
				    }
				    p.setSpecialAmount(p.getSpecialAttack().getSpecialAmount());
			    }
		    }
        }
    }
}
