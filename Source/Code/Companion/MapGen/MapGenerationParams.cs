using Duality.Editor;

namespace Duality.Plugins.Companion.MapGen
{
    [EditorHintCategory(ResNames.MapGenCategory)]
    public class MapGenerationParams : Resource
    {
        private int _width;
        private int _height;
        private int _minRoomSize;
        private int _maxRoomSize;
        private int _minCorridorLength;
        private int _maxCorridorLength;
        private int _featureNum;
        private int _maxIterations;

        public int Width
        {
            get => _width;
            set => _width = value;
        }

        public int Height
        {
            get => _height;
            set => _height = value;
        }

        public int MinRoomSize
        {
            get => _minRoomSize;
            set => _minRoomSize = value;
        }

        public int MaxRoomSize
        {
            get => _maxRoomSize;
            set => _maxRoomSize = value;
        }

        public int MinCorridorLength
        {
            get => _minCorridorLength;
            set => _minCorridorLength = value;
        }

        public int MaxCorridorLength
        {
            get => _maxCorridorLength;
            set => _maxCorridorLength = value;
        }

        public int FeatureNum
        {
            get => _featureNum;
            set => _featureNum = value;
        }

        public int MaxIterations
        {
            get => _maxIterations;
            set => _maxIterations = value;
        }
    }
}
