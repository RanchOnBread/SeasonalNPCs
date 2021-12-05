using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace SeasonalNPCs.NPCs
{
    [AutoloadHead]
    public class ChristmasNPC : ModNPC
    {
        public override string Texture {
            get { return "SeasonalNPCs/NPCs/ChristmasNPC"; }
        }

        public override bool Autoload(ref string name)
        {
            name = "Christmerchant";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 26;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 5;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7; 
            npc.damage = 12;
            npc.defense = 17;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public override string TownNPCName()
        {
            switch(WorldGen.genRand.Next(4))
            {
                case 0:
                    return "Cocoa";
                case 1:
                    return "Jingle";
                case 2:
                    return "Ornamer";
                default: 
                    return "Jolly";
            }
        }

        public override string GetChat()
        {
            int otherNPC = NPC.FindFirstNPC(NPCID.Merchant);
            if(otherNPC >= 0 && Main.rand.NextBool(4))
            {
                return "Why can't " + Main.npc[otherNPC].GivenName + " be just a bit more festive?";
            }
              switch(Main.rand.Next(4))
            {
                case 0:
                    return "Why can't Christmas be every day?";
                case 1:
                    return "Wish I had some hot chocolate right about now.";
                case 2:
                    return "Nothing beats the smell of a fresh Christmas tree!";
                case 3:
                    return "Sorry bud, but your item might be stuck in a loose present!";
                default:
                    return "It's cold, but it can be colder!";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");      
            button2 = "Give me a quote";     
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if(firstButton)
            {
                // This is makes it a shop
                shop = true;
            }
            else
            {              
                Main.npcChatText = RandomPhrase();
            }
        }

       public string RandomPhrase()
       {
            switch(Main.rand.Next(6))
            {
                case 0:
                    return "Criket Wireless.";
                case 1:
                    return "Im going to make the spotlight for us to battle the big guy.";
                case 2:
                    return "The toast was a fluke.";
                case 3:
                    return "Im wondering whether to have the hunters cloak over the grim sandwhich!";
                case 4:
                    return "Im going to HP PhotoSmart this.";
                default:
                    return "The bacon tree is where people find themselves.";
            }       
       }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ItemID.Present);
            shop.item[nextSlot].value = 20000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.ChristmasTree);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.SugarCookie);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Holly);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.ReindeerAntlers);
            shop.item[nextSlot].value = 10000;
            nextSlot++;
            if(Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.HandWarmer);
                shop.item[nextSlot].value = 500000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.CnadyCanePickaxe);
                shop.item[nextSlot].value = 100000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Toolbox);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.RedRyder);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.SnowGlobe);
                shop.item[nextSlot].value = 300000;
                nextSlot++;
            }
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Present);
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 26;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 20;
            randExtraCooldown = 25;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.SnowBallFriendly;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 5f;
            randomOffset = 1f;
        }
    }
}