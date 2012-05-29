using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;

namespace WorldServer.packethandler.commands
{
    class Yell : Command
    {
        public void execute(Player player, string[] arguments)
        {
            if(arguments.Length == 0) {
                player.getPackets().sendMessage("[Yell command]: what are you expecting.. to yell blank message?");
                return;
            }

            string yellMsg = string.Join(" ", arguments);

		    foreach(Player p in Server.getPlayerList()) {
			    if (p != null) {
                    p.getPackets().sendMessage(player.getLoginDetails().getUsername() + ": " + yellMsg);
			    }
		    }
        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
