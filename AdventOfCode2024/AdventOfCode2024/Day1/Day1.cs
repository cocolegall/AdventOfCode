using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Day1
{
    public class Day1
    {
        private void ReadLines(StreamReader sr, out int[] arr1, out int[] arr2)
        {
            List<int> L1 = new List<int>();
            List<int> L2 = new List<int>();
            var line = sr.ReadLine();
            while (line != null)
            {
                string[] elements = line.Split("   ");
                int.TryParse(elements[0], out int res1);
                int.TryParse(elements[1], out int res2);
                L1.Add(res1);
                L2.Add(res2);
                line = sr.ReadLine();
            }
            arr1 = L1.ToArray();
            arr2 = L2.ToArray();
        }
        public int SolutionPart1(StreamReader sr)
        {
            ReadLines(sr, out int[] arr1, out int[] arr2);
            Array.Sort(arr1);
            Array.Sort(arr2);
            int N = arr1.Length;
            int[] res = new int[N];
            for (int i = 0; i < N; i++)
            {
                res[i] = Math.Abs(arr1[i] - arr2[i]);
            }
            return res.Sum();
        }
        public int SolutionPart2(StreamReader sr)
        {
            ReadLines(sr, out int[] arr1, out int[] arr2);
            Array.Sort(arr1);
            Array.Sort(arr2);
            int N = arr1.Length;
            int[] res = new int[N];
            for(int i = 0; i < N; i++)
            {
                int times = 0;
                for(int j = 0; j < N; j++)
                {
                    if (arr1[i] == arr2[j]) times++;
                }
                res[i] = times * arr1[i];
            }
            return res.Sum();
        }
    }
}
