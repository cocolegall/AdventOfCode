using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Day2
{
    internal class Day2
    {
        private string[] ReadLines(StreamReader rs)
        {
            List<string> res = new List<string>();
            var line = rs.ReadLine();
            while (line != null)
            {
                string lineContent = line;
                res.Add(lineContent);
                line = rs.ReadLine();
            }
            return res.ToArray();
        }
        public int Solution(StreamReader rs)
        {
            var input = ReadLines(rs);
            int res = 0;
            for(int i = 0; i<input.Length; i++)
            {
                var stringLineContent = input[i].Split(" ");
                int[] lineContent = new int[stringLineContent.Length];
                for(int j = 0; j < stringLineContent.Length; j++)
                {
                    int.TryParse(stringLineContent[j], out lineContent[j]);
                }
                for(int j = 0;  j < lineContent.Length-1; j++)
                {
                    bool decreasing = false;
                    bool increasing = false;
                    if (lineContent[j].Equals(lineContent[j + 1]))
                    {
                        continue;
                    }
                    if (lineContent[j] < lineContent[j + 1])
                    {
                        increasing = true;
                    }
                    decreasing = true;
                    if (increasing)
                    {
                        if (lineContent[j] > lineContent[j + 1])
                        {
                            continue;
                        }
                    }
                    if (decreasing)
                    {
                        if (lineContent[j] < lineContent[j + 1])
                        {
                            continue;
                        }
                    }
                    if (Math.Abs(lineContent[j] - lineContent[j + 1]) >= 5)
                    {
                        continue;
                    }
                    res++;
                }
            }
            return res;
        }
    }
}
