using System;

namespace Duality.Plugins.Companion.Math.Geometry
{
	/// <summary>
	/// Represents a 2d line.
	/// </summary>
	public class Line2D : IEquatable<Line2D>, IShape
	{
		/// <summary>
		/// Gets or sets the first vector of the line.
		/// </summary>
		public Vector2 VectorA { get; set; }

		/// <summary>
		/// Gets or sets the second vector of the line.
		/// </summary>
		public Vector2 VectorB { get; set; }

		public Vector2 Center
		{
			get
			{
				var xM = (VectorA.X + VectorB.X) * 0.5f;
				var yM = (VectorA.Y + VectorB.Y) * 0.5f;
				return new Vector2(xM, yM);
			}
		}

		/// <summary>
		/// Gets the distance between both vectors of the line.
		/// </summary>
		public float Length
		{
			get { return (VectorA - VectorB).Length; }
		}

		/// <summary>
		/// Gets the slope of the line.
		/// </summary>
		public float Slope
		{
			get { return (VectorA.Y - VectorB.Y) / (VectorA.X - VectorB.X); }
		}

		public Line2D(Vector2 a, Vector2 b)
		{
			VectorA = a;
			VectorB = b;
		}

		public static bool AreParallel(Line2D firstLine, Line2D secondLine)
		{
			throw new NotImplementedException();
		}

		public bool Equals(Line2D other)
		{
			throw new NotImplementedException();
		}

		public Rect BoundingRectangle
		{
			get { throw new NotImplementedException(); }
		}

		public bool Contains(float x, float y)
		{
			throw new NotImplementedException();
		}

		public bool Contains(Vector2 point)
		{
			throw new NotImplementedException();
		}
	}
}