using Terraria.ID;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using SeasonalNPCs.NPCs;
using Microsoft.Xna.Framework;

namespace SeasonalNPCs.Items
{
	public class RadioPresent : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault(""); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Summons the Christmerchant");
		}

		public override void SetDefaults() 
		{
		    item.useTime = 28;
			item.useTurn = true;
			item.useStyle = 1;
            item.useAnimation = 45;
			item.autoReuse = false;
			item.UseSound = SoundID.Item37;
			
			item.width = 25;
            item.height = 25;
            item.rare = 3;
            item.value = 200;
            item.maxStack = 1;
			item.consumable = true;
		}

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType("ChristmasNPC"));
        }

        public override bool UseItem(Player player) 
        { 
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.ChristmasNPC>());
            return true;
        }

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SnowBlock, 30);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddRecipeGroup("IronBar", 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}