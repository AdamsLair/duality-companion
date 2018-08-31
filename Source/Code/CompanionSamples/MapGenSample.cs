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
        private MapGenerationData _mapGenerationData;
        [DontSerialize] private TilemapController _tilemapController;

        public MapGenerationData MapGenerationData
        {
            get => _mapGenerationData;
            set => _mapGenerationData = value;
        }

        void ICmpInitializable.OnInit(InitContext context)
        {
            if (context == InitContext.Activate && _mapGenerationData != null)
            {
                _tilemapController = GameObj.GetComponent<TilemapController>();
                _tilemapController.SetupTilemap(_mapGenerationData);
                _tilemapController.UpdateTilemap(new MapGenerator().GenerateMap(_mapGenerationData));
                
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
                _tilemapController.UpdateTilemap(new MapGenerator().GenerateMap(_mapGenerationData));
            }
        }
    }
}
