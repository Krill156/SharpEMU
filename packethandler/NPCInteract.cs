using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WorldServer.player;
using WorldServer.net;
using WorldServer.player.skills;
using WorldServer.combat;
using WorldServer.player.skills.fishing;
using WorldServer.player.skills.slayer;
using WorldServer.minigames.agilityarena;
using WorldServer.minigames.warriorguild;
using WorldServer.definitions.areas;
using WorldServer.npc;
using WorldServer.player.skills.thieving;
using WorldServer.minigames.barrows;
using WorldServer.definitions;

namespace WorldServer.packethandler
{
    class NPCInteract : PacketHandler
    {
	    public void handlePacket(Player player,  Packet packet) {
		    switch(packet.getPacketId()) {
                case PacketHandlers.PacketId.NPC_FIRST_CLICK:
				    handleFirstClickNPC(player, packet);
				    break;

                case PacketHandlers.PacketId.NPC_SECOND_CLICK:
				    handleSecondClickNPC(player, packet);
				    break;

                case PacketHandlers.PacketId.NPC_THIRD_CLICK:
				    handleThirdClickNPC(player, packet);
				    break;

                case PacketHandlers.PacketId.NPC_FOURTH_CLICK:
				    handleFourthClickNPC(player, packet);
				    return;

                case PacketHandlers.PacketId.NPC_FIFTH_CLICK:
				    handleFifthClickNPC(player, packet);
				    break;

                case PacketHandlers.PacketId.NPC_EXAMINE:
                    handleExamineNPC(player, packet);
                    break;

                case PacketHandlers.PacketId.MAGIC_ON_NPC:
				    handleMagicOnNPC(player, packet);
				    break;

                case PacketHandlers.PacketId.ITEM_ON_NPC:
				    handleItemOnNPC(player, packet);
				    break;
		    }
	    }

	    private void handleFirstClickNPC(Player player, Packet packet) {
		    int npcIndex = packet.readLEShortA();
		    if (npcIndex < 0 || npcIndex > Constants.MAX_NPCS || player.isDead() || player.getTemporaryAttribute("cantDoAnything") != null) {
			    return;
		    }
		    SkillHandler.resetAllSkills(player);
		    Npc npc = Server.getNpcList()[npcIndex];
		    if (npc == null || npc.isDestroyed()) {
			    return;
		    }
		    Combat.newAttack(player, npc);
	    }
	
	    private void handleSecondClickNPC(Player player, Packet packet) {
		    int npcIndex = packet.readLEShort();
		    if (npcIndex < 0 || npcIndex > Constants.MAX_NPCS || player.isDead() || player.getTemporaryAttribute("cantDoAnything") != null) {
			    return;
		    }
		    Npc npc = Server.getNpcList()[npcIndex];
		    if (npc == null || npc.isDestroyed()) {
			    return;
		    }
		    Console.WriteLine("Second click NPC " + npc.getId());
		    SkillHandler.resetAllSkills(player);
		    if (Fishing.wantToFish(player, npc, false)) {
			    return;
		    } else if (Slayer.talkToMaster(player, npc)) {
			    return;
		    } else if (AgilityArena.dialogue(player, npc, false)) {
			    return;
		    } else if (TzHaar.interactTzhaarNPC(player, npc, 1)) {
			    return;
		    } else if (WarriorGuild.talkToWarriorGuildNPC(player, npc, 1)) {
			    return;
		    } else if (BoatOptions.interactWithBoatNPC(player, npc)) {
			    return;
		    }
		    switch(npc.getId()) {
			    case 519: // Bob
				    BrokenBarrows.talkToBob(player, npc, -1, 1);
				    break;
				
			    case 553: // Aubury
				    HomeArea.interactWithAubury(player, npc, 1);
				    break;
				
			    case 1862: // Ali morisanne
				    if (npc.getLocation().inArea(2319, 3177, 2321, 3182)) { // Home Ali
					    HomeArea.interactWithAliMorissaae(player, npc);
					    break;
				    } else if (npc.getLocation().inArea(3311, 3198, 3316, 3199)) { // Al Kharid Ali
					    AlKharid.interactWithAliMorissaae(player, npc);
					    break;
				    }
				    break;
		    }
	    }

	    private void handleThirdClickNPC(Player player, Packet packet) {
		    int npcIndex = packet.readShortA();
		    if (npcIndex < 0 || npcIndex > Constants.MAX_NPCS || player.isDead() || player.getTemporaryAttribute("cantDoAnything") != null) {
			    return;
		    }
		    Npc npc = Server.getNpcList()[npcIndex];
		    if (npc == null || npc.isDestroyed()) {
			    return;
		    }
		    Console.WriteLine("Third click NPC " + npc.getId());
		    SkillHandler.resetAllSkills(player);
		    if (Thieving.wantToThieveNpc(player, npc)) {
			    return;
		    } else if (Fishing.wantToFish(player, npc, true)) {
			    return;
		    } else if (AgilityArena.dialogue(player, npc, true)) {
			    return;
		    } else if (TzHaar.interactTzhaarNPC(player, npc, 2)) {
			    return;
		    } else if (WarriorGuild.talkToWarriorGuildNPC(player, npc, 2)) {
			    return;
		    }
		    switch(npc.getId()) {
			    case 553: // Aubury
				    HomeArea.interactWithAubury(player, npc, 2);
				    break;
				
			    case 519: // Bob
				    BrokenBarrows.talkToBob(player, npc, -1, 2);
				    break;
		    }
	    }
	
	    private void handleFourthClickNPC(Player player, Packet packet) {
		    int npcIndex = packet.readUShort();
		    if (npcIndex < 0 || npcIndex > Constants.MAX_NPCS || player.isDead() || player.getTemporaryAttribute("cantDoAnything") != null) {
			    return;
		    }
		    Npc npc = Server.getNpcList()[npcIndex];
		    if (npc == null || npc.isDestroyed()) {
			    return;
		    }
		    Console.WriteLine("Fourth click NPC " + npc.getId());
		    SkillHandler.resetAllSkills(player);
		    if (Slayer.openSlayerShop(player, npc)) {
			    return;
		    }
		    switch(npc.getId()) {
			    case 553: // Aubury
				    HomeArea.interactWithAubury(player, npc, 3);
				    break;
		    }
	    }
	
	    private void handleFifthClickNPC(Player player, Packet packet) {
		    int npcIndex = packet.readLEShort();
		    if (npcIndex < 0 || npcIndex > Constants.MAX_NPCS || player.isDead() || player.getTemporaryAttribute("cantDoAnything") != null) {
			    return;
		    }
		    Npc npc = Server.getNpcList()[npcIndex];
		    if (npc == null || npc.isDestroyed()) {
			    return;
		    }
		    Console.WriteLine("Fifth click NPC " + npc.getId());
		    SkillHandler.resetAllSkills(player);
		    if (Slayer.openPointsInterface(player, npc)) {
			    return;
		    }
	    }

        private void handleExamineNPC(Player player, Packet packet)
        {
            int npcId = packet.readUShort();
            if (npcId < 0 || npcId > NpcData.getTotalNpcDefinitions() || player.isDead() || player.getTemporaryAttribute("cantDoAnything") != null)
                return;

            player.getPackets().sendMessage(NpcData.forId(npcId).getExamine());
        }

	    private void handleMagicOnNPC(Player player, Packet packet) {
		    int childId = packet.readLEShort();
		    int interfaceId = packet.readLEShort();
		    int junk = packet.readShortA();
	        int npcIndex = packet.readLEShortA();
		    if (npcIndex < 0 || npcIndex > Constants.MAX_NPCS || player.isDead() || player.getTemporaryAttribute("cantDoAnything") != null) {
			    return;
		    }
		    Npc npc = Server.getNpcList()[npcIndex];
		    if (npc == null || npc.isDestroyed()) {
			    return;
		    }
		    SkillHandler.resetAllSkills(player);
		    player.setTarget(npc);
		    MagicCombat.newMagicAttack(player, npc, childId, interfaceId == 193);
		    Console.WriteLine(childId);
	    }
	
	    private void handleItemOnNPC(Player player, Packet packet) {
		    int interfaceId = packet.readInt();
		    int slot = packet.readLEShort();
		    int npcIndex = packet.readLEShort();
		    int item = packet.readLEShortA();
		    if (npcIndex < 0 || npcIndex > Constants.MAX_NPCS || player.isDead() || player.getTemporaryAttribute("cantDoAnything") != null) {
			    return;
		    }
            Npc npc = Server.getNpcList()[npcIndex];
            if (npc == null || npc.isDestroyed()) {
                return;
            }
		    SkillHandler.resetAllSkills(player);
		    player.getPackets().closeInterfaces();
		    Console.WriteLine("Item on NPC " + npc.getId());
		    if (player.getInventory().getItemInSlot(slot) == item) {
			    switch(npc.getId()) {
				    case 519: // Bob
					    BrokenBarrows.talkToBob(player, npc, player.getInventory().getItemInSlot(slot), 0);
					    break;
			    }
		    }
	    }
    }
}
