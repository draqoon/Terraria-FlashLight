namespace Flashlight.Projectiles {

	public class LightWave: LesserLightWave {

		public override void SetDefaults() {
			base.SetDefaults();
			this.Projectile.light = 15.0f;
			this.Projectile.timeLeft = 20;
		}

	}
}
