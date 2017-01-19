namespace Duality.Plugins.Companion.Tweens
{
	/// <summary>
	/// Object used to tween Vector3 values.
	/// </summary>
	public class Vector3Tween : Tween<Vector3>
	{
		// Static readonly delegate to avoid multiple delegate allocations
		private static readonly LerpFunc<Vector3> LerpFunc = Vector3.Lerp;

		/// <summary>
		/// Initializes a new Vector3Tween instance.
		/// </summary>
		public Vector3Tween() : base(LerpFunc) { }
	}
}