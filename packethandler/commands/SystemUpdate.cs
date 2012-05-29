﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;
using WorldServer.events;

namespace WorldServer.packethandler.commands
{
    class SystemUpdate : Command
    {
        public void execute(Player player, string[] arguments)
        {
            if (!Server.isUpdateInProgress())
            {   //could of hardcoded the Event right inside this command :S
                player.getPackets().sendMessage("Started a system update, this cannot be stopped!");
                Server.registerEvent(new SystemUpdateEvent()); 
                Server.setUpdateInProgress(true);
            }
        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
