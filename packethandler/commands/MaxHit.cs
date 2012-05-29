using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;

namespace WorldServer.packethandler.commands
{
    class MaxHit : Command
    {
        public void execute(Player player, string[] arguments)
        {
            player.getPackets().sendMessage("Maxhit = " + player.getMaxHit());
        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
