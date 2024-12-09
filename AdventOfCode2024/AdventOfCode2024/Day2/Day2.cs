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
            var res = input.Select(s => s.Split(" ")
                .Select(v => int.Parse(v)).ToArray())
                .Select(s => s.Zip(s.Skip(1),(a,b) => b-a).ToArray())
                .Where(s => s.All(v => v>0) || s.All(v => v<0))
                .Where(s => s.All(v => Math.Abs(v)<4) & s.All(v => v!=0))
                .Count();
            return res;
        }
    }
}
