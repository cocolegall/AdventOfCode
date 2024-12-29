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
        public int SolutionPart1(StreamReader rs)
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
        public int SolutionPart2(StreamReader rs)
        {
            var input = ReadLines(rs);

            var resErrorSign = input.Select(s => s.Split(" ")
                .Select(v => int.Parse(v)).ToArray())
                .Where(v => IsSafe(v, 1));
            return resErrorSign.Count();
        }
        private bool IsSafe(IEnumerable<int> enumerable, int authorizedError)
        {
            var res = CheckList(enumerable, out int firstIndex, out int secondIndex);
            if (!res && authorizedError == 1)
            {
                var elementList = enumerable.ToList();
                if (firstIndex == -1) return res;
                var firstTestList = new List<int>(elementList);
                var secondTestList = new List<int>(elementList);
                firstTestList.RemoveAt(firstIndex);
                secondTestList.RemoveAt(secondIndex);
                res = IsSafe(firstTestList, 0) ? true : IsSafe(secondTestList, 0);
            }
            return res;
        }
        private bool CheckList(IEnumerable<int> enumerable, out int firstIndex, out int secondIndex)
        {
            var enumerator = enumerable.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                firstIndex = -1;
                secondIndex = -1;
                return false;
            }
            var current = enumerator.Current;
            int currentIndex = 0;
            if (!enumerator.MoveNext())
            {
                firstIndex = -1;
                secondIndex = -1;
                return true;
            }
            var next = enumerator.Current;
            int nextIndex = 1;

            var isAscending = current < next;
            var isDescending = current > next;
            
            if(!isAscending && !isDescending || Math.Abs(current - next) > 3)
            {
                firstIndex = currentIndex;
                secondIndex = nextIndex;
                return false;
            }
            while (enumerator.MoveNext())
            {
                current = next;
                currentIndex = nextIndex;

                next = enumerator.Current;
                nextIndex++;

                if(isAscending && current >= next)
                {   
                    firstIndex = currentIndex;
                    secondIndex = nextIndex;
                    return false;
                }

                if(isDescending && current <= next)
                {
                    firstIndex = currentIndex;
                    secondIndex = nextIndex;
                    return false;
                }

                if(Math.Abs(next - current) > 3)
                {
                    firstIndex = currentIndex;
                    secondIndex = nextIndex;
                    return false;
                }
            }
            firstIndex = -1;
            secondIndex = -1;
            return true;
        }
    }
}
