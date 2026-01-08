using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._8
{
    internal class Solution
    {
        public static int Solve1(StreamReader reader)
        {
            var line = reader.ReadLine();
            var coordinates = new List<(long,long,long)>();
            while (line != null)
            {
                var l = line.Split(',');
                coordinates.Add((Convert.ToInt64(l[0]), Convert.ToInt64(l[1]), Convert.ToInt64(l[2])));
                line = reader.ReadLine();
            }
            Dictionary<(int,int), double> dist = new Dictionary<(int,int), double>();

            for (int i = 0; i < coordinates.Count; i++)
            {
                for (int j = i+1; j < coordinates.Count; j++)
                {
                    var dx = coordinates[j].Item1 - coordinates[i].Item1;
                    var dy = coordinates[j].Item2 - coordinates[i].Item2;
                    var dz = coordinates[j].Item3 - coordinates[i].Item3;
                    var distij = Math.Sqrt(dx * dx + dy * dy + dz * dz);
                    dist.Add((i, j), distij);
                }
            }
            var pointsOrderedByDist = dist.OrderBy(kv => kv.Value).ToDictionary(); //Implement my own algo
            
            var uf = new UnionFind(coordinates.Count);
            for(int i = 0; i < 1000; i++)
            {
                uf.Union(pointsOrderedByDist.Keys.ToList()[i].Item1, pointsOrderedByDist.Keys.ToList()[i].Item2);
            }
            var circuits = Enumerable.Range(0, coordinates.Count)
                    .Select(i => uf.ComponentSize(i))
                    .Distinct()
                    .OrderByDescending(x => x)
                    .ToList();
            int result = circuits.Take(3).Aggregate(1, (a, b) => a * b);

            return result;
        }

        public static long Solve2(StreamReader reader)
        {
            var line = reader.ReadLine();
            var coordinates = new List<(long, long, long)>();
            while (line != null)
            {
                var l = line.Split(',');
                coordinates.Add((Convert.ToInt64(l[0]), Convert.ToInt64(l[1]), Convert.ToInt64(l[2])));
                line = reader.ReadLine();
            }
            Dictionary<(int, int), double> dist = new Dictionary<(int, int), double>();

            for (int i = 0; i < coordinates.Count; i++)
            {
                for (int j = i + 1; j < coordinates.Count; j++)
                {
                    var dx = coordinates[j].Item1 - coordinates[i].Item1;
                    var dy = coordinates[j].Item2 - coordinates[i].Item2;
                    var dz = coordinates[j].Item3 - coordinates[i].Item3;
                    var distij = Math.Sqrt(dx * dx + dy * dy + dz * dz);
                    dist.Add((i, j), distij);
                }
            }
            var pointsOrderedByDist = dist.OrderBy(kv => kv.Value).ToDictionary(); //Implement my own algo
            var uf = new UnionFind(coordinates.Count);
            var res = (0,0);
            for(int i = 0; i < pointsOrderedByDist.Count; i++)
            {
                if(i == pointsOrderedByDist.Count - 3)
                {
    
                }
                var lastElem = uf.Union(pointsOrderedByDist.Keys.ToList()[i].Item1, pointsOrderedByDist.Keys.ToList()[i].Item2);
                if ( lastElem != (0, 0))
                {
                    res = lastElem;
                    break;
                }
            }
            // This works but is not optimized at all
            return coordinates[res.Item1].Item1 * coordinates[res.Item2].Item1;
        }

        internal class UnionFind
        {
            private int[] size;
            public int[] parent;
            List<int> root;
            public UnionFind(int n)
            {
                parent = Enumerable.Range(0, n).ToArray();
                size = Enumerable.Repeat(1, n).ToArray();
                root = Enumerable.Range(0, n).ToList();
            }

            public int Find(int x)
            {
                if (parent[x] != x)
                {
                    return parent[x] = Find(parent[x]);
                }
                return parent[x];
            }

            public (int,int) Union(int a, int b)
            {
                int ra = Find(a);
                int rb = Find(b);
                
                if(ra == rb)
                {
                    return (0, 0);
                }
                if(root.Count == 2)
                {
                    return (a, b);
                }
                if(a < b)
                {
                    parent[rb] = ra;
                    size[ra] += size[rb];
                    root.Remove(rb);
                    return (0,0);
                }
                parent[ra] = rb;
                size[rb] += size[ra];
                root.Remove(ra);

                return (0,0);

            }
            public int ComponentSize(int x)
                => size[Find(x)];
        }
    }
}
