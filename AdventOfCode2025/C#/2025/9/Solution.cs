using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._9
{
    internal static class Solution
    {
        public static long Solve1(StreamReader reader)
        {
            List <(int,int)> redTiles = new List<(int, int)>();
            var line = reader.ReadLine();
            while(line != null)
            {
                var input = line.Split(',');
                redTiles.Add((Convert.ToInt32(input[0]), Convert.ToInt32(input[1])));
                line = reader.ReadLine();
            }
            
            long maxArea = 0;
            for(int i = 0; i < redTiles.Count; i++)
            {
                for(int j = i + 1; j < redTiles.Count; j++)
                {
                    long width = Math.Abs(redTiles[i].Item1 - redTiles[j].Item1) + 1;
                    long height = Math.Abs(redTiles[i].Item2 - redTiles[j].Item2) + 1;
                    long area = width * height;
                    if(area > maxArea)
                    {
                        maxArea = area;
                    }
                }
            }
            return maxArea;
        }

        public static long Solve2(StreamReader reader)
        {

        }
    }
}
