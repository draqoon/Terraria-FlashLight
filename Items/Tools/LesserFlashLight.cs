using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Flashlight.Projectiles;

namespace Flashlight.Items.Tools {
    public class LesserFlashLight : ModItem {
        public override void SetStaticDefaults() {
            this.DisplayName.SetDefault( "Lesser Flash Light" );
            this.Tooltip.SetDefault( "Lesser flash light that uses gel as fuel" );
            Item.staff[this.Item.type] = true;
        }

        public override void SetDefaults() {
            // Common Properties
            Item.width = 40;
            Item.height = 40;
            Item.rare = ItemRarityID.Pink;

            // Use Properties
            Item.useTime = 3; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 3; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            // Weapon Properties
            Item.DamageType = DamageClass.Default;
            Item.damage = 0;
            Item.knockBack = 0f;
            Item.noMelee = true;

            // Other Properties
            Item.shoot = ModContent.ProjectileType<LesserLightWave>();
            Item.shootSpeed = 25f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = AmmoID.Gel;

            this.Item.value = Item.buyPrice( 0, 5, 0, 0 );
        }

        public override Vector2? HoldoutOrigin() {
            return new Vector2( 15f, 15f );
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            for( var i = 0; i < 3; i++ ) {
                var newVelocity = Utils.RotatedBy( velocity, (double)MathHelper.ToRadians( (i - 1) * 3 ) );
                Projectile.NewProjectile( source, position, newVelocity, type, damage, knockback, player.whoAmI, 0f, 0f );
            }

            return false;
        }

        protected virtual int ConsumeAmmoInterval => 5;
        private int ShootCount { get; set; } = 0;

        public override bool CanConsumeAmmo( Item ammo, Player player ) {
            this.ShootCount += 1;
            if( this.ConsumeAmmoInterval < this.ShootCount ) {
                this.ShootCount = 0;
                return true;
            }
            return false;

        }

        public override void AddRecipes() {
            this.CreateRecipe()
                .AddRecipeGroup( RecipeGroupID.IronBar, 10 )
                .AddIngredient( ItemID.Gel, 100 )
                .AddIngredient( ItemID.Wire, 100 )
                .AddTile( TileID.Anvils )
                .Register();
        }
    }
}