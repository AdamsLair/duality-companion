using System;
using Duality.Audio;
using Duality.Resources;

namespace Duality.Plugins.Companion.Audio
{
	public static class AudioManager
	{
		private const string soundExt = ".Sound.res";

		private static string sfxPath = @"Data\SFX";
		private static string musicPath = @"Data\Music";
		private static SoundInstance musicInstance;

		public static string SfxPath
		{
			get { return sfxPath; }
			set { sfxPath = value; }
		}

		public static string MusicPath
		{
			get { return musicPath; }
			set { musicPath = value; }
		}

		public static void PlaySfx (ContentRef<Sound> sound, float volume = 1f, float panning = 0f)
		{
			SoundInstance soundInstance = DualityApp.Sound.PlaySound (sound);
			soundInstance.Volume = volume;
			soundInstance.Panning = panning;
		}

		public static void PlaySfx (string name, float volume = 1f, float panning = 0f)
		{
			string path = sfxPath + @"\" + name + soundExt;
			ContentRef<Sound> sound = ContentProvider.RequestContent<Sound> (path);
			if (!sound.IsAvailable)
			{
				throw new ArgumentException (string.Format ("Sound resource not found at '{0}'", path));
			}
			PlaySfx (sound, volume, panning);
		}

		public static void PlayMusic (ContentRef<Sound> music, float volume = 1f, float fadeSeconds = 1f, bool looped = true)
		{
			if (musicInstance != null && !musicInstance.Paused)
			{
				musicInstance.FadeOut (fadeSeconds);
			}
			musicInstance = DualityApp.Sound.PlaySound (music);
			musicInstance.Looped = looped;
			musicInstance.Volume = 0f;
			musicInstance.FadeTo (volume, fadeSeconds);
		}

		public static void PlayMusic (string name, float volume = 1f, float fadeSeconds = 1f, bool looped = true)
		{
			string path = musicPath + @"\" + name + soundExt;
			ContentRef<Sound> music = ContentProvider.RequestContent<Sound> (path);
			if (!music.IsAvailable)
			{
				throw new ArgumentException(string.Format("Sound resource not found at '{0}'", path));
			}
			PlayMusic (music, volume, fadeSeconds, looped);
		}

		public static void StopMusic (float fadeSeconds = 1f)
		{
			if (musicInstance != null && !musicInstance.Paused)
			{
				musicInstance.FadeOut (fadeSeconds);
			}
		}
	}
}
