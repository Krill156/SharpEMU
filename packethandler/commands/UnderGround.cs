using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;
using WorldServer.model;

namespace WorldServer.packethandler.commands
{
    class UnderGround : Command
    {
        public void execute(Player player, string[] arguments)
        {
            player.teleport(new Location(player.getLocation().getX(), player.getLocation().getY() + 6400, 0));
        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
