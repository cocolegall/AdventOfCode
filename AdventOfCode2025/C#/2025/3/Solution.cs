using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace _2025._3
{
    internal class Solution
    {
        public static int Solve1(StreamReader reader)
        {
            var line = reader.ReadLine();
            List <int[]> banks = new List <int[]>();
            while (line != null)
            {
                var bank = new List<int>();
                foreach(var elem  in line)
                {
                    bank.Add(Convert.ToInt16(elem.ToString()));
                }
                banks.Add(bank.ToArray());
                line = reader.ReadLine();
            }
            var res = 0;
            foreach (var bank in banks)
            {
                var max = Max(bank);
                var secondMax = (0,0);
                if(max.Item1 == bank.Length-1)
                {
                    secondMax = Max(bank[..(bank.Length-1)]);
                    res += Convert.ToInt32($"{secondMax.Item2}{max.Item2}");
                    continue;
                }
                secondMax = Max(bank[(max.Item1+1)..]);
                res += Convert.ToInt32($"{max.Item2}{secondMax.Item2}");
            }
            return res;

        }

        public static UInt64 Solve2(StreamReader reader)
        {
            var line = reader.ReadLine();
            List<int[]> banks = new List<int[]>();
            while (line != null)
            {
                var bank = new List<int>();
                foreach (var elem in line)
                {
                    bank.Add(Convert.ToInt16(elem.ToString()));
                }
                banks.Add(bank.ToArray());
                line = reader.ReadLine();
            } 
            UInt64 res = 0;
            foreach (var bank in banks)
            {
                int allowedGap = bank.Length - 12;
                string maxJoltage = "";
                for(int i = 0; i < bank.Length; i++)
                {
                    if(maxJoltage.Length >= 12 || (bank.Length - i) < allowedGap+1)
                    {
                        break;
                    }
                    var elem = Max(bank[i..(i+allowedGap + 1)]);
                    maxJoltage += elem.Item2.ToString();
                    allowedGap -= (elem.Item1);
                    i = elem.Item1+i;
                }
                res += Convert.ToUInt64(maxJoltage);
            }
            return res;
        }


        private static (int,int) Max(int[] arr)
        {
            var max = 0;
            int i = 0;
            var index = 0;
            foreach (var item in arr)
            {
                if (item > max)
                {
                    index = i;
                    max = item;   
                }
                i++;
            }
            return (index,max);
        }
    }
}
