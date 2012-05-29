using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.player;
using WorldServer.util;

namespace WorldServer.clans
{
    class ClanUser
    {
        private Player p;
        private Clan clan;
        private Clan.ClanRank rights;

        public ClanUser(Player p, Clan clan)
        {
            this.p = p;
            this.clan = clan;
            this.rights = Clan.ClanRank.NO_RANK;
        }

        public Player getClanMember()
        {
            return p;
        }

        public void setClanRights(Clan.ClanRank rights)
        {
            if (rights == Clan.ClanRank.NO_RANK)
            {
                if (clan.getOwnerFriends().Contains(p.getLoginDetails().getLongName()))
                {
                    rights = Clan.ClanRank.FRIEND;
                }
            }
            else
            {
                if(!clan.getUsersWithRank().ContainsKey(p.getLoginDetails().getUsername()))
                    clan.getUsersWithRank().Add(p.getLoginDetails().getUsername(), rights);
                if (clan.getUsersWithRank().Count >= 250)
                {
                    misc.WriteError("Clan 'usersWithRank' map size needs increasing!");
                }
            }
            this.rights = rights;
        }

        public Clan.ClanRank getClanRights()
        {
            return rights;
        }

        public Clan getClan()
        {
            return clan;
        }
    }
}
