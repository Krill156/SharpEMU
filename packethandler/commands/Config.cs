using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;

namespace WorldServer.packethandler.commands
{
    class Config : Command
    {
        public void execute(Player player, string[] arguments)
        {
            if (arguments.Length < 2)
            {
                player.getPackets().sendMessage("[Config command]: ::config id value  (example ::config 1 1)");
                return;
            }

            int id = 0;
            int value = 0;

            if (!int.TryParse(arguments[0], out id) && !int.TryParse(arguments[1], out value))
            {
                player.getPackets().sendMessage("[Config command]: ::config id value  (example ::config 1 1)");
                return;
            }

            player.getPackets().sendConfig(id, value);
        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
