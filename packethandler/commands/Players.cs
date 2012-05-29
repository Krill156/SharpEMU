using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;

namespace WorldServer.packethandler.commands
{
    class Players : Command
    {
        public void execute(Player player, string[] arguments)
        {
            //I miss those interfaces that people used to do in 317/377 serers..
            //TODO: add that interface!.
            player.getPackets().sendMessage("Total players online: " + Server.getPlayerList().Count);
        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
