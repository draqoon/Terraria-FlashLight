using System;
using Terraria.ID;
using Terraria.ModLoader;

namespace Flashlight.Projectiles;
public class LesserLightWave : ModProjectile {

    public override void SetDefaults() {
        this.Projectile.alpha = 255;
        this.Projectile.width = 200;
        this.Projectile.height = 100;
        this.Projectile.aiStyle = -1;
        this.Projectile.light = 10.0f;
        this.Projectile.friendly = true;
        this.Projectile.tileCollide = false;
        this.Projectile.penetrate = -1;
        this.Projectile.timeLeft = 10;
        this.Projectile.ignoreWater = true;
        this.AIType = ProjectileID.LastPrismLaser;
    }

    public override void AI() {
        if( this.Projectile.alpha > 0 )
            this.Projectile.alpha -= 15;
        if( this.Projectile.alpha < 0 )
            this.Projectile.alpha = 0;

        this.Projectile.rotation = (float)Math.Atan2( this.Projectile.velocity.Y, this.Projectile.velocity.X ) + 1.57f;
    }

    public override bool? CanCutTiles() => false;

}
