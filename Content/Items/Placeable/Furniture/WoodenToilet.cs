// using Terraria;
// using Terraria.ID;
// using Terraria.ModLoader;

// namespace PureSkyblock.Content.Items.Placeable.Furniture
// {
// 	public class WoodenToilet : ModItem
// 	{
// 		public override void SetDefaults() {
// 			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.WoodenToilet>());
// 			Item.width = 16;
// 			Item.height = 24;
// 			Item.value = 150;
// 		}

// 		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
// 		public override void AddRecipes() {
// 			CreateRecipe()
// 				.AddIngredient(ItemID.Wood, 10)
// 				.AddTile(TileID.Anvils)
// 				.Register();
// 		}
// 	}
// }