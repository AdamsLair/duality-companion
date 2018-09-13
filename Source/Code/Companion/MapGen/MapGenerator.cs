using System;
using System.Collections.Generic;
using Duality;

namespace Duality.Plugins.Companion.MapGen
{
    public enum TileType
    {
        Solid,
        Empty
    }

    public class MapGenerator
    {
        [DontSerialize] private MapGenerationParams _genParams;

        public Grid<TileType> GenerateMap(MapGenerationParams mapGenerationParams)
        {
            _genParams = mapGenerationParams;
            var map = new Grid<TileType>(_genParams.Width - 2, _genParams.Height - 2);
            map.Fill(TileType.Solid, 0, 0, map.Width, map.Height);

            CreateCenterRoom(map);

            var numberOfFeaturesAdded = 0;
            var iterations = 0;
            while (numberOfFeaturesAdded < _genParams.FeatureNum && iterations <= _genParams.MaxIterations)
            {
                if (TryAddFeature(map))
                {
                    numberOfFeaturesAdded++;
                }

                iterations++;
            }

            map.AssumeRect(-1, -1, _genParams.Width, _genParams.Height);
            return map;
        }

        private void CreateCenterRoom(Grid<TileType> map)
        {
            var roomWidth = MathF.Rnd.Next(_genParams.MinRoomSize, _genParams.MaxRoomSize);
            var roomHeight = MathF.Rnd.Next(_genParams.MinRoomSize, _genParams.MaxRoomSize);

            var left = MathF.Rnd.Next(1, map.Width - roomWidth - 1);
            var top = MathF.Rnd.Next(1, map.Height - roomHeight - 1);

            map.Fill(TileType.Empty, left, top, roomWidth, roomHeight);
        }

        private bool TryAddFeature(Grid<TileType> map)
        {
            var rndFeature = MathF.Rnd.Next((int) Feature.Last);
            switch ((Feature) rndFeature)
            {
                case Feature.Corridor:
                    return TryAddCorridor(map);
                case Feature.Room:
                    return TryAddRoom(map);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool TryAddRoom(Grid<TileType> map)
        {
            var walls = GetWalls(map);
            var wallBase = walls[MathF.Rnd.Next(walls.Count)];
            var roomDir1 = GetDirection(map, wallBase);
            var roomDir2 = new Point2(roomDir1.X == 1 ? 0 : 1, roomDir1.Y == 1 ? 0 : 1);

            var room2 = MathF.Rnd.Next(_genParams.MinRoomSize, _genParams.MaxRoomSize);
            var roomOffset = MathF.Rnd.Next(room2);
            var room1 = MathF.Rnd.Next(_genParams.MinRoomSize, _genParams.MaxRoomSize);
            var solidToEmpty = new List<Point2>();

            for (var c1 = 0; c1 < room1; c1++)
            {
                for (var c2 = 0; c2 < room2; c2++)
                {
                    var roomPos = wallBase + roomDir1 * c1 + roomDir2 * (c2 - roomOffset);
                    if (!map.On(roomPos) || map.At(roomPos) == TileType.Empty)
                    {
                        return false;
                    }

                    solidToEmpty.Add(roomPos);
                }
            }

            foreach (var coord in solidToEmpty)
            {
                map[coord.X, coord.Y] = TileType.Empty;
            }

            return true;
        }

        private bool TryAddCorridor(Grid<TileType> map)
        {
            var walls = GetWalls(map);
            var wallBase = walls[MathF.Rnd.Next(walls.Count)];
            var corridorDir = GetDirection(map, wallBase);
            var solidToEmpty = new List<Point2>();

            var corridorLength = MathF.Rnd.Next(_genParams.MinCorridorLength, _genParams.MaxCorridorLength);
            for (var corridorIndex = 0; corridorIndex < corridorLength; ++corridorIndex)
            {
                var corridorPos = wallBase + corridorDir * corridorIndex;
                if (IsInvalidPos(map, corridorIndex, corridorPos))
                {
                    return false;
                }

                solidToEmpty.Add(corridorPos);
            }

            foreach (var coord in solidToEmpty)
            {
                map[coord.X, coord.Y] = TileType.Empty;
            }

            return true;
        }

        private static bool IsInvalidPos(Grid<TileType> map, int corridorIndex, Point2 corridorPos)
        {
            return !map.On(corridorPos) || map[corridorPos.X, corridorPos.Y] == TileType.Empty ||
                   map.NeighbourCount(corridorPos, TileType.Empty) > 0 && corridorIndex > 0;
        }

        private static Point2 GetDirection(Grid<TileType> map, Point2 selectedWall)
        {
            Point2 corridorDir;
            if (map.At(selectedWall.X - 1, selectedWall.Y) == TileType.Empty)
            {
                corridorDir = new Point2(1, 0);
            } else if (map.At(selectedWall.X, selectedWall.Y - 1) == TileType.Empty)
            {
                corridorDir = new Point2(0, 1);
            } else if (map.At(selectedWall.X + 1, selectedWall.Y) == TileType.Empty)
            {
                corridorDir = new Point2(-1, 0);
            } else if (map.At(selectedWall.X, selectedWall.Y + 1) == TileType.Empty)
            {
                corridorDir = new Point2(0, -1);
            } else
            {
                throw new Exception("Unexpected case");
            }

            return corridorDir;
        }

        private static List<Point2> GetWalls(Grid<TileType> map)
        {
            var walls = new List<Point2>();
            map.MapForeach((x, y, type) =>
            {
                if (type == TileType.Solid && map.NeighbourCount(new Point2(x, y), TileType.Empty) > 0)
                {
                    walls.Add(new Point2(x, y));
                }
            });
            return walls;
        }

        private enum Feature
        {
            Corridor = 0,
            Room = 1,
            Last = 2
        }
    }
}
