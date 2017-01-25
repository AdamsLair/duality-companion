using Duality.Components;
using Duality.Editor;
using Duality.Input;
using Duality.Plugins.Companion.Audio;
using Duality.Resources;

namespace Duality.Plugins.Companion.Samples
{
	[EditorHintCategory (ResNames.SampleComponentCategory)]
	[RequiredComponent(typeof(Camera))]
	public class AutoScroller : Component, ICmpUpdatable
    {
		[DontSerialize]
		private float x;

	    public void OnUpdate ()
	    {
			float delta = Time.SPFMult * Time.TimeMult;
			x += delta;

			Vector3 movement = new Vector3(x * 200, MathF.Sin(x) * 50, this.GameObj.Transform.Pos.Z);
			this.GameObj.Transform.MoveTo(movement);
		}
    }
}
