﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.npc;
using WorldServer.player;
using WorldServer.model;

namespace WorldServer.events
{
    class AggressiveNpcEvent : Event
    {
        public AggressiveNpcEvent() 
            :base(750) {}

	    public override void runAction() {
		    foreach (Npc npc in Server.getNpcList()) {
			    if (!npc.getDefinition().isAggressive()) {
				    continue;
			    }
			    foreach(Player p in Server.getPlayerList()) {
				    if (p != null && npc != null) {
					    if (p.getLocation().getZ() == npc.getLocation().getZ()) {
						    if (p.getLocation().inArea(npc.getMinimumCoords().getX(), npc.getMinimumCoords().getY(), npc.getMaximumCoords().getX(), npc.getMaximumCoords().getY())) {
							    if (p.getLocation().inArea(npc.getLocation().getX() - 3, npc.getLocation().getY() - 3, npc.getLocation().getX() + 3, npc.getLocation().getY() + 3)) {
								    if (!npc.isDead() && !npc.inCombat() && !npc.isDestroyed() && !npc.isHidden() && !p.inCombat() && ((npc.getDefinition().getCombat() >= (p.getSkills().getCombatLevel() * 2)) || Location.inWilderness(p.getLocation()))) {
									    npc.setTarget(p);
									    npc.setEntityFocus(p.getClientIndex());
									    npc.getFollow().setFollowing(p);
								    }
							    }
						    }
					    }
				    }
			    }
		    }
	    }
    }
}
