using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;

namespace WorldServer.packethandler.commands
{
    class KickAll : Command
    {
        public void execute(Player player, string[] arguments)
        {
            foreach (Player p in Server.getPlayerList())
            {
                if (p != null)
                    p.getPackets().forceLogout(); //even kicks yourself too lol.
            }
        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
