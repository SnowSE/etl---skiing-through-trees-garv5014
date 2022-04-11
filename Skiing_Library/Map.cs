using System.IO;

namespace Skiing_Library
{
    public class Map
    {
        public string[] MapRows { get; set; } 
        public int Width { get; set; }
        public int Collisions { get; set; } = 0;
        private int bestSlope = 0;
        private int leastCollisions = int.MaxValue;



        public Map()
        {
            Width = 0;
        }
        public Map(string filePath)
        {
            ReadTreeMap(filePath);
        }

        private void ReadTreeMap(string mapPath)
        {
            MapRows = File.ReadAllLines(mapPath);
            Width = MapRows[0].Length;
        }

        public int GetLoopIndex(int xPos)
        {
            return xPos % Width;
        }

        public void SkiSlope(int slope)
        {
            int xPos = 0;
            for (int i = 0; i < MapRows.Length; i++)
            {
                UpdateCollision(xPos, i);
                xPos += slope;
            }
        }

        private void UpdateCollision(int xPos, int row)
        {
            if (CollisionOccurs(xPos, row)) //Make own function?
            {
                Collisions++;
            }
        }

        private bool CollisionOccurs(int xPos, int row)
        {
            return MapRows[row][GetLoopIndex(xPos)] == '#';
        }

        public int GetBestSlope()
        {
            for (int slope = 0; slope < Width; ++slope)
            {
                UpdateBestSlope(slope);
            }

            return bestSlope;
        }

        private void UpdateBestSlope(int slope)
        {
            Collisions = 0;
            SkiSlope(slope);
            if (Collisions < leastCollisions)
            {
                leastCollisions = Collisions;
                bestSlope = slope;
            }
            Console.WriteLine($"Slope: {slope}:1, Collisions: {Collisions}");
        }
    }
}