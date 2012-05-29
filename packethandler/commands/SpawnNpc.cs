using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;
using WorldServer.npc;
using WorldServer.model;

namespace WorldServer.packethandler.commands
{
    class SpawnNpc : Command
    {
        public void execute(Player player, string[] arguments)
        {
            if (arguments.Length == 0)
            {
                player.getPackets().sendMessage("[SpawnNpc command]: ::npc npc_id");
                return;
            }

            int npcId = 0;
            if (!int.TryParse(arguments[0], out npcId))
            {
                player.getPackets().sendMessage("[SpawnNpc command]: ::npc npc_id");
                return;
            }

            Npc npc = new Npc(npcId, player.getLocation());
            npc.setMinimumCoords(new Location(player.getLocation().getX() - 5, player.getLocation().getY() - 5, player.getLocation().getZ()));
            npc.setMaximumCoords(new Location(player.getLocation().getX() + 5, player.getLocation().getY() + 5, player.getLocation().getZ()));
            Server.getNpcList().Add(npc);
        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
