using Duality.Plugins.Companion.Drawing;
using Duality.Resources;

namespace Duality.Plugins.Companion.Samples
{
	public class CompanionSamplesPlugin : CorePlugin
	{
        protected override void InitPlugin()
        {
            base.InitPlugin();
            SplashScreen.Register(Colors.DarkOliveGreen, "Checkerboard", "DualityIcon", "Checkerboard");
        }
    }
}
