using System.Diagnostics;

namespace _2025._7
{
    internal class Solution
    {
        public static int Solve1(StreamReader reader)
        {
            var line = reader.ReadLine();
            var rawInputs = new List<string>();
            while (line != null)
            {
                rawInputs.Add(line);
                line = reader.ReadLine();
            }

            var currentBeam = new List<int>();
            var count = 0;
            for(int i = 0; i < rawInputs.Count; i++)
            {
                if (rawInputs[i].Contains("S"))
                {
                    currentBeam.Add(rawInputs[i].IndexOf("S"));
                    continue;
                }
                var newBeam = new List<int>(currentBeam);
                for(int j = 0; j < currentBeam.Count; j++)
                {
                    var beam = currentBeam[j];
                    if (rawInputs[i][beam] == '.')
                    {
                        continue;
                    }
                    if(!newBeam.Contains(beam-1) && beam-1 > 0)
                    {
                        newBeam.Add(beam - 1);
                    }
                    if(!newBeam.Contains(beam+1) && beam+1 < rawInputs[0].Length)
                    {
                        newBeam.Add(beam + 1);
                    }
                    newBeam.Remove(beam);
                    count++;
                }
                currentBeam.Clear();
                currentBeam.AddRange(newBeam);
            }

            return count;
        }

        public static long Solve2(StreamReader reader)
        {
            Dictionary<(int, int), List<(int,int)>> graph = new Dictionary<(int, int), List<(int, int)>>();
            var line = reader.ReadLine();
            var rawInputs = new List<string>();
            while (line != null)
            {
                    rawInputs.Add(line);
                line = reader.ReadLine();
            }

            var currentBeam = new List<int>();
            var startIdx = (0, 0);
            for (int i = 0; i < rawInputs.Count; i++)
            {
                //init
                if (rawInputs[i].Contains("S"))
                {
                    var idx = rawInputs[i].IndexOf("S");
                    currentBeam.Add(idx);
                    startIdx = (i, idx);
                    graph.Add(startIdx, new List<(int, int)>(1));
                    continue;
                }

                var newBeam = new List<int>(currentBeam);
                for (int j = 0; j < currentBeam.Count; j++)
                {
                    var beam = currentBeam[j];
                    if (rawInputs[i][beam] == '.')
                    {
                        if(!graph.ContainsKey((i-1, beam)))
                        {
                            continue;
                        }
                        graph.TryAdd((i, beam), new List<(int, int)>());
                        graph[(i-1,beam)].Add((i, beam));
                        continue;
                    }
                    graph.TryAdd((i, beam - 1), new List<(int, int)>());
                    graph.TryAdd((i, beam + 1), new List<(int, int)>());
                    if (!newBeam.Contains(beam - 1) && beam - 1 > 0)
                    {
                        newBeam.Add(beam - 1);
                    }
                    if (!newBeam.Contains(beam + 1) && beam + 1 < rawInputs[0].Length)
                    {
                        newBeam.Add(beam + 1);
                    }
                    newBeam.Remove(beam);
                    graph[(i - 1, beam)].Add((i, beam-1));
                    graph[(i - 1, beam)].Add((i, beam + 1));
                }
                currentBeam.Clear();
                currentBeam.AddRange(newBeam);
            }

            Dictionary<(int, int), long> mem = new Dictionary<(int, int), long>();
            return CountWithDfs(graph, startIdx, mem);
        }

        public static long CountWithDfs(Dictionary<(int, int), List<(int, int)>> graph, (int,int) node, Dictionary<(int,int), long> mem)
        {
            var child = graph[node];

            if (mem.ContainsKey(node))
            {
                return mem[node];
            }

            if(child.Count == 0)
            {
                mem.Add(node, 1); 
                return 1;
            }
            
            long count = 0;
            foreach(var c in child)
            {
                count += CountWithDfs(graph, c, mem);
            }
            mem.Add(node, count);
            return count;
        }
    }
}
