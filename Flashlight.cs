using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Flashlight
{
    public class Flashlight : Mod
    {
        public override void Load() {
            base.Load();

            var rg = new RecipeGroup( () => "Any Cobalt Bar", ItemID.CobaltBar, ItemID.PalladiumBar );
            RecipeGroup.RegisterGroup( "AnyCobaltBar", rg );
        }
    }
}