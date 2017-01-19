using Duality.Drawing;

namespace Duality.Plugins.Companion.Tweens
{
	/// <summary>
	/// Object used to tween Color values.
	/// </summary>
	public class ColorTween : Tween<ColorRgba>
	{
		// Static readonly delegate to avoid multiple delegate allocations
		private static readonly LerpFunc<ColorRgba> LerpFunc = ColorRgba.Lerp;

		/// <summary>
		/// Initializes a new ColorTween instance.
		/// </summary>
		public ColorTween() : base(LerpFunc) { }
	}
}