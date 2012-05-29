using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;

namespace WorldServer.packethandler.commands
{
    class Master : Command
    {
        public void execute(Player player, string[] arguments)
        {
            foreach (Skills.SKILL skill in Enum.GetValues(typeof(Skills.SKILL)))
            {
                player.getSkills().setCurLevel(skill, 99);
                player.getSkills().setXp(skill, Skills.getXpForLevel(99));
            }
            player.getPackets().sendSkillLevels();
            player.getUpdateFlags().setAppearanceUpdateRequired(true);
        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
