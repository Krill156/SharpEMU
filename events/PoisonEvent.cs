using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;
using WorldServer.model;
using WorldServer.util;

namespace WorldServer.events
{
    class PoisonEvent : Event
    {
        private Entity target;

        public PoisonEvent(Entity target, int poisonAmount)
            : base(30000 + misc.random(30000))
        {
		    this.target = target;
		    initialize(poisonAmount);
	    }

	    private void initialize(int poisonAmount) { 
		    if (target is Player) {
			    if (((Player)target).getSuperAntipoisonCycles() > 0) {
				    stop();
				    return;
			    }
			    ((Player)target).getPackets().sendMessage("You have been poisoned!");
		    }
		    target.setPoisonAmount(poisonAmount);
	    }

        public override void runAction()
        {
		    if (!target.isPoisoned() || target.isDead()) {
			    stop();
			    return;
		    }
		    if (target is Player) {
			    ((Player) target).getPackets().closeInterfaces();
		    }
		    target.hit(target.getPoisonAmount(), Hits.HitType.POISON_DAMAGE);
		    if (misc.random(200) >= 100) {
			    target.setPoisonAmount(target.getPoisonAmount() - 1);
		    }
		    if (misc.random(10) == 0) {
			    target.setPoisonAmount(0);
			    stop();
			    return;
		    }
		    setTick(30000 + misc.random(30000));
	    }
    }
}
