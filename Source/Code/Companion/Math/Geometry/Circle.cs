using System;

namespace Duality.Plugins.Companion.Math.Geometry
{
	public struct Circle : IShape, IEquatable<Circle>
	{
		public Rect BoundingRectangle { get; }

		public Vector2 Center { get; set; }

		public float Radius { get; set; }
		
		public bool Contains(float x, float y)
		{
			return Radius <= MathF.Sqrt(MathF.Pow(Center.X - x, 2) + MathF.Pow(Center.Y - y, 2));
		}

		public bool Contains(Vector2 point)
		{
			return Contains(point.X, point.Y);
		}

		public bool Equals(Circle other)
		{
			return Radius == other.Radius && Radius == other.Radius;
		}
	}
}