using System.Linq;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ObjectData;
using PureSkyblock.Content.Items.Placeable;
﻿using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria.Enums;

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
            else if (type == TileID.Trees)
            {
                if (Main.rand.NextBool(3))
                {
                    Item.NewItem(null, new Vector2(i * 16, j * 16), ModContent.ItemType<LeafBlock>());
                }
            }
        }


        public override void Load() => IL_WorldGen.ShakeTree += ModifyForestTreeShakeDrops;
        private void ModifyForestTreeShakeDrops(ILContext il)
        {
            ILCursor c = new(il);

            c.GotoNext(MoveType.After, x => x.MatchCall(typeof(PlantLoader), nameof(PlantLoader.ShakeTree)));

            c.Emit(OpCodes.Ldloc_0); // x
            c.Emit(OpCodes.Ldloc_1); // y
            c.Emit(OpCodes.Ldloc_3); // treeType
            c.EmitDelegate(HookShakeTree);
        }
        private static void HookShakeTree(int x, int y, TreeTypes treeType)
        {
            int type = Main.tile[x, y].TileType;

            if (type > TileID.Count)
                return;

            if (treeType == TreeTypes.Forest)
            {
                Item.NewItem(null, new Vector2(x * 16, y * 16), ItemID.Acorn);
            }

        }
    }
}