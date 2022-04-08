using System;
using Skiing_Library;

namespace Skiing_Amongst_Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map("TreeMap.txt");
            Console.WriteLine($"Your best slope was {map.GetBestSlope()}:1");
        }
    }
}
