using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;
using WorldServer.model;

namespace WorldServer.packethandler.commands
{
    class Test : Command
    {
        public void execute(Player player, string[] arguments)
        {
            if (arguments.Length == 0)
            {
                player.getPackets().sendMessage("[Animation command]: ::t emote_number");
                return;
            }

            int animation = 0;
            if (!int.TryParse(arguments[0], out animation))
            {
                player.getPackets().sendMessage("[Animation command]: ::emote emote_number");
                return;
            }
            //1179 flash + skill icon  , 1230 = make box
           player.getPackets().sendConfig(1179, animation); //start flashing appropriate skill icons
           player.getPackets().sendChatboxInterface2(740);


        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
