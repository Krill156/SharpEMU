using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;

namespace WorldServer.packethandler.commands
{
    class SpawnObject : Command
    {
        public void execute(Player player, string[] arguments)
        {
            //TODO: Possible TODO.
            //I guess this command is for testing where object should be placed to spawnedObjects.cfg / objectLocations.cfg?
  	        //Err I don't like this command too much as the objects spawned are fake.. 
            //gotta maybe add to WorldObjects, like SpawnNPC :S later.

            if (arguments.Length < 2)
            {
                player.getPackets().sendMessage("[SpawnObject command]: ::obj objectId face");
                return;
            }

            int objectId = 0;
            int face = 0;

            if(!int.TryParse(arguments[0], out objectId)) {
                player.getPackets().sendMessage("[SpawnObject command]: objectId is not a number ::obj objectId face");
                return;
            }

            if(!int.TryParse(arguments[1], out face)) {
                player.getPackets().sendMessage("[SpawnObject command]: face is not a number ::obj objectId face");
                return;
            }

		    foreach(Player p in Server.getPlayerList()) {
			    p.getPackets().createObject(objectId, player.getLocation(), face, 10);
		    }
        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
