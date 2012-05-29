using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;

namespace WorldServer.packethandler.commands
{
    class Uptime : Command
    {
        public void execute(Player player, string[] arguments)
        {
            TimeSpan uptime = TimeSpan.FromMilliseconds(Environment.TickCount - Server.serverStartupTime); //milliseconds lol.
            player.getPackets().sendMessage("Server been running for: " + (int)uptime.TotalDays + " days, " + uptime.Hours + " hours, " + uptime.Minutes + " minutes, " + uptime.Seconds + " seconds, " + uptime.Milliseconds + " milliseconds.");
        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
