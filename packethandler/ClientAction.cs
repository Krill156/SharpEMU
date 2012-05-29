using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WorldServer.player;
using WorldServer.net;
using WorldServer.definitions;

namespace WorldServer.packethandler
{
    class ClientAction : PacketHandler
    {	
	    public void handlePacket(Player player, Packet packet) {
		    switch(packet.getPacketId()) {
                case PacketHandlers.PacketId.IDLE:
                case PacketHandlers.PacketId.MOVE_CAMERA:
                case PacketHandlers.PacketId.PING:
                    player.getConnection().setPinged();
                    break;
                case PacketHandlers.PacketId.FOCUS:
                case PacketHandlers.PacketId.CLICK_MOUSE:
                case PacketHandlers.PacketId.SOUND_SETTINGS:
				    break;

                case PacketHandlers.PacketId.WINDOW_TYPE:
				    handleScreenSettings(player, packet);
				    break;
		    }
		
	    }

	    private void handleScreenSettings(Player player, Packet packet) {
		    int windowType = packet.readByte() & 0xff;
		    int windowWidth = packet.readUShort();
		    int windowHeight = packet.readUShort();
		    int junk = packet.readByte() & 0xff;
		    player.getPackets().configureGameScreen(windowType);
	    }
    }
}
