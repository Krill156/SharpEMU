using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;
using WorldServer.definitions;

namespace WorldServer.packethandler.commands
{
    class ReloadLadderXml : Command
    {
        public void execute(Player player, string[] arguments)
        {
            if (arguments.Length == 0)
            {
                player.getPackets().sendMessage("[Reload Ladders & Stairs XML File]: This command is only for server developers.");
                player.getPackets().sendMessage("Reloading... [Could crash server if populated, as all ladders get erased]");
                LaddersAndStairs.load();
                player.getPackets().sendMessage("Reloaded.");

            }
        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
