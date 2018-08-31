using System;
using Duality.Editor;
using Duality.Plugins.Tilemaps;

namespace Duality.Plugins.Companion.MapGen
{
    [EditorHintCategory(ResNames.MapGenCategory)]
    [RequiredComponent(typeof(Tilemap))]
    public class TilemapController : Component
    {
        private int _emptyTileIndex;
        private int _solidTileIndex;
        [DontSerialize] private Tilemap _tilemap;

        public int EmptyTileIndex1
        {
            get => _emptyTileIndex;
            set => _emptyTileIndex = value;
        }

        public int SolidTileIndex
        {
            get => _solidTileIndex;
            set => _solidTileIndex = value;
        }

        public void SetupTilemap(MapGenerationData genData)
        {
            _tilemap = GameObj.GetComponent<Tilemap>();
            _tilemap.Resize(genData.Width, genData.Height);
            var tileGrid = _tilemap.BeginUpdateTiles();
            tileGrid.Fill(new Tile(_emptyTileIndex), 0, 0, tileGrid.Width, tileGrid.Height);
            _tilemap.EndUpdateTiles();
        }

        public void UpdateTilemap(Grid<TileType> generatedMap, int xMin, int xMax, int yMin, int yMax)
        {
            var tileGrid = _tilemap.BeginUpdateTiles();

            for (var y = yMin; y <= yMax; y++)
            {
                for (var x = xMin; x <= xMax; x++)
                {
                    int tileIndex;
                    switch (generatedMap[x, y])
                    {
                        case TileType.Solid:
                            tileIndex = _solidTileIndex;
                            break;
                        case TileType.Empty:
                            tileIndex = _emptyTileIndex;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    tileGrid[x, y] = new Tile(tileIndex);
                }
            }

            var width = xMax - xMin + 1;
            var height = yMax - yMin + 1;
            Tile.UpdateAutoTileCon(tileGrid, null, xMin, yMin, width, height, _tilemap.Tileset);
            Tile.ResolveIndices(tileGrid, xMin, yMin, xMax-xMin+1, yMax-yMin+1, _tilemap.Tileset);
            _tilemap.EndUpdateTiles();
        }

        public void UpdateTilemap(Grid<TileType> generatedMap)
        {
            UpdateTilemap(generatedMap, 0, generatedMap.Width - 1, 0, generatedMap.Height - 1);
        }
    }
}
