using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;

namespace WorldServer.packethandler.commands
{
    interface Command
    {
        void execute(Player player, string[] arguments);
        int minimumRightsNeeded();
    }
}
