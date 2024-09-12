using System.Linq;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ObjectData;
using PureSkyblock.Content.Items.Placeable;

namespace PureSkyblock.Common.GlobalTiles
{
	// This example uses a GlobalTile to affect the properties of an existing tile.
	// Tweaking existing tiles is doable to some degree.
	public class TreeDrops : GlobalTile
	{
        //This will cause trees to have a 5% chance of dropping gold ore
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (type == TileID.Trees && !fail)
            {
                //We MUST check for fail to be false, as KillTile is actually called every time a tile is hit by an axe/pickaxe.  We only want to give ore when the tile is mined.
                
                Item.NewItem(null, new Vector2(i * 16, j * 16), ModContent.ItemType<LeafBlock>()); //Replace ItemID.GoldOre with ModContent.ModItem<YourItemType>() to spawn a modded item.
                
            }
        }
	}
}