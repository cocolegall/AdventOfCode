using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2024.Day3
{
    internal class Day3
    {
        private string ReadLines(StreamReader sr)
        {
            var line = sr.ReadLine();
            string res = "";
            while(line != null)
            {
                res += line;
                line = sr.ReadLine();
            }
            return res;
        }

        public int Solution(StreamReader sr)
        {
            string input = ReadLines(sr);
            var pattern = @"mul\(\d+,\d+\)";
            MatchCollection matches = Regex.Matches(input, pattern);
            int sum = 0;
            foreach(Match match in matches)
            {
                int start = match.Value.IndexOf("(");
                int end = match.Value.IndexOf(")");
                string[] elements = match.Value.Substring(start+1, end-start-1).Split(',');
                int firstElement = int.Parse(elements[0]);
                int secondElement = int.Parse(elements[1]);
                sum += firstElement * secondElement;
            }

            return sum;
        }
    }
}
