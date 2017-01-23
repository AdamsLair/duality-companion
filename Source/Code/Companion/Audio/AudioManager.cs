using System;
using Duality.Audio;
using Duality.Resources;

namespace Duality.Plugins.Companion.Audio
{
	/// <summary>
	/// Playing one-hit sound effects and looped music, optionally from a dedicated sound resource directory.
	/// </summary>
	public static class AudioManager
	{
		private const string soundExt = ".Sound.res";

		private static string sfxPath = @"Data\SFX";
		private static string musicPath = @"Data\Music";
		private static SoundInstance musicInstance;

		/// <summary>
		/// The path of the folder in which the sound effect resources are being searched.
		/// Default location is 'Data\SFX'.
		/// </summary>
		public static string SfxPath
		{
			get { return sfxPath; }
			set { sfxPath = value; }
		}

		/// <summary>
		/// The path of the folder in which the music sound resources are being searched.
		/// Default location is 'Data\Music'.
		/// </summary>
		public static string MusicPath
		{
			get { return musicPath; }
			set { musicPath = value; }
		}

		/// <summary>
		/// Plays an one-shot sound effect.
		/// </summary>
		/// <param name="sound">The sound resource to play.</param>
		/// <param name="volume">The playback volume of sound to play. Ranging from 0f to 1f.</param>
		/// <param name="panning">The panning position of the sound to play. Ranging from -1f (left) to 1f (right).</param>
		public static void PlaySfx (ContentRef<Sound> sound, float volume = 1f, float panning = 0f)
		{
			SoundInstance soundInstance = DualityApp.Sound.PlaySound (sound);
			soundInstance.Volume = volume;
			soundInstance.Panning = panning;
		}

		/// <summary>
		/// Plays an one-shot sound effect from the resource directory located at <see cref="SfxPath"/>.
		/// </summary>
		/// <param name="name">The resource file name, without extension.
		/// For example, if you want to play 'Data\SFX\Hit.Sound.res', than name should be 'Hit'.</param>
		/// <param name="volume">The playback volume of sound to play. Ranging from 0f to 1f.</param>
		/// <param name="panning">The panning position of the sound to play. Ranging from -1f (left) to 1f (right).</param>
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

		/// <summary>
		/// Plays a music/ambience/etc. sound. The previously played music fades out.
		/// </summary>
		/// <param name="music">The sound resource to play.</param>
		/// <param name="volume">The playback volume of sound to play. Ranging from 0f to 1f.</param>
		/// <param name="fadeSeconds">The time this piece takes to fade in, and the previous piece to fade out.</param>
		/// <param name="looped">Wheter the piece should be looped or not.</param>
		public static void PlayMusic (ContentRef<Sound> music, float volume = 1f, float fadeSeconds = 1f, bool looped = true)
		{
			if (musicInstance != null && !musicInstance.Paused)
			{
				musicInstance.FadeOut (fadeSeconds);
			}
			musicInstance = DualityApp.Sound.PlaySound (music);
			musicInstance.Looped = looped;
			musicInstance.BeginFadeIn (fadeSeconds);
		}

		/// <summary>
		/// Plays a music/ambience/etc. sound from the resource directory located at <see cref="MusicPath"/>.
		/// The previously played music fades out.
		/// </summary>
		/// <param name="name">The resource file name, without extension.
		/// For example, if you want to play 'Data\SFX\Music_01.Sound.res', than name should be 'Music_01'.</param>
		/// <param name="volume">The playback volume of sound to play. Ranging from 0f to 1f.</param>
		/// <param name="fadeSeconds">The time this piece takes to fade in, and the previous piece to fade out.</param>
		/// <param name="looped">Wheter the piece should be looped or not.</param>
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

		/// <summary>
		/// Fades out the currently played music piece.
		/// </summary>
		/// <param name="fadeSeconds">The time the fade out takes.</param>
		public static void StopMusic (float fadeSeconds = 1f)
		{
			if (musicInstance != null && !musicInstance.Paused)
			{
				musicInstance.FadeOut (fadeSeconds);
			}
		}
	}
}
