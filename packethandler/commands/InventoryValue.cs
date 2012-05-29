﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;
using WorldServer.model;

namespace WorldServer.packethandler.commands
{
    class InventoryValue : Command
    {
        public void execute(Player player, string[] arguments)
        {
            int price = 0;
            for (int i = 0; i < player.getInventory().getItems().Length; i++)
            {
                if (player.getInventory().getItemInSlot(i) > 0)
                {
                    price += (player.getInventory().getSlot(i).getDefinition().getPrice().getNormalPrice() * player.getInventory().getAmountInSlot(i));
                    if (player.getInventory().getItemInSlot(i) == 995) //gold itself.
                        price += player.getInventory().getAmountInSlot(i);
                }
            }
            player.getPackets().sendMessage("Value of inventory: " + price.ToString("#,##0") + " in gold.");
        }

        public int minimumRightsNeeded()
        {
            return 0;
        }
    }
}
