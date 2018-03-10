using Duality.Components;
using Duality.Components.Renderers;
using Duality.Drawing;
using Duality.Plugins.Companion.Coroutines;
using Duality.Plugins.Companion.Drawing;
using Duality.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duality.Plugins.Companion
{
    public sealed class SplashScreen
    {
        [RequiredComponent(typeof(SpriteRenderer))]
        private class SpriteOrder : Component
        {
            public int Order { get; set; }
        }

        private static readonly TimeSpan WAIT_TIME = TimeSpan.FromSeconds(1.5);

        private static ColorRgba _background;
        private static string[] _logos;
        private static Scene _splash;

        public static void Register(params string[] logos)
        {
            Register(Colors.White, logos);
        }

        public static void Register(ColorRgba background, params string[] logos)
        {
            _background = background;
            _logos = logos;

            Scene.Entered += SplashIntercept;
        }

        private static void SplashIntercept(object sender, EventArgs e)
        {
            if (Scene.Current == DualityApp.AppData.StartScene)
            {
                _splash = BuildScene();
                Scene.SwitchTo(_splash);
            }

            if (Scene.Current == _splash)
            {
                Scene.Entered -= SplashIntercept;
                Coroutine.Start(SplashCoroutine());
            }
        }

        private static Scene BuildScene()
        {
            Scene splash = new Scene();

            GameObject camera = new GameObject();
            camera.AddComponent<Transform>();
            camera.GetComponent<Transform>().Pos = new Vector3(0, 0, -500);
            camera.AddComponent<Camera>();
            camera.GetComponent<Camera>().ClearColor = _background;
            splash.AddObject(camera);

            int i = 0;
            foreach (string s in _logos)
            {
                ContentRef<Material> logo = ContentProvider.GetAvailableContent<Material>().FirstOrDefault(l => l.Name == s);
                Texture tx = logo.Res?.MainTexture.Res;

                if (tx != null)
                {
                    BatchInfo bi = new BatchInfo(logo.Res);
                    bi.Technique = DrawTechnique.Alpha;

                    GameObject sprite = new GameObject();
                    sprite.AddComponent<Transform>();
                    sprite.AddComponent<SpriteRenderer>();
                    sprite.AddComponent<SpriteRenderer>().ColorTint = Colors.TransparentWhite;
                    sprite.GetComponent<SpriteRenderer>().Rect = new Rect(tx.Size).WithOffset(-tx.Size / 2);
                    sprite.GetComponent<SpriteRenderer>().CustomMaterial = bi;
                    sprite.AddComponent<SpriteOrder>();
                    sprite.GetComponent<SpriteOrder>().Order = i;

                    splash.AddObject(sprite);
                    i++;
                }
            }

            Texture duality = Material.DualityLogoBig.Res.MainTexture.Res;
            BatchInfo dualityBi = new BatchInfo(Material.DualityLogoBig.Res);
            dualityBi.Technique = DrawTechnique.Alpha;

            GameObject dualityLogo = new GameObject();
            dualityLogo.AddComponent<Transform>();
            dualityLogo.AddComponent<SpriteRenderer>();
            dualityLogo.AddComponent<SpriteRenderer>().ColorTint = Colors.TransparentWhite;
            dualityLogo.GetComponent<SpriteRenderer>().Rect = new Rect(duality.Size).WithOffset(-duality.Size / 2);
            dualityLogo.GetComponent<SpriteRenderer>().CustomMaterial = dualityBi;
            dualityLogo.AddComponent<SpriteOrder>();
            dualityLogo.GetComponent<SpriteOrder>().Order = i;
            splash.AddObject(dualityLogo);

            return splash;
        }

        private static IEnumerable<ICoroutineAction> SplashCoroutine()
        {
            yield return new WaitForTime(WAIT_TIME);

            foreach (SpriteRenderer sr in _splash.FindComponents<SpriteOrder>()
                .OrderBy(so => so.Order)
                .Select(so => so.GameObj.GetComponent<SpriteRenderer>()))
            {
                yield return new ContinuousAction(() =>
                {
                    float alpha = sr.ColorTint.A / 255f;
                    alpha = MathF.Min(alpha + (Time.SPFMult * Time.TimeMult), 1);
                    sr.ColorTint = sr.ColorTint.WithAlpha(alpha);

                    return alpha >= 1;
                });
                yield return new WaitForTime(WAIT_TIME);
                yield return new ContinuousAction(() =>
                {
                    float alpha = sr.ColorTint.A / 255f;
                    alpha = MathF.Max(alpha - (Time.SPFMult * Time.TimeMult), 0);
                    sr.ColorTint = sr.ColorTint.WithAlpha(alpha);

                    return alpha <= 0;
                });
            }

            yield return new WaitForTime(WAIT_TIME);
            Scene.SwitchTo(DualityApp.AppData.StartScene);
        }
    }
}
