using Duality.Editor;
using Duality.Input;
using Duality.Plugins.Companion.Audio;
using Duality.Resources;

namespace Duality.Plugins.Companion.Samples
{
	[EditorHintCategory (ResNames.SampleComponentCategory)]
    public class AudioPlayerSample : Component, ICmpUpdatable
    {
	    public void OnUpdate ()
	    {
		    if (DualityApp.Keyboard.KeyHit (Key.Q))
			{
			    AudioManager.PlayMusic ("music_01");
		    }
			else if (DualityApp.Keyboard.KeyHit (Key.W))
			{
			    AudioManager.PlayMusic ("music_02");
		    }
			else if (DualityApp.Keyboard.KeyHit (Key.E))
			{
			    AudioManager.PlaySfx ("Pickup");
		    }
			else if (DualityApp.Keyboard.KeyHit (Key.R))
			{
				AudioManager.StopMusic (5f);
			}
			else if (DualityApp.Keyboard.KeyHit (Key.T))
			{
			    Scene.SwitchTo (DualityApp.AppData.StartScene);
		    }
		}
    }
}
