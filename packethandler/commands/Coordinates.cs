using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;
using WorldServer.model;

namespace WorldServer.packethandler.commands
{
    class Coordinates : Command
    {
        public void execute(Player player, string[] arguments)
        {
            Location loc = player.getLocation();
            player.getPackets().sendMessage("Coordinates are X = [" + loc.getX() + "] Y = [" + loc.getY() + "] Z = [" + loc.getZ() + "]");
        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
