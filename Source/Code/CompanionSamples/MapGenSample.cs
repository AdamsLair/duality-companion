using Duality.Drawing;
using Duality.Editor;
using Duality.Input;
using Duality.Plugins.Companion.MapGen;

namespace Duality.Plugins.Companion.Samples
{
    [RequiredComponent(typeof(TilemapController))]
    [EditorHintCategory(ResNames.SampleComponentCategory)]
    public class MapGenSample : Component, ICmpInitializable
    {
        private ContentRef<MapGenerationParams> _mapGenerationParams;
        [DontSerialize] private TilemapController _tilemapController;

        public ContentRef<MapGenerationParams> MapGenerationParams
        {
            get => _mapGenerationParams;
            set => _mapGenerationParams = value;
        }

        void ICmpInitializable.OnInit(InitContext context)
        {
            if (context == InitContext.Activate && _mapGenerationParams != null)
            {
                _tilemapController = GameObj.GetComponent<TilemapController>();
                _tilemapController.SetupTilemap(_mapGenerationParams.Res);
                _tilemapController.UpdateTilemap(new MapGenerator().GenerateMap(_mapGenerationParams.Res));
                
                DualityApp.Keyboard.KeyDown += KeyDownCallback;
            }
        }

        void ICmpInitializable.OnShutdown(ShutdownContext context)
        {
            DualityApp.Keyboard.KeyDown -= KeyDownCallback;
        }
        
        private void KeyDownCallback(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                _tilemapController.UpdateTilemap(new MapGenerator().GenerateMap(_mapGenerationParams.Res));
            }
        }
    }
}
