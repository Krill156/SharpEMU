using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;

namespace WorldServer.packethandler.commands
{
    class Animation : Command
    {
        public void execute(Player player, string[] arguments)
        {
            if (arguments.Length == 0)
            {
                player.getPackets().sendMessage("[Animation command]: ::emote emote_number");
                return;
            }

            int animation = 0;
            if (!int.TryParse(arguments[0], out animation))
            {
                player.getPackets().sendMessage("[Animation command]: ::emote emote_number");
                return;
            }

            player.setLastAnimation(new model.Animation(animation));
        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
