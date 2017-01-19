namespace Duality.Plugins.Companion.Tweens
{
	/// <summary>
	/// The behavior to use when manually stopping a tween.
	/// </summary>
	public enum StopBehavior
	{
		/// <summary>
		/// Does not change the current value.
		/// </summary>
		AsIs,

		/// <summary>
		/// Forces the tween progress to the end value.
		/// </summary>
		ForceComplete
	}
}