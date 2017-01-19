namespace Duality.Plugins.Companion.Tweens
{
	/// <summary>
	/// Object used to tween float values.
	/// </summary>
	public class FloatTween : Tween<float>
	{
		private static float LerpFloat(float start, float end, float progress)
		{
			return start + (end - start) * progress;
		}

		// Static readonly delegate to avoid multiple delegate allocations
		private static readonly LerpFunc<float> LerpFunc = LerpFloat;

		/// <summary>
		/// Initializes a new FloatTween instance.
		/// </summary>
		public FloatTween() : base(LerpFunc) { }
	}
}