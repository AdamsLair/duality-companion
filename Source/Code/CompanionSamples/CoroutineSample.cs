using Duality.Components;
using Duality.Components.Physics;
using Duality.Components.Renderers;
using Duality.Editor;
using Duality.Plugins.Companion.Coroutines;
using Duality.Plugins.Companion.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duality.Plugins.Companion.Samples
{
    [EditorHintCategory(ResNames.SampleComponentCategory)]
    public class CoroutineSample : Component, ICmpUpdatable
    {
        [DontSerialize]
        private Coroutine c = null;

        public void OnUpdate()
        {
            if (DualityApp.Keyboard.KeyHit(Input.Key.Space))
            {
                if (c == null)
                    c = Coroutine.Start(DoMagic(this.GameObj.ParentScene.FindComponent<Camera>()));
                else
                    c.Abort();
            }
            if (DualityApp.Keyboard.KeyHit(Input.Key.X))
            {
                Coroutine.Start(Spawner(new Transform()));
            }
        }

        [DontSerialize]
        private int x = 0;

        private IEnumerable<ICoroutineAction> Spawner(Transform source)
        {
            GameObject go = new GameObject();
            go.AddComponent<Transform>(source.Clone() as Transform);
            go.AddComponent<SpriteRenderer>();
            go.AddComponent<RigidBody>().IgnoreGravity = true;
            go.GetComponent<Transform>().TurnBy(MathF.PiOver2);

            this.GameObj.ParentScene.AddObject(go);
            yield return new WaitAll(
                new ContinuousAction(() => { go.GetComponent<RigidBody>().ApplyLocalForce(Vector2.UnitY); return true; }),
                new WaitForTime(TimeSpan.FromSeconds(2))
                );
            if (x++ < 5)
            {
                yield return new WaitOne(
                    Coroutine.Start(Spawner(go.Transform)),
                    new WaitForTime(TimeSpan.FromSeconds(1))
                    );
            }
            go.DisposeLater();
        }

        private IEnumerable<ICoroutineAction> DoMagic(Camera c)
        {
            yield return new WaitAll(
                new WaitForTime(TimeSpan.FromSeconds(5)),
                //new WaitForFrames(5),
                new ContinuousAction(() => { c.GameObj.Transform.MoveBy(Vector2.UnitX * Time.LastDelta * 0.01f); return true; })
                );
            c.GameObj.Transform.MoveBy(new Vector3(0, 100, 0));
            yield return new WaitForTime(TimeSpan.FromSeconds(3));
            c.GameObj.Transform.MoveBy(new Vector3(0, 0, 500));
            c.ClearColor = Colors.OrangeRed;
            yield return new WaitOne(
                new WaitForTime(TimeSpan.FromHours(3)), 
                new WaitForSignal("neverGet"), 
                new WaitForTime(TimeSpan.FromSeconds(10))
            );
            c.ClearColor = Colors.Black;
            c.GameObj.Transform.MoveBy(new Vector3(-100, 0, 0));
            c.GameObj.Transform.TurnBy(MathF.PiOver2);
        }
    }
}
