namespace Duality.Plugins.Companion.Math.Geometry
{
	public interface IShape
	{
		Rect BoundingRectangle { get; }
		bool Contains(float x, float y);
		bool Contains(Vector2 point);
	}
}