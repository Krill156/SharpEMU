using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;
using WorldServer.minigames.agilityarena;
using WorldServer.model;

namespace WorldServer.packethandler.commands
{
    class TestStillGraphics : Command
    {
        	public void execute(Player player, string[] arguments) {
                if (arguments.Length == 0)
                {

                    /*
                     * Testing the newStillGraphics, 
                     * it seems to do exactly what packet sent in mask appendGraphicsUpdate does
                     * only extra feature about it is you control how far in tiles you want it to appear
                     */
                    for(byte i = 0; i < 255; i++)
                        player.getPackets().newStillGraphics(player.getLocation(), new Graphics(392, 0, 100), i);
                    return;

                }

	        }

            public int minimumRightsNeeded()
            {
                return 0;
            }
    }
}
