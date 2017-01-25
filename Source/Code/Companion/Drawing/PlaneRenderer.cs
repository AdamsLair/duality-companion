using Duality.Components;
using Duality.Components.Renderers;
using Duality.Drawing;
using Duality.Editor;
using Duality.Resources;

namespace Duality.Plugins.Companion.Drawing
{
	[EditorHintCategory(ResNames.DrawingEditorCategory)]
	[RequiredComponent(typeof(Transform))]
	public class PlaneRenderer : Component, ICmpRenderer, ICmpInitializable
	{
		public enum ScrollingMode
		{
			Horiziontal,
			Vertical,
			Both
		}

		[DontSerialize] private VertexC1P3T2[] vertices       = new VertexC1P3T2[4];
		[DontSerialize] private Vector3        posTemp        = Vector3.Zero;
		[DontSerialize] private float          scaleTemp      = 0;
		[DontSerialize] private Vector2        uvDelta        = Vector2.Zero;
		[DontSerialize] private Vector2        sourcePosition = Vector2.Zero;
		[DontSerialize] private Vector2        backgroundSize = Vector2.Zero;

		[DontSerialize] private Transform      transform;

		[DontSerialize] private Vector2        topLeft     = Vector2.Zero;
		[DontSerialize] private Vector2        bottomLeft  = Vector2.Zero;
		[DontSerialize] private Vector2        bottomRight = Vector2.Zero;
		[DontSerialize] private Vector2        topRight    = Vector2.Zero;

		public ContentRef<Material> SharedMaterial {get; set;}

		public ContentRef<Material> CustomMaterial { get; set; }

		public ScrollingMode Scrolling { get; set; }

		public ColorRgba ColorTint { get; set; }

		public Vector2 Offset { get; set; }

		public float ScrollingMultiplier { get; set; }

		public PlaneRenderer()
		{
			this.ColorTint = ColorRgba.White;
			this.SharedMaterial = Duality.Resources.Material.Checkerboard;
			this.Offset = Vector2.Zero;

			this.ScrollingMultiplier = 1;
		}

		[EditorHintFlags(MemberFlags.Invisible)]
		public float BoundRadius
		{
			get { return 0; }
		}

		public void Draw(Duality.Drawing.IDrawDevice device)
		{
			// Find out about the into-camera-space transformation at the object's position
			this.posTemp = this.transform.Pos;

			// Vertical or Both
			if (this.Scrolling != ScrollingMode.Horiziontal) this.posTemp.Y = device.RefCoord.Y;
			// Horizontal or Both
			if (this.Scrolling != ScrollingMode.Vertical) this.posTemp.X = device.RefCoord.X;

			this.scaleTemp = 1.0f;
			device.PreprocessCoords(ref this.posTemp, ref this.scaleTemp);

			Vector2 textureSize = Vector2.One;
			Vector2 uvSize = Vector2.Zero;

			if (this.CustomMaterial.IsAvailable)
			{
				textureSize = this.CustomMaterial.Res.MainTexture.Res.Size;
				uvSize = this.CustomMaterial.Res.MainTexture.Res.UVRatio;
			}
			else
			{
				textureSize = this.SharedMaterial.Res.MainTexture.Res.Size;
				uvSize = this.SharedMaterial.Res.MainTexture.Res.UVRatio;
			}

			// How big will the texture appear on screen
			Vector2 textureScaled = textureSize * this.transform.Scale * this.scaleTemp;

			// and how much will we have to scale it to make it fill the screen
			Vector2 textureScale = device.TargetSize / textureScaled;

			// Multiply by 2 to be sure that the sprite doesn't end exactly on the side of the screen
			// (for rotation purposes)
			if (this.Scrolling != ScrollingMode.Horiziontal) textureSize.Y *= textureScale.Y * 2;
			if (this.Scrolling != ScrollingMode.Vertical) textureSize.X *= textureScale.X * 2;

			Rect rectTemp = new Rect(textureSize).WithOffset(-textureSize / 2);
			
			this.topLeft = rectTemp.TopLeft;
			this.bottomLeft = rectTemp.BottomLeft;
			this.bottomRight = rectTemp.BottomRight;
			this.topRight = rectTemp.TopRight;

			// Calculate the "actual" texture size on screen
			textureSize *= this.transform.Scale * this.scaleTemp;

			uvDelta = uvSize / textureScaled;
			uvSize *= textureSize / textureScaled;

			uvDelta *= (device.RefCoord.Xy - this.Offset);
			if (this.Scrolling == ScrollingMode.Horiziontal) uvDelta.Y = 0;
			if (this.Scrolling == ScrollingMode.Vertical) uvDelta.X = 0;

			Rect uvRect = new Rect(uvSize).WithOffset(-uvSize / 2);

			if (this.Scrolling == ScrollingMode.Horiziontal) uvRect = uvRect.WithOffset(0, uvSize.Y / 2);
			if (this.Scrolling == ScrollingMode.Vertical) uvRect = uvRect.WithOffset(uvSize.X / 2, 0);
			
			uvDelta *= this.transform.Scale * this.scaleTemp * ScrollingMultiplier;

			// Apply object rotation and (object + perspective) scale
			Vector2 xDot, yDot;
			MathF.GetTransformDotVec(this.transform.Angle, this.transform.Scale * this.scaleTemp, out xDot, out yDot);

			MathF.TransformDotVec(ref this.topLeft, ref xDot, ref yDot);
			MathF.TransformDotVec(ref this.bottomLeft, ref xDot, ref yDot);
			MathF.TransformDotVec(ref this.bottomRight, ref xDot, ref yDot);
			MathF.TransformDotVec(ref this.topRight, ref xDot, ref yDot);

			// Define vertices. 
			this.vertices[0].Pos.X = this.posTemp.X + this.topLeft.X;
			this.vertices[0].Pos.Y = this.posTemp.Y + this.topLeft.Y;
			this.vertices[0].Pos.Z = this.posTemp.Z;
			this.vertices[0].TexCoord = uvRect.TopLeft + uvDelta;
			this.vertices[0].Color = this.ColorTint;

			this.vertices[1].Pos.X = this.posTemp.X + this.bottomLeft.X;
			this.vertices[1].Pos.Y = this.posTemp.Y + this.bottomLeft.Y;
			this.vertices[1].Pos.Z = this.posTemp.Z;
			this.vertices[1].TexCoord = uvRect.BottomLeft + uvDelta; 
			this.vertices[1].Color = this.ColorTint;

			this.vertices[2].Pos.X = this.posTemp.X + this.bottomRight.X;
			this.vertices[2].Pos.Y = this.posTemp.Y + this.bottomRight.Y;
			this.vertices[2].Pos.Z = this.posTemp.Z;
			this.vertices[2].TexCoord = uvRect.BottomRight + uvDelta; 
			this.vertices[2].Color = this.ColorTint;

			this.vertices[3].Pos.X = this.posTemp.X + this.topRight.X;
			this.vertices[3].Pos.Y = this.posTemp.Y + this.topRight.Y;
			this.vertices[3].Pos.Z = this.posTemp.Z;
			this.vertices[3].TexCoord = uvRect.TopRight + uvDelta; 
			this.vertices[3].Color = this.ColorTint;

			if(this.CustomMaterial.IsAvailable)
				device.AddVertices(this.CustomMaterial, VertexMode.Quads, this.vertices);
			else
				device.AddVertices(this.SharedMaterial, VertexMode.Quads, this.vertices);
		}

		public bool IsVisible(Duality.Drawing.IDrawDevice device)
		{
			return (device.VisibilityMask & VisibilityFlag.AllGroups) != VisibilityFlag.None &&
					(device.VisibilityMask & VisibilityFlag.ScreenOverlay) == VisibilityFlag.None;
		}

		public void OnInit(Component.InitContext context)
		{
			this.transform = this.GameObj.Transform;
			this.sourcePosition = this.transform.Pos.Xy;
		}

		public void OnShutdown(Component.ShutdownContext context)
		{
			// nothing to do here
		}
	}
}
