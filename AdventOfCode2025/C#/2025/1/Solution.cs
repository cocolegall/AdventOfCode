namespace _2025._1
{
    class Solution
    {
        public static int Solve1(StreamReader reader)
        {
            var dir = new List<char>();
            var times = new List<int>();
            var line = reader.ReadLine();
            while(line != null)
            {
                dir.Add(line[0]);
                times.Add(int.Parse(line[1..]));
                line = reader.ReadLine();
            }

            var pos = 50;
            var res = 0;
            for (int i = 0; i < dir.Count; ++i)
            {
                if (dir[i].Equals('R'))
                {
                    var rShift = times[i] + pos;
                    if(rShift%100 == 0)
                    {
                        res++;
                        pos = 0;
                        continue;
                    }
                    if(rShift > 100)
                    {
                        pos = rShift - (100*(rShift/100));
                        continue;
                    }
                    pos = rShift;
                    continue;
                }
                var lShift = pos - times[i];
                if(lShift%100 == 0)
                {
                    res++;
                    pos = 0;
                    continue;
                }
                if(lShift < 0)
                {
                    var n = (100 * (lShift / 100));
                    pos = 100 + (lShift - n);
                    continue;
                }
                pos = lShift;
                continue;
            }
            return res;
        }
        public static int Solve2(StreamReader reader)
        {
            var dir = new List<char>();
            var times = new List<int>();
            var line = reader.ReadLine();
            while(line != null)
            {
                dir.Add(line[0]);
                times.Add(int.Parse(line[1..]));
                line = reader.ReadLine();
            }

            var pos = 50;
            var res = 0;
            for (int i = 0; i < dir.Count; ++i)
            {
                if (dir[i].Equals('R'))
                {
                    var rShift = times[i] + pos;
                    if(rShift%100 == 0)
                    {
                        res += (rShift / 100) != 0 ? rShift/100 : 1;
                        pos = 0;
                        continue;
                    }
                    if(rShift > 100)
                    {
                        var numClick = (rShift / 100) != 0 ? rShift / 100 : 1;
                        pos = rShift - (100 * (rShift / 100));
                        res += numClick;
                        continue;
                    }
                    pos = rShift;
                    continue;
                }
                var numLClick = (times[i] / 100);
                res += numLClick;
                var lShift = pos - (times[i] - (100 * (times[i]/100)));
                if (lShift == 0)
                {
                    res++;
                    pos = 0;
                    continue;
                }
                if(lShift < 0)
                {
                    if(pos != 0)
                        res++;
                    pos = 100 + lShift;
                    continue;
                }
                pos = lShift;
                continue;
            }
            return res;
        }
    }
}
