using Duality.Drawing;
using Duality.Editor;
using Duality.Plugins.Companion.Components;
using Duality.Plugins.Companion.Math.Geometry;

namespace Duality.Plugins.Companion.Samples
{
	[EditorHintCategory(ResNames.SampleComponentCategory)]
	public class GeometrySample : OverlayRenderer, ICmpUpdatable
	{
		public override float BoundRadius { get { return 0; } }

		public Line2D Line
		{
			get { return line; }
			set { line = value; }
		}

		// geometry stuff
		private Circle circle = new Circle(new Vector2(200, 200), 50);

		private Line2D line = new Line2D(new Vector2(400, 400), new Vector2(200, 100));

		private bool isMouseHover = false;

		public void OnUpdate()
		{
		}

		public override void Draw(IDrawDevice device)
		{
			base.Draw(device);

			var canvas = new Canvas(device);
			var screenPos = DualityApp.Mouse.Pos;
			isMouseHover = circle.Contains(screenPos);

			canvas.State.ColorTint = ColorRgba.Green;
			canvas.DrawLine(line.VectorA.X, line.VectorA.Y, line.VectorB.X, line.VectorB.Y);
			canvas.FillCircle(line.Center.X, line.Center.Y, 5);

			if (isMouseHover)
			{
				canvas.FillCircle(circle.Center.X, circle.Center.Y, circle.Radius);
			}
			else
			{
				canvas.DrawCircle(circle.Center.X, circle.Center.Y, circle.Radius);
			}

			canvas.State.ColorTint = ColorRgba.Red;
			canvas.DrawRect(circle.BoundingRectangle.X, circle.BoundingRectangle.Y, circle.BoundingRectangle.W, circle.BoundingRectangle.H);

			canvas.State.ColorTint = ColorRgba.White;
			canvas.State.TransformScale = new Vector2(1.5f);
			canvas.DrawText("m=" + line.Slope.ToString(), line.Center.X, line.Center.Y, 1.5f, Alignment.Center, true);

			canvas.State.TransformScale = new Vector2(1f);
		}
	}
}