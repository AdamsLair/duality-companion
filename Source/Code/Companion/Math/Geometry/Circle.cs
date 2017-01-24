using System;

namespace Duality.Plugins.Companion.Math.Geometry
{
	/// <summary>
	/// Represents a 2d circle.
	/// </summary>
	public struct Circle : IShape, IEquatable<Circle>
	{
		/// <summary>
		/// Gets the bounding rectangle of the circle.
		/// </summary>
		public Rect BoundingRectangle
		{
			get { return new Rect(Center.X - Radius, Center.Y - Radius, Radius * 2f, Radius * 2f); }
		}

		/// <summary>
		/// Gets or sets the center (position) of the circle.
		/// </summary>
		public Vector2 Center { get; set; }

		/// <summary>
		/// Gets or sets the radius of the circle.
		/// </summary>
		public float Radius { get; set; }

		public Circle(Vector2 center, float radius)
		{
			this.Center = center;
			this.Radius = radius;
		}

		public bool Contains(float x, float y)
		{
			return Radius >= MathF.Sqrt(MathF.Pow(Center.X - x, 2) + MathF.Pow(Center.Y - y, 2));
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