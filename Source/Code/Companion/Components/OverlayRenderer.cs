using Duality.Drawing;

namespace Duality.Plugins.Companion.Components
{
	public abstract class OverlayRenderer : Component, ICmpRenderer
	{
		public abstract float BoundRadius { get; }

		public bool IsVisible(IDrawDevice device)
		{
			return (device.VisibilityMask & VisibilityFlag.AllGroups) != VisibilityFlag.None &&
					(device.VisibilityMask & VisibilityFlag.ScreenOverlay) != VisibilityFlag.None;
		}

		public virtual void Draw(IDrawDevice device)
		{
		}
	}
}