using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duality.Plugins.Companion
{
	public static class Timer
	{
		public delegate void TimerElapsedEventDelegate();

		internal struct TimerInstance
		{
			internal float Interval;
			internal float Elapsed;

			internal uint RepeatsLeft;

			internal bool IsRealTime;
			internal bool IsActive;

			internal bool IsExpired;
			internal TimerElapsedEventDelegate OnTimerElapsedHandler;
		}

		private static Dictionary<object, TimerInstance> _instances = new Dictionary<object, TimerInstance>();

		internal static void OnUpdate()
		{
			float lastDeltaRealtime = Time.LastDelta;
			float lastDeltaGameTime = Time.MsPFMult * Time.TimeMult;

			for(int i = 0; i < _instances.Values.Count; i++)
			{
				TimerInstance timer = _instances.Values.ElementAt(i);

				timer.IsExpired = false;
				if (timer.IsRealTime) timer.Elapsed += lastDeltaRealtime;
				else timer.Elapsed += lastDeltaGameTime;

				if(timer.Elapsed >= timer.Interval)
				{
					timer.Elapsed -= timer.Interval;
					timer.IsExpired = true;

					if (timer.OnTimerElapsedHandler != null) timer.OnTimerElapsedHandler();
					if (--timer.RepeatsLeft == 0) timer.IsActive = false;
				}
			}
		}

		/// <summary>
		/// Add a Timer to the managed list
		/// </summary>
		/// <param name="key">The key of the Timer</param>
		/// <param name="interval">The interval in milliseconds after which the Timer will fire</param>
		/// <param name="handler">The handler function that is called after the Timer fires</param>
		/// <param name="realTime">If true, the Timer will count time based on real time clock, instead of in-game one. Defaults to false</param>
		/// <param name="repeats">The maximum amount of times the Timer will fire before stopping. Defaults to 1</param>
		public static void AddTimer(object key, float interval, TimerElapsedEventDelegate handler, bool realTime = false, uint repeats = 1)
		{
			_instances[key] = new TimerInstance()
			{
				Interval = interval,
				Elapsed = 0,
				RepeatsLeft = repeats,
				IsRealTime = realTime,
				IsActive = true,
				IsExpired = false,
				OnTimerElapsedHandler = handler
			};
		}

		/// <summary>
		/// Remove a Timer from the managed list, if present
		/// </summary>
		/// <param name="key">The key of the Timer</param>
		public static void RemoveTimer(object key)
		{
			_instances.Remove(key);
		}

		/// <summary>
		/// Sets a Timer as Active
		/// </summary>
		/// <param name="key">The key of the Timer</param>
		public static void StartTimer(object key)
		{
			TimerInstance timer;

			if (_instances.TryGetValue(key, out timer))
			{
				timer.IsActive = true;
			}
		}

		/// <summary>
		/// Sets a Timer as Inactive. The elapsed time will not be lost.
		/// </summary>
		/// <param name="key">The key of the Timer</param>
		public static void StopTimer(object key)
		{
			TimerInstance timer;

			if (_instances.TryGetValue(key, out timer))
			{
				timer.IsActive = false;
			}
		}

		/// <summary>
		/// Sets a Timer as Inactive. The elapsed time will be lost.
		/// </summary>
		/// <param name="key">The key of the Timer</param>
		public static void ClearTimer(object key)
		{
			TimerInstance timer;

			if (_instances.TryGetValue(key, out timer))
			{
				timer.IsActive = false;
				timer.Elapsed = 0;
			}
		}

		/// <summary>
		/// Indicates if a Timer fired in the current frame.
		/// </summary>
		/// <param name="key">The key of the Timer</param>
		/// <returns>True if the Timer fired in this frame. False otherwise</returns>
		public static bool IsExpired(object key)
		{
			bool result = false;

			TimerInstance timer;

			if (_instances.TryGetValue(key, out timer))
			{
				result = timer.IsExpired;
			}

			return result;
		}

		/// <summary>
		/// Returns the amount of time passed relative to the whole interval of a Timer.
		/// </summary>
		/// <param name="key">The key of the Timer</param>
		/// <returns>A value between 0 (inclusive) and 1 (exclusive)</returns>
		public static float GetCompletion(object key)
		{
			float result = 0;

			TimerInstance timer;

			if (_instances.TryGetValue(key, out timer))
			{
				result = timer.Elapsed / timer.Interval;
			}

			return result;
		}
	}
}
