using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PureSkyblock.Common.GlobalItems
{
    // This is another part of the ExampleShiftClickSlotPlayer.cs that adds a tooltip line to the gel
    public class DirtRecipeGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.DirtBlock;

        public override void AddRecipes()
        {
            Recipe.Create(ItemID.DirtBlock)
                .AddIngredient(ModContent.ItemType<Content.Items.Placeable.LeafBlock>(), 4)
                .AddTile(ModContent.TileType<Content.Tiles.Furniture.Composter>())
                .Register();
        }
    }
}