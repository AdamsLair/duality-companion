namespace Duality.Plugins.Companion.Math.Geometry
{
	public static class GeometryHelper
	{
		/// <summary>
		/// Converts degrees to radians.
		/// </summary>
		/// <param name="angle">The angle.</param>
		/// <returns>Returns the radians.</returns>
		public static double DegreeToRadian(double angle)
		{
			return MathF.Pi * angle / 180.0;
		}

		/// <summary>
		/// Converts radians to degrees.
		/// </summary>
		/// <param name="angle">The angle.</param>
		/// <returns>Returns the degree.</returns>
		public static double RadianToDegree(double angle)
		{
			return angle * (180.0 / MathF.Pi);
		}
	}
}