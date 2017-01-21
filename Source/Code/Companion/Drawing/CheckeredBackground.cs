using Duality.Drawing;
using Duality.Editor;
using Duality.Resources;

namespace Duality.Plugins.Companion.Drawing
{
	[EditorHintCategory (ResNames.DrawingEditorCategory)]
	public class CheckeredBackground : Component, ICmpRenderer
	{
		[DontSerialize] private VertexC1P3T2[] vertices     = new VertexC1P3T2[4];
		[DontSerialize] private Vector3        fullScreen   = Vector3.Zero;
		[DontSerialize] private Vector2        uvDelta      = Vector2.Zero;
		[DontSerialize] private Vector2        lastPosition = Vector2.Zero;

		public float Z { get; set; }

		public CheckeredBackground()
		{
			this.vertices[0].TexCoord = Vector2.Zero;
			this.vertices[1].TexCoord = Vector2.UnitY;
			this.vertices[2].TexCoord = Vector2.One;
			this.vertices[3].TexCoord = Vector2.UnitX; 
			
			this.Z = 500;
		}

		[EditorHintFlags(MemberFlags.Invisible)]
		public float BoundRadius
		{
			get { return 0; }
		}

		public void Draw(Duality.Drawing.IDrawDevice device)
		{
			this.fullScreen = device.GetSpaceCoord(DualityApp.TargetResolution - device.RefCoord.Xy);

			this.vertices[0].Pos = device.GetSpaceCoord(Vector2.Zero - device.RefCoord.Xy);
			this.vertices[0].Pos.Z = device.FocusDist + this.Z;

			this.vertices[2].Pos = device.GetSpaceCoord(Vector2.One * DualityApp.TargetResolution - device.RefCoord.Xy);
			this.vertices[2].Pos.Z = device.FocusDist + this.Z;

			this.vertices[1].Pos = device.GetSpaceCoord(Vector2.UnitY * DualityApp.TargetResolution - device.RefCoord.Xy);
			this.vertices[1].Pos.Z = device.FocusDist + this.Z;

			this.vertices[3].Pos = device.GetSpaceCoord(Vector2.UnitX * DualityApp.TargetResolution - device.RefCoord.Xy);
			this.vertices[3].Pos.Z = device.FocusDist + this.Z;
			/*
			float scale = 1;
			device.PreprocessCoords(ref this.vertices[0].Pos, ref scale);
			device.PreprocessCoords(ref this.vertices[1].Pos, ref scale);
			device.PreprocessCoords(ref this.vertices[2].Pos, ref scale);
			device.PreprocessCoords(ref this.vertices[3].Pos, ref scale);
			*/
			this.uvDelta = (device.RefCoord.Xy - this.lastPosition) / DualityApp.TargetResolution;

			this.vertices[0].TexCoord += this.uvDelta;
			this.vertices[1].TexCoord += this.uvDelta;
			this.vertices[2].TexCoord += this.uvDelta;
			this.vertices[3].TexCoord += this.uvDelta;

			this.vertices[0].Color = ColorRgba.White;
			this.vertices[1].Color = ColorRgba.White;
			this.vertices[2].Color = ColorRgba.White;
			this.vertices[3].Color = ColorRgba.White;

			Canvas canvas = new Canvas(device);
			canvas.State.SetMaterial(Material.Checkerboard);
			canvas.DrawVertices(this.vertices, VertexMode.Quads);

			this.lastPosition = device.RefCoord.Xy;
		}

		public bool IsVisible(Duality.Drawing.IDrawDevice device)
		{
			return (device.VisibilityMask & VisibilityFlag.AllGroups) != VisibilityFlag.None &&
					(device.VisibilityMask & VisibilityFlag.ScreenOverlay) == VisibilityFlag.None;
		}
	}
}
