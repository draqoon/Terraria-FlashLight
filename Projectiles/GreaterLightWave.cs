namespace Flashlight.Projectiles {

	public class GreaterLightWave: LesserLightWave {

		public override void SetDefaults() {
			base.SetDefaults();
			this.Projectile.light = 20.0f;
			this.Projectile.timeLeft = 40;
		}

	}
}
