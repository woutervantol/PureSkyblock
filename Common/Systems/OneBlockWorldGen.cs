using System.Collections.Generic;
using Terraria;
using Terraria.IO;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PureSkyblock.Common.Systems
{
	// This example shows spawning rubble tiles during world generation.
	public class OneBlockWorldGen : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            foreach (GenPass genpass in tasks)
            {
                genpass.Disable();
            }
        }

        public override void PostWorldGen()
        {
            // TileID.Grass = 2
            WorldUtils.Gen(new Point(Main.spawnTileX, Main.spawnTileY), new Shapes.Rectangle(2, 1), new Actions.SetTile(TileID.Grass));
            WorldUtils.Gen(new Point(Main.spawnTileX, Main.spawnTileY-1), new Shapes.Rectangle(1, 1), new Actions.PlaceTile(TileID.Saplings));
            bool success = false;
            int attempts = 0;
            while (!success)
            {
                attempts++;
                if (attempts>1000)
                {
                    break;
                }
                success = WorldGen.AttemptToGrowTreeFromSapling(Main.spawnTileX, Main.spawnTileY-1, false);
                // success = grown != -1;
            }
            WorldUtils.Gen(new Point(Main.spawnTileX+1, Main.spawnTileY-1), new Shapes.Rectangle(1, 2), new Actions.ClearTile());
            

            
        }
    }
}