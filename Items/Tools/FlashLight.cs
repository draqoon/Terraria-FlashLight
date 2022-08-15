using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Flashlight.Projectiles;

namespace Flashlight.Items.Tools {
    public class FlashLight : LesserFlashLight {
        public override void SetStaticDefaults() {
            this.DisplayName.SetDefault( "Flash Light" );
            this.Tooltip.SetDefault( "Flash light that uses gel as fuel" );
            Item.staff[this.Item.type] = true;
        }

        public override void SetDefaults() {
            base.SetDefaults();

            Item.rare = ItemRarityID.Yellow;
            Item.shoot = ModContent.ProjectileType<LightWave>();
            this.Item.value = Item.buyPrice( 0, 50, 0, 0 );
        }

        protected override int ConsumeAmmoInterval => base.ConsumeAmmoInterval * 2;

        public override void AddRecipes() {
            this.CreateRecipe()
                .AddIngredient<LesserFlashLight>()
                .AddRecipeGroup( RecipeGroup.recipeGroupIDs["AnyCobaltBar"], 10 )
                .AddIngredient( ItemID.Gel, 300 )
                .AddIngredient( ItemID.Wire, 300 )
                .AddTile( TileID.MythrilAnvil )
                .Register();
        }
    }
}