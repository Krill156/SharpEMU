using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;

namespace WorldServer.packethandler.commands
{
    class Interface : Command
    {
        public void execute(Player player, string[] arguments)
        {
            if (arguments.Length == 0)
            {
                player.getPackets().sendMessage("[Interface command]: ::inter interface_number");
                return;
            }

            int intreface = 0;
            if (!int.TryParse(arguments[0], out intreface))
            {
                player.getPackets().sendMessage("[Interface command]: ::inter interface_number");
                return;
            }

            player.getPackets().displayInterface(intreface);
        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
