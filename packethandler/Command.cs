using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WorldServer.player;
using WorldServer.net;
using WorldServer.packethandler.commands;

namespace WorldServer.packethandler
{
    class Command : PacketHandler
    {
        public void handlePacket(Player player, Packet p)
        {
            string command = p.readRS2String().ToLower();
            CommandManager.execute(player, command);
        }
    }
}
