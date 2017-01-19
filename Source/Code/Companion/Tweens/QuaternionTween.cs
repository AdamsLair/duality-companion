namespace Duality.Plugins.Companion.Tweens
{
	/// <summary>
	/// Object used to tween Quaternion values.
	/// </summary>
	public class QuaternionTween : Tween<Quaternion>
	{
		// Static readonly delegate to avoid multiple delegate allocations
		private static readonly LerpFunc<Quaternion> LerpFunc = Quaternion.Slerp;

		/// <summary>
		/// Initializes a new QuaternionTween instance.
		/// </summary>
		public QuaternionTween() : base(LerpFunc) { }
	}
}