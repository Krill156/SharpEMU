using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player.skills.fletching;
using WorldServer.player.skills.herblore;
using WorldServer.player.skills.cooking;
using WorldServer.player.skills.mining;
using WorldServer.player.skills.smithing;
using WorldServer.player.skills.woodcutting;
using WorldServer.player.skills.fishing;
using WorldServer.player.skills.crafting;

namespace WorldServer.player.skills
{
    class SkillHandler
    {
        public static int SKILLCAPE_PRICE = 250000;

	    public static void resetAllSkills(Player p) {
		    Fletching.setFletchItem(p, null);
		    Herblore.setHerbloreItem(p, null);
		    Cooking.setCookingItem(p, null);
		    Mining.resetMining(p);
		    Smithing.resetSmithing(p);
		    Woodcutting.resetWoodcutting(p);
		    Fishing.resetFishing(p);
		    Crafting.resetCrafting(p);
		    p.removeTemporaryAttribute("harvesting");
	    }
    }
}
