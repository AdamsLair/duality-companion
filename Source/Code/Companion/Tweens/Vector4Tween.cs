namespace Duality.Plugins.Companion.Tweens
{
	/// <summary>
	/// Object used to tween Vector4 values.
	/// </summary>
	public class Vector4Tween : Tween<Vector4>
	{
		// Static readonly delegate to avoid multiple delegate allocations
		private static readonly LerpFunc<Vector4> LerpFunc = Vector4.Lerp;

		/// <summary>
		/// Initializes a new Vector4Tween instance.
		/// </summary>
		public Vector4Tween() : base(LerpFunc) { }
	}
}