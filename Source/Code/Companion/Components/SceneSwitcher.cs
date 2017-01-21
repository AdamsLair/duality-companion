using System;
using Duality.Drawing;
using Duality.Editor;
using Duality.Plugins.Companion.Tweens;
using Duality.Resources;

namespace Duality.Plugins.Companion.Components
{
	[EditorHintCategory (ResNames.ComponentsEditorCategory)]
	public class SceneSwitcher : Component
	{
		[EditorHintFlags(MemberFlags.Invisible)]
		public EventHandler<SceneSwitchEventArgs> Switched
		{
			get { return switched; }
			set { switched = value; }
		}

		[DontSerialize]
		private EventHandler<SceneSwitchEventArgs> switched;

		[DontSerialize]
		private bool isSwitching = false;

		public void Switch(ContentRef<Scene> nextScene, float duration, ColorRgba color, Easing easing = Easing.Linear)
		{
			if (!isSwitching)
			{
				isSwitching = true;

				var faderOut = GameObj.AddComponent<ColorFader>();
				faderOut.FadeOut(duration / 2f, color, easing);

				var faderIn = new GameObject("ColorFader").AddComponent<ColorFader>();
				faderIn.FadeIn(duration / 2f, color, easing);

				faderOut.Faded += delegate
				{
					if (nextScene != null)
					{
						nextScene.Res.AddObject(faderIn.GameObj);

						Scene.SwitchTo(nextScene);
						isSwitching = false;

						faderIn.Faded += delegate
						{
							faderIn.GameObj.DisposeLater();
						};
					}
				};
			}
		}
	}

	public class SceneSwitchEventArgs : EventArgs
	{
		public ContentRef<Scene> NextScene
		{
			get { return nextScene; }
			set { nextScene = value; }
		}

		private ContentRef<Scene> nextScene;

		public SceneSwitchEventArgs(ContentRef<Scene> nextScene)
		{
			this.nextScene = nextScene;
		}
	}
}