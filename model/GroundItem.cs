using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;

namespace WorldServer.model
{
    class GroundItem : Item
    {
        private Location location;
        private Player owner;
        private int ownerId;
        private bool respawn;
        private long dropTime;
        bool global;

        public GroundItem(int id, int amount, Location location, Player owner)
            : base(id, amount)
        {
            this.location = location;
            this.owner = owner;
            respawn = false;
            this.dropTime = Environment.TickCount;
            if (owner != null)
            {
                ownerId = owner.getIndex();
            }
        }

        public static GroundItem newPlayerDroppedItem(Player player, Item item)
        {
            return new GroundItem(item.getItemId(), item.getItemAmount(), player.getLocation(), player);
        }

        public Location getLocation()
        {
            return location;
        }

        public Player getOwner()
        {
            return owner;
        }

        public void setOwner(Player p)
        {
            this.owner = p;
        }

        public int getOwnerId()
        {
            return ownerId;
        }

        public bool isRespawn()
        {
            return respawn;
        }

        public void setRespawn(bool respawn)
        {
            this.respawn = respawn;
        }

        public long getDropTime()
        {
            return dropTime;
        }

        public bool isGlobal()
        {
            return global;
        }

        public void setGlobal(bool global)
        {
            this.global = global;
        }
    }
}
