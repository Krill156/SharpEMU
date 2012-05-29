using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WorldServer.player;
using WorldServer.net;

namespace WorldServer.packethandler
{
    interface PacketHandler
    {
        void handlePacket(Player player, Packet p);
    }
}
