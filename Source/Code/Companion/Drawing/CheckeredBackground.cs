using Duality.Drawing;
using Duality.Editor;
using Duality.Resources;

namespace Duality.Plugins.Companion.Drawing
{
	[EditorHintCategory(ResNames.DiagnosticsEditorCategory)]
	public class CheckeredBackground : Component, ICmpRenderer
	{
		[DontSerialize] private VertexC1P3T2[] vertices       = new VertexC1P3T2[4];
		[DontSerialize] private Vector3        posTemp        = Vector3.Zero;
		[DontSerialize] private float          scaleTemp      = 0;
		[DontSerialize] private Vector2        uvDelta        = Vector2.Zero;
		[DontSerialize] private Vector2        lastPosition   = Vector2.Zero;
		[DontSerialize] private Vector2        backgroundSize = Vector2.Zero;

		[DontSerialize] private Vector2        topLeft     = Vector2.Zero;
		[DontSerialize] private Vector2        bottomLeft  = Vector2.Zero;
		[DontSerialize] private Vector2        bottomRight = Vector2.Zero;
		[DontSerialize] private Vector2        topRight    = Vector2.Zero;

		public float Z { get; set; }

		public ColorRgba Tint { get; set; }

		public CheckeredBackground()
		{
			this.vertices[0].TexCoord = Vector2.Zero;
			this.vertices[1].TexCoord = 2 * Vector2.UnitY;
			this.vertices[2].TexCoord = 2 * Vector2.One;
			this.vertices[3].TexCoord = 2 * Vector2.UnitX; 
			
			this.Z = 500;
			this.Tint = ColorRgba.White;
		}

		[EditorHintFlags(MemberFlags.Invisible)]
		public float BoundRadius
		{
			get { return 0; }
		}

		public void Draw(Duality.Drawing.IDrawDevice device)
		{
			// Find out about the into-camera-space transformation at the object's position
			this.posTemp = device.RefCoord;
			this.posTemp.Z = Z;

			this.scaleTemp = 1.0f;
			device.PreprocessCoords(ref this.posTemp, ref this.scaleTemp);

			// Define the rect we're going to render
			backgroundSize = device.TargetSize / this.scaleTemp;
			backgroundSize.X = backgroundSize.Y = MathF.Max(backgroundSize.X, backgroundSize.Y);

			Rect rectTemp = new Rect(backgroundSize * 2).WithOffset(-backgroundSize);

			this.topLeft = rectTemp.TopLeft;
			this.bottomLeft = rectTemp.BottomLeft;
			this.bottomRight = rectTemp.BottomRight;
			this.topRight = rectTemp.TopRight;

			// Apply object rotation and (object + perspective) scale
			Vector2 xDot, yDot;
			MathF.GetTransformDotVec(0, scaleTemp, out xDot, out yDot);

			MathF.TransformDotVec(ref this.topLeft, ref xDot, ref yDot);
			MathF.TransformDotVec(ref this.bottomLeft, ref xDot, ref yDot);
			MathF.TransformDotVec(ref this.bottomRight, ref xDot, ref yDot);
			MathF.TransformDotVec(ref this.topRight, ref xDot, ref yDot);

			// Define vertices. Note how we completely ignore the XY position from PreprocessCoords above.
			// We just render out rect as we intended. It floats around as if stuck on the screen.
			uvDelta = (device.RefCoord.Xy - lastPosition) / (backgroundSize) * device.GetScaleAtZ(Z);

			this.vertices[0].Pos.Xy = this.topLeft;
			this.vertices[0].Pos.Z = this.posTemp.Z;
			this.vertices[0].TexCoord += this.uvDelta;
			this.vertices[0].Color = this.Tint;

			this.vertices[1].Pos.Xy = this.bottomLeft;
			this.vertices[1].Pos.Z = this.posTemp.Z;
			this.vertices[1].TexCoord += this.uvDelta;
			this.vertices[1].Color = this.Tint;

			this.vertices[2].Pos.Xy = this.bottomRight;
			this.vertices[2].Pos.Z = this.posTemp.Z;
			this.vertices[2].TexCoord += this.uvDelta;
			this.vertices[2].Color = this.Tint;

			this.vertices[3].Pos.Xy = this.topRight;
			this.vertices[3].Pos.Z = this.posTemp.Z;
			this.vertices[3].TexCoord += this.uvDelta;
			this.vertices[3].Color = this.Tint;

			device.AddVertices(Material.Checkerboard, VertexMode.Quads, this.vertices);
			this.lastPosition = device.RefCoord.Xy;
		}

		public bool IsVisible(Duality.Drawing.IDrawDevice device)
		{
			return (device.VisibilityMask & VisibilityFlag.AllGroups) != VisibilityFlag.None &&
					(device.VisibilityMask & VisibilityFlag.ScreenOverlay) == VisibilityFlag.None;
		}
	}
}
