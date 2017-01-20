using System;
using Duality.Drawing;
using Duality.Editor;
using Duality.Plugins.Companion.Tweens;
using Duality.Resources;

namespace Duality.Plugins.Companion.Components
{
	public class ColorFader : OverlayRenderer, ICmpUpdatable
	{
		[EditorHintFlags(MemberFlags.Invisible)]
		public EventHandler Faded
		{
			get { return faded; }
			set { faded = value; }
		}

		public override float BoundRadius
		{
			get { return 0; }
		}

		[DontSerialize] private EventHandler        faded;
		[DontSerialize] private readonly ColorTween colorTween = new ColorTween();

		public void FadeIn(float duration, ColorRgba color, Easing easing)
		{
			if (this.colorTween.State != TweenState.Running)
			{
				this.colorTween.Start(color, new ColorRgba(0, 0, 0, 0f), duration, easing);
			}
		}

		public void FadeOut(float duration, ColorRgba color, Easing easing)
		{
			if (this.colorTween.State != TweenState.Running)
			{
				this.colorTween.Start(new ColorRgba(0, 0, 0, 0f), color, duration, easing);
			}
		}

		public void OnUpdate()
		{
			if (this.colorTween.State == TweenState.Running)
			{
				this.colorTween.Update(Time.LastDelta);
			}

			if (colorTween.State == TweenState.Stopped)
			{
				if (this.faded == null)
				{
					this.faded.Invoke(this, EventArgs.Empty);
				}
				this.colorTween.Stop(StopBehavior.ForceComplete);
			}
		}

		public override void Draw(IDrawDevice device)
		{
			base.Draw(device);

			if (colorTween.State == TweenState.Running)
			{
				var canvas = new Canvas(device);
				canvas.State.SetMaterial(new BatchInfo(DrawTechnique.Alpha, colorTween.CurrentValue));
				canvas.FillRect(0, 0, DualityApp.TargetResolution.X, DualityApp.TargetResolution.Y);
			}
		}
	}
}