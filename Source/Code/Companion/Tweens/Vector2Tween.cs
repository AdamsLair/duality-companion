namespace Duality.Plugins.Companion.Tweens
{
	/// <summary>
	/// Object used to tween Vector2 values.
	/// </summary>
	public class Vector2Tween : Tween<Vector2>
	{
		// Static readonly delegate to avoid multiple delegate allocations
		private static readonly LerpFunc<Vector2> LerpFunc = Vector2.Lerp;

		/// <summary>
		/// Initializes a new Vector2Tween instance.
		/// </summary>
		public Vector2Tween() : base(LerpFunc) { }
	}
}