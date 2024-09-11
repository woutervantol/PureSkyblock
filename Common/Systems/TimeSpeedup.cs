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
	public class TimeSpeedup : ModSystem
    {
        public override void ModifyTimeRate(ref double timeRate, ref double tileUpdateRate, ref double eventUpdateRate)
        {
            Main.NewText($"timeRate: {timeRate}.");
           
        }
    }
}