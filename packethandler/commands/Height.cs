using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;
using WorldServer.model;

namespace WorldServer.packethandler.commands
{
    class Height : Command
    {
        public void execute(Player player, string[] arguments)
        {
            if (arguments.Length == 0)
            {
                player.getPackets().sendMessage("[Height command]: ::height 0 [0,1,2,3] are possible");
                return;
            }

            int heightLevel = 0;
            if (!int.TryParse(arguments[0], out heightLevel))
            {
                player.getPackets().sendMessage("[Height command]: ::height 0 [0,1,2,3] are possible");
                return;
            }

            player.teleport(new Location(player.getLocation().getX(), player.getLocation().getY(), heightLevel));
        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
