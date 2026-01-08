namespace _2025._5
{
    internal class Solution
    {
        public static int Solve1(StreamReader reader)
        {
            var line = reader.ReadLine();
            var range = new List<(long, long)>();
            var ids = new List<long>();
            bool feelIds = false;
            while (line != null)
            {
                if(!string.IsNullOrEmpty(line) && !feelIds)
                {
                    var r = line.Split('-');
                    range.Add((Convert.ToInt64(r[0]), Convert.ToInt64(r[1])));
                    line = reader.ReadLine();
                    continue;
                }
                line = reader.ReadLine();
                if(line == null)
                {
                    continue;
                }
                feelIds = true;
                ids.Add(Convert.ToInt64(line));
            }

            var count = 0;
            for(int i = 0; i < ids.Count; i++)
            {
                foreach(var r in range)
                {
                    if(IsIntInRange(r.Item1, r.Item2, ids[i]))
                    {
                        count++;
                        break;
                    }
                }
            }


            return count;
        }

        public static bool IsIntInRange(long a, long b, long elem)
        {
            if(a <= elem &&  b >= elem)
            {
                return true;
            }
            return false;
        }


        public static long Solve2(StreamReader reader)
        {
            var line = reader.ReadLine();
            var range = new Dictionary<long,long>();
            var starter = new List<long>();
            while (!string.IsNullOrEmpty(line))
            {
                var r = line.Split('-');
                var start = Convert.ToInt64(r[0]);
                var end = Convert.ToInt64(r[1]);
                if (range.TryGetValue(start, out var e ))
                {
                    if(e < end)
                    {
                        range[start] = end;
                    }
                }
                else
                {
                    range.Add(start, end);
                    starter.Add(start);
                }
                line = reader.ReadLine();   
            }
            starter.Sort();
            long count = 0;
            for(int i = 0; i < starter.Count; i++)
            {
                var start = starter[i];
                if(!range.TryGetValue(start, out var end))
                {
                    continue;
                }
                for(int j = i+1; j < starter.Count; j++)
                {
                    var startToCompare = starter[j];
                    if (range.TryGetValue(startToCompare, out var endToCompare))
                    {
                        if(startToCompare > end)
                        {
                            // Out because starter[i] < starter[i+1]
                            break;
                        }
                        if(endToCompare > end)
                        {
                            end = endToCompare;
                            range[start] = endToCompare;
                        }
                        range.Remove(startToCompare);
                    }
                }
            }

            foreach(var (s,e) in range)
            {
                count += (e - s) + 1;
            }

            return count;
        }
    }
}
