using System;
using Duality.Components;

namespace Duality.Plugins.Companion.Components
{
	[RequiredComponent (typeof(Camera))]
	public class CameraShaker : Component, ICmpUpdatable
	{
		/// <summary>
		/// Takes a time, defined as a float value, and returns a Vector2 which represents
		/// the camera displacement.
		/// To avoid side effects with the other parameters, the resulting Vector's components
		/// should be in the range [-1, 1].
		/// </summary>
		public delegate Vector2 ShakeGenerator (float time);

		/// <summary>
		/// The type of shaking
		/// </summary>
		public enum ShakeDirection
		{
			/// <summary>
			/// Left-Right - implemented as a cosine function.
			/// </summary>
			Horizontal,

			/// <summary>
			/// Up-Down - implemented as a cosine function.
			/// </summary>
			Vertical,

			/// <summary>
			/// Spiral-like - implemented as a cosine function on the X and a sine on the Y.
			/// </summary>
			Circular
		}

		[DontSerialize] private float          damping;
		[DontSerialize] private ShakeGenerator generator;
		[DontSerialize] private Vector2        lastShake;
		[DontSerialize] private uint           speed;
		[DontSerialize] private float          strength;

		void ICmpUpdatable.OnUpdate ()
		{
			if (this.generator != null)
			{
				this.GameObj.Transform.MoveBy (-this.lastShake);

				this.lastShake = this.generator ((float)Time.GameTimer.TotalSeconds * this.speed) * this.strength;
				this.strength -= this.damping * Time.SPFMult * Time.TimeMult;

				if (this.strength <= 1f)
				{
					this.generator = null;
					this.lastShake = Vector2.Zero;
				}
				else
				{
					this.GameObj.Transform.MoveBy (this.lastShake);
				}
			}
		}

		/// <summary>
		/// Adds a shake to the camera. If the previous shaking is not complete, the remaining strength
		/// will combine with the new one.
		/// </summary>
		/// <param name="direction">The direction of the shake.</param>
		/// <param name="strength">
		/// The strength of the shake, or how many pixels it will move at most in one direction (assuming
		/// the shake function stays in its default range of [-1, 1]). Defaults to 10.
		/// </param>
		/// <param name="time">How long, in seconds, the shake should last. Defaults to .5.</param>
		/// <param name="speed">The speed of the shake. The lower, the less the camera will shake. Defaults to 100.</param>
		public void Shake (ShakeDirection direction = ShakeDirection.Horizontal, uint strength = 10, float time = .5f, uint speed = 100)
		{
			switch (direction)
			{
				case ShakeDirection.Horizontal:
					Shake (t => new Vector2 (MathF.Cos (t), 0), strength, time, speed);
					break;

				case ShakeDirection.Vertical:
					Shake (t => new Vector2 (0, MathF.Cos (t)), strength, time, speed);
					break;

				case ShakeDirection.Circular:
					Shake (t => new Vector2 (MathF.Sin (t), MathF.Cos (t)), strength, time, speed);
					break;

				default:
					throw new ArgumentOutOfRangeException ("Unexpected case");
			}
		}

		/// <summary>
		/// Adds a shake to the camera. If the previous shaking is not complete, the remaining strength
		/// will combine with the new one.
		/// This requires a custom implementation of the generator function.
		/// </summary>
		/// <param name="generator">The function that generates displacement based on time.</param>
		/// <param name="strength">
		/// The strength of the shake, or how many pixels it will move at most in one direction (assuming
		/// the shake function stays in its default range of [-1, 1]).
		/// </param>
		/// <param name="time">How long, in seconds, the shake should last.</param>
		/// <param name="speed">The speed of the shake. The lower, the less the camera will shake.</param>
		public void Shake (ShakeGenerator generator, uint strength, float time, uint speed)
		{
			if (time < 0) {
				throw new ArgumentException("Time must be greater than 0");
			}

			this.generator = generator;
			this.strength += strength;
			this.damping = strength / time;
			this.speed = speed;
		}
	}
}