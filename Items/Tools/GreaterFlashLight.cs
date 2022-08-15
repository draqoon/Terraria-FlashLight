using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Flashlight.Projectiles;

namespace Flashlight.Items.Tools {
    public class GreaterFlashLight : LesserFlashLight {
        public override void SetStaticDefaults() {
            this.DisplayName.SetDefault( "Greater Flash Light" );
            this.Tooltip.SetDefault( "Greater Flash light that uses gel as fuel" );
            Item.staff[this.Item.type] = true;
        }

        public override void SetDefaults() {
            base.SetDefaults();

            Item.rare = ItemRarityID.Purple;
            Item.shoot = ModContent.ProjectileType<GreaterLightWave>();
            this.Item.value = Item.buyPrice( 5, 0, 0, 0 );
        }

        protected override int ConsumeAmmoInterval => base.ConsumeAmmoInterval * 3;

        public override void AddRecipes() {
            this.CreateRecipe()
                .AddIngredient<FlashLight>()
                .AddIngredient( ItemID.LunarBar, 10 )
                .AddIngredient( ItemID.Gel, 999 )
                .AddIngredient( ItemID.Wire, 999 )
                .AddTile( TileID.LunarCraftingStation )
                .Register();
        }
    }
}