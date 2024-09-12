using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace PureSkyblock.Content.Tiles.Furniture;

public class Composter : ModTile
{
    public override void SetStaticDefaults()
    {
        // Properties
        Main.tileTable[Type] = true;
        Main.tileSolidTop[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;
        TileID.Sets.IgnoredByNpcStepUp[Type] = true; // This line makes NPCs not try to step up this tile during their movement. Only use this for furniture with solid tops.

        AdjTiles = new int[] { TileID.WorkBenches };

        // Placement
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        TileObjectData.newTile.CoordinateHeights = new[] {16, 18};
        // TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, -2);
        TileObjectData.addTile(Type);
    }
}