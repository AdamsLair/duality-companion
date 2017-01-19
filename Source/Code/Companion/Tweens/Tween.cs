// TinyTween.cs
//
// Orginal source: https://gist.github.com/nickgravelyn/4953988
// Copyright (c) 2013 Nick Gravelyn
//
// Source adjusted for Duality

using Duality.Drawing;
using System;

namespace Duality.Plugins.Companion.Tweens
{
	// <summary>
	/// Takes in progress which is the percentage of the tween complete and returns
	/// the interpolation value that is fed into the lerp function for the tween.
	/// </summary>
	/// <remarks>
	/// Scale functions are used to define how the tween should occur. Examples would be linear,
	/// easing in quadratic, or easing out circular. You can implement your own scale function
	/// or use one of the many defined in the ScaleFuncs static class.
	/// </remarks>
	/// <param name="progress">The percentage of the tween complete in the range [0, 1].</param>
	/// <returns>The scale value used to lerp between the tween's start and end values</returns>
	public delegate float ScaleFunc(float progress);

	/// <summary>
	/// Standard linear interpolation function: "start + (end - start) * progress"
	/// </summary>
	/// <remarks>
	/// In a language like C++ we wouldn't need this delegate at all. Templates in C++ would allow us
	/// to simply write "start + (end - start) * progress" in the tween class and the compiler would
	/// take care of enforcing that the type supported those operators. Unfortunately C#'s generics
	/// are not so powerful so instead we must have the user provide the interpolation function.
	///
	/// Thankfully frameworks like XNA and Unity provide lerp functions on their primitive math types
	/// which means that for most users there is nothing specific to do here. Additionally this file
	/// provides concrete implementations of tweens for vectors, colors, and more for XNA and Unity
	/// users, lessening the burden even more.
	/// </remarks>
	/// <typeparam name="T">The type to interpolate.</typeparam>
	/// <param name="start">The starting value.</param>
	/// <param name="end">The ending value.</param>
	/// <param name="progress">The interpolation progress.</param>
	/// <returns>The interpolated value, generally using "start + (end - start) * progress"</returns>
	public delegate T LerpFunc<T>(T start, T end, float progress);

	// <summary>
	/// A concrete implementation of a tween object.
	/// </summary>
	/// <typeparam name="T">The type to tween.</typeparam>
	public class Tween<T> : ITween<T> where T : struct
	{
		private readonly LerpFunc<T> lerpFunc;

		private float currentTime;
		private float duration;
		private ScaleFunc scaleFunc;
		private TweenState state;

		private T start;
		private T end;
		private T value;

		/// <summary>
		/// Gets the current time of the tween.
		/// </summary>
		public float CurrentTime { get { return currentTime; } }

		/// <summary>
		/// Gets the duration of the tween.
		/// </summary>
		public float Duration { get { return duration; } }

		/// <summary>
		/// Gets the current state of the tween.
		/// </summary>
		public TweenState State { get { return state; } }

		/// <summary>
		/// Gets the starting value of the tween.
		/// </summary>
		public T StartValue { get { return start; } }

		/// <summary>
		/// Gets the ending value of the tween.
		/// </summary>
		public T EndValue { get { return end; } }

		/// <summary>
		/// Gets the current value of the tween.
		/// </summary>
		public T CurrentValue { get { return value; } }

		/// <summary>
		/// Initializes a new Tween with a given lerp function.
		/// </summary>
		/// <remarks>
		/// C# generics are good but not good enough. We need a delegate to know how to
		/// interpolate between the start and end values for the given type.
		/// </remarks>
		/// <param name="lerpFunc">The interpolation function for the tween type.</param>
		public Tween(LerpFunc<T> lerpFunc)
		{
			this.lerpFunc = lerpFunc;
			state = TweenState.Stopped;
		}

		/// <summary>
		/// Starts a tween.
		/// </summary>
		/// <param name="start">The start value.</param>
		/// <param name="end">The end value.</param>
		/// <param name="duration">The duration of the tween.</param>
		/// <param name="scaleFunc">A function used to scale progress over time.</param>
		public void Start(T start, T end, float duration, Easing easing)
		{
			if (duration <= 0)
			{
				throw new ArgumentException("duration must be greater than 0");
			}

			switch (easing)
			{
				case Easing.Linear:
					this.scaleFunc = ScaleFuncs.Linear;
					break;

				case Easing.CubicEaseIn:
					this.scaleFunc = ScaleFuncs.CubicEaseIn;
					break;

				case Easing.CubicEaseOut:
					this.scaleFunc = ScaleFuncs.CubicEaseOut;
					break;

				case Easing.CubicEaseInOut:
					this.scaleFunc = ScaleFuncs.CubicEaseInOut;
					break;

				case Easing.QuadraticEaseIn:
					this.scaleFunc = ScaleFuncs.QuadraticEaseIn;
					break;

				case Easing.QuadraticEaseOut:
					this.scaleFunc = ScaleFuncs.QuadraticEaseOut;
					break;

				case Easing.QuadraticEaseInOut:
					this.scaleFunc = ScaleFuncs.QuadraticEaseInOut;
					break;

				case Easing.QuarticEaseIn:
					this.scaleFunc = ScaleFuncs.QuarticEaseIn;
					break;

				case Easing.QuarticEaseOut:
					this.scaleFunc = ScaleFuncs.QuarticEaseOut;
					break;

				case Easing.QuarticEaseInOut:
					this.scaleFunc = ScaleFuncs.QuarticEaseInOut;
					break;

				case Easing.SineEaseIn:
					this.scaleFunc = ScaleFuncs.SineEaseIn;
					break;

				case Easing.SineEaseOut:
					this.scaleFunc = ScaleFuncs.SineEaseOut;
					break;

				case Easing.SineEaseInOut:
					this.scaleFunc = ScaleFuncs.SineEaseInOut;
					break;

				default:
					this.scaleFunc = ScaleFuncs.Linear;
					break;
			}

			currentTime = 0;
			this.duration = duration;

			state = TweenState.Running;

			this.start = start;
			this.end = end;

			UpdateValue();
		}

		/// <summary>
		/// Pauses the tween.
		/// </summary>
		public void Pause()
		{
			if (state == TweenState.Running)
			{
				state = TweenState.Paused;
			}
		}

		/// <summary>
		/// Resumes the paused tween.
		/// </summary>
		public void Resume()
		{
			if (state == TweenState.Paused)
			{
				state = TweenState.Running;
			}
		}

		/// <summary>
		/// Stops the tween.
		/// </summary>
		/// <param name="stopBehavior">The behavior to use to handle the stop.</param>
		public void Stop(StopBehavior stopBehavior)
		{
			state = TweenState.Stopped;

			if (stopBehavior == StopBehavior.ForceComplete)
			{
				currentTime = duration;
				UpdateValue();
			}
		}

		/// <summary>
		/// Updates the tween.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time to add to the tween.</param>
		public void Update(float elapsedTime)
		{
			if (state != TweenState.Running)
			{
				return;
			}

			currentTime += elapsedTime;
			if (currentTime >= duration)
			{
				currentTime = duration;
				state = TweenState.Stopped;
			}

			UpdateValue();
		}

		/// <summary>
		/// Helper that uses the current time, duration, and delegates to update the current value.
		/// </summary>
		private void UpdateValue()
		{
			if (scaleFunc != null)
				value = lerpFunc(start, end, scaleFunc(currentTime / duration));
		}
	}
}