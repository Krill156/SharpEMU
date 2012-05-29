using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.events;
using System.IO;
using System.Xml.Serialization;
using WorldServer.player;
using WorldServer.util;

namespace WorldServer.definitions
{
    class ShopManager
    {
        	
	    private Dictionary<int, Shop> shops;
	
	    public ShopManager() {
            if (!File.Exists(misc.getServerPath() + @"\data\shops.xml"))
            {
                misc.WriteError(@"Missing data\shops.xml");
                return;
            }
            try
            {
                //Deserialize text file to a new object.
                StreamReader objStreamReader = new StreamReader(misc.getServerPath() + @"\data\shops.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(List<Shop>));

                List<Shop> listShops = (List<Shop>)serializer.Deserialize(objStreamReader);
                shops = new Dictionary<int, Shop>();
                foreach (Shop shop in listShops)
                {
                    shops.Add(shop.id, shop);
                }
            }
            catch (Exception e)
            {
                misc.WriteError((e.InnerException == null ? e.ToString() : e.InnerException.ToString()));
            }

		    //shops = (Map<Integer, Shop>) XStreamUtil.getXStream().fromXML(new FileInputStream("data/shops.xml"));
            Event updateShopAmountsEvent = new Event(60000);
            updateShopAmountsEvent.setAction(() => {
		        updateShopAmounts();
		    });
            Server.registerEvent(updateShopAmountsEvent);
		    Console.WriteLine("Loaded " + shops.Count + " shops.");
	    }

	    private void updateShopAmounts() {
            foreach (KeyValuePair<int, Shop> s in shops) {
			    s.Value.updateAmounts();
			    foreach(Player p in Server.getPlayerList()) {
				    if (p == null || p.getShopSession() == null) {
					    continue;
				    }
				    if (p.getShopSession().getShopId() == s.Key) {
					    p.getPackets().sendItems(-1, 64271, 31, s.Value.getStock());
				    }
			    }
		    }
	    }
	
	    public Shop getShop(int id) {
		    return shops[id];
		
	    }
    }
}
