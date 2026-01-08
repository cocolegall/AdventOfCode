namespace _2025._2
{
    internal class Solution
    {
        public static long Solve1(StreamReader reader)
        {
            var line = reader.ReadLine();
            if(line == null)
            {
                throw new Exception("Input cannot be null");
            }
            var elem = line.Split(",");
            var range = new List<(long, long)>();
            foreach(var e in elem)
            {
                var r = e.Split("-");
                range.Add((Convert.ToInt64(r[0]), Convert.ToInt64(r[1])));
            }
            long res = 0;
            foreach(var r in range)
            {
                for(var i = r.Item1; i <= r.Item2; i++)
                {
                    res += NumRepeatedSequence(i);
                }
            }

            return res;
        }
        public static long NumRepeatedTwiceInSequence(long a)
        {
            var aString = a.ToString();
            if(aString.Length%2 != 0)
            {
                return 0;
            }
            var arr1 = aString[..(aString.Length / 2)];
            var arr2 = aString[(aString.Length / 2)..];
            if(arr1 == arr2)
            {
                return a;
            }
            return 0;
        }

        public static long NumRepeatedSequence(long a)
        {
            var aString = a.ToString();
            long res = 0;
            for (var i = 1; i <= aString.Length/2; i++)
            {
                var arr = aString[..i];
                if(aString.Length%arr.Length != 0)
                {
                    continue;
                }
                bool isInvalid = true;
                for (var j = i; j <= aString.Length-i; j+= i)
                {
                    var arr1 = aString[..i];
                    var arr2 = aString[j..(j+i)];
                    if(arr1 != arr2)
                    {
                        isInvalid = false;
                        break;
                    }
                }
                if (isInvalid)
                {
                    res += a;
                    break;
                }
            }
            return res;
        }
    }
}
