using System.IO;

namespace Skiing_Library
{
    public class Map
    {
        public string[] MapTiles { get; set; }
        public int Width { get; set; }
        public int collisions { get; set; } = 0;

        public Map()
        {

        }
        public Map(string filePath)
        {
            ReadTreeMap(filePath);
        }

        public void ReadTreeMap(string mapPath)
        {
            MapTiles = File.ReadAllLines(mapPath);
            Width = MapTiles[0].Length;
        }

        public int GetLoopIndex(int xPos)
        {
            return xPos % Width;
        }

        public void SkiSlope(int slope)
        {
            int xPos = 0;
            for (int i = 0; i < MapTiles.Length; i++)
            {
                UpdateCollision(xPos, i);
                xPos += slope;
            }
        }

        private void UpdateCollision(int xPos, int i)
        {
            if (MapTiles[i][GetLoopIndex(xPos)] == '#')
            {
                collisions++;
            }
        }
    }
}