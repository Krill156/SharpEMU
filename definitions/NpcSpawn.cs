using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.npc;
using System.IO;
using System.Xml.Serialization;
using WorldServer.model;
using WorldServer.util;

namespace WorldServer.definitions
{
    public class NpcSpawn
    {
        public int id;
        public Location location;
        public Location minimumCoords;
        public Location maximumCoords;
        public WalkType walkType;
        public FaceDirection faceDirection = FaceDirection.NORTH;

        public static void load()
        {

            if (!File.Exists(misc.getServerPath() + @"\data\npcs.xml"))
            {
                misc.WriteError(@"Missing data\npcs.xml");
                return;
            }
            try {
                //Deserialize text file to a new object.
                StreamReader objStreamReader = new StreamReader(misc.getServerPath() + @"\data\npcs.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(List<NpcSpawn>));
                List<NpcSpawn> spawns = (List<NpcSpawn>)serializer.Deserialize(objStreamReader);

                foreach (NpcSpawn ns in spawns)
                {
                    Npc n = new Npc(ns.id, ns.location);
                    n.setMinimumCoords(ns.minimumCoords);
                    n.setMaximumCoords(ns.maximumCoords);
                    n.setWalkType(ns.walkType);
                    n.setFaceDirection(ns.faceDirection);
			        Server.getNpcList().Add(n);
		        }
            }
            catch (Exception e)
            {
                misc.WriteError((e.InnerException == null ? e.ToString() : e.InnerException.ToString()));
            }
            Console.WriteLine("Spawned " + Server.getNpcList().Count + " npcs.");
        }
    }
}
